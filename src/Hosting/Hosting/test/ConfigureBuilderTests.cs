// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Microsoft.AspNetCore.Hosting.Tests;

public class ConfigureBuilderTests
{
    /// <summary>
    /// 捕获服务异常详细信息
    /// </summary>
    [Fact]
    public void CapturesServiceExceptionDetails()
    {
        var methodInfo = GetType().GetMethod(nameof(InjectedMethod), BindingFlags.NonPublic | BindingFlags.Static);
        Assert.NotNull(methodInfo);

        var services = new ServiceCollection()
            .AddSingleton<CrasherService>()
            .BuildServiceProvider();

        var applicationBuilder = new ApplicationBuilder(services);

        var builder = new ConfigureBuilder(methodInfo);
        Action<IApplicationBuilder> action = builder.Build(instance: null);
        var ex = Assert.Throws<InvalidOperationException>(() => action.Invoke(applicationBuilder));

        Assert.NotNull(ex);
        Assert.Equal($"Could not resolve a service of type '{typeof(CrasherService).FullName}' for the parameter"
            + $" 'service' of method '{methodInfo.Name}' on type '{methodInfo.DeclaringType.FullName}'.", ex.Message);

        // the inner exception contains the root cause
        Assert.NotNull(ex.InnerException);
        Assert.Equal("服务初始化失败", ex.InnerException.Message);
        Assert.Contains(nameof(CrasherService), ex.InnerException.StackTrace);
    }

    private static void InjectedMethod(CrasherService service)
    {
        Assert.NotNull(service);
    }

    /// <summary>
    /// 崩溃服务（一调用构造函数就抛异常）
    /// </summary>
    private class CrasherService
    {
        public CrasherService()
        {
            throw new Exception("服务初始化失败");
        }
    }

    [Fact]
    public void ConfigurationGetChildTest()
    {
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string>
            {
                ["root:a"] = "a",
                ["root:b"] = "b",
                ["root:b:c"] = "c",
            })
            .Build();

        var root = configuration.GetSection("root");
        var children = root.GetChildren();

        Assert.Equal(2, children.Count());
    }

    [Fact]
    public void ConfigurationAsEnumerableTest()
    {
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string>
            {
                ["root"] = "root",
                ["root:a"] = "a",
                ["root:b"] = "b",
                ["root:b:c"] = "c",
                ["root:a:d:e"] = "e",
                ["root:f"] = "f",
            })
            .Build();

        var result = configuration.AsEnumerable();
        var rootA = configuration.GetSection("root:a");
        var t = rootA.AsEnumerable(true);

        Assert.Equal(7, result.Count());
        Assert.Equal(2, t.Count());
    }
}

// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.AspNetCore.Builder;

namespace Microsoft.AspNetCore.Hosting;

/// <summary>
/// Provides an interface for extending the middleware pipeline with new
/// Configure methods. Can be used to add defaults to the beginning or
/// end of the pipeline without having to make the app author explicitly
/// register middleware.
/// 提供一个接口，用于使用新的 Configure 方法扩展中间件管道。
/// 可用于将默认值添加到管道的开头或结尾，而无需让应用作者显式注册中间件
/// </summary>
public interface IStartupFilter
{
    /// <summary>
    /// Extends the provided <paramref name="next"/> and returns an <see cref="Action"/> of the same type.
    /// </summary>
    /// <param name="next">The Configure method to extend.</param>
    /// <returns>A modified <see cref="Action"/>.</returns>
    Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next);
}

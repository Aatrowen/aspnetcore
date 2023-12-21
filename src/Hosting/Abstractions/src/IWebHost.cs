// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.AspNetCore.Http.Features;

namespace Microsoft.AspNetCore.Hosting;

/// <summary>
/// Represents a configured web host.
/// 一个已配置的 Web主机
/// </summary>
public interface IWebHost : IDisposable
{
    /// <summary>
    /// The <see cref="IFeatureCollection"/> exposed by the configured server.
    /// </summary>
    IFeatureCollection ServerFeatures { get; }

    /// <summary>
    /// The <see cref="IServiceProvider"/> for the host.
    /// </summary>
    IServiceProvider Services { get; }

    /// <summary>
    /// Starts listening on the configured addresses.
    /// 开始监听配置的地址。
    /// </summary>
    void Start();

    /// <summary>
    /// Starts listening on the configured addresses.
    /// </summary>
    /// <param name="cancellationToken">Used to abort program start.</param>
    /// <returns>A <see cref="Task"/> that completes when the <see cref="IWebHost"/> starts.</returns>
    Task StartAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Attempt to gracefully stop the host.
    /// 尝试正常（优雅的）停止主机。
    /// </summary>
    /// <param name="cancellationToken">Used to indicate when stop should no longer be graceful.</param>
    /// <returns>A <see cref="Task"/> that completes when the <see cref="IWebHost"/> stops.</returns>
    Task StopAsync(CancellationToken cancellationToken = default);
}

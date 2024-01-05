// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Microsoft.AspNetCore.Http;

/// <summary>
/// A function that can process an HTTP request.
/// 处理HTTP请求的函数，2014年的老代码了
/// 看起来所有HTTP请求，只需要一个 HttpContext 便可以执行
/// </summary>
/// <param name="context">The <see cref="HttpContext"/> for the request. 给个http上下文</param>
/// <returns>A task that represents the completion of request processing.</returns>
public delegate Task RequestDelegate(HttpContext context);

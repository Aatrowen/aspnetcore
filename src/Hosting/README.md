# Hosting 托管？宿主？=> 主机

Hosting provides the entry point for configuring and running your application.
提供了配置和运行应用程序的入口点

Documentation for Hosting can be found in the [ASP.NET Core Web Host](https://learn.microsoft.com/aspnet/core/fundamentals/host/web-host) and [.NET Generic Host in ASP.NET Core](https://learn.microsoft.com/aspnet/core/fundamentals/host/generic-host) docs.

## Description

The following contains a description of the sub-directories.

- `Abstractions`: Contains the main Hosting and Startup interfaces. 主要包含 Hosting + Startup 的接口
- `Hosting`: Contains the default implementations for **GenericHost, WebHost, and Startup**.
- `Server.Abstractions`: Contains the interfaces for Server implementations.
- `Server.IntegrationTesting`: Contains classes to help deploy servers for testing across the repo.
- `TestHost`: Contains a server implementation for in-memory testing against a server.
- `WindowsServices`: Contains methods to run an application as a Windows service.
- `samples`: Contains a few sample apps that show examples of using hosting. 使用hosting的示例！

## Development Setup

### Build

To build this specific project from source, follow the instructions [on building the project](../../docs/BuildFromSource.md#step-3-build-the-repo).

### Test

To run the tests for this project, [run the tests on the command line](../../docs/BuildFromSource.md#running-tests-on-command-line) in this directory.

## More Information

For more information, see the [ASP.NET Core README](../../README.md).

# IronBarCode Linux Compatibility & Setup Guide

***Based on <https://ironsoftware.com/get-started/linux/>***


IronBarcode is fully compatible with Linux and supports **.NET Standard**, **.NET Core**, and **.NET Framework** across various Linux distributions.

<div class="main-content__small-images-inline">
    <img src="https://img.icons8.com/color/96/000000/linux--v1.png" alt="Linux">
    <img src="https://img.icons8.com/color/96/000000/docker.png" alt="Docker">
    <img src="https://img.icons8.com/fluency/96/000000/azure-1.png" alt="Azure">
    <img src="https://img.icons8.com/color/96/000000/amazon-web-services.png" alt="Amazon">
    <img src="https://img.icons8.com/color/96/000000/ubuntu--v1.png" alt="Ubuntu">
    <img src="https://img.icons8.com/color/96/000000/debian--v1.png" alt="Debian">
</div> 

Operating IronBarcode on Linux does not require any modifications to your existing code, as it is fully operational from the start due to extensive testing and optimization by our development team.

With cloud services predominantly running on Linux platforms, it is crucial to support Linux at Iron Software. We utilize these technologies extensively and know that many of our Enterprise and SaaS clients depend on them too.

## Officially Supported Linux Distributions

We **officially support** the following **64-bit** Linux distributions, ensuring a seamless, zero-configuration setup for IronBarcode:

* Ubuntu ≥18
* Debian ≥10
* CentOS ≥7

While these distributions are fully supported, others may still work but could require some manual setup for optimal performance.

## Linux Specific Barcode Package

The `BarCode.Linux` package is designed to provide barcode functionality on Linux systems for .NET cross-platform projects. This package specifically targets Linux environments, so the standard BarCode package is not required.

[PM > Install-Package BarCode.Linux](https://www.nuget.org/packages/BarCode.Linux)

## Enhanced Ubuntu Compatibility

Ubuntu is the primary operating system we test on, due to its widespread use in cloud infrastructure like Azure, which supports our rigorous testing and deployment processes. Ubuntu also enjoys full support from Microsoft .NET and has official Docker images available.

### Ubuntu 20
<div class="main-content__small-images-inline">
    <img src="https://img.icons8.com/color/48/000000/microsoft.png" alt="Microsoft">
    <img src="https://img.icons8.com/color/48/000000/ubuntu--v1.png" alt="Ubuntu">
    <img src="https://img.icons8.com/color/48/000000/chrome--v1.png" alt="Chrome">
    <img src="https://img.icons8.com/color/48/000000/safari--v1.png" alt="Safari">
    <img src="https://img.icons8.com/color/48/000000/docker.png" alt="Docker">
    <img src="https://img.icons8.com/fluency/48/000000/azure-1.png" alt="Azure">
</div> 

**Official Microsoft Docker Images**

* [.NET Standard](https://hub.docker.com/r/microsoft/dotnet-runtime/)
* [ASP.NET Core](https://hub.docker.com/r/microsoft/dotnet-aspnet/)

**Setup for Ubuntu 20** 

When setting up IronBarcode on Ubuntu 20, begin by gaining _sudo_ admin rights, then incorporate the following commands into your Dockerfile:
```dockerfile
# Update the package list

***Based on <https://ironsoftware.com/get-started/linux/>***

RUN apt update

# Install libgdiplus for GDI+ graphic support

***Based on <https://ironsoftware.com/get-started/linux/>***

RUN apt install -y libgdiplus
```    

### Ubuntu 18

Ubuntu 18 setup mirrors that of Ubuntu 20 with identical requirements and Docker image recommendations. Follow the same instructions as above to enable IronBarcode on Ubuntu 18.

### Debian Support

#### Debian 11 and Debian 10 Environments:

Here are the Docker configurations for Debian 11 and 10:

<div class="main-content__small-images-inline">
    <img src="https://img.icons8.com/color/48/000000/debian.png" alt="Debian">
    <img src="https://img.icons8.com/color/48/000000/microsoft.png" alt="Microsoft">
    <img src="https://img.icons8.com/color/48/000000/chrome--v1.png" alt="Chrome">
    <img src="https://img.icons8.com/color/48/000000/safari--v1.png" alt="Safari">
    <img src="https://img.icons8.com/color/48/000000/docker.png" alt="Docker">
    <img src="https://img.icons8.com/fluency/48/000000/azure-1.png" alt="Azure">
</div> 

**Official Microsoft Docker Images**

* [.NET Standard](https://hub.docker.com/r/microsoft/dotnet-runtime/)
* [ASP.NET Core](https://hub.docker.com/r/microsoft/dotnet-aspnet/)

**Setup for Debian**

For Debian systems, use these Docker commands to prepare the environment for IronBarcode:
```dockerfile
# Refresh the package database

***Based on <https://ironsoftware.com/get-started/linux/>***

RUN apt update

# Install GDI+ support with libgdiplus

***Based on <https://ironsoftware.com/get-started/linux/>***

RUN apt install -y libgdiplus
```

### CentOS

**CentOS 7 Configuration** 

To get IronBarcode functional on CentOS 7, execute the following Docker commands:
```dockerfile
# Add EPEL repository for additional packages

***Based on <https://ironsoftware.com/get-started/linux/>***

RUN yum install epel-release -y

# Install Mono for .NET compatibility

***Based on <https://ironsoftware.com/get-started/linux/>***

RUN yum install mono-complete -y

# Incorporate libgdiplus and libc6-dev for enhanced graphics support

***Based on <https://ironsoftware.com/get-started/linux/>***

RUN yum install libgdiplus libc6-dev -y
```
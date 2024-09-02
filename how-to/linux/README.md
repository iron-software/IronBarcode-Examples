# IronBarCode Linux Compatibility and Installation Guide

IronBarCode is fully compatible with Linux and supports development in **.NET Core** and **.NET 5**, not to mention environments like Docker, Azure, macOS, and Windows.

<div class="main-content__small-images-inline">
    <img src="https://img.icons8.com/color/96/000000/linux--v1.png" alt="Linux">
    <img src="https://img.icons8.com/color/96/000000/docker.png" alt="Docker">
    <img src="https://img.icons8.com/fluency/96/000000/azure-1.png" alt="Azure">
    <img src="https://img.icons8.com/color/96/000000/amazon-web-services.png" alt="Amazon">
    <img src="https://img.icons8.com/color/96/000000/ubuntu--v1.png" alt="Ubuntu">
    <img src="https://img.icons8.com/color/96/000000/debian--v1.png" alt="Debian">
</div>

We suggest using .NET Core 3.1 or .NET 5 along with any runtime versions designated as [LTS by Microsoft](https://dotnet.microsoft.com/platform/support/policy) because these versions offer long-term support and have proven stability on Linux platforms.

IronBarCode typically works immediately on Linux, requiring no modifications to the code, thanks to extensive testing and optimization by our engineering team.

The adoption of Linux is crucial since many cloud services like Azure Web Apps, Azure Functions, AWS EC2, AWS Lambda, and Azure DevOps Docker predominantly utilize Linux. At Iron Software, we regularly use these cloud services and understand that they are important for our Enterprise and SaaS customers as well.

### Officially Supported Linux Distributions

For a seamless "zero configuration" setup of IronBarCode, we **officially support** the following **64-bit** Linux distributions:

* Ubuntu 20
* Ubuntu 18
* Debian 11
* Debian 10 _\[The Default Linux Distro on Microsoft Azure\]_
* CentOS 7

For guidance on installing IronBarCode on an unsupported Linux version, please refer to "Other Linux Distros" section below.

It's recommended to use Microsoft's [Official Docker Images](https://hub.docker.com/_/microsoft-dotnet-runtime/). Some Linux distros may need manual setup via `apt-get`, as detailed in "Linux Manual Setup" later in this document.

### Installation Command

```shell
Install-Package BarCode
```

## Ubuntu Compatibility

Ubuntu has undergone the most rigorous testing at Iron Software, particularly because it is widely used on the Azure platforms which host our continuous integration and deployment systems. Official Microsoft support and Docker images are also available for Ubuntu.

### Ubuntu 20
<div class="main-content__small-images-inline">
    <img src="https://img.icons8.com/color/48/000000/microsoft.png" alt="Microsoft">
    <img src="https://img.icons8.com/color/48/000000/ubuntu--v1.png" alt="Ubuntu">
    <img src="https://img.icons8.com/color/48/000000/chrome--v1.png" alt="Chrome">
    <img src="https://img.icons8.com/color/48/000000/safari--v1.png" alt="Safari">
    <img src="https://img.icons8.com/color/48/000000/docker.png" alt="Docker">
    <img src="https://img.icons8.com/fluency/48/000000/azure-1.png" alt="Azure">
</div>

**Official Microsoft Docker Images:**

*   [64-bit Ubuntu 20.04 Docker Image for .NET Runtime 3.1 ('3.1-focal')](https://hub.docker.com/_/microsoft-dotnet-runtime/)
*   [64-bit Ubuntu 20.04 Docker Image for .NET Runtime 5.0 ('5.0-focal')](https://hub.docker.com/_/microsoft-dotnet-runtime/)

**Setup Instructions for Ubuntu 20**

To configure IronBarCode in a Docker environment, ensure you have _sudo_ privileges and add the following commands to your Dockerfile:

```bash
RUN apt update
RUN apt install -y libgdiplus
```

### Setup Guides for Other Supported Linux Distributions

The setup procedure for Ubuntu 18, Debian 11, Debian 10, and CentOS 7 follows similar patterns to Ubuntu 20, emphasizing the installation of `libgdiplus` and ensuring compatibility with provided Microsoft Official Docker Images.

For Ubuntu 18, while there is no specific .NET 5 Docker image, compatibility generally remains high, and the setup commands mirror those of Ubuntu 20.

For both Debian 11 and Debian 10, the setup involves using appropriate Docker images and installing `libgdiplus` as outlined in the Dockerfile commands listed above.

**CentOS 7 Setup** requires the following commands, which focus on installing additional dependencies:

```bash
RUN yum install epel-release -y
RUN yum install mono-complete -y
RUN yum install libgdiplus libc6-dev -y
```

Please refer to the **Common Dependency Patterns for Linux** section above for a broad reference to necessary dependency packages across various Linux OS versions.
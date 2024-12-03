# Guide to IronBarCode on Linux Platforms

***Based on <https://ironsoftware.com/how-to/linux/>***


IronBarCode is compatible with Linux for **.NET Core** and **.NET 5** applications, and is also well-suited for use in environments like Docker, Azure, macOS, and of course, Windows.

<div class="main-content__small-images-inline">
    <img src="https://img.icons8.com/color/96/000000/linux--v1.png" alt="Linux">
    <img src="https://img.icons8.com/color/96/000000/docker.png" alt="Docker">
    <img src="https://img.icons8.com/fluency/96/000000/azure-1.png" alt="Azure">
    <img src="https://img.icons8.com/color/96/000000/amazon-web-services.png" alt="Amazon">
    <img src="https://img.icons8.com/color/96/000000/ubuntu--v1.png" alt="Ubuntu">
    <img src="https://img.icons8.com/color/96/000000/debian--v1.png" alt="Debian">
</div> 

For optimal performance and support, we recommend utilizing .NET Core 3.1 or .NET 5, especially versions designated as [LTS (Long-Term Support) by Microsoft](https://dotnet.microsoft.com/platform/support/policy). These versions have been extensively tested on Linux platforms and are backed by long-term support guarantees.

IronBarCode functions seamlessly on Linux without the need for modifications in code, thanks to extensive testing and tuning by our dedicated engineering team.

Linux platforms are crucial for numerous cloud services like Azure Web Apps, Azure Functions, AWS EC2, AWS Lambda, and Docker pipelines used in Azure DevOps. Iron Software frequently leverages these cloud services and understands their importance to our Enterprise and SAAS customers.

### Supported Linux Distributions

IronBarCode **officially supports** the latest **64-bit** Linux distributions listed below for a straightforward, "zero configuration" setup:

*   Ubuntu 20
*   Ubuntu 18
*   Debian 11
*   Debian 10 _\[Defaults on Microsoft Azure Linux Distributions\]_
*   Centos 7

For Linux versions not officially supported, see "Other Linux Distros" later in this guide for setup information.

It's advisable to use the [Official Docker Images by Microsoft](https://hub.docker.com/_/microsoft-dotnet-runtime/) to ensure compatibility. Configuration on other distributions might require manual setups, such as using apt-get commands. More details on this can be found in "Linux Manual Setup" towards the end of this documentation.

To install IronBarCode, use the following NuGet command:

```shell
Install-Package BarCode
```

## Compatibility with Ubuntu

Ubuntu is the most thoroughly tested Linux distribution in our suite, mainly because of its extensive use in Azure's infrastructure which aids continuous testing and deployment. Ubuntu also supports official Microsoft .NET frameworks and Docker images.

### Ubuntu 20
<div class="main-content__small-images-inline">
    <img src="https://img.icons8.com/color/48/000000/microsoft.png" alt="Microsoft">
    <img src="https://img.icons8.com/color/48/000000/ubuntu--v1.png" alt="Ubuntu">
    <img src="https://img.icons8.com/color/48/000000/chrome--v1.png" alt="Chrome">
    <img src="https://img.icons8.com/color/48/000000/safari--v1.png" alt="Safari">
    <img src="https://img.icons8.com/color/48/000000/docker.png" alt="Docker">
    <img src="https://img.icons8.com/fluency/48/000000/azure-1.png" alt="Azure">
</div>

**Official Microsoft Docker Images for Ubuntu 20:**

*   [64-bit Ubuntu 20.04 Docker Image for .NET Runtime 3.1 ('3.1-focal')](https://hub.docker.com/_/microsoft-dotnet-runtime/)
*   [64-bit Ubuntu 20.04 Docker Image for .NET Runtime 5.0 ('5.0-focal')](https://hub.docker.com/_/microsoft-dotnet-runtime/)

**Setup Instructions for Ubuntu 20**

To deploy IronBarCode within a Docker environment on Ubuntu 20, execute the following commands ensuring you possess _sudo_ administrative rights:

    RUN apt update
    RUN apt install -y libgdiplus

### Ubuntu 18

<div class="main-content__small-images-inline">
    <img src="https://img.icons8.com/color/48/000000/microsoft.png" alt="Microsoft">
    <img src="https://img.icons8.com/color/48/000000/ubuntu--v1.png" alt="Ubuntu">
    <img $"{image_url}" alt="Chrome">
    <img src="https://img.icons8.com/color/48/000000/safari--v1.png" alt="Safari">
    <img src="https://img.icons8.com/color/48/000000/docker.png" alt="Docker">
    <img src="https://img.icons8.com/fluency/48/000000/azure-1.png" alt="Azure">
</div> 

**Official Microsoft Docker Images for Ubuntu 18:**

*   [64-bit Ubuntu 18.04 Docker Image for .NET Runtime 3.1 ('3.1-bionic')](https://hub.docker.com/_/microsoft-dotnet-runtime/)

While there is no official Docker image for .NET 5 on Ubuntu 18, the compatibility remains exceptionally high.

**Setup Instructions for Ubuntu 18**

To run IronBarCode on Ubuntu 18, append the following commands to your Dockerfile, ensuring administrative privileges:

    RUN apt update
    RUN apt install -y libgdiplus

### Debian 11 and 10

For Debian 11 and 10, follow similar Docker setup guidelines as Ubuntu, noting that Debian 10 is often used as a default in Microsoft’s Docker-enabled .NET projects in Visual Studio. Both distributions support the same .NET Runtimes as Ubuntu and follow similar setup instructions.

**CentOS 7 Setup** For setting up IronBarCode on CentOS 7 using Docker, execute the following:

    RUN yum install epel-release -y
    RUN sudo yum install mono-complete -y
    RUN sudo yum install libgdiplus libc6-dev -y
    
**Common Dependency Patterns for Linux** Additionally, study the dependency packages for other Linux OS’s highlighted above.

    RUN apt update
    RUN apt install -y libgdiplus

This guide is designed to ensure a smooth setup and deployment of IronBarCode across various Linux distributions, facilitating seamless integration into your development pipeline.
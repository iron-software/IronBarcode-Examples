# IronBarCode Linux Compatibility & Setup Guide

***Based on <https://ironsoftware.com/how-to/linux/>***


IronBarCode is fully compatible with Linux for **.NET Core** and **.NET 5** applications, extending its support to other platforms like Docker, Azure, macOS, and of course, Windows.

<div class="main-content__small-images-inline">
    <img src="https://img.icons8.com/color/96/000000/linux--v1.png" alt="Linux">
    <img src="https://img.icons8.com/color/96/000000/docker.png" alt="Docker">
    <img src="https://img.icons8.com/fluency/96/000000/azure-1.png" alt="Azure">
    <img src="https://img.icons8.com/color/96/000000/amazon-web-services.png" alt="Amazon">
    <img src="https://img.icons8.com/color/96/000000/ubuntu--v1.png" alt="Ubuntu">
    <img src="https://img.icons8.com/color/96/000000/debian--v1.png" alt="Debian">
</div>

It is advisable to work with .NET Core 3.1 or .NET 5 under environments that are listed as [LTS by Microsoft](https://dotnet.microsoft.com/platform/support/policy), as these versions receive extensive long-term support and stable testing on Linux platforms.

IronBarCode is designed to operate seamlessly on Linux, demanding no modifications in your code. This out-of-the-box functionality is made possible through rigorous testing and optimizations by our dedicated team.

Support for Linux is crucial due to its extensive use in cloud services like Azure Web Apps, Azure Functions, AWS EC2, AWS Lambda, and Docker, all of which are integral to the operations of many Enterprise and SaaS customers at Iron Software.

### Supported Linux Distributions

We **strongly endorse** the following **64-bit** Linux distributions for a straightforward "zero configuration" installation of IronBarCode:

* Ubuntu 20
* Ubuntu 18
* Debian 11
* Debian 10 _\[Azure's Default Linux Distro\]_
* Centos 7

For setups incompatibile with the above versions, please consult "Other Linux Distros" below for guidance. 

Leveraging Microsoft's [Official Docker Images](https://hub.docker.com/_/microsoft-dotnet-runtime/) is recommended, although unsupported Linux distros may need manual configurations via apt-get. Details are further explained in the "Linux Manual Setup" section of this guide.

To integrate IronBarCode, add the following NuGet package:

```shell
Install-Package BarCode
```

## Ubuntu Compatibility Guide

Ubuntu stands as the most rigorously tested environment due to its prevalent use in our continuous testing and Azure deployments, bolstered with official Microsoft .NET and Docker image support.

### Ubuntu 20

<div class="main-content__small-images-inline">
    <img src="https://img.icons8.com/color/48/000000/microsoft.png" alt="Microsoft">
    <img src="https://img.icons8.com/color/48/000000/ubuntu--v1.png" alt="Ubuntu">
    <img src="https://img.icons8.com/color/48/000000/chrome--v1.png" alt="Chrome">
    <img src="https://img.icons8.com/color/48/000000/safari--v1.png" alt="Safari">
    <img src="https://img.icons8.com/color/48/000000/docker.png" alt="Docker">
    <img src="https://img.icons8.com/fluency/48/000000/azure-1.png" alt="Azure">
</div>

**Adopt these setup steps for IronBarCode in Ubuntu 20 Docker files, ensuring you have _sudo_ admin rights:**

```dockerfile
RUN apt update
RUN apt install -y libgdiplus
```

### Ubuntu 18
<div class="main-content__small-images-inline">
  <!-- remaining content -->
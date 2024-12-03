# Configuring IronBarCode for Docker Environments

***Based on <https://ironsoftware.com/how-to/docker-linux/>***


Are you interested in [Reading or Generating Barcodes with C#](https://ironsoftware.com/csharp/barcode/)?

IronBarCode is now fully compatible with Docker, including support for Azure Docker Containers on both Linux and Windows platforms.

<div class="main-content__small-images-inline">
    <img src="https://img.icons8.com/color/96/000000/docker--v1.png" alt="Docker">
    <img src="https://img.icons8.com/fluency/96/000000/azure-1.png" alt="Azure">
    <img src="https://img.icons8.com/color/96/000000/linux--v1.png" alt="Linux">
    <img src="https://img.icons8.com/color/96/000000/amazon-web-services--v1.png" alt="Amazon">
    <img src="https://img.icons8.com/color/96/000000/windows-logo--v1.png" alt="Windows">
</div>

## The Advantages of Docker

Docker provides a streamlined method for developers to package, deploy, and operate applications within a compact, self-contained, and transferable container. This enables the application to run seamlessly across different computing environments.

## Getting Started with IronBarCode on Linux

For developers unfamiliar with Docker in a .NET environment, a helpful resource is available that covers the essentials of Docker debugging and its integration with Visual Studio projects. You can find this guide here: [Setting Up Docker with Visual Studio](https://docs.microsoft.com/en-us/visualstudio/containers/edit-and-refresh?view=vs-2019).

Additionally, it's beneficial to go through our detailed [IronBarCode Linux Setup and Compatibility Guide](https://ironsoftware.com/csharp/barcode/how-to/linux/) which will aid you in setting up and configuring IronBarCode on various Linux distributions.

### Suggested Linux Docker Environments for IronBarCode

For a smooth integration of IronBarCode, we advise using the following 64-bit Linux operating systems which provide straightforward setup:

- Ubuntu 22
- Ubuntu 20
- Ubuntu 18
- Debian 11
- Debian 10 _[Currently designated as Microsoft Azure's default Linux distribution]_
- CentOS 7

We recommend deploying [Microsoft’s Official Docker Images](https://hub.docker.com/_/microsoft-dotnet-runtime/). While other Linux distributions are partially supported, they might necessitate additional setup steps through `apt-get`. For further instructions, refer to our "[Linux Manual Setup](https://ironsoftware.com/csharp/barcode/how-to/linux/)" guide.

This document includes practical Docker file configurations for Ubuntu and Debian.

## Essential Steps for Installing IronBarCode on Linux using Docker

To effectively utilize IronBarCode on Linux platforms within Docker environments, we strongly recommend integrating the [IronBarCode NuGet Package](https://www.nuget.org/packages/BarCode/). This package ensures compatibility across Windows, macOS, and Linux systems.

```bash
Install-Package BarCode
```

Optimizing your installation with the appropriate Docker configuration is crucial for leveraging IronBarCode’s full potential in your applications. Below, you'll find various Dockerfile examples tailored for different Ubuntu and Debian distributions, illustrating how to set up environments that support IronBarCode. These Dockerfiles provide a blueprint to configure your system correctly, from installing necessary packages to setting up your application to run seamlessly in Docker.

### Opt for the NuGet Package Solution

For a seamless development experience across Windows, macOS, and Linux, we advise leveraging the [IronBarCode](https://www.nuget.org/packages/BarCode/) NuGet package.

```shell
Install-Package IronBarCode
```

## Dockerfile Examples for Ubuntu using IronBarCode

Below you'll find Dockerfile configurations for integrating the `IronBarCode` library into Ubuntu Linux environments, showcasing its compatibility with various .NET versions.

<div class="main-content__small-images-inline">
    <img src="https://img.icons8.com/color/96/000000/docker--v1.png" alt="Docker">
    <img src="https://img.icons8.com/color/96/000000/ubuntu--v1.png" alt="Ubuntu">
</div>

### Ubuntu 22 - .NET 7 Setup

```console
# base image using Ubuntu 22 with .NET 7 runtime

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/runtime:7.0-jammy AS base
WORKDIR /app

# Update package lists

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

RUN apt-get update

# Develop with .NET 7 SDK on Ubuntu 22

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:7.0-jammy AS build
WORKDIR /src
# pulling NuGet packages

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"
# compile and build

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build
# finalize and prepare deployment

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish
# Execute application

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

### Ubuntu 22 - .NET 6 (LTS Version)

```console
# Base runtime for Ubuntu 22 with .NET 6

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/runtime:6.0-jammy AS base
WORKDIR /app

# Update lists

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

RUN apt-get update

# Development stage using .NET 6 SDK

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:6.0-jammy AS build
WORKDIR /src
# Restoring packages

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"
# Building the application

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build
# Publishing the application

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish
# Final stage to run the application

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

### Older Ubuntu Versions with LTS .NET

```console
# Set up for older Ubuntu versions with respective .NET LTS versions

***Based on <https://ironsoftware.com/how-to/docker-linux/>***


# Ubuntu 20 with .NET 6 LTS

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/runtime:6.0-focal AS base
WORKDIR /app
RUN apt-get update
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"
COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]

# Repeat these steps for Ubuntu 20 with .NET 5 and .NET 3.1, and Ubuntu 18 with .NET 3.1, swapping out runtime and SDK versions as needed.

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

```

Each Dockerfile here is tailored to accommodate the specific needs of each Ubuntu version while ensuring IronBarCode's functionality remains intact across different .NET environments.

<div class="main-content__small-images-inline">
    <img src="https://img.icons8.com/color/96/000000/docker--v1.png" alt="Docker"> 
    <img src="https://img.icons8.com/color/96/000000/ubuntu--v1.png" alt="Ubuntu">
</div>

### Configuring Ubuntu 22 for .NET 7 Deployment

```console
# Establish the base image with Ubuntu 22 and .NET runtime

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/runtime:7.0-jammy AS base
WORKDIR /app
# Update package lists

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

RUN apt update

# Develop the software using the .NET SDK on Ubuntu 22

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:7.0-jammy AS build
WORKDIR /src
# Retrieve packages needed for the project

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"
# Compile the source code

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build
# Package the application for release

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Prepare the final run environment

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```
```

```console
# Establish the base runtime environment using Ubuntu 22 and .NET

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/runtime:7.0-jammy AS base
WORKDIR /app
# Begin with updating the package lists

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

RUN apt update

# Set up the development environment for .NET on Ubuntu 22

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:7.0-jammy AS build
WORKDIR /src
# Retrieve and restore NuGet packages for the project

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"
# Proceed to compile the project

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build
# Prepare the project for publication

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish
# Setup the final runtime image

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

```console
# Base runtime image (Ubuntu 22 with .NET 6 LTS runtime)

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/runtime:6.0-jammy AS runtime
WORKDIR /app
# Update packages list

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

RUN apt-get update

# Setup .NET SDK for development (Ubuntu 22 with .NET 6)

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:6.0-jammy AS development
WORKDIR /src
# Restoring NuGet packages using the project's .csproj file

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"
# Compile and build the project

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build
# Publish the project

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM development AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish
# Execute application

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM runtime AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

```console
# Establish the base runtime environment using Ubuntu 22 with .NET

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/runtime:6.0-jammy AS base
WORKDIR /app
# Execute package updates

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

RUN apt update

# Create the base environment for app development using .NET SDK

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:6.0-jammy AS build
WORKDIR /src
# Restore necessary NuGet packages for the project

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"
# Compile the project files

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build
# Publish the built project

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish
# Set the runtime environment and run the application

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

### Setting Up .NET 6 (LTS) on Ubuntu 20 Using Docker

```console
# Base image utilizing Ubuntu 20 and .NET runtime

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/runtime:6.0-focal AS base
WORKDIR /app
# Perform package updates

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

RUN apt update

# Development image setup with Ubuntu 20 and .NET SDK

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
# Restore all NuGet packages needed for the project

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"
# Compile the project

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build
# Prepare for publication

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish
# Set up the runtime environment

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```
```

Below is the paraphrased section of the article with paths resolved to `ironsoftware.com`:

```console
# Starting with the base image running .NET on Ubuntu 20

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/runtime:6.0-focal AS base
WORKDIR /app
# Execute package updates

***Based on <https://ironsoftware.com/how-to/docker-linux/>***



RUN apt update


# Establishing the development environment with .NET SDK on Ubuntu 20

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
# Rehydrate NuGet packages

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"
# Proceed to compile the project

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build
# Moving to the publication phase

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish
# Setting up the final runtime image

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

This revised Docker configuration leverages Ubuntu 20 as its foundation, maintains the clarity and functionality of the original script, and emphasizes the step-by-step process for building and deploying the .NET application using Docker.

Here's the paraphrased section of the article, with all relative URL paths and images resolved to `ironsoftware.com`:


### Ubuntu 20 Using .NET 5 

```console
# starting with the runtime environment (Ubuntu 20 with .NET 5)

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/runtime:5.0-focal AS base
WORKDIR /app
# updating package list

***Based on <https://ironsoftware.com/how-to/docker-linux/>***


RUN apt update

# moving on to the development environment setup

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
# fetching all required NuGet packages

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"
# compiling the application

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build
# preparing for publishing

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish
# setting up the final runtime environment

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```
```

Here's the paraphrased section:

```console
# Starting with the base Ubuntu 20 image containing the .NET runtime

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/runtime:5.0-focal AS base
WORKDIR /app
# Update package lists

***Based on <https://ironsoftware.com/how-to/docker-linux/>***


RUN apt update

# Setting up the development environment using the Ubuntu 20 .NET SDK image

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
# Retrieve packages for the project

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"
# Compile the application

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build
# Prepare the application for deployment

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish
# Set up the final runtime environment

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

### Ubuntu 20 Using .NET 3.1 Long-Term Support Version

```console
# Establish the base runtime environment using Ubuntu 20 and .NET runtime

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/runtime:3.1-focal AS base
WORKDIR /app

# Update package lists

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

RUN apt update

# Setting up the development environment by adding .NET SDK on Ubuntu 20

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:3.1-focal AS build
WORKDIR /src

# Restore NuGet packages from the .csproj file

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Transition to the Example project directory to start the build process

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Prepare for publishing the project by creating a separate publish environment

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Setup the final runtime image, copy over the published files and set the entry point for the application

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

```console
# Initializing base runtime environment (Ubuntu 20 with .NET runtime)

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/runtime:3.1-focal AS base
WORKDIR /app
# Start package installation process

***Based on <https://ironsoftware.com/how-to/docker-linux/>***


RUN apt update

# Setting up the development environment (Ubuntu 20 with .NET SDK)

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:3.1-focal AS build
WORKDIR /src
# Retrieving and restoring NuGet packages

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"
# Initiating project build

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build
# Project publishing phase

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish
# Final stage to run the application

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

### Configuration for Ubuntu 18 Using .NET Core 3.1 LTS

```console
# Use Ubuntu 18 with the .NET Core runtime as the base image

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/runtime:3.1-bionic AS base
WORKDIR /app
# Begin with updating packages

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

RUN apt update

# Continue by setting up the SDK environment for development

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:3.1-bionic AS build
WORKDIR /src
# Proceed with the restoration of NuGet packages

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"
# Compile the project files

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build
# Prepare for deployment by publishing the project

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish
# Final image setup for runtime

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```
This configuration effectively utilizes Docker to set up an environment suitable for running applications developed in .NET Core 3.1 LTS on Ubuntu 18, ensuring essential updates are applied and dependencies are managed cleanly.

Below is the paraphrased section of the Docker configuration:

```console
# Start with the base runtime environment (Ubuntu 18 with .NET)

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/runtime:3.1-bionic AS base
WORKDIR /app
# Update system packages

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

RUN apt update

# Establish the development environment

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:3.1-bionic AS build
WORKDIR /src
# Restore the NuGet packages required

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"
# Build the .NET project

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build
# Publish the project using .NET

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish
# Setup the final running environment

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

This rewritten Dockerfile maintains the original structure while using varied terminology for descriptions and instructions, ensuring clarity and readability in deploying an application using Docker on Ubuntu 18 with .NET 3.1.

## Docker Configuration for Debian with IronBarCode

The following sections outline the Docker configurations for Debian systems, ensuring compatibility and ease of deployment for IronBarCode on different .NET versions.

### Debian 11 with .NET 7

```console
# Using Debian 11 with the ASP.NET Core Runtime

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/aspnet:7.0-bullseye-slim AS base
WORKDIR /app
# Update and install packages

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

RUN apt update

# Set up the development image with .NET SDK for Debian 11

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:7.0-bullseye-slim AS build
WORKDIR /src
# Restore packages from NuGet

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"
# Compile and build the application

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build
# Publish the application

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish
# Final stage to run the application

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

### Debian 11 with .NET 6 (LTS)

```console
# Base runtime image setup for Debian 11 with ASP.NET Core Runtime

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/aspnet:6.0-bullseye-slim AS base
WORKDIR /app
# Package installation update

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

RUN apt update

# Development environment setup with .NET SDK for Debian 11

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:6.0-bullseye-slim AS build
WORKDIR /src
# Restoring NuGet packages

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"
# Building the application

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build
# Application publishing stage

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish
# Final setup to run the application

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

### Debian 11 with .NET 5

```console
# Initial runtime setup for Debian 11 with ASP.NET Core Runtime

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/aspnet:5.0-bullseye-slim AS base
WORKDIR /app
# Update packages

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

RUN apt update

# Configure development image with .NET SDK

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:5.0-bullseye-slim AS build
WORKDIR /src
# NuGet package restoration

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"
# Compile and build the code

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build
# Publish the application

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish
# Prepare the final environment to run the application

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

### Debian 11 with .NET 3.1 LTS

```console
# Setting up the runtime image on Debian 11 with ASP.NET Core Runtime

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/aspnet:3.1-bullseye-slim AS base
WORKDIR /app
# Install system updates

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

RUN apt update

# Establish the development environment with the .NET SDK

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:3.1-bullseye-slim AS build
WORKDIR /src
# Restore packages via NuGet

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"
# Compile and build the project

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build
# Publish the project

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish
# Final step to run the application

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

Each Dockerfile example demonstrates a streamlined approach for configuring Docker environments tailored for IronBarCode functionality across various Debian releases and .NET versions.

### Configuring .NET 7 on Debian 11

```console
# Initialize the base runtime environment using Debian 11 with ASP.NET Core Runtime

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/aspnet:7.0-bullseye-slim AS base
WORKDIR /app
# Update packages

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

RUN apt update

# Set up the development environment using Debian 11 with .NET SDK

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:7.0-bullseye-slim AS build
WORKDIR /src
# Retrieve NuGet packages

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"
# Compile the project

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build
# Publish the project to the app directory

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish
# Establish the final run stage

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```
```

```console
# Establish the foundational runtime environment for Debian 11 with ASP.NET Core Runtime

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/aspnet:7.0-bullseye-slim AS base
WORKDIR /app
# Initiate package installation

***Based on <https://ironsoftware.com/how-to/docker-linux/>***


RUN apt update

# Set up the development environment for Debian 11 using .NET SDK

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:7.0-bullseye-slim AS build
WORKDIR /src
# Initiate the restoration of NuGet packages

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"
# Commence the build process

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build
# Initiate the publishing of the project

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish
# Prepare the app for execution

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

```console
# Start with the base runtime image for Debian 11 and ASP.NET Core

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/aspnet:6.0-bullseye-slim AS base
WORKDIR /app
# Update system packages

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

RUN apt update

# Proceed to create the development image for Debian 11 using the .NET SDK

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:6.0-bullseye-slim AS build
WORKDIR /src
# Retrieve NuGet packages required for the project

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"
# Compile the project

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Prepare the publishing stage

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Define the final runtime image

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

```console
# Define the base image with the ASP.NET Core Runtime for Debian 11

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/aspnet:6.0-bullseye-slim AS base
WORKDIR /app
# Initiate package installation

***Based on <https://ironsoftware.com/how-to/docker-linux/>***


RUN apt update


# Set up a development image using the .NET SDK for Debian 11

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:6.0-bullseye-slim AS build
WORKDIR /src
# Synchronize NuGet packages

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"
# Compile the application

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build
# Prepare the application for deployment

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish
# Prepare the runtime environment

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

### Debian 11 Configuration Using .NET 5

Below is a guide to creating a Docker container based on Debian 11 with the support of the .NET 5 runtime and SDK, allowing you to run a .NET application.

```console
# Starting with the base image for Debian 11 with the ASP.NET Core Runtime

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/aspnet:5.0-bullseye-slim AS base
WORKDIR /app
# Update the repository's package listings

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

RUN apt update

# Proceeding with the SDK setup necessary for .NET 5 development

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:5.0-bullseye-slim AS build
WORKDIR /src
# Retrieving necessary NuGet packages for the 'Example' project

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"
# Proceed to compile the application from source

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build
# Publishing the built project

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish
# Setting up the runtime environment

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

This Dockerfile outlines the essential configuration steps to get a Debian 11 environment ready for developing and deploying applications using .NET 5, ensuring lightweight and efficacious deployment via Docker.

```console
# Set up the base image using Debian 11 with ASP.NET Core Runtime

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/aspnet:5.0-bullseye-slim AS base
WORKDIR /app
# Initiate package updates

***Based on <https://ironsoftware.com/how-to/docker-linux/>***


RUN apt update

# Prepare the development environment using Debian 11 with .NET SDK

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:5.0-bullseye-slim AS build
WORKDIR /src
# Restore NuGet packages necessary for the project

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"
# Compile the project

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build
# Publish the build to the publish directory

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish
# Setup the final runtime image

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

Here is the paraphrased section:

### Debian 11 Configuration for .NET 3.1 LTS

```console
# Primary runtime environment (Debian 11 with ASP.NET Core Runtime)

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/aspnet:3.1-bullseye-slim AS base
WORKSPACE /app

# Install updates and necessary packages

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

RUN apt update

# Development environment setup (Debian 11 with .NET SDK)

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:3.1-bullseye-slim AS build
WORKSPACE /src

# Retrieve and restore NuGet packages

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Build the application

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY . .
WORKSPACE "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Publish the application

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Final stage to prepare the app runtime environment

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM base AS final
WORKSPACE /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

This updated section aligns with the latest configurations and best practices for deploying applications using .NET 3.1 LTS on Debian 11.

Here is the paraphrased version of the specified section:

```console
# Set up the base image using Debian 11 with ASP.NET Core Runtime

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/aspnet:3.1-bullseye-slim AS base
WORKDIR /app
# Perform system updates

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

RUN apt update

# Prepare the development environment with .NET SDK on Debian 11

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:3.1-bullseye-slim AS build
WORKDIR /src
# Retrieve project dependencies

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"
# Compile the application

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build
# Create the publishable build

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish
# Set the final runtime environment

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

This version maintains the original process and command structure but rewords instructions and comments for clarity and variance.

### Debian 10 with .NET 5 Framework

```console
# base runtime image (Debian 10 w/ .NET runtime)

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app
# install necessary packages

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

RUN apt update

# base development image (Debian 10 w/ .NET SDK)

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
# restore NuGet packages

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"
# build project

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build
# publish project

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish
# run the application

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```
This Dockerfile configures a Debian 10 environment to run a .NET 5 application, starting with a base image with the .NET Runtime. It updates the system and installs required packages, then uses a .NET SDK image for building and publishing the application, finalizing by setting up the runtime environment for deployment.
```

```console
# Base runtime environment image using Debian 10 with .NET 5.0

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app
# Preparing environment by updating packages

***Based on <https://ironsoftware.com/how-to/docker-linux/>***



RUN apt update


# Development setup with .NET SDK on Debian 10

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
# Importing and restoring necessary NuGet packages

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"
# Initiating project build

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build
# Publishing the project from build environment

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish
# Setting up the final runtime environment

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

Here's the paraphrased section of the article:

### Debian 10 and .NET 3.1 LTS Environment

For running applications under Debian 10 with .NET 3.1 LTS, the set-up involves the following steps:

```console
# Start with the base ASP.NET Core Runtime on Debian 10

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/runtime:3.1 AS base
WORKDIR /app

# Update installed packages

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

RUN apt update

# Continue by setting up the development environment

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src

# Bring in NuGet packages needed for the project

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Proceed with the build

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Get ready to publish the project

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Final preparation for runtime

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

This configuration ensures your application is bundled and deployed effectively in a Debian 10 environment with .NET 3.1 LTS.

```console
# define the foundational runtime environment using .NET 3.1 on Debian 10

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/runtime:3.1 AS base
WORKDIR /app
# proceed with package installations

***Based on <https://ironsoftware.com/how-to/docker-linux/>***


RUN apt update

# establish the development environment using .NET SDK on Debian 10

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
# initiate package restoration

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"
# commence building the project

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build
# prepare for project publication

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish
# finalize and set up the running application

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

```console
# CentOS 7 base image

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM centos:7 AS base
# Adding Microsoft package repository

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

RUN rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
# Installing .NET Runtime

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

RUN yum install -y dotnet-runtime-7.0
WORKDIR /app

# Setup build environment in CentOS 7

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM centos:7 AS build
# Adding Microsoft package sources

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

RUN rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
# Installing .NET SDK

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

RUN yum install -y dotnet-sdk-7.0

WORKDIR /src
# Restore NuGet packages

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"
# Building the project

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build
# Publishing the project

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Setting up the final runtime environment

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

```console
# Establish the base runtime environment for CentOS 7

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM centos:7 as base
# Install required system packages

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

RUN rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
RUN yum install -y dotnet-runtime-7.0
WORKDIR /app

# Create a build environment based on CentOS 7

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM centos:7 as build
# Inject necessary system packages

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

RUN rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
RUN yum install -y dotnet-sdk-7.0

WORKDIR /src
# Sync and restore NuGet packages

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"
# Compile the project files

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build
# Prepare the build for deployment

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish
# Set up the application to run from the compiled build

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

Here is the paraphrased version of the specified section from the article, with relative URL paths resolved:


### Configuring CentOS 7 with .NET 6 (Long Term Support)

```console
# Start with the base CentOS 7 runtime image

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM centos:7 as base
# Add Microsoft package repository and install the .NET 6 runtime

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

RUN rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
RUN yum install -y dotnet-runtime-6.0
# Set the working directory

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

WORKDIR /app

# Create the build environment using the same CentOS 7 image

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM centos:7 as build
# Install necessary packages for .NET SDK

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

RUN rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
RUN yum install -y dotnet-sdk-6.0
    
# Set the source directory and restore the project dependencies

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

WORKDIR /src
COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"
# Copy over the source code and build the project

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build
# Publish the application to the app directory

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Prepare the final image, copy the published files to the app directory, and set the entrypoint

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```
```

```console
# Initialize CentOS 7 base image for runtime

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM centos:7 as base
# Install required packages

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

RUN rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
RUN yum install -y dotnet-runtime-6.0
WORKDIR /app

# Set up CentOS 7 base image for SDK

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM centos:7 as build
# Add necessary packages

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

RUN rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
RUN yum install -y dotnet-sdk-6.0

# Set the working directory and start package restoration

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

WORKDIR /src
# Retrieve NuGet packages

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"
# Copy all project files and build the project

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build
# Start the publishing phase

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish
# Set up the final stage to run the app

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

### CentOS 7 configuration for .NET Core 3.1 LTS

```console
# Base system image setup for CentOS 7

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM centos:7 AS base

# Install initial package setup

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

RUN yum install sudo -y
RUN sudo rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
RUN sudo yum install aspnetcore-runtime-3.1 -y

# Prepare the application's working directory

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

WORKDIR /app
EXPOSE 80
EXPOSE 443

# Setup the development environment using the CentOS 7 image

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM centos:7 AS build

# Necessary package installations for development

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

RUN yum install sudo -y
RUN sudo rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
RUN sudo yum install dotnet-sdk-3.1 -y
    
# Setting the work directory and restoring the needed NuGet packages

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

WORKDIR /src
COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Build steps for your .NET project

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Creating the publish image from the build image

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Final setup using the base image, running the application

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```
```

```console
# Set up the base runtime environment using CentOS 7

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM centos:7 AS base

# Load necessary packages for the runtime

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

RUN yum install sudo -y
RUN sudo rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
RUN sudo yum install aspnetcore-runtime-3.1 -y

# Configure working directory and open necessary ports

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

WORKDIR /app
EXPOSE 80
EXPOSE 443

# Create the SDK image from CentOS 7 for development

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM centos:7 AS build

# Install SDK and necessary development packages

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

RUN yum install sudo -y
RUN sudo rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
RUN sudo yum install dotnet-sdk-3.1 -y

# Set source directory for the build

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

WORKDIR /src
# Start restoring NuGet packages required for the project

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"
# Compile the project to check for errors

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build
# Proceed to publish the project after successful build

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish
# Setting up the runtime environment, copy the published app and set entry point

***Based on <https://ironsoftware.com/how-to/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```


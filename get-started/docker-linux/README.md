# Configuring IronBarcode for Docker Containers

***Based on <https://ironsoftware.com/get-started/docker-linux/>***


IronBarcode offers complete compatibility with Docker, accommodating both Azure and AWS containers across Linux and Windows environments.

<div class="main-content__small-images-inline">
    <img src="https://img.icons8.com/color/96/000000/docker--v1.png" alt="Docker">
    <img src="https://img.icons8.com/fluency/96/000000/azure-1.png" alt="Azure">
    <img src="https://img.icons8.com/color/96/000000/linux--v1.png" alt="Linux">
    <img src="https://img.icons8.com/color/96/000000/amazon-web-services--v1.png" alt="Amazon">
    <img src="https://img.icons8.com/color/96/000000/windows-logo--v1.png" alt="Windows">
</div>

## Benefits of Using Docker

Docker provides developers with a streamlined method to package, distribute, and execute any application as a compact, self-contained container. These containers offer portability and can operate seamlessly across different computing environments.

## Introduction to IronBarcode with Linux

For those new to using Docker in combination with .NET, we suggest checking out this [informative article](https://docs.microsoft.com/en-us/visualstudio/containers/edit-and-refresh?view=vs-2019) which provides a thorough guide on how to configure Docker for debugging and integrating it with Visual Studio projects.

Additionally, to ensure optimal use of IronBarcode on Linux platforms, please refer to our detailed [IronBarcode Linux setup and compatibility guide](https://ironsoftware.com/csharp/barcode/get-started/linux/).

### Suggested Linux Docker Distributions for IronBarcode

For a straightforward setup of IronBarcode, the following 64-bit Linux distributions are recommended:

* Ubuntu 18 or newer
* Debian 10 or newer
* CentOS 7 or newer

It is advisable to utilize [Microsoft's official Docker images](https://hub.docker.com/_/microsoft-dotnet-runtime/) for these environments. While partial support is available for other Linux distributions, they might necessitate manual configurations and additional installations of dependencies. For detailed instructions on configuring IronBarcode on Linux, refer to our [Linux manual setup guide](https://ironsoftware.com/csharp/barcode/get-started/linux/).

## Essential Steps for Installing IronBarcode in Linux Docker Environments

To seamlessly integrate IronBarcode into your Docker-based Linux setups, we advise utilizing the [IronBarCode NuGet Package](https://www.nuget.org/packages/BarCode/). This package is designed for ease of use across various operating systems including Windows, macOS, and Linux, ensuring a smooth workflow for developers.

```shell
Install-Package BarCode
```

### NuGet Package Integration

It is advisable to implement the [IronBarCode](https://www.nuget.org/packages/BarCode/) NuGet Package for smooth development across Windows, macOS, and Linux environments.

Here is the paraphrased version of the specified section from the article, with the URL resolved:

-----
```shell
# Install the IronBarCode package from NuGet

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

Install-Package BarCode
```

## Dockerfiles for Ubuntu Linux

<div class="main-content__small-images-inline">
    <img src="https://img.icons8.com/color/96/000000/docker--v1.png" alt="Docker"> 
    <img src="https://img.icons8.com/color/96/000000/ubuntu--v1.png" alt="Ubuntu">
</div>

### Ubuntu 22 with .NET 7

```dockerfile
# Use the .NET 7 runtime base image for Ubuntu 22

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/runtime:7.0-jammy AS base
WORKDIR /app

# Update packages and install dependencies

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN apt update

# Now use the .NET 7 SDK base image for development

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:7.0-jammy AS build
WORKDIR /src

# Retrieve and restore any NuGet packages for the project

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Transfer the full project to build it

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Publish the build to the 'app/publish' directory

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Setup the runtime environment, move built files for execution

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

### Ubuntu 22 with .NET 6 (LTS)

```dockerfile
# Establish base with Ubuntu 22 and the .NET 6 runtime

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/runtime:6.0-jammy AS base
WORKDIR /app

# Update and install needed packages

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN apt update

# Set up the .NET 6 SDK for development purposes

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:6.0-jammy AS build
WORKDIR /src

# Restore necessary NuGet packages

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Copy and build the project

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Publish the project to the designated output directory

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Prepare the final image and copy over the published app

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

### Ubuntu 20 with .NET 6 (LTS)

```dockerfile
# Begin with .NET 6 runtime base image for Ubuntu 20

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/runtime:6.0-focal AS base
WORKDIR /app

# Update system and install required packages

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN apt update

# Switch to the SDK image for building the project

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src

# Restore the project dependencies

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Copy the project files and compile the application

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Publish the compiled application

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Setup the final runtime environment

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

<div class="main-content__small-images-inline">
    <img src="https://img.icons8.com/color/96/000000/docker--v1.png" alt="Docker"> 
    <img src="https://img.icons8.com/color/96/000000/ubuntu--v1.png" alt="Ubuntu">
</div>

```dockerfile
# Starting with the base Ubuntu 22 runtime image configured for .NET 7

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/runtime:7.0-jammy AS base
WORKDIR /app

# Initiate package updates

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN apt update

# Set the base SDK image for Ubuntu 22 and .NET SDK 7

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:7.0-jammy AS build
WORKDIR /src

# Pull and load NuGet packages for the application

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Transfer source code and compile it in the Docker image

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Publish the project data from the build to the publish folder

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Prepare the final image by deploying the app on the configured base image

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

```dockerfile
# Starting with the base image for .NET runtime on Ubuntu 22

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/runtime:7.0-jammy AS base
WORKDIR /app

# Update system packages

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN apt update

# Setting up the build environment using the .NET SDK on Ubuntu 22

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:7.0-jammy AS build
WORKDIR /src

# Copying and restoring NuGet packages for the project

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Compiling the project from sources

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Creating the publish image and deploying the build

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Constructing the final runtime image and configuring the entrypoint

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

### Setting Up Ubuntu 22 with .NET 6 (Long-Term Support)

Below is the Dockerfile for creating an environment with Ubuntu 22 configured with the .NET 6 LTS:

```dockerfile
# Base image using Ubuntu 22 with installed .NET runtime

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/runtime:6.0-jammy AS base
WORKDIR /app

# Update package lists

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN apt update

# Development image with Ubuntu 22 and .NET SDK

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:6.0-jammy AS build
WORKDIR /src

# NuGet package restoration

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Compiling the application

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Publishing the application

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Final Docker image to run the application

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

This Dockerfile outlines the process for setting up a .NET 6 application on Ubuntu 22 LTS. It ensures the application is up-to-date, built, and ready to be deployed and run seamlessly.

```dockerfile
# Establish the base image using Ubuntu 22 and .NET runtime

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/runtime:6.0-jammy AS base
WORKDIR /app

# Update and install essential packages

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN apt update

# Set up the development environment with .NET SDK on Ubuntu 22

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:6.0-jammy AS build
WORKDIR /src

# Fetch and restore NuGet packages

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Compile the application from the project files

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Create a publication of the project

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Prepare the final runnable image of the app

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

### Ubuntu 20 Configuration for .NET 6 (Long Term Support)

```dockerfile
# Begin with the base image containing .NET runtime specific to Ubuntu 20

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/runtime:6.0-focal AS base
WORKDIR /app

# Update available packages

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN apt update

# Continue with the development image that includes the .NET SDK

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src

# Start restoration of NuGet packages

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Proceed with project construction

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Move onto the publishing stage

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Finalize with the preparation of the ultimate image to run the application

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

```dockerfile
# Establishing the base image for runtime environment (Ubuntu 20 with .NET 6 runtime)

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/runtime:6.0-focal AS base
WORKDIR /app

# Update the package list

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN apt update

# Setting up the development environment image (Ubuntu 20 with .NET 6 SDK)

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src

# Fetch and restore NuGet dependencies

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Copy all files and build the project

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Create an image for deploying the application by publishing the project

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Configure the final runtime image and set it up for execution

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

### Setup for Ubuntu 20 Using .NET 5

```dockerfile
# Choose the base image equipped with the .NET 5 runtime

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/runtime:5.0-focal AS base
WORKDIR /app

# Update the available package references

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN apt update

# Select the development image that includes the .NET 5 SDK

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src

# Restore all NuGet packages specified in the project

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Copy source code and build the project in Release configuration, output to /app/build

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Proceed to publish the project

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Prepare the final runtime image, copy the published app

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

Here's the paraphrased section:

```dockerfile
# Initialize the base runtime environment with Ubuntu 20 and .NET

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/runtime:5.0-focal AS base
WORKDIR /app

# Update available packages

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN apt update

# Set up the development environment with .NET SDK on Ubuntu 20

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src

# Fetch and install the NuGet dependencies

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Compile the application code

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Prepare the app for deployment

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Prepare the final Docker image with the built application

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

```dockerfile
# Using Ubuntu 20 and .NET 3.1 LTS for the base runtime environment

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/runtime:3.1-focal AS base
WORKDIR /app

# Updating the package lists

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN apt update

# Setting up the base development environment with Ubuntu 20 and .NET SDK 3.1

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:3.1-focal AS build
WORKDIR /src

# Restoring the NuGet packages specified in the project

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Building the project from the project file

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Publishing the project to prepare it for the final image

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Establishing the final runtime image with the published contents

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

Below is the paraphrased version of the Dockerfile section for Ubuntu 20:

```dockerfile
# Setup the initial runtime environment using Ubuntu 20 and .NET

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/runtime:3.1-focal AS base
WORKDIR /app

# Update and install required system packages

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN apt update

# Prepare the development environment with the .NET SDK on Ubuntu 20

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:3.1-focal AS build
WORKDIR /src

# Fetch and install the necessary NuGet packages

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Compile the application from the source code

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Generate the publishable output of the project

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Define the final runtime image to host the application

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

This version rephrases the initial Dockerfile with clearer comments and organized steps, enhancing the readability and maintainability of the Dockerfile.

### Ubuntu 18 and .NET 3.1 LTS Setup

```dockerfile
# Starting with the base image for Ubuntu 18 and .NET Core runtime

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/runtime:3.1-bionic AS base
WORKDIR /app

# Update system packages

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN apt update

# Establish the development environment on Ubuntu 18 with .NET SDK

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:3.1-bionic AS build
WORKDIR /src

# Retrieve and install project dependencies

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Compile the application

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Prepare the application for deployment

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Configure the final container with the deployed application

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

Here's the paraphrased version of the Dockerfile for setting up a .NET application in an Ubuntu 18 environment:

```dockerfile
# Starting with the base image, including .NET runtime for Ubuntu 18

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/runtime:3.1-bionic AS base
WORKDIR /app

# Execute system package update

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN apt update

# Setting up the development environment with .NET SDK for Ubuntu 18

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:3.1-bionic AS build
WORKDIR /src

# Transferring NuGet package configurations and restoring them

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Copying project files and building the project

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Transition to the publish phase with the artifacts from the build

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Preparing the final runnable image from the build outputs

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM base AS final
WORKWORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

This revised version retains the technical specificity needed while adopting a slightly varied structure and phrasing, ensuring clarity and proper technical setup for running a .NET application using Docker.

## Debian Linux Docker Configuration

For deploying IronBarcode on Debian Linux using Docker, we provide detailed Dockerfile configurations for different versions of .NET.

### Debian 11 with .NET 7

```dockerfile
# Use Debian 11 with ASP.NET Core Runtime as the base image

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/aspnet:7.0-bullseye-slim AS base
WORKDIR /app

# Install updates and dependencies

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN apt update

# Configure the build environment using the .NET SDK

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:7.0-bullseye-slim AS build
WORKDIR /src

# Restore dependencies specified in the Example.csproj

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Copy source code and compile the project

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Publish the build to the app directory

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Final stage to deploy the application

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

### Debian 11 with .NET 6 (LTS)

```dockerfile
# Starting with the base image for Debian 11 with ASP.NET Core Runtime

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/aspnet:6.0-bullseye-slim AS base
WORKDIR /app

# Install necessary system updates

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN apt update

# Setting up the development image with .NET SDK

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:6.0-bullseye-slim AS build
WORKDIR /src

# Restore NuGet packages referenced by the project

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Copy the source files and build the project

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Publishing the built project

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Final setup for running the application

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

### Debian 11 with .NET 5

```dockerfile
# Set up the initial layer using Debian 11 and the ASP.NET Core Runtime

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/aspnet:5.0-bullseye-slim AS base
WORKDIR /app

# Update and install dependencies

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN apt update

# Prepare the build environment with the .NET SDK layer

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:5.0-bullseye-slim AS build
WORKDIR /src

# Restore all packages required by the application

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Proceed to copy the source code and build the application

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Publish the application to the designated output folder

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Final layer to run the application

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

### Debian 11 with .NET 3.1 LTS

```dockerfile
# Begin with the ASP.NET Core Runtime as the base for Debian 11

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/aspnet:3.1-bullseye-slim AS base
WORKDIR /app

# Pull the latest package updates

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN apt update

# Establish a build environment using the appropriate .NET SDK

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:3.1-bullseye-slim AS build
WORKDIR /src

# Restore NuGet packages as per the project's specifications

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Copy all project files and build the project

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Publish the final build to the app path

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Last stage, get the app ready to run

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

### Debian 11 with .NET 7 Setup

```dockerfile
# Initialize the base image with ASP.NET Core Runtime for Debian 11

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/aspnet:7.0-bullseye-slim AS base
WORKDIR /app

# Update and install required packages

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN apt update

# Set up the development environment with .NET SDK for Debian 11

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:7.0-bullseye-slim AS build
WORKDIR /src

# Reconfigure NuGet packages

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Compile the project

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Prepare for deployment

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Configure the runtime environment and launch

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```
This Docker configuration provides a streamlined process for setting up a .NET 7 environment on Debian 11, ensuring your applications are ready to deploy with efficiency and stability.

Here is the paraphrased section of the Dockerfile you requested:

```dockerfile
# Establish the base runtime environment using Debian 11 and ASP.NET Core Runtime

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/aspnet:7.0-bullseye-slim AS base
WORKDIR /app

# Update the package lists

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN apt update

# Set up the development environment with Debian 11 and .NET SDK

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:7.0-bullseye-slim AS build
WORKDIR /src

# Copy the project file and restore NuGet packages

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Copy all source files and compile the project

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Prepare the publish stage

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Create the final run image

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

### Debian 11 Setup for .NET 6 (Long-Term Support)

```dockerfile
# Start with a Base Image of Debian 11 Including the .NET Core Runtime

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/aspnet:6.0-bullseye-slim AS base
WORKSPACE /app

# Update packages

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN apt update

# Development Image Base on Debian 11 with .NET Software Development Kit Installed

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:6.0-bullseye-slim AS build
WORKSPACE /src

# Restore dependencies specified in the NuGet Package

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Compile and build the application

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY . .
WORKSPACE "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Publish the application

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Final Docker Image to Run the Application

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM base AS final
WORKSPACE /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```
```

```dockerfile
# Establish the base runtime environment (Debian 11 with ASP.NET Core Runtime)

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/aspnet:6.0-bullseye-slim AS base
WORKDIR /app

# Update and install necessary system packages

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN apt update

# Setup the base development environment (Debian 11 with .NET SDK)

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:6.0-bullseye-slim AS build
WORKDIR /src

# Retrieve and install NuGet dependencies

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Compile and build the project files

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Stage for publishing the built project

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Setup the final runtime image to deploy the application

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

### .NET 5 on Debian 11 Environment Setup

```dockerfile
# Base runtime image (Debian 11 with the ASP.NET Core Runtime)

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/aspnet:5.0-bullseye-slim AS base
WORKDIR /app

# Install necessary packages

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN apt update

# Base development image (Debian 11 with the .NET SDK)

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:5.0-bullseye-slim AS build
WORKDIR /src

# Restore NuGet packages

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Build project

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Publish project

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Final image to run the app

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

```dockerfile
# Setting up the foundational runtime environment with ASP.NET Core Runtime on Debian 11

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/aspnet:5.0-bullseye-slim AS base
WORKDIR /app

# Updating and installing essential packages

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN apt update

# Establishing the development environment using .NET SDK on Debian 11

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:5.0-bullseye-slim AS build
WORKDIR /src

# Retrieving NuGet packages necessary for the application

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Compiling the project files

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Staging the built application files for deployment

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Preparing the final deployable Docker image

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```
This version retains the original's structure and instructions while altering phrasing and syntax for a fresh presentation of the Docker configuration for deploying a .NET application on Debian 11 using Iron Software's tools.

### Debian 11 with Long-Term Support for .NET 3.1

```dockerfile
# Starting from the base runtime image (Debian 11 with ASP.NET Core Runtime)

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/aspnet:3.1-bullseye-slim AS base
WORKDIR /app

# Initial package installations

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN apt update

# Setting up the development image (Debian 11 with .NET SDK)

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:3.1-bullseye-slim AS build
WORKDIR /src

# Restoring NuGet packages for the project

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Building the project with .NET

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Publishing the project

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Final step to prepare the running image

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

Here's the paraphrased section updated with fully resolved URL paths:

```dockerfile
# Starting point image for runtime (Debian 11 with ASP.NET Core Runtime)

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/aspnet:3.1-bullseye-slim AS base
WORKDIR /app

# Package installation

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN apt update

# Development base image (Debian 11 with .NET SDK)

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:3.1-bullseye-slim AS build
WORKDIR /src

# Bringing in NuGet packages

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Compilation of the project

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Publishing the project

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Establishing the final image to execute the application

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

### Debian 10 with .NET 5 Environment Setup

```dockerfile
# Start with the base runtime image for Debian 10 along with the .NET runtime

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

# Update the system packages

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN apt update

# Transition to the development image for Debian 10 with the .NET SDK

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

# Restore the NuGet packages using the project file

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Continue by copying all relevant source files and building the project

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Move to the publish stage to finalize the preparation of application files

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Final runtime image to deploy application

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```
```

```dockerfile
# Establish the base runtime environment using Debian 10 and .NET 5.0

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

# Execute package updates

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN apt update

# Set up the development environment with the .NET 5.0 SDK on Debian 10

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

# Restore dependencies specified in Example project

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Build the Example project

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Create the publish image from build output

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Prepare the final runtime image

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

### Debian 10 using .NET 3.1 Long Term Support

```dockerfile
# Initial base runtime image setup for Debian 10 utilizing .NET runtime

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/runtime:3.1 AS base
WORKDIR /app

# Execute package installation updates

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN apt update

# Construct the development image beginning with Debian 10 and the .NET SDK

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src

# Begin restoring NuGet packages

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Progress to building the project

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Progress to the publishing phase

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Set up the final runtime image

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

```dockerfile
# Initial runtime environment (Debian 10 featuring the .NET runtime)

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/runtime:3.1 AS base
WORKDIR /app

# Execute package updates

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN apt update

# Establish the foundation development image (Debian 10 with .NET SDK)

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src

# Sync and restore the NuGet packages

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Compile the project

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Process for publishing the application

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Finalize the image to operate the application

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

### CentOS 7 with .NET 7 Setup

Here's how to configure a CentOS 7 Docker container for .NET 7:

1. **Base Image Preparation**: Start with CentOS 7 as the base environment.

   ```dockerfile
   # Use CentOS 7 image
   FROM centos:7 as base
   
   # Setup Microsoft's package repository and install .NET runtime
   RUN rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
   RUN yum install -y dotnet-runtime-7.0
   WORKDIR /app
   ```

2. **Development Environment Setup**: Prepare the development environment in another stage of build to keep the build environment separate from runtime.

   ```dockerfile
   # Prepare the SDK environment
   FROM centos:7 as build
   
   # Install the Microsoft SDK package
   RUN rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
   RUN yum install -y dotnet-sdk-7.0
   WORKDIR /src
   ```

3. **NuGet Package Restoration**: Ensure that the IronBarCode's NuGet package is ready to use within the project.

   ```dockerfile
   # Restore the NuGet packages
   COPY ["Example/Example.csproj", "Example/"]
   RUN dotnet restore "Example/Example.csproj"
   ```

4. **Application Building**: Proceed to compile and build the .NET project.

   ```dockerfile
   # Copy the entire source folder, build the project
   COPY . .
   WORKDIR "/src/Example"
   RUN dotnet build "Example.csproj" -c Release -o /app/build
   ```

5. **Publishing the Application**: Create the publish artifact ready for deployment on any server.

   ```dockerfile
   # Setup the publish stage
   FROM build AS publish
   RUN dotnet publish "Example.csproj" -c Release -o /app/publish
   ```

6. **Final Image Creation**: Setup the final Docker image by copying the published files to the base image.

   ```dockerfile
   # Prepare the final runnable image
   FROM base AS final
   WORKDIR /app
   COPY --from=publish /app/publish .
   ENTRYPOINT ["dotnet", "Example.dll"]
   ```

This configuration ensures that the application is running with the latest .NET 7 framework on a CentOS 7 base, leveraging Docker's capabilities for isolated and replicable environments.
```

Here is the paraphrased Dockerfile for setting up and deploying a .NET application on a CentOS 7 environment using the `Example` project:

```dockerfile
# Establish the foundational runtime environment using CentOS 7

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM centos:7 AS base

# Download and install necessary packages

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
RUN yum install -y dotnet-runtime-7.0
WORKDIR /app

# Create the software development kit environment on CentOS 7

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM centos:7 AS build

# Download and install the required SDK

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
RUN yum install -y dotnet-sdk-7.0

WORKDIR /src

# Retrieve NuGet packages for the Example project

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Compile the Example project

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Prepare the publish stage and deploy the application

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Set up the final runtime environment to host the application

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

This revised Dockerfile provides a step-by-step guide to building and deploying a .NET application in a CentOS 7 container, ensuring each step is defined for clarity and maintaining efficient application deployment workflows.

### CentOS 7 Configured with .NET 6 (Long-Term Support)

```dockerfile
# Begin by setting up the CentOS 7 base runtime environment

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM centos:7 AS base

# Install essential packages from Microsoft's repository

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
RUN yum install -y dotnet-runtime-6.0
WORKDIR /app

# Prepare the CentOS 7 SDK image

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM centos:7 AS build

# Incorporate necessary packages, ensuring SDK compatibility

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
RUN yum install -y dotnet-sdk-6.0

# Set the workspace directory to /src

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

WORKDIR /src

# Begin restoration of NuGet packages

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Proceed with project build

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Move forward to the publish phase

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Construct the final runnable image using the base settings

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# Define the entry point for the application

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

ENTRYPOINT ["dotnet", "Example.dll"]
```

```dockerfile
# Initial base image with CentOS 7

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM centos:7 AS base

# Install required Microsoft packages and .NET runtime

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
RUN yum install -y dotnet-runtime-6.0
WORKDIR /app

# Set up the build environment using the same base CentOS 7 image

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM centos:7 AS build

# Repeat installations for building the SDK

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
RUN yum install -y dotnet-sdk-6.0
WORKDIR /src

# Copy and restore NuGet package dependencies

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Copy all project files and build

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Publish the application from the build stage

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Create the final runtime image from the initial base

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

### CentOS 7 with .NET 3.1 Long Term Support (LTS)

```dockerfile
# Base operating system (CentOS 7)

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM centos:7 AS base

# Adding Microsoft repository and installing .NET runtime

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN yum install sudo -y
RUN sudo rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
RUN sudo yum install aspnetcore-runtime-3.1 -y

WORKDIR /app
EXPOSE 80
EXPOSE 443

# SDK environment for building the application (CentOS 7)

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM centos:7 AS build

# Setting up the development environment

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN yum install sudo -y
RUN sudo rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
RUN sudo yum install dotnet-sdk-3.1 -y

WORKDIR /src

# Handling project dependencies

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Compiling the application

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Preparing the release build

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# The final runnable container setup

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```
```

```dockerfile
# Set up the base image using CentOS 7

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM centos:7 AS base

# Install required packages

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN yum install sudo -y
RUN sudo rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
RUN sudo yum install aspnetcore-runtime-3.1 -y

# Set the working directory and expose necessary ports

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

WORKDIR /app
EXPOSE 80
EXPOSE 443

# Prepare the SDK image based on CentOS 7

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM centos:7 AS build

# Fetch and install essential packages

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

RUN yum install sudo -y
RUN sudo rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
RUN sudo yum install dotnet-sdk-3.1 -y

# Configure the source directory

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

WORKDIR /src

# Retrieve and install NuGet packages

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Compile the project

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Proceed to the publishing stage

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Establish the final runtime image

***Based on <https://ironsoftware.com/get-started/docker-linux/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```


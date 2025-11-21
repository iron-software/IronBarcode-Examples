# IronBarCode Advanced Installation Guide

***Based on <https://ironsoftware.com/get-started/advanced-installation-nuget/>***


IronBarCode is a versatile library designed to meet the diverse needs of various environments. To streamline our support for different platforms, we distribute our files in separate packages. This approach avoids the burden of excessive downloads for users, providing a more tailored installation experience based on your specific environment needs.

Rather than opting for the standard `IronBarCode` NuGet Package, you can explore specialized packages on NuGet. While the functionality and API remain consistent across packages, their development approaches may vary slightly.

This guide serves as a comparison and recommendation for choosing the most suitable `IronBarCode` version depending on your project requirements.

## BarCode NuGet Package

![](https://img.icons8.com/color/72/000000/windows-logo.png) ![](https://img.icons8.com/windows/72/000000/nuget.png) ![](https://img.icons8.com/color/72/000000/docker.png) ![](https://img.icons8.com/fluency/72/000000/azure-1.png) ![](https://img.icons8.com/color/72/000000/amazon-web-services.png) ![](https://img.icons8.com/color/72/000000/ubuntu--v1.png)

This is the most commonly utilized package and is optimized for quick setup in Visual Studio, making it ideal for a wide range of projects.

[**PM > Install-Package BarCode**](https://www.nuget.org/packages/BarCode)
- Includes `BarCode.Slim`
- Includes `BarCode.Detection`
- Contains `IronSoftware.ReaderInternals.Windows`, specific to Windows 

## BarCode.Slim NuGet Package

![](https://img.icons8.com/windows/72/000000/nuget.png)

Focused on a smaller footprint, this package excludes features like Machine Learning for barcode detection.

[**PM > Install-Package BarCode.Slim**](https://www.nuget.org/packages/BarCode.Slim)
- This package is a dependency for others.
- Includes the core `IronBarCode.dll`.
- Excludes platform-specific dependencies and `Barcode.Detection`.

Consider adding `Barcode.Detection` if dealing with inputs having significant digital noise.

## BarCode.Detection NuGet Package

![](https://img.icons8.com/windows/72/000000/nuget.png)

This advanced package leverages Machine Learning to enhance barcode detection accuracy, offering customizable parameters for developers.

[**PM > Install-Package BarCode.Detection**](https://www.nuget.org/packages/BarCode.Detection)
- Platform-agnostic support.
- Part of the base BarCode package.

## BarCode.Linux

![](https://img.icons8.com/color/72/000000/linux--v1.png) ![](https://img.icons8.com/color/72/000000/debian.png) ![](https://img.icons8.com/color/72/000000/ubuntu.png) ![](https://img.icons8.com/color/72/000000/centos.png) ![](https://img.icons8.com/windows/72/000000/nuget.png) ![](https://img.icons8.com/fluency/72/000000/azure-1.png) ![](https://img.icons8.com/color/72/000000/amazon-web-services.png) ![](https://img.icons8.com/color/72/000000/docker.png)

Excellently suits cloud and Linux-based operating systems, especially on platforms like AWS & Lambda, and Azure Functions. For Linux configurations, check this [guide](https://ironsoftware.com/csharp/barcode/get-started/linux/).

[**PM > Install-Package BarCode.Linux**](https://www.nuget.org/packages/BarCode.Linux)
- Includes `BarCode.Slim`
- Includes `BarCode.Detection`
- Contains `IronSoftware.ReaderInternals.Linux`, tailored for Linux

## BarCode.MacOs & BarCode.MacOs.ARM NuGet Packages

![](https://img.icons8.com/color/72/000000/mac-client.png) ![](https://img.icons8.com/windows/72/000000/nuget.png)

These packages specifically cater to macOS & macOS.ARM environments, perfect for integrating IronBarCode into macOS applications. For detailed setup, visit this [macOS guide](https://ironsoftware.com/csharp/barcode/get-started/macos/).

[**PM > Install-Package BarCode.MacOs**](https://www.nuget.org/packages/BarCode.MacOs)
[**PM > Install-Package BarCode.MacOs.ARM**](https://www.nuget.org/packages/BarCode.MacOs.ARM)
- Includes `BarCode.Slim`
- Includes `BarCode.Detection`
- Contains `IronSoftware.ReaderInternals.iOS` or `IronSoftware.ReaderInternals.MacOs.ARM`, macOS-specific dependencies

## BarCode.iOS NuGet Package

![](https://img.icons8.com/?size=72&id=20822&format=png&color=000000) ![](https://img.icons8.com/windows/72/000000/nuget.png)

Tailored for iOS mobile applications, this package facilitates easy integration of IronBarCode into iOS systems. For setup details, refer to this [iOS guide](https://ironsoftware.com/csharp/barcode/get-started/ios/).

[**PM > Install-Package BarCode.iOS**](https://www.nuget.org/packages/BarCode.iOS)
- Includes `BarCode.Slim`
- Contains `IronSoftware.ReaderInternals.iOS`, developed for iOS

## BarCode.Android NuGet Package

![](https://img.icons8.com/?size=72&id=P2AnGyiJxMpp&format=png&color=000000) ![](https://img.icons8.com/windows/72/000000/nuget.png)

Enhance your Android development with IronBarCode to create seamless barcode applications on Android. Check out this [Android guide](https://ironsoftware.com/csharp/barcode/get-started/android/) for setup information.

[**PM > Install-Package BarCode.Android**](https://www.nuget.org/packages/BarCode.Android)
- Contains `BarCode.Slim`
- Holds `IronSoftware.ReaderInternals.Android`, an Android-centric dependency
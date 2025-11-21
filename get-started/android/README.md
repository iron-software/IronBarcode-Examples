# How to Implement Barcode Reading and Writing on Android using .NET MAUI

***Based on <https://ironsoftware.com/get-started/android/>***


<div class="container-fluid">
    <div class="row">
        <div class="col-md-2">
            <img src="https://ironsoftware.com/img/platforms/h74/android.svg">
        </div>
    </div>
</div>

.NET MAUI (Multi-platform App UI), a modern successor to Xamarin.Forms, allows developers to design and deploy applications across Android, iOS, macOS, and Windows, all using .NET. This framework facilitates the development of native interfaces that are consistent across different platforms.

Incorporate barcode functionalities into your Android applications with the `BarCode.Android` package!

## IronBarcode Android Package Overview

The `BarCode.Android` package is specifically tailored to include barcode functionality on Android platforms within .NET multi-platform projects, making the general BarCode package unnecessary.

```shell
:InstallCmd Install-Package BarCode.Android
```

<link rel="stylesheet" type="text/css" href="https://ironsoftware.com/front/css/content__install-components__extended.css" media="print" onload="this.media='all'; this.onload=null;">
<div class="products-download-section">
    <div class="js-modal-open product-item nuget" style="width: fit-content; margin-left: auto; margin-right: auto;" data-modal-id="trial-license-after-download">
        <div class="product-image">
            <img class="img-responsive add-shadow" alt="C# NuGet Library for PDF" src="https://ironsoftware.com/img/nuget-logo.svg">
        </div>
        <div class="product-info">
            <h3>Install using <span>NuGet</span></h3>
        </div>
        <div class="js-open-modal-ignore copy-nuget-section" data-toggle="tooltip" data-placement="bottom" title="" data-original-title="Click to copy">
            <div class="copy-nuget-row">
            <pre class="install-script">Install-Package BarCode.Android</pre>
            <div class="copy-button">
                <button class="btn btn-default copy-nuget-script" type="button" data-toggle="popover" data-placement="bottom" data-content="Copied." aria-label="Copy the Package Manager command" data-original-title="" title="">
                <span class="far fa-copy"></span>
                </button>
            </div>
        </div>
    </div>
    <div class="nuget-link">nuget.org/packages/BarCode.Android/</div>
    </div>
</div>

## Starting a .NET MAUI Project

Launch Visual Studio and initiate a new project by clicking "Create a new project". Look up MAUI, choose the .NET MAUI App template, and proceed by clicking "Next".

## Integration of BarCode.Android Library

Adding this library into your project can be done through several methods. NuGet offers the simplest approach.

1. In Visual Studio, right-click "Dependencies" and select "Manage NuGet Packages ...".
2. Navigate to the "Browse" tab and look for "BarCode.Android".
3. Choose the "BarCode.Android" package and click on "Install".

To avoid any platform conflict, configure the .csproj to load this package only for Android-specific builds as follows:

1. Right-click the *.csproj file of your project and select "Edit Project File".
2. Add a new ItemGroup element with a conditional filter:

```xml
<ItemGroup Condition="$(TargetFramework.Contains('android')) == true">
    <PackageReference Include="BarCode.Android" Version="2025.3.4" />
</ItemGroup>
```

3. Relocate the "BarCode.Android" PackageReference into the newly established ItemGroup.

This setup restricts usage of the "BarCode.Android" package to Android platforms only. For iOS, consider integrating [BarCode.iOS](https://nuget.org/packages/BarCode.iOS/).

## Configuring the Android Bundle

Modify the ".csproj" file to define the bundle settings for Android:

```xml
<AndroidBundleConfigurationFile>BundleConfig.json</AndroidBundleConfigurationFile>
```

Establish a "BundleConfig.json" at the project's root, containing key configurations for your Android bundle:

```json
{
    "optimizations": {
        "uncompress_native_libraries": {}
    }
}
```

These settings ensure that native libraries are not compressed, optimizing their performance within the Android system.

## Application User Interface Design

Expand your XAML configuration to facilitate user interactions for generating and reading barcodes or QR codes. Here's an example setup:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="IronBarcodeMauiAndroid.MainPage">

    <VerticalStackLayout Padding="20">
        <HorizontalStackLayout>
            <CheckBox x:Name="generatePdfCheckBox" IsChecked="{Binding IsGeneratePdfChecked}" />
            <Label Text="PDF (unchecked for PNG)" VerticalOptions="Center"/>
        </HorizontalStackLayout>
        
        <Entry x:Name="barcodeInput" Placeholder="Enter barcode value..." />
        <Button Text="Generate and save barcode" Clicked="WriteBarcode" />

        <Entry x:Name="qrInput" Placeholder="Enter QR code value..." />
        <Button Text="Generate and save QR code" Clicked="WriteQRcode" />

        <Button
            Text="Read Barcode"
            Clicked="ReadBarcode"
            HorizontalOptions="Center"
            Margin="20, 20, 20, 10"/>
        <ScrollView
            BackgroundColor="LightGray"
            Padding="10"
            Margin="10, 10, 10, 30">
            <Label x:Name="OutputText"/>
        </ScrollView>
    </VerticalStackLayout>

</ContentPage>
```

## Barcode Operations

The functions above allow the user to dynamically switch between PDF and PNG output formats for barcodes and QR codes. Set your trial or full license key before generation begins.

The subsequent code demonstrates capturing input for barcode generation, creating the barcode, and saving the output file. For iOS compatibility, ensure the file path customization allows access to the `Files` app.
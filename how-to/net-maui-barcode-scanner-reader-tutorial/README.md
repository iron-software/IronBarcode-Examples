# .NET MAUI Barcode Scanner

## Introduction

[.NET MAUI](https://learn.microsoft.com/en-us/dotnet/maui/what-is-maui) (.NET Multi-platform App UI) offers a unified approach for developers to build applications that run across multiple platforms like Microsoft Windows, iOS, and Android using a single shared codebase. This framework distinguishes itself by enabling developers to utilize native controls and augment them with additional components. This integration significantly reduces development time by allowing the use of pre-built elements and services without having to code everything from the ground up.

In this guide, we will discuss how to implement QR code and barcode scanning capabilities within a .NET MAUI Windows application.

## IronBarcode: C# Barcode Library

IronBarcode is a powerful .NET library designed for simplicity and efficiency in barcode management within apps. It offers a comprehensive API that manages the generation and reading of QR codes and other barcode types, making it possible to manipulate barcode data one element at a time. This library operates independently without the need for external dependencies and is easily accessible via NuGet Package Manager for installation.

Supporting a wide array of barcode formats including Code 39, Code 128, PDF417, and others, IronBarcode works not only as a barcode generator but also as a robust QR code scanner. It decodes data from various sources, such as images and streams, into readable formats. This article provides a step-by-step process on utilizing IronBarcode in .NET MAUI applications for barcode scanning.

## Steps to Read and Scan Barcode in .NET MAUI App

### Prerequisites

1. Visual Studio 2022
2. An existing .NET MAUI project open in Visual Studio
3. Reliable internet connection for installing the IronBarcode library via NuGet

Once these prerequisites are met, proceed to the next steps.

### Install IronBarcode Library

To install the IronBarcode library, use the following command in the NuGet Packages Console:

```shell
Install-Package BarCode
```

This command fetches the latest version of IronBarcode for your project. Always confirm the latest version available on the [NuGet website](https://www.nuget.org/packages/BarCode/).

### Frontend

Begin by creating the user interface:

The user interface consists of two buttons, a text area, and an image box. One button will be for selecting a barcode, and the other for copying barcode text. The image box will display the selected barcode image.

Update the *MainPage.xaml* with the following layout:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="MAUI_Barcode.MainPage">

    <ScrollView>
        <VerticalStackLayout
            Spacing="25"
            Padding="30,0"
            VerticalOptions="Center">

            <Button
                x:Name="ImageSelect"
                Text="Select Barcode"
                SemanticProperties.Hint="Select Image"
                Clicked="SelectBarcode"
                HorizontalOptions="Center" />
            <Image
                x:Name="barcodeImage"
                SemanticProperties.Description="Selected Barcode"
                HeightRequest="200"
                HorizontalOptions="Center" />
            <Editor x:Name="outputText"
                Placeholder="Output text"
                HeightRequest="100"
                WidthRequest="500" />
            <Button
                x:Name="copyText"
                Text="Copy"
                SemanticProperties.Hint="Copy Text"
                WidthRequest="150"
                Clicked="CopyEditorText"
                HorizontalOptions="Center" />

        </VerticalStackLayout>
    </ScrollView>

</ContentPage>
```

### Barcode Scanning using IronBarcode

The following code snippet outlines the process for selecting and scanning a barcode:

```cs
private async void SelectBarcode(object sender, EventArgs e)
{
    var images = await FilePicker.Default.PickAsync(new PickOptions
    {
    PickerTitle = "Pick image",
    FileTypes = FilePickerFileType.Images
    });
    var imageSource = images.FullPath.ToString();
    barcodeImage.Source = imageSource;
    var result = BarcodeReader.Read(imageSource).First().Text;
    outputText.Text = result;
}
```

To copy the scanned barcode text and notify the user:

```cs
private async void CopyEditorText (object sender, EventArgs e)
{
    await Clipboard.SetTextAsync(outputText.Text);
    await DisplayAlert("Success", "Text is copied!", "OK");
}
```

Explore the complete project on [GitHub](https://github.com/tayyab-create/Read-and-Scan-Barcode-in-MAUI).

### Output

Initial state when no barcode is selected yet:

![.NET MAUI Barcode Scanner Tutorial Using IronBarcode - Figure 1: Output when no image is selected](https://ironsoftware.com/static-assets/barcode/how-to/net-maui-barcode-scanner-reader-tutorial/net-maui-barcode-scanner-reader-tutorial-1.webp)

Output upon selecting a barcode:

![.NET MAUI Barcode Scanner Tutorial Using IronBarcode - Figure 2: Output after image is selected](https://ironsoftware.com/static-assets/barcode/how-to/net-maui-barcode-scanner-reader-tutorial/net-maui-barcode-scanner-reader-tutorial-2.webp)

Copying text confirmation:

![.NET MAUI Barcode Scanner Tutorial Using IronBarcode - Figure 3: Copy alert](https://ironsoftware.com/static-assets/barcode/how-to/net-maui-barcode-scanner-reader-tutorial/net-maui-barcode-scanner-reader-tutorial-3.webp)

## Conclusion

This article has detailed the process of integrating barcode scanning functionality in a .NET MAUI application using the IronBarcode library. IronBarcode proves to be a highly capable and versatile tool for managing barcodes, offering detailed control and customization options. For educational purposes, IronBarcode is free, but commercial applications require a paid license. Learn more about licensing [here](https://ironsoftware.com/csharp/barcode/licensing/).
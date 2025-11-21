# .NET MAUI Barcode Scanner

***Based on <https://ironsoftware.com/get-started/net-maui-barcode-scanner-reader-tutorial/>***


## Introduction

[.NET MAUI](https://learn.microsoft.com/en-us/dotnet/maui/what-is-maui), or .NET Multi-platform App UI, revolutionizes the development of unified applications across multiple platforms, allowing the creation of apps for Microsoft Windows, iOS, and Android within a singular project framework. This platform distinguishes itself by utilizing native controls and offering additional components to enhance developer productivity, thus accelerating app development without needing to code every element from the ground up.

In this guide, we will cover the integration of IronBarcode into a .NET MAUI Windows application for efficient barcode and QR code scanning.

## IronBarcode: C# Barcode Library

IronBarcode, a .NET library, is utilized for reading barcodes within our application. It offers a straightforward and effective API that simplifies the development process without requiring in-depth knowledge of barcode systems. Installation is manageable via the NuGet package manager.

IronBarcode efficiently reads various barcode formats, including _Code 39_, _Code 128_, _PDF417_, and others. It handles data from multiple sources, such as image files, memory streams, and PDF documents.

## Steps to Read Barcodes in a .NET MAUI App

Below are the steps to implement barcode reading in your .NET MAUI app.

### Prerequisites

1. Visual Studio 2022
2. A project setup for .NET MAUI in Visual Studio

### Installation of IronBarcode

The IronBarcode library can be added to your project using the Visual Studio `Package Manager Console`. Access this console via `Tools > NuGet Package Manager > Package Manager Console` and enter the following command:

```shell
Install-Package BarCode
```

This command will integrate the latest version of IronBarcode into your MAUI project. Alternatively, search for it directly on the [NuGet website](https://www.nuget.org/packages/BarCode/).

### Creating the User Interface

You should start by crafting the user interface. Here's what you'll need: two buttons, a text area, and an image box — one button for selecting the barcode image and the other for copying the barcode text to clipboard. The image box will display the chosen image.

Update your *MainPage.xaml* with the following code:

```xml
<?xml version="1.0" encoding="utf-8"?>
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
            <Editor
                x:Name="outputText"
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

Layout elements are vertically stacked for a centered design, which you can adjust as needed.

### Implementing Barcode Scanning

For barcode scanning, first, a `FilePicker` will be used to select an image:

```cs
private async void SelectBarcode(object sender, EventArgs e)
{
    // Enables the user to select an image file via FilePicker.
    var images = await FilePicker.Default.PickAsync(new PickOptions
    {
        PickerTitle = "Pick image",
        FileTypes = FilePickerFileType.Images
    });

    // Retrieves and converts the full file path of the selected image.
    var imageSource = images.FullPath.ToString();

    // Sets the image view source to the selected file path.
    barcodeImage.Source = imageSource;

    // Decodes the barcode using IronBarcode and extracts the scan result.
    var result = BarcodeReader.Read(imageSource).First().Text;

    // Displays the decoded text in the output field.
    outputText.Text = result;
}
```

Additionally, here's how to handle text copying from the output:

```cs
private async void CopyEditorText(object sender, EventArgs e)
{
    // Copies the displayed text from the output to the clipboard.
    await Clipboard.SetTextAsync(outputText.Text);

    // Notifies the user of successful text copying.
    await DisplayAlert("Success", "Text is copied!", "OK");
}
```

The source code for this project is available on [GitHub](https://github.com/tayyab-create/Read-and-Scan-Barcode-in-MAUI).

### Outputs

Initially, the application will display no image because none has been selected:

![.NET MAUI Barcode Scanner Tutorial Using IronBarcode - Figure 1: Output when no image is selected](https://ironsoftware.com/static-assets/barcode/how-to/net-maui-barcode-scanner-reader-tutorial/net-maui-barcode-scanner-reader-tutorial-1.webp)

Once a barcode is selected, the decoded text will appear, displayed like this:

![.NET MAUI Barcode Scanner Tutorial Using IronBarcode - Figure 2: Output after image is selected](https://ironsoftware.com/static-assets/barcode/how-to/net-maui-barcode-scanner-reader-tutorial/net-maui-barcode-scanner-reader-tutorial-2.webp)

Clicking the 'Copy' button will trigger a notification:

![.NET MAUI Barcode Scanner Tutorial Using IronBarcode - Figure 3: Copy alert](https://ironsoftware.com/static-assets/barcode/how-to/net-maui-barcode-scanner-reader-tutorial/net-maui-barcode-scanner-reader-tutorial-3.webp)

## Conclusion

This tutorial illustrated the process of implementing barcode scanning in a .NET MAUI application using IronBarcode. Known for its reliability in reading even complex barcodes, IronBarcode also offers customizable options for creating new barcodes with different fonts and styles. For more detailed tutorials on IronBarcode, visit this [page](https://ironsoftware.com/csharp/barcode/tutorials/reading-barcodes/).

Note, IronBarcode requires suitable licensing for both development and commercial deployment. For more details, refer to the licensing [here](https://ironsoftware.com/csharp/barcode/licensing/).
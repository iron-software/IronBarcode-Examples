# .NET MAUI Barcode Scanner

***Based on <https://ironsoftware.com/how-to/net-maui-barcode-scanner-reader-tutorial/>***


## Introduction

[.NET MAUI](https://learn.microsoft.com/en-us/dotnet/maui/what-is-maui) (short for .NET Multi-platform App UI) is a versatile framework designed for developing cross-platform applications using a unified codebase. It enables developers to build apps for Microsoft Windows, iOS, and Android within the same project. What distinguishes .NET MAUI from other frameworks is its integration of native controls and additional components, which greatly accelerate development by reducing the need to code everything from scratch.

This guide will demonstrate how to integrate barcode and QR code scanning functionality into a .NET MAUI application running on Windows.

## IronBarcode: The C# Barcode Library

IronBarcode simplifies the task of generating and reading barcodes in .NET applications. This library offers a powerful yet easy-to-use API that lets developers work with QR codes and other barcode formats at an object level. This means you can handle barcode operations method-by-method without detailed knowledge of barcode technologies, and no external dependencies are required thanks to its standalone nature. IronBarcode can be effortlessly incorporated into projects via NuGet.

Supported barcode types include QR codes, Code 39, Code 128, and PDF417, among others. Beyond generation, IronBarcode also excels as a barcode reader, translating images, streams, GIFs, and more into human-readable text. The next sections will cover the practical use of IronBarcode for reading QR codes in .NET MAUI applications.

## Steps to Incorporate Barcode Scanning in .NET MAUI Apps

### Prerequisites

- Visual Studio 2022.
- A functional .NET MAUI project setup in Visual Studio.
- An active internet connection to install the IronBarcode package.

Once the prerequisites are met, proceed as follows:

### Install the IronBarcode Library

IronBarcode can be installed directly from the NuGet Package Manager Console with the following command:

```shell
Install-Package BarCode
```

This command retrieves the latest version of IronBarcode for your project. To explore more versions, visit the [NuGet website](https://www.nuget.org/packages/BarCode/).

### Building the Frontend

Start by crafting the front-end interface.

Replace the content within the `MainPage.xaml` file with this markup:

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

This layout includes buttons for image selection and text copying, an image display area, and a text editor.

### Scanning Barcodes with IronBarcode

The following code snippet demonstrates selecting and scanning a barcode image:

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

And here's how to copy the scanned text and notify the user:

```cs
private async void CopyEditorText (object sender, EventArgs e)
{
    await Clipboard.SetTextAsync(outputText.Text);
    await DisplayAlert("Success", "Text is copied!", "OK");
}
```

This project can be found on [GitHub](https://github.com/tayyab-create/Read-and-Scan-Barcode-in-MAUI).

### Results Display

Upon execution, you'll initially see this display:
![No image selected](https://ironsoftware.com/static-assets/barcode/how-to/net-maui-barcode-scanner-reader-tutorial/net-maui-barcode-scanner-reader-tutorial-1.webp)

After selecting a barcode:
![Barcode image displayed](https://ironsoftware.com/static-assets/barcode/how-to/net-maui-barcode-scanner-reader-tutorial/net-maui-barcode-scanner-reader-tutorial-2.webp)

And the confirmation after text copying:
![Copy confirmation dialog](https://ironsoftware.com/static-assets/barcode/how-to/net-maui-barcode-scanner-reader-tutorial/net-maui-barcode-scanner-reader-tutorial-3.webp)

## Conclusion

This tutorial outlined the procedure for barcode reading within .NET MAUI applications using the IronBarcode library, a comprehensive tool for handling various barcode operations efficiently. For non-commercial development, IronBarcode is freely accessible. However, a commercial license is required for business applications and can be reviewed [here](https://ironsoftware.com/csharp/barcode/licensing/). For further guidance, check out more IronBarcode tutorials [here](https://ironsoftware.com/csharp/barcode/tutorials/reading-barcodes/).
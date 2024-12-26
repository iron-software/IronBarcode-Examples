# .NET MAUI Barcode Scanner

***Based on <https://ironsoftware.com/how-to/net-maui-barcode-scanner-reader-tutorial/>***


## Introduction

[.NET MAUI](https://learn.microsoft.com/en-us/dotnet/maui/what-is-maui), short for .NET Multi-platform App UI, represents a unified framework designed to support the creation of cross-platform applications utilizing a single codebase. It enables developers to construct applications for Microsoft Windows, iOS, and Android within a single project. One distinct advantage of .NET MAUI is its integration with native controls and supplemental components, allowing developers to more rapidly develop applications with pre-built elements, significantly reducing the need to program everything from the ground up.

In this tutorial, we explore how to implement QR code and barcode scanning within a .NET MAUI Windows application.

## IronBarcode: C# Barcode Library

IronBarcode stands as a prominent .NET library for managing barcodes. It simplifies the process of barcode generation and reading through a set of straightforward, default APIs. Users can create and decipher QR codes and other barcode formats through object-oriented methods, streamlining the development process without the need for deep understanding of barcode mechanics or reliance on external dependencies. Installation is straightforward via the NuGet Package Manager.

IronBarcode supports diverse barcode formats including QR, Code 39, Code 128, and PDF417 among others. The library allows for reading and generating QR codes directly, interpreting the data embedded within barcodes into text readable by humans. Inputs can be processed from images, streams, GIFs, and more. This guide will further detail utilizing IronBarcode in .NET MAUI applications.

## Steps to Read and Scan Barcodes in a .NET MAUI App

Proceed through the following steps to begin QR code reading in your .NET MAUI application.

### Prerequisites

- Visual Studio 2022
- An active .NET MAUI project in Visual Studio
- Reliable internet connection to download the IronBarcode library

Once these requirements are met, you’re ready to proceed to the next step.

### Installing IronBarcode Library

Install IronBarcode from the NuGet Packages Console with this command:

```shell
Install-Package BarCode
```

Use this command to fetch the latest version of IronBarcode for your MAUI project. For the most recent updates, refer to the IronBarcode [NuGet package page](https://www.nuget.org/packages/BarCode/).

### Frontend Design

First, we need to design the front end. Construct a layout consisting of two buttons, one text area, and one image display area. One button will function to select the barcode image, and the other will copy the barcode text to the clipboard. Display the chosen image in the image box. Modify the *MainPage.xaml* file with the following content:

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

Feel free to adjust the layout to better fit your application’s design needs.

### Barcode Scanning with IronBarcode

This segment covers the barcode scanning process using IronBarcode. Utilize a `FilePicker` for selecting image files, then retrieve and set the image path in the image box. Finally, use the `Read` function from `BarcodeReader` to extract the text from the barcode:

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

Use the following code to copy text from the text editor to the clipboard and inform the user with a confirmation alert:

```cs
private async void CopyEditorText (object sender, EventArgs e)
{
    await Clipboard.SetTextAsync(outputText.Text);
    await DisplayAlert("Success", "Text has been copied!", "OK");
}
```

Access the project on GitHub for more information on reading and scanning barcodes with .NET MAUI. 

### Screenshots and Output

Before a barcode is selected, the application will display as follows:

![.NET MAUI Barcode Scanner Tutorial Using IronBarcode - Figure 1: Output when no image is selected](https://ironsoftware.com/static-assets/barcode/how-to/net-maui-barcode-scanner-reader-tutorial/net-maui-barcode-scanner-reader-tutorial-1.webp)

Upon selecting a barcode, the application will show the image and the decoded text like this:

![.NET MAUI Barcode Scanner Tutorial Using IronBarcode - Figure 2: Output after image is selected](https://ironsoftware.com/static-assets/barcode/how-to/net-maui-barcode-scanner-reader-tutorial/net-maui-barcode-scanner-reader-tutorial-2.webp)

When the 'Copy' button is pressed, a notification will confirm the action:

![.NET MAUI Barcode Scanner Tutorial Using IronBarcode - Figure 3: Copy alert](https://ironsoftware.com/static-assets/barcode/how-to/net-maui-barcode-scanner-reader-tutorial/net-maui-barcode-scanner-reader-tutorial-3.webp)

## Conclusion

This guide illustrates the seamless integration and functionality of the IronBarcode in a .NET MAUI application for efficient barcode reading and generation. IronBarcode excels in decoding complex barcodes to actual text, ensuring the output accuracy expected by users. For more comprehensive insights and tutorials on using IronBarcode, follow this [tutorial series on reading barcodes](https://ironsoftware.com/csharp/barcode/tutorials/reading-barcodes/).

While IronBarcode is free for development, a commercial license is necessary for production use. Learn more about licensing options [here](https://ironsoftware.com/csharp/barcode/licensing/).
# Creating Barcode Images in C&num;

This guide explores the process of generating barcodes in C# .NET using the Iron Barcode library.

We'll cover the steps required to produce and style a barcode in either C# or VB.NET, and demonstrate how to output the barcode as an image.

## Installation

To begin, you’ll need to integrate the Iron Barcode library, which enhances your .NET applications with barcode capabilities. You can install it using the NuGet package manager or by downloading the .NET Barcode DLL.

```shell
Install-Package BarCode
```

<div class="article-img tutorial-img">
	<img src="https://ironsoftware.com/img/tutorials/csharp-barcode-image-generator/banner.jpg" alt="Effortlessly generating barcodes and QR codes in .NET with Iron Barcode, a robust C# library" class="img-responsive">
</div>

## Simple Barcode Rendering

Here, we demonstrate how straightforward it is to create a barcode populated with either numerical or text data using a few lines of code with Iron Barcode.

```cs
using IronBarCode;

// Create and save a simple barcode image as PNG
GeneratedBarcode simpleBarcode = IronBarCode.BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode", BarcodeWriterEncoding.Code128);
simpleBarcode.SaveAsPng("simpleBarcode.png");

// Open the image in the default viewer
System.Diagnostics.Process.Start("simpleBarcode.png");
```

First, we initiate the barcode creation by setting its value and choosing a format from the `IronBarCode.BarcodeWriterEncoding` enumeration. We then proceed to save it as an image file.

<center>
<img src="https://ironsoftware.com/img/tutorials/csharp-barcode-image-generator/render-a-simple-barcode.png" alt="Example of creating a barcode image in C#" class="img-responsive add-shadow img-margin" style="max-width:50%" >
</center>

The final piece of the example code launches the saved barcode image, allowing you to view the output.

## Advanced Barcode Customization

Moving beyond basics, we might need additional customization in real-world applications.

In the next example, we demonstrate how to add text annotations, adjust the font, display a value below the barcode, customize margins and barcode color, and save the output.

We can choose to output in different formats like HTML or PDF instead of an image file.

```cs
using IronBarCode;
using IronSoftware.Drawing;

// Enhance a QR code by adding annotations and changing styles
GeneratedBarcode styledBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode", BarcodeWriterEncoding.QRCode);
styledBarcode.AddAnnotationTextAboveBarcode("Product URL:");
styledBarcode.AddBarcodeValueTextBelowBarcode();
styledBarcode.SetMargins(100);
styledBarcode.ChangeBarCodeColor(Color.Purple);

// Save as HTML
styledBarcode.SaveAsHtmlFile("StyledBarcode.html");
```

<center>
<img src="https://ironsoftware.com/img/tutorials/csharp-barcode-image-generator/advanced-barcode-creation.png" alt="Enhanced barcode creation in C# with annotations and styled elements" class="img-responsive add-shadow img-margin" style="max-width:33%" >
</center>

For in-depth details, the `[GeneratedBarcode](https://ironsoftware.com/csharp/barcode/object-reference/api/IronBarCode.GeneratedBarcode.html)` class documentation in the [API Reference](https://ironsoftware.com/csharp/barcode/object-reference/) is highly recommended.

## Efficient Barcode Generation

Our final example showcases Iron Barcode's fluent API, which follows a method chaining pattern similar to System.Linq, allowing you to configure and export a barcode in a seamless, single line of code.

```cs
using IronBarCode;
using IronSoftware.Drawing;

// Using fluent API for efficient barcode generation
string value = "https://ironsoftware.com/csharp/barcode";
Bitmap barcodeBitmap = BarcodeWriter.CreateBarcode(value, BarcodeEncoding.PDF417).ResizeTo(300, 200).SetMargins(100).ToBitmap();
```

This results in a `System.Drawing.Bitmap` of a PDF417 barcode.

<center>
<img src="https://ironsoftware.com/img/tutorials/csharp-barcode-image-generator/fluent-generated-barcode.png" alt="Efficient barcode generation using Iron BarCode's Fluent API in C#" class="img-responsive add-shadow img-margin" style="max-width:40%" >
</center>

## Additional Resources

For further exploration of this topic and other features like [reading barcodes from images in C#](https://ironsoftware.com/csharp/barcode/use-case/read-barcode-image-csharp/), check out various resources available on GitHub and Iron Software's website.

### C&num; Source Code

Access the complete C# source code for this "Barcode Image Generation" tutorial on GitHub or download it as a project for Visual Studio 2017:

- [GitHub Repository](https://github.com/iron-software/Iron-Barcode-CSharp-Barcode-Image-Generator-Tutorial)
- [Download Source Code](https://ironsoftware.com/downloads/assets/tutorials/csharp-barcode-image-generator/Iron-Barcode-CSharp-Barcode-Image-Generator-Tutorial.zip)

### Further Reading

You may also find the `BarcodeReader` class in the [API Reference](https://ironsoftware.com/csharp/barcode/object-reference/api/IronBarCode.BarcodeWriter.html) helpful. This section provides insights into using the library as a [C# Barcode Scanner](https://ironsoftware.com/csharp/barcode/use-case/barcode-scanner-csharp/).

Additional tutorials on QR codes and barcode reading with .NET are also available to expand your knowledge.
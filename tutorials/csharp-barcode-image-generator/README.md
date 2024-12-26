# Generate Barcode Images in C&#35;

***Based on <https://ironsoftware.com/tutorials/csharp-barcode-image-generator/>***


This guide will teach you how to create a barcode using the C# .NET framework with the help of Iron Barcode.

Explore the process of generating a barcode in either C# or VB.NET, learn how to style it, and discover how to save it as an image.

### Start with IronBarcode



---



<br>

## Setup

The initial step is to install the Iron Barcode library to extend the .NET framework with barcode capabilities. This can be achieved through our [NuGet package](https://www.nuget.org/packages/BarCode/) or by obtaining the [.NET Barcode DLL](https://ironsoftware.com/csharp/barcode/packages/IronBarCode.zip).

```shell
Install-Package BarCode
```

<div class="article-img tutorial-img">
	<img src="https://ironsoftware.com/img/tutorials/csharp-barcode-image-generator/banner.jpg" alt="Creating Barcodes and QR in .NET can be difficult operation without a reliable C# Library for Barcodes.  Here comes Iron Barcode" class="img-responsive">
</div>

## Simple Barcode Rendering

Below, we demonstrate how a barcode with either numerical or textual content can be generated effortlessly using Iron Barcode.

```cs
using IronBarCode;

// Generating a Simple BarCode image and saving it as PNG
GeneratedBarcode myBarcode = IronBarCode.BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode", BarcodeWriterEncoding.Code128);
myBarcode.SaveAsPng("myBarcode.png");

// This line will pop open the image using your default image viewer
System.Diagnostics.Process.Start("myBarcode.png");
```

We begin by defining the content and format for the barcode, using the `IronBarCode.BarcodeWriterEncoding` enum. Next, we decide whether to save it as an image file or use a `System.Drawing.Image` or `Bitmap` object. That's all there is to the coding part!

<center>
<img src="https://ironsoftware.com/img/tutorials/csharp-barcode-image-generator/render-a-simple-barcode.png" alt="Create a barcode image in C# example"  class="img-responsive add-shadow img-margin" style="max-width:50%"  >
</center>

The last code line simply opens the generated barcode image so that it can be viewed directly.

## Advanced Barcode Generation

Even though the initial example should serve most basic needs, real-world applications often require enhanced features.

In the example below, we demonstrate how to annotate a barcode, adjust the font, display its value, modify margins and barcode color, then save the result.

Additionally, you might opt to output HTML or PDF instead of an image, depending on your application needs.

```cs
using IronBarCode;
using IronSoftware.Drawing;

// Styling a QR code and adding annotation text
GeneratedBarcode myBarCode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode", BarcodeWriterEncoding.QRCode);
myBarCode.AddAnnotationTextAboveBarcode("Product URL:");
myBarCode.AddBarcodeValueTextBelowBarcode();
myBarCode.SetMargins(100);
myBarCode.ChangeBarCodeColor(Color.Purple);

// Save as HTML
myBarCode.SaveAsHtmlFile("MyBarCode.html");
```

<center>
<img src="https://ironsoftware.com/img/tutorials/csharp-barcode-image-generator/advanced-barcode-creation.png" alt="Use C# to create an annotated and styled barcode image "  class="img-responsive add-shadow img-margin" style="max-width:33%"  >
</center>

This code is quite straightforward, but for any clarification, you may refer to the `[GeneratedBarcode](https://ironsoftware.com/csharp/barcode/object-reference/api/IronBarCode.GeneratedBarcode.html)` class documentation within our [API Reference](https://ironsoftware.com/csharp/barcode/object-reference/).

## Barcode Generation Fluency

In our concluding example, observe how a barcode can be created, styled, and exported as a Bitmap all in a single, fluent line of code.

Iron Barcode provides a Fluent API that resembles `System.Linq`, allowing multiple method calls to be chained together elegantly.

```cs
using IronBarCode;
using IronSoftware.Drawing;

// Fluent API for Barcode Image generation.
string value = "https://ironsoftware.com/csharp/barcode";
AnyBitmap barcodeBitmap = BarcodeWriter.CreateBarcode(value, BarcodeEncoding.PDF417).ResizeTo(300, 200).SetMargins(100).ToBitmap();
System.Drawing.Bitmap barcodeLegacyBitmap = (System.Drawing.Bitmap)barcodeBitmap;
```

This results in a `System.Drawing.Image` of a PDF417 barcode as shown below:

<center>
<img src="https://ironsoftware.com/img/tutorials/csharp-barcode-image-generator/fluent-generated-barcode.png" alt="Simple, Fluent barcode generation in C# using Iron BarCode"  class="img-responsive add-shadow img-margin" style="max-width:40%"  >
</center>

## More Resources

To further understand this tutorial and learn how to [read images from barcodes in C#](https://ironsoftware.com/csharp/barcode/use-case/read-barcode-image-csharp/), consider checking it out on GitHub, downloading it as a *Visual Studio Project*, or exploring other examples, including our guide on QR code creation.

### C&#35; Source Code Access

The source code for this "Barcode Image Generation" tutorial is available as a Visual Studio 2017 project:

* [Github Repository](https://github.com/iron-software/Iron-Barcode-CSharp-Barcode-Image-Generator-Tutorial)
* [C# Source Code Zip](https://ironsoftware.com/downloads/assets/tutorials/csharp-barcode-image-generator/Iron-Barcode-CSharp-Barcode-Image-Generator-Tutorial.zip)

### Additional Documentation

The [BarcodeReader](https://ironsoftware.com/csharp/barcode/object-reference/api/IronBarCode.BarcodeWriter.html) classes, featured in our API Reference, are highly informative. Explore how to use Iron Barcode as a [C# Barcode Scanner](https://ironsoftware.com/csharp/barcode/use-case/barcode-scanner-csharp/) and delve into additional tutorials covering QR codes and Barcode Image Reading with .NET.
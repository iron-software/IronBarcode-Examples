# Generating Barcode Images in C#

***Based on <https://ironsoftware.com/tutorials/csharp-barcode-image-generator/>***


This guide demonstrates how to create barcodes using C# .NET, utilizing the powerful Iron Barcode library.

We'll learn how quick and straightforward it is to generate barcodes in either C# or VB.NET, customize their appearance, and export them as images.

## Installation Steps

To begin, let's install the Iron Barcode library, which extends the .NET framework with barcode functionalities. Installation can be handled via the Iron Software's [NuGet package](https://www.nuget.org/packages/BarCode/) or by downloading the [.NET Barcode DLL](https://ironsoftware.com/csharp/barcode/packages/IronBarCode.zip).

```shell
Install-Package BarCode
```

<div class="article-img tutorial-img">
	<img src="https://ironsoftware.com/img/tutorials/csharp-barcode-image-generator/banner.jpg" alt="Creating Barcodes and QR in .NET can be difficult operation without a reliable C# Library for Barcodes. Here comes Iron Barcode" class="img-responsive">
</div>

## Basic Barcode Rendering

The following snippet illustrates how a barcode can be generated using just a few lines of code with Iron Barcode.

```cs
using IronBarCode;
using BarCode;
namespace ironbarcode.CsharpBarcodeImageGenerator
{
    public class Section1
    {
        public void Run()
        {
            // Create a simple barcode image and save as PNG
            GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode", BarcodeWriterEncoding.Code128);
            myBarcode.SaveAsPng("myBarcode.png");
            
            // This command will open the image in your default viewer
            System.Diagnostics.Process.Start("myBarcode.png");
        }
    }
}
```

We start by specifying the barcode's content and choosing a format from the `IronBarCode.BarcodeWriterEncoding` enum. We then save it as an image file, as simple as that!

<center>
<img src="https://ironsoftware.com/img/tutorials/csharp-barcode-image-generator/render-a-simple-barcode.png" alt="Create a barcode image in C# example" class="img-responsive add-shadow img-margin" style="max-width:50%"  >
</center>

The final line in the above snippet displays the generated barcode image.

## Advanced Barcode Creation

Moving beyond simple examples, we can enhance our barcodes with custom annotations, colors, and more, as shown below:

```cs
using IronSoftware.Drawing;
using BarCode;
namespace ironbarcode.CsharpBarcodeImageGenerator
{
    public class Section2
    {
        public void Run()
        {
            // Customize a QR code with annotations and color adjustments
            GeneratedBarcode myBarCode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode", BarcodeWriterEncoding.QRCode);
            myBarCode.AddAnnotationTextAboveBarcode("Product URL:");
            myBarCode.AddBarcodeValueTextBelowBarcode();
            myBarCode.SetMargins(100);
            myBarCode.ChangeBarCodeColor(Color.Purple);
            
            // Export the stylized barcode as HTML
            myBarCode.SaveAsHtmlFile("MyBarCode.html");
        }
    }
}
```

<center>
<img src="https://ironsoftware.com/img/tutorials/csharp-barcode-image-generator/advanced-barcode-creation.png" alt="Use C# to create an annotated and styled barcode image "  class="img-responsive add-shadow img-margin" style="max-width:33%"  >
</center>

For comprehensive details on enhanced functions, see the [`GeneratedBarcode`](https://ironsoftware.com/csharp/barcode/object-reference/api/IronBarCode.GeneratedBarcode.html) class in the [API Reference](https://ironsoftware.com/csharp/barcode/object-reference/).

## One-Line Barcode Generation with Fluent API

Lastly, utilizing a Fluent API approach, we can create and customize a barcode in just one line:

```cs
using IronSoftware.Drawing;
using BarCode;
namespace ironbarcode.CsharpBarcodeImageGenerator
{
    public class Section3
    {
        public void Run()
        {
            // Use Fluent API to generate and style a barcode image.
            string value = "https://ironsoftware.com/csharp/barcode";
            AnyBitmap barcodeBitmap = BarcodeWriter.CreateBarcode(value, BarcodeEncoding.PDF417).ResizeTo(300, 200).SetMargins(100).ToBitmap();
            System.Drawing.Bitmap barcodeLegacyBitmap = (System.Drawing.Bitmap)barcodeBitmap;
        }
    }
}
```

The example produces an image of a PDF417 barcode styled succinctly in one line.

<center>
<img src="https://ironsoftware.com/img/tutorials/csharp-barcode-image-generator/fluent-generated-barcode.png" alt="Simple, Fluent barcode generation in C# using Iron BarCode"  class="img-responsive add-shadow img-margin" style="max-width:40%"  >
</center>

## Learn More

To delve deeper into this code sample and explore how to [read barcode images in C#](https://ironsoftware.com/csharp/barcode/use-case/read-barcode-image-csharp/), consider checking the project on GitHub or downloading it as a Visual Studio Project.

### Source Code Availability

Access the source for this tutorial from the following locations:

* [GitHub Repository](https://github.com/iron-software/Iron-Barcode-CSharp-Barcode-Image-Generator-Tutorial)
* [C# Source Code Download](https://ironsoftware.com/downloads/assets/tutorials/csharp-barcode-image-generator/Iron-Barcode-CSharp-Barcode-Image-Generator-Tutorial.zip)

### Additional Documentation

Explore further with Iron Software through the [BarcodeReader](https://ironsoftware.com/csharp/barcode/object-reference/api/IronBarCode.BarcodeWriter.html) classes in our API documentation, and learn about using it as a [C# Barcode Scanner](https://ironsoftware.com/csharp/barcode/use-case/barcode-scanner-csharp/).

Discover other tutorials on topics such as QR codes and reading barcode images with .NET.
# Barcodes & QR Codes in C# & VB.NET Development

***Based on <https://ironsoftware.com/docs/docs/>***


Utilizing Iron Barcode, a software library by Iron Software, is a straightforward way to implement barcode reading and writing across all .NET languages, including C#.

## Setting Up IronBarcode

Getting started involves installing the Iron Barcode library. This can be done either through our NuGet package or by [downloading the DLL](https://ironsoftware.com/csharp/barcode/packages/IronBarCode.zip) directly from our site. All of the functionality provided by Iron Barcode resides within the `IronBarcode` namespace.

The simplest approach for installation is by using the NuGet Package Manager in Visual Studio:

The specific package to search for is named "BarCode".

```shell
Install-Package BarCode
```

[View the package on NuGet](https://www.nuget.org/packages/Barcode/)

## Barcode and QR Code Reading Strategies

To read a barcode using Iron Barcode, a minimal amount of code is required.

```cs
using IronBarCode;

BarcodeResults results = BarcodeReader.Read("QuickStart.jpg");
if (results != null)
{
    foreach (BarcodeResult result in results)
    {
        Console.WriteLine(result.Text);
    }
}
```

To enhance the performance of barcode reading, it's possible to specify certain barcode types to limit the scope of search or to focus on a specified region within the image.

```cs
using IronBarCode;

BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    ExpectMultipleBarcodes = false,
    ExpectBarcodeTypes = BarcodeEncoding.QRCode | BarcodeEncoding.Code128,
    CropArea = new System.Drawing.Rectangle(100, 200, 300, 400),
};

BarcodeResults result = BarcodeReader.Read("QuickStart.jpg", options);
if (result != null)
{
    Console.WriteLine(result.First().Text);
}
```

Scanning multiple barcodes in a single operation is also supported.

```cs
using IronBarCode;

BarcodeResults results = BarcodeReader.Read("MultipleBarcodes.png");

foreach (BarcodeResult result in results)
{
    Console.WriteLine(result.Value);
}
```

Iron Barcode is also capable of reading barcodes from PDFs or multi-page TIFF files.

```cs
using IronBarCode;

BarcodeResults resultsFromPDF = BarcodeReader.Read("MultipleBarcodes.pdf");
foreach (BarcodeResult result in resultsFromPDF)
{
    Console.WriteLine(result.Value);
}

// Reading from a multi-page TIFF with image correction:
BarcodeResults resultsFromTIFF = BarcodeReader.Read("Multiframe.tiff", new BarcodeReaderOptions
{
    Speed = ReadingSpeed.Detailed,
    ExpectMultipleBarcodes = true,
});
```

## Creating Barcodes

Creating new barcodes involves using the `BarcodeWriter` class. Simply specify the barcode type and the data.

```cs
using IronBarCode;

GeneratedBarcode barcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode", BarcodeEncoding.Code128);
barcode.SaveAsImage("NewBarcode.png");
```

## Customizing Barcodes

Iron Barcode allows for extensive customization of barcode aesthetics through its Fluent API. Adjust size, margins, colors, and readability easily.

```cs
using IronBarCode;

GeneratedBarcode barcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode", BarcodeEncoding.Code128);
barcode.AddAnnotationTextAboveBarcode("Product URL:")
       .AddBarcodeValueTextBelowBarcode()
       .SetMargins(20)
       .ChangeBarCodeColor(IronSoftware.Drawing.Color.Blue)
       .SaveAsImage("StyledBarcode.png");
```

## HTML and Image Exports

The library provides flexible export options for barcodes as HTML content or various image formats.

```cs
using IronBarCode;

GeneratedBarcode barcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode", BarcodeEncoding.Code128);
barcode.SaveAsPng("Barcode.png");
barcode.SaveAsHtmlFile("Barcode.html");
barcode.SaveAsJpeg("Barcode.jpeg");
barcode.SaveAsPdf("Barcode.pdf");
```

## Generating Advanced QR Codes

For QR codes, the `QRCodeWriter` class allows setting error correction levels and integrating logos for branded outputs.

```cs
using IronBarCode;
using IronSoftware.Drawing;

QRCodeLogo logo = new QRCodeLogo("logo.png");
GeneratedBarcode qrWithLogo = QRCodeWriter.CreateQrCodeWithLogo("https://ironsoftware.com/csharp/barcode/", logo);
qrWithLogo.ChangeBarCodeColor(Color.Black).SaveAsPdf("BrandedQR.pdf");
```

## Supported Barcode Formats

Iron Barcode supports numerous barcode types, including:

- QR, Aztec, Data Matrix, CODE 93, CODE 128
- Linear and stacked barcodes like PDF-417 and RSS-14
- Numerical formats like UPC, EAN, and Codabar

## Why Opt for Iron Barcode?

Iron Barcode enables easy barcode integration with .NET, emphasizing high accuracy and low error rates. It provides vast options for customization and is optimized to handle real-world scenarios including imperfectly captured images.

## Moving Forward

For deeper insights into using Iron Barcode, explore our tutorials, engage with us on GitHub, or consult the [.NET API Reference](https://ironsoftware.com/csharp/barcode/object-reference/) styled like MSDN.
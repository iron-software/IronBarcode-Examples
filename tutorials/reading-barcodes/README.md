# Read Barcodes in C&#x23; #

## Install the Barcode Library in your Visual Studio Project

IronBarcode offers a comprehensive and robust library for barcode reading in .NET environments.

To integrate Iron Barcode into your project, the simplest method is to utilize our NuGet package. Alternatively, you can download and include the <a class="js-modal-open" href="https://ironsoftware.com/csharp/barcode/packages/IronBarCode.zip" data-modal-id="trial-license-after-download">DLL</a> directly into your project or the global assembly cache. IronBarcode is highly effective for creating C# Barcode Scanner applications.

```shell
Install-Package BarCode
```

## Decode Your First Barcode

Utilizing the Iron Barcode library makes reading Barcodes or QR Codes in .NET remarkably straightforward. In this initial example, we demonstrate how to decode a barcode with just a single line of code.

<center>
<img src="https://ironsoftware.com/img/tutorials/reading-barcodes/GetStarted.png" alt="Code128 Barcode Image to be Scanned with C#" class="img-responsive add-shadow img-margin" style="max-width:500px">
</center>

This allows us to retrieve various attributes such as value, image, encoding type, and any binary data, which we can then display on the console.

```cs
using IronBarCode;
using System;

BarcodeResult Result = BarcodeReader.QuicklyReadOneBarcode("GetStarted.png");

if (Result != null && Result.Text == "https://ironsoftware.com/csharp/barcode/")
{
  Console.WriteLine("Successful scan. Decoded Value: " + Result.Text);
}
```

### Enhance Accuracy and Focus

In the following example, introducing our `TryHarder` variable to the `QuicklyReadOneBarcode` method increases the effort made to decode a QR code that could be hidden, damaged, or angled.

```cs
BarcodeResult Result = BarcodeReader.QuicklyReadOneBarcode("TryHarderQR.png", BarcodeEncoding.QRCode | BarcodeEncoding.Code128 , true);
```

Here is the QR Code being read, despite its 45-degree rotation:

<center>
<img src="https://ironsoftware.com/img/tutorials/reading-barcodes/TryHarderQR.png" alt="Scanning a QR code rotated through 45 degrees with C#" class="img-responsive add-shadow img-margin" style="max-width:250px">
</center>

We illustrate that specifying one or more barcode formats can significantly refine the accuracy and performance of the barcode reading. The `|` symbol (bitwise OR) allows multiple formats to be specified simultaneously.

Expanding on this, the `BarcodeReader.ReadASingleBarcode` Method offers even greater precision.

```cs
BarcodeResult Result = IronBarCode.BarcodeReader.ReadASingleBarcode("TryHarderQR.png", BarcodeEncoding.QRCode | BarcodeEncoding.Code128, BarcodeReader.BarcodeRotationCorrection.High, BarcodeReader.BarcodeImageCorrection.MediumCleanPixels);
```

## Decoding Multiple Barcodes

### PDF Documents
Next, we explore reading from a [scanned PDF document](https://ironsoftware.com/img/tutorials/reading-barcodes/MultipleBarcodes.pdf) to identify all one-dimensional barcodes within, using minimal lines of code.

As demonstrated, this approach is similar to reading a single barcode but now includes details such as the page number where the barcode was found.

```cs
using IronBarCode;
using System;
using System.Drawing;

PagedBarcodeResult[] PDFResults = BarcodeReader.ReadBarcodesFromPdf("MultipleBarcodes.pdf");

foreach (var PageResult in PDFResults)
{
    string Value = PageResult.Value;
    int PageNum = PageResult.PageNumber;
    System.Drawing.Bitmap Img = PageResult.BarcodeImage;
    BarcodeEncoding BarcodeType = PageResult.BarcodeType;
    byte[] Binary = PageResult.BinaryValue;
    Console.WriteLine(PageResult.Value + " on page " + PageNum);
}
```

Here are the barcodes found across different pages:

<center>
<img src="https://ironsoftware.com/img/tutorials/reading-barcodes/MultipleBarcodes.png" alt="C# - Reading Barcodes from a PDF results" class="img-responsive add-shadow img-margin" style="max-width:250px">
</center>

### Scans and TIFFs

Similarly, scanning from a multi-frame TIFF will yield comparable outcomes to those obtained from a PDF.

<center>
<img src="https://ironsoftware.com/img/tutorials/reading-barcodes/Multiframe.tiff.overview.png" alt="C# - Reading Barcodes from a multi-frame TIFF image" class="img-responsive add-shadow img-margin" style="max-width:100%">
</center>

```cs
PagedBarcodeResult[] MultiFrameResults = BarcodeReader.ReadBarcodesFromMultiFrameTiff("Multiframe.tiff", BarcodeEncoding.Code128, BarcodeReader.BarcodeRotationCorrection.High, BarcodeReader.BarcodeImageCorrection.MediumCleanPixels);

foreach (var PageResult in MultiFrameResults)
{
    // ...
}
```

### Multithreading

For scanning multiple documents, improving efficiency is achieved by creating a list of the documents and utilizing the `BarcodeReader.ReadBarcodesMultithreaded` method. This approach leverages multiple threads and potentially all CPU cores to expedite the barcode scanning process.

```cs
var ListOfDocuments = new [] { "Image1.png", "image2.JPG", "image3.pdf" };
PagedBarcodeResult[] BatchResults = BarcodeReader.ReadBarcodesMultiThreaded(ListOfDocuments);

foreach (var Result in BatchResults)
{
    string Value = Result.Value;
    // ...
}
```

## Decoding Barcodes from Imperfect Images

Real-world scenarios often require reading barcodes from imperfect images, such as scans or photographs. These images might contain digital noise or be skewed. Unlike most conventional open-source .NET barcode generators and readers, [Barcode Reader in C#](https://ironsoftware.com/csharp/barcode/use-case/barcode-reader-csharp/) effortlessly handles these challenges.

### Photographs

In our example with photographs, setting specific barcode rotation correction and image correction functionalities helps correct digital noise and skewing effects that are common in images taken with cellphone cameras.

<center>
<img src="https://ironsoftware.com/img/tutorials/reading-barcodes/Photo.thumb.png" alt="Reading a barcode from a phone camera in C#"  class="img-responsive add-shadow img-margin">
</center>

```cs
var PhotoResult = BarcodeReader.ReadASingleBarcode("Photo.png", BarcodeEncoding.Code128, BarcodeReader.BarcodeRotationCorrection.Medium, BarcodeReader.BarcodeImageCorrection.DeepCleanPixels);

string Value = PhotoResult.Value;
System.Drawing.Bitmap Img = PhotoResult.BarcodeImage;
BarcodeEncoding BarcodeType = PhotoResult.BarcodeType;
byte[] Binary = PhotoResult.BinaryValue;
Console.WriteLine(PhotoResult.Value);
```

### Scans

The subsequent example illustrates the approach for reading QR codes and PDF-417 barcodes from a [scanned PDF document](https://ironsoftware.com/img/tutorials/reading-barcodes/Scan.pdf). Here, we adjust the level of barcode rotation correction and image correction to lightly clean the document, avoiding significant performance costs.

<center>
<img src="https://ironsoftware.com/img/tutorials/reading-barcodes/Scan.pdf.thumb.jpg" alt="Reading barcodes from a scanned PDF document in C#" class="img-responsive add-shadow img-margin" style="max-width:70%">
</center>

```cs
var ScanResults = BarcodeReader.ReadBarcodesFromPdf("Scan.pdf", BarcodeEncoding.All, BarcodeReader.BarcodeRotationCorrection.Low, BarcodeReader.BarcodeImageCorrection.LightlyCleanPixels);

foreach (var PageResult in ScanResults)
{
  string Value = PageResult.Value;
  ///...
}
```

### Thumbnails
This final example demonstrates that this [C# Barcode Generator](https://ironsoftware.com/csharp/barcode/use-case/generate-barcode-csharp/) also excels in reading corrupted thumbnails of barcodes.

<center>
<img src="https://ironsoftware.com/img/tutorials/reading-barcodes/ThumbnailOfBarcode.gif" alt="Automatic barcode thumbnail size correction.  File readable using Iron Barcode in C#" class="img-responsive add-shadow img-margin" style="max-width:70%">
</center>

Barcode reader methods are equipped to automatically detect small or thumbnail-sized barcode images, compensating for extensive digital noise to render them readable again.

```cs
BarcodeResult SmallResult = BarcodeReader.QuicklyReadOneBarcode("ThumbnailOfBarcode.gif", BarcodeEncoding.Code128);
```

## Summary

Iron Barcode is a flexible .NET software library and [C# QR Code Generator](https://ironsoftware.com/csharp/barcode/use-case/generate-qr-code-csharp/) capable of reading a wide array of barcode formats, including imperfect barcodes from real-world images such as photographs, scans, or screenshots.

### Further Reading

Explore additional tutorials in this section and the examples on our homepage to kickstart your project.

Our comprehensive [API Reference](https://ironsoftware.com/csharp/barcode/object-reference/) offers detailed insights into the `BarcodeReader` class and the `BarcodeEncoding` enum, showcasing the extensive capabilities of this C# Barcode Library.

### Source Code Downloads

We encourage you to download and explore this tutorial by accessing the source code or by visiting our GitHub repository. The source for this [.NET Barcode Reader](https://ironsoftware.com/csharp/barcode/use-case/net-barcode-reader/) tutorial is available as a Visual Studio 2017 Console Application project written in C#.

* [Tutorial Github Repository](https://github.com/iron-software/Iron-Barcode-Reading-Barcodes-In-CSharp)
* [C# Source Code in a Zip File](https://ironsoftware.com/downloads/assets/tutorials/reading-barcodes/Iron-Barcode-Reading-Barcodes-In-CSharp.zip)
# How to Extract Barcodes from Streams

***Based on <https://ironsoftware.com/how-to/read-barcodes-from-streams/>***


***

***

In the .NET Framework, the `MemoryStream` class is instrumental for managing data that isn't tied to a physical file. Instead, it handles data directly in memory. This versatility is particularly useful when working with dynamic data or when physical storage is not a viable option.

IronBarcode leverages this capability well beyond just handling files, enabling barcode reading straight from streams, including both PDF documents and images. Here’s how this is effectively accomplished with IronBarcode:

## Extracting Barcodes from Image Streams

This example demonstrates using IronBarcode to retrieve barcodes from an image stream or even multiple image streams encapsulated in a `List<>`.

```cs
using IronBarCode;
using IronSoftware.Drawing;
using System;
using System.Collections.Generic;
using System.IO;

// List to hold memory streams of images
List<MemoryStream> imageStreams = new List<MemoryStream>();
imageStreams.Add(AnyBitmap.FromFile("image1.jpg").ToStream());
imageStreams.Add(AnyBitmap.FromFile("image2.jpg").ToStream());
imageStreams.Add(AnyBitmap.FromFile("image3.png").ToStream());

var barcodes = BarcodeReader.Read(imageStreams);

// Iterate over the extracted barcodes and print them
foreach (var barcode in barcodes)
{
    Console.WriteLine(barcode.ToString());
}
```

In the code above, IronBarcode processes both individual and lists of `MemoryStream` objects through the `BarcodeReader.Read()` method to decode any barcodes present. Utilizing our open source `IronDrawing` library, images can be converted into `MemoryStream` objects. Existing streams can also be directly fed into `BarcodeReader.Read()` if they are already in memory.

## Extracting Barcodes from PDF Stream

This section clarifies how to read barcodes from a PDF by using IronBarcode with a stream interface.

```cs
using IronBarCode;
using IronPdf;
using System;
using System.IO;

// Convert a PDF file to MemoryStream
MemoryStream pdfStream = PdfDocument.FromFile(@"file_path.pdf").Stream;

var barcodesFromPdf = BarcodeReader.ReadPdf(pdfStream);

// Display each read barcode
foreach (var barcode in barcodesFromPdf)
{
    Console.WriteLine(barcode.ToString());
}
```

The approach here is quite similar to reading barcodes from images. `BarcodeReader.ReadPdf()` is specifically tailored to handle PDF streams directly, using `IronPDF` to convert the PDF file into a `MemoryStream`. For scenarios involving multiple PDF documents, it’s recommended to merge them into a single stream before processing, optimizing the workflow and ensuring seamless barcode extraction.

Experience the flexibility of IronBarcode and integrate it into your application to expand your document and image processing capabilities!
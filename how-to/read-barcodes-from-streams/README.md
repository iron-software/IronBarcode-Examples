# Reading Barcodes from Memory Streams

---

---

The .NET Framework’s `MemoryStream` class allows for reading and writing data to a stream held in memory rather than on disk. This type of stream is excellent for handling data temporarily in applications without the need for physical file storage.

IronBarcode extends its functionality to read barcodes not only from image or PDF files but also directly from data streams. This powerful API can efficiently process both PDF documents and image streams, extracting barcode information seamlessly. Let's explore how this can be done.

## Reading Barcodes from an Image Stream

Below, we demonstrate how to utilize IronBarcode to parse barcode data from a single or multiple image streams contained in a `List<>`.

```cs
using IronBarCode;
using IronSoftware.Drawing;
using System;
using System.Collections.Generic;
using System.IO;

// Prepare a list of memory streams containing images
List<MemoryStream> streams = new List<MemoryStream>();
streams.Add(AnyBitmap.FromFile("image1.jpg").ToStream());
streams.Add(AnyBitmap.FromFile("image2.jpg").ToStream());
streams.Add(AnyBitmap.FromFile("image3.png").ToStream());

// Read barcodes from the streams
var barcodes = BarcodeReader.Read(streams);

foreach (var barcode in barcodes)
{
    Console.WriteLine(barcode.ToString());
}
```

In the example above, we use `BarcodeReader.Read()` to process `MemoryStream` objects. We also introduce `IronSoftware.Drawing`—a versatile, open-source library—to convert images into `MemoryStream` format. If you already have `MemoryStream` instances of images, they can directly be fed into `BarcodeReader.Read()` to extract barcode data.

## Extracting Barcodes from PDF Streams

Next, let's look at how IronBarcode can parse barcode data from PDFs streamed as `MemoryStream` objects.

```cs
using IronBarCode;
using IronPdf;
using System;
using System.IO;

// Convert the PDF file to a MemoryStream
MemoryStream pdfStream = PdfDocument.FromFile(@"file_path.pdf").Stream;

// Read barcodes specifically from a PDF stream
var barcodesFromPdf = BarcodeReader.ReadPdf(pdfStream);

foreach (var barcode in barcodesFromPdf)
{
    Console.WriteLine(barcode.ToString());
}
```

The process of reading barcodes from a PDF `MemoryStream` is straightforward and utilizes `BarcodeReader.ReadPdf()`. IronPDF assists in converting a PDF file into a `MemoryStream`. For scenarios involving multiple PDFs, it's advisable to merge the PDFs into a single stream before processing with `BarcodeReader.ReadPdf()`.

Feel free to explore these methods and customize the library usage to fit your specific needs!
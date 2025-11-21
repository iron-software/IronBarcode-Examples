# How to Extract Barcodes from Streams

***Based on <https://ironsoftware.com/how-to/read-barcodes-from-streams/>***


The `MemoryStream` class in the .NET Framework offers a flexible means to work with data that is temporarily kept in memory, bypassing the need for physical file storage. This feature is crucial when dealing with transient data manipulation in applications.

IronBarcode is adept at scanning and interpreting barcodes directly from streams aside from the usual image and PDF files. This powerful feature allows developers to feed streams of images or PDF documents directly to IronBarcode, which processes and reveals the barcode data contained within. Let’s explore how you can harness this capability in your applications.

## Quickstart: Direct Barcode Extraction from Image Streams

Leveraging IronBarcode to decode barcodes straight from an image stream is incredibly straightforward, requiring minimal code. The example below illustrates how simple it is to perform this operation in a .NET environment, avoiding intermediate disk storage.

```cs
:title=Efficient Barcode Extraction from Streams
var scanResult = IronBarCode.BarcodeReader.Read(myImageStream);
Console.WriteLine(scanResult[0].Text); // Output the first barcode's text
```


## Extracting Barcodes from Image Streams

This segment demonstrates the procedure of using IronBarcode to interpret image streams, including handling multiple streams encapsulated in a `List<MemoryStream>`. Here is an example code snippet annotated to enhance clarity of the process:

```csharp
using IronBarCode;
using System;
using System.Collections.Generic;
using System.IO;

class ExtractBarcodeFromStream
{
    static void Main(string[] args)
    {
        // Initialize a list to hold image streams
        List<MemoryStream> imageStreams = new List<MemoryStream>
        {
            // Adding MemoryStream instances with image data
            new MemoryStream(File.ReadAllBytes("sample1.png")),
            new MemoryStream(File.ReadAllBytes("sample2.png"))
        };

        using IronBarCode;
        using IronSoftware.Drawing;
        using System;
        using System.Collections.Generic;
        using System.IO;

        List<MemoryStream> streams = new List<MemoryStream>();
        streams.Add(AnyBitmap.FromFile("photo1.jpg").ToStream());
        streams.Add(AnyBitmap.FromFile("photo2.jpg").ToStream());
        streams.Add(AnyBitmap.FromFile("photo3.png").ToStream());

        var detectedBarcodes = BarcodeReader.Read(streams);

        foreach (var barcode in detectedBarcodes)
        {
            Console.WriteLine(barcode.ToString()); // Print each decoded barcode
        }
    }
}
```

This example highlights how IronBarcode can process both individual `MemoryStream` instances and lists of them through the `BarcodeReader.Read()` function.

## Decoding Barcodes from PDF Stream

Here, the focus shifts to extracting barcodes embedded within PDFs via a `MemoryStream`. Below is the modified and explained segment of code:

```csharp
using IronBarCode;
using IronPdf;
using System;
using System.IO;

MemoryStream pdfStream = PdfDocument.FromFile(@"path_to_pdf.pdf").Stream;

var extractedBarcodes = BarcodeReader.ReadPdf(pdfStream);

foreach (var barcode in extractedBarcodes)
{
    Console.WriteLine(barcode.ToString()); // Output the decoded barcode data
}
```

As demonstrated, converting a PDF document into a `MemoryStream` and retrieving barcode data from it is efficiently handled by the `BarcodeReader.ReadPdf()` method. Utilizing `IronPDF` assists in this conversion, creating a seamless stream from PDF documents for barcode scanning. For scenarios involving multiple PDFs, it's advantageous to merge them into a single stream for optimal results. Experimentation with these techniques will enable customization to fit specific project requirements.
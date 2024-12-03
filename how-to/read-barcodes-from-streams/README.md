# How to Interpret Barcodes from Stream Data

***Based on <https://ironsoftware.com/how-to/read-barcodes-from-streams/>***


---

The .NET Framework's `MemoryStream` class allows data manipulation via stream storage in memory rather than from a physical file. This capability is crucial when dealing with data not attached to a file system.

IronBarcode, a robust .NET library, not only reads barcodes from images and PDFs but also from streams. This feature is particularly useful when working with images or documents dynamically generated or directly available in memory. Here, we'll go through how to decode barcodes from such data streams using IronBarcode.

## Decoding Barcodes from Image Streams

This guide demonstrates using IronBarcode with image streams, allowing barcode reading from single or multiple streamed images stored in a `List<>`.

```cs
using System.IO;
using BarCode;
namespace IronBarcodeExamples
{
    public class ImageStreamExample
    {
        public void Execute()
        {
            List<MemoryStream> imageStreamList = new List<MemoryStream>();
            imageStreamList.Add(AnyBitmap.FromFile("image1.jpg").ToStream());
            imageStreamList.Add(AnyBitmap.FromFile("image2.jpg").ToStream());
            imageStreamList.Add(AnyBitmap.FromFile("image3.png").ToStream());

            var readBarcodes = BarcodeReader.Read(imageStreamList);

            foreach (var barcode in readBarcodes)
            {
                Console.WriteLine(barcode.ToString());
            }
        }
    }
}
```

The above sample illustrates how `MemoryStream` instances can be read using `BarcodeReader.Read()`. The integration of IronDrawing, a free, open-source library under the IronBarcode umbrella, aids in converting images to `MemoryStream`. If the image streams are already available as `MemoryStream` instances, they can directly be utilized in the `BarcodeReader.Read()` method to detect barcodes.

## Decoding Barcodes from PDF Streams

Next, let's explore barcode reading from PDF file streams, either as individual `MemoryStream` objects or from multiple document streams combined.

```cs
using System.IO;
using BarCode;
namespace IronBarcodeExamples
{
    public class PdfStreamExample
    {
        public void Execute()
        {
            MemoryStream pdfStream = PdfDocument.FromFile(@"file_path.pdf").Stream;

            var decodedBarcodes = BarcodeReader.ReadPdf(pdfStream);

            foreach (var barcode in decodedBarcodes)
            {
                Console.WriteLine(barcode.ToString());
            }
        }
    }
}
```

The process is similar for PDF documents, utilizing `BarcodeReader.ReadPdf()` for decoding. This method expects a `MemoryStream` from a PDF, facilitated by IronPDF, which converts PDF files into streamable formats. For effective processing, combining multiple PDF files into a single stream before decoding can be advantageous. Feel encouraged to explore and modify the library to suit your requirements!
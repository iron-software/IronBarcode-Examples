# Exporting Barcodes to PDF Using IronBarcode

***Based on <https://ironsoftware.com/how-to/create-barcode-as-pdf/>***


In this guide, we will demonstrate how to leverage IronBarcode to transform barcodes into PDF format. IronBarcode facilitates the conversion of barcodes into files, binary data, or directly into a memory stream.

## Quick Start: Instant Barcode Export to PDF

This example illustrates how effortless it is to convert a barcode to a PDF in .NET utilizing the IronBarcode library. A single line of code is all that's needed to generate a barcode ready for PDF.

```cs
:title=Create PDF Barcode Effortlessly
var pdfBytes = IronBarCode.BarcodeWriter.CreateBarcode("FastPDF", IronBarCode.BarcodeWriterEncoding.Code128).ToPdfBinaryData();
```

## Saving Barcodes as PDF Files

To store a barcode in a PDF format on your local drive, start by creating a `GeneratedBarcode` instance using `BarcodeWriter.CreateBarcode`, then convert and store it using the `SaveAsPdf()` function. Here is how you can accomplish this:

```csharp
using IronBarCode;

// Create and save a barcode as PDF on disk
GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.DataMatrix);
myBarcode.SaveAsPdf("myBarcode.pdf");
```

## Generating Barcodes as PDF Binary Data

For generating a barcode as PDF binary data, create a barcode first and utilize the `ToPdfBinaryData()` function to get the data as a `byte[]` array. Here's the code snippet for this process:

```csharp
using IronBarCode;

// Generate a barcode and convert to binary PDF data
GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.DataMatrix);
byte[] myBarcodeByte = myBarcode.ToPdfBinaryData();
```

## Converting Barcodes to PDF Streams

If you need to export the barcode as a memory stream, generate the barcode and use the `ToPdfStream()` method. This returns a `System.IO.Stream`, which is useful for streaming applications. Below is the relevant code example:

```csharp
using IronBarCode;
using System.IO;

// Create a barcode and export as a PDF stream
GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.DataMatrix);
Stream myBarcodeStream = myBarcode.ToPdfStream();
```
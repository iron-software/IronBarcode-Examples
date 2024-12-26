# Exporting Barcodes to PDF with IronBarcode

***Based on <https://ironsoftware.com/how-to/create-barcode-as-pdf/>***


---

---

## Introduction to IronBarcode

One of IronBarcode's standout features is the ability to export `GeneratedBarcode` objects to PDF format. Users appreciate not only the standard PDF file conversion but also the alternative outputs such as PDF binary data and PDF streams. This flexibility allows developers to either use the PDFs as final output saved to disk or as intermediary data within applications. Let’s delve into how each of these functionalities can be implemented.

## Saving Barcodes as PDF Files

Primarily, you might want to store your `GeneratedBarcode` directly as a **PDF file**. This is often used for archiving or sharing as a final document. Here’s how you can accomplish this:

```cs
using IronBarCode;

GeneratedBarcode barcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.DataMatrix);
barcode.SaveAsPdf("exportedBarcode.pdf");
```

In this example, we first generate a barcode with the `CreateBarcode()` function, specifying both the content and encoding type. Then, we use the `SaveAsPdf()` method, passing a desired file name to store our barcode as a PDF file. 

## Generating PDF Binary Data from Barcodes

IronBarcode also supports converting `GeneratedBarcode` objects to **PDF binary data**. This is useful for applications that need to handle file content directly without creating physical files:

```cs
using IronBarCode;

GeneratedBarcode barcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.DataMatrix);
byte[] pdfBinary = barcode.ToPdfBinaryData();
```
The above code demonstrates creating a barcode that is directly converted to a byte array representing the PDF data. This approach is valuable for further manipulation or transmission of PDF content within an application.

## Converting Barcodes to PDF Stream

Similarly, converting a `GeneratedBarcode` to a **PDF stream** provides another versatile option for programmatic PDF handling:

```cs
using IronBarCode;
using System.IO;

GeneratedBarcode barcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.DataMatrix);
Stream pdfStream = barcode.ToPdfStream();
```

By using the `ToPdfStream()` method, we create a `Stream` object encapsulating the PDF data. This stream can be used for further processing or integration within .NET applications where streams are commonly utilized.

## Conclusion

IronBarcode offers powerful PDF export capabilities for barcodes, catering to different needs—whether saving directly to files, manipulating binary PDF data, or handling PDF streams within applications. These features make IronBarcode a versatile tool for developers needing to integrate barcode functionality in their .NET software.
# Extracting Barcodes from PDF Documents

***Based on <https://ironsoftware.com/how-to/read-barcodes-from-pdf/>***


Extracting barcodes from PDF documents involves identifying and decoding the barcodes embedded within the PDF pages. This technology eliminates the need for manual scanning of printed barcodes, enabling direct extraction of encoded information from digital documents. This functionality is especially beneficial in automating tasks such as processing invoices, shipping labels, reports, and other documents that embed data within barcodes.

## Quickstart: Extracting Barcodes Directly from PDFs

Get started quickly by utilizing IronBarcode’s `ReadPdf` method, which facilitates the immediate reading of barcodes from PDFs without the need for image conversion. This single line of code allows for swift barcode data extraction, setting the stage for more sophisticated implementations if required.

```cs
:title=Extract Barcodes from PDF with One Line
var results = IronBarCode.BarcodeReader.ReadPdf("invoice.pdf");
```

### Minimal Workflow Overview

1. Install the barcode processing library.
2. Initialize `PdfBarcodeReaderOptions` if necessary.
3. Employ the `ReadPdf` method from `BarcodeReader` to extract barcodes.
4. Adjust barcode reading settings using `BarcodeReaderOptions`.
5. Retrieve and utilize the barcode data.

## Direct Barcode Reading from PDFs

IronBarcode excels not only in reading barcodes from images but also from PDF files, eliminating the need to convert PDFs to images prior to extraction. Given the complex nature of PDFs relative to images, a distinct method, `BarcodeReader.ReadPdf()`, is employed. This method supports various PDF inputs, such as:

- **`byte[]` array**: Direct byte array representation of a PDF.
- **`IEnumerable<Byte[]>`**: Collections of byte arrays representing PDFs.
- **`MemoryStream`**: PDFs represented as MemoryStream.
- **`IEnumerable<Stream>`**: Collections of MemoryStreams representing PDFs.
- **`String`**: Path or name string of a PDF file within the project.
- **`IEnumerable<String>`**: Collections of strings representing file paths or names.

The `BarcodeReader.ReadPdf()` not only accepts various input types but also `PdfBarcodeReaderOptions` for enhanced reading options. Here’s a code snippet demonstrating its usage to extract barcodes from PDF documents:

```csharp
using IronBarCode;
using System;
using System.Collections.Generic;

List<String> documents = new List<String> { @"pdf_a.pdf", @"pdf_b.pdf" };

var barcodes = BarcodeReader.ReadPdfs(documents);  // Also accepts individual PDF file paths

foreach (var barcode in barcodes)
{
    Console.WriteLine(barcode.ToString());
}
```

### Simultaneous Reading from Multiple PDFs

IronBarcode's `ReadPdfs` method allows for efficient barcode extraction from multiple PDFs, streamlining processes where numerous documents are involved.

```cs
using IronBarCode;
using System;
using System.Collections.Generic;
using System.IO;

string directoryPath = @"YOUR_DIRECTORY_PATH";
List<string> pdfFiles = new List<string>(Directory.GetFiles(directoryPath, "*.pdf"));

var extractedBarcodes = BarcodeReader.ReadPdfs(pdfFiles);

foreach (var file in extractedBarcodes)
{
    foreach (var barcode in file)
    {
        Console.WriteLine($"Barcode {barcode.ToString()} found on page {barcode.PageNumber}");
    }
}
```

## Configuring PDF Barcode Reader Options

Similar to image-based barcode extraction, PDF barcode reading can be tailored through `PdfBarcodeReaderOptions`, enhancing **quality, accuracy, and speed**. These options are inheritable from `BarcodeReaderOptions` and include additional PDF-specific settings, enabling users to specify page numbers or a range:

```csharp
using IronBarCode;
using System.Collections.Generic;

List<int> pagesToRead = new List<int> { 1, 2, 3 };

PdfBarcodeReaderOptions options = new PdfBarcodeReaderOptions(pagesToRead)
{
    // Additional PDF-specific options
};
```

### Additional PDF Reader Settings

- **DPI**: Set the resolution for better barcode image clarity in PDFs.
- **PageNumbers**: Optimize scanning by specifying pages known to contain barcodes.
- **Password**: Access encrypted PDFs by providing the necessary decryption password.
- **Scale**: Adjust the scaling factor to enhance the visibility of smaller barcodes.

## Advanced Barcode Extraction Techniques

Integrating advanced settings with `PdfBarcodeReaderOptions` can significantly improve barcode reading performance from PDF documents.

```csharp
using IronBarCode;
using System;
using System.Collections.Generic;

List<int> focusedPages = new List<int>() { 1, 2, 3 };

PdfBarcodeReaderOptions advancedOptions = new PdfBarcodeReaderOptions(focusedPages)
{
    DPI = 150,
    Password = "secure",
    Scale = 4,
    Speed = ReadingSpeed.Detailed,
    ExpectBarcodeTypes = BarcodeEncoding.Code93,
    ExpectMultipleBarcodes = true
};

var readBarcodes = BarcodeReader.ReadPdf(@"specific_pdf_path.pdf", advancedOptions);
foreach (var barcode in readBarcodes)
{
    Console.WriteLine(barcode.ToString());
}
```

In this revised snippet, `PdfBarcodeReaderOptions` are thoroughly configured to enhance the reading accuracy and efficiency of barcodes embedded in PDFs.
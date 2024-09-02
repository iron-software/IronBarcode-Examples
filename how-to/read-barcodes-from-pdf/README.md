# Reading Barcodes from PDF Documents Using C#

## How to Extract Barcodes from PDF Files in C#

Follow these steps to accurately and efficiently read barcodes from PDF files using C#:

1. First, ensure the appropriate barcode library is added to your project.
2. Initialize `PdfBarcodeReaderOptions` to set specific reading parameters (if necessary).
3. Apply the `BarcodeReader.ReadPdf` method to process barcodes within PDF files.
4. Optionally, fine-tune the barcode reading process using `BarcodeReaderOption`.
5. Retrieve and handle the extracted barcode data.

### Direct Barcode Extraction from PDFs

IronBarcode excels not only in scanning barcodes from images but also from PDFs, eliminating the need for intermediate conversions to image formats. This direct approach from PDFs uses the `BarcodeReader.ReadPdf()` method, which is capable of handling various PDF input forms:

- **byte [] array**: Directly from a byte array.
- **IEnumerable<Byte []>**: From a collection of byte arrays.
- **MemoryStream**: Using a MemoryStream.
- **IEnumerable<Stream>**: From a collection of MemoryStreams.
- **String**: Via a direct file path or document name.
- **IEnumerable<String>**: From a list of file paths or document names.

The `BarcodeReader.ReadPdf()` method not only simplifies the process but enhances it with `PdfBarcodeReaderOptions` for advanced configurations. The following example demonstrates how to use this method for reading barcodes from PDF documents:

```csharp
using IronBarCode;
using System;
using System.Collections.Generic;

List<String> docs = new List<String> { "pdf_a.pdf", "pdf_b.pdf" };

var myBarcode = BarcodeReader.ReadPdf(docs);  // Also supports individual PDF file paths

foreach (var barcode in myBarcode)
{
    Console.WriteLine(barcode.ToString());  // Print each barcode value
}
```

In this example, IronBarcode directly reads from a list of PDF documents, extracting barcode information efficiently. If there are issues such as unreadable barcodes or slow performance, adjustments can be made using `PdfBarcodeReaderOptions` to optimize the reading quality and speed.

### Configuring PDF Barcode Reader Options

Similar to image barcode reading, PDF barcode extraction can be customized with `PdfBarcodeReaderOptions`. This allows improvements in reading accuracy, quality, and performance by adjusting properties such as:

#### DPI
This option allows specifying the DPI (Dots Per Inch), improving barcode recognition on low-quality images within PDFs.

#### PageNumbers
To streamline processing, specify the exact pages to scan, enhancing performance when dealing with large documents.

#### Password
For encrypted PDFs, set a password to access and read the file's content.

#### Scale
Adjust the scale factor for better barcode readability especially when barcodes are small.

See how to implement `PdfBarcodeReaderOptions` in your project:

```csharp
using IronBarCode;
using System;
using System.Collections.Generic;

List<int> pageNumbers = new List<int> { 1, 2, 3 };

PdfBarcodeReaderOptions options = new PdfBarcodeReaderOptions(pageNumbers)
{
    DPI = 150,
    Password = "barcode",
    Scale = 3.5,
    Speed = ReadingSpeed.Detailed,
    ExpectBarcodeTypes = BarcodeEncoding.Code93,
    ExpectMultipleBarcodes = true
};

var myBarcode = BarcodeReader.ReadPdf("pdf_a_filepath.pdf", options);
foreach (var barcode in myBarcode)
{
    Console.WriteLine(barcode.ToString());  // Print each decoded value
}
```

This configuration uses specific PDF pages and properties to enhance readability, demonstrating the flexibility and power of IronBarcode's PDF handling capabilities.
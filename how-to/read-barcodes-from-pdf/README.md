# How to Extract Barcodes from PDF Documents

***Based on <https://ironsoftware.com/how-to/read-barcodes-from-pdf/>***


## Extracting Barcode Data from PDFs in C#

1. Get started by adding the barcode processing library to your project.
2. Create an instance of `PdfBarcodeReaderOptions` if necessary.
3. Utilize the `ReadPdf` function from `BarcodeReader` to extract barcodes from PDF files.
4. Configure additional settings through the `BarcodeReaderOption`.
5. Retrieve and use barcode data from the PDF.

***

## Direct Barcode Reading from PDF Documents

IronBarcode excels not only in reading barcodes from images but also directly from PDF files. This capability eliminates the need to convert PDFs into images before barcode extraction. Working with PDFs involves a different approach due to their complex format. This is handled by the `BarcodeReader.ReadPdf()` method, which supports several input types:

- **byte [] array**: Direct byte array representation of a PDF.
- **IEnumerable<Byte []>**: A collection of PDFs as byte arrays.
- **MemoryStream**: A PDF in MemoryStream form.
- **IEnumerable<Stream>**: A collection of MemoryStreams holding PDF data.
- **String**: The path or name string of the PDF file if it is included within the project.
- **IEnumerable<String>**: A list of PDF document path or names.

In addition to the above inputs, `BarcodeReader.ReadPdf()` can be configured with `PdfBarcodeReaderOptions` for enhanced reading capabilities. See the following C# example demonstrating how to use the `ReadPdf` method:

```cs
using IronBarCode;
using System;
using System.Collections.Generic;

List<String> documentPaths = new List<String> { "pdf_a.pdf", "pdf_b.pdf" };

var results = BarcodeReader.ReadPdf(documentPaths);

foreach (var barcode in results)
{
    Console.WriteLine(barcode.ToString());
}
```

From the example, you can see that adding the path strings of the PDF documents directly to the `ReadPdf` method allows the extraction of barcode values, which can then be printed easily using a `foreach` loop with the `ToString()` method.

Should there be any reading issues or performance concerns, employing `PdfBarcodeReaderOptions` can optimize the reading process regarding quality, accuracy, and performance.

## Configuring PDF Barcode Reader Options

Configuring the `PdfBarcodeReaderOptions` similar to `BarcodeReaderOptions` but with enhancements specific to PDFs can significantly improve performance. Important properties to configure include the concerned page numbers for targeted reading:

```cs
using IronBarCode;
using System.Collections.Generic;

List<int> pages = new List<int> { 1, 2, 3 };

PdfBarcodeReaderOptions options = new PdfBarcodeReaderOptions(pages)
{
    // Additional properties specific to PDFs
};
```

### Additional Properties Available in PdfBarcodeReaderOptions

#### DPI

Setting the DPI (Dots Per Inch) is crucial when dealing with low-quality barcode images within PDFs. You can set this property using an integer.

#### PageNumbers

Pre-identifying which pages contain the necessary barcodes can drastically reduce processing time as it avoids scanning unnecessary pages. This is a 1-based index; thus, page one is represented as `1`.

#### Password

If the PDF is password-protected, this property allows the usage of a password to access the file. Note: IronBarcode does not retrieve or bypass PDF passwords.

#### Scale

Adjust the scale factor for width and height during image conversion, with a default value set at 3.5. Beneficial for enlarging small barcodes in the PDF for better recognition.

## Advanced Barcode Extraction from PDF

Now that you know how to configure `PdfBarcodeReaderOptions`, here’s how you can apply these settings to extract barcodes:

```cs
using IronBarCode;
using System;
using System.Collections.Generic;

List<int> selectedPages = new List<int> { 1, 2, 3 };

PdfBarcodeReaderOptions advancedOptions = new PdfBarcodeReaderOptions(selectedPages)
{
    DPI = 150,
    Password = "barcode",
    Scale = 3.5,
    Speed = ReadingSpeed.Detailed,
    ExpectBarcodeTypes = BarcodeEncoding.Code93,
    ExpectMultipleBarcodes = true
};

var extractedBarcodes = BarcodeReader.ReadPdf("pdf_a_filepath.pdf", advancedOptions);

foreach (var barcode in extractedBarcodes)
{
    Console.WriteLine(barcode.ToString());
}
```

This robust example demonstrates initializing `PdfBarcodeReaderOptions` with a selected page range and specific properties to optimize the extraction process. The enhanced settings are then used along with the target PDF path in the `ReadPdf` method.
# How to Extract Barcodes from PDF Documents

***Based on <https://ironsoftware.com/how-to/read-barcodes-from-pdf/>***


## Extracting Barcodes from PDF Files Using C#

1. Begin by adding the necessary barcode library to handle PDF files.
2. Initialize `PdfBarcodeReaderOptions` to customize the barcode reading process.
3. Utilize the `BarcodeReader.ReadPdf` method to extract barcodes from PDFs.
4. Apply specific barcode reading configurations via `BarcodeReaderOption`.
5. Retrieve and utilize the barcode information extracted.

***

## Direct Barcode Extraction from PDF Documents

IronBarcode is not only proficient in reading barcodes from images but is also equipped to directly extract barcodes from PDF files. This feature eliminates the need to convert PDF files into images beforehand, streamlining the process. The `BarcodeReader.ReadPdf()` method is specifically designed for PDFs and accepts various types of PDF document inputs, including:

- **byte [] array**: Directly as a byte array.
- **IEnumerable<Byte []>**: As collections of byte arrays.
- **MemoryStream**: Using the MemoryStream data type.
- **IEnumerable<Stream>**: As collections of MemoryStream objects.
- **String**: Through a direct path string of the PDF document.
- **IEnumerable<String>**: As collections of path/name strings.

Additionally, the `BarcodeReader.ReadPdf()` method can utilize `PdfBarcodeReaderOptions` for enhanced reading capabilities, which will be further discussed below. Below is a demonstration of how to use the `BarcodeReader.ReadPdf()` method to efficiently read barcodes from PDF documents.

```cs
using System.Collections.Generic;
using BarCode;
namespace ironbarcode.ReadBarcodesFromPdf
{
    public class SampleBarcodeExtraction
    {
        public void Run()
        {
            var documentPaths = new List<String> { @"pdf_a.pdf", @"pdf_b.pdf" };
            var extractedBarcodes = BarcodeReader.ReadPdf(documentPaths);

            foreach (var barcode in extractedBarcodes)
            {
                Console.WriteLine(barcode.ToString());
            }
        }
    }
}
```

In the above example, PDF document paths are fed into the `BarcodeReader.ReadPdf()` method to extract barcode information efficiently. The results are stored in a variable, and a `foreach` loop is then used to print each barcode value to the console.

## Configuring PDF Barcode Reader Settings

Similar to image barcode extraction, PDF barcode reading also permits customization via `PdfBarcodeReaderOptions`. Adjusting settings within this option can enhance the accuracy and performance of barcode reading in PDFs. Initial configurations often include specifying the page numbers to apply these settings:

```cs
using System.Collections.Generic;
using BarCode;
namespace ironbarcode.ReadBarcodesFromPdf
{
    public class ConfigureBarcodeOptions
    {
        public void Run()
        {
            var pagesToRead = new List<int> { 1, 2, 3 };
            var pdfBarcodeOptions = new PdfBarcodeReaderOptions(pagesToRead);
        }
    }
}
```

### Additional Configuration Properties

#### DPI
Set the DPI (Dots Per Inch) to improve recognition of barcodes in poor-quality PDFs using an integer value.

#### PageNumbers
Prefilter the pages to read by specifying page numbers. This is particularly effective for large PDFs with multiple pages.

#### Password
Access secured PDF files requiring a password with a string input, enabling barcode reading from protected documents.

#### Scale
Adjust the scale factor to enhance visibility and readability of small barcodes in PDFs. This property accepts an integer value.

## Advanced Barcode Extraction Techniques

Applying appropriate `PdfBarcodeReaderOptions` yields precise and efficient barcode extraction from PDFs. Here’s how these settings can be implemented:

```cs
using System.Collections.Generic;
using BarCode;
namespace ironbarcode.ReadBarcodesFromPdf
{
    public class AdvancedBarcodeExtraction
    {
        public void Run()
        {
            var selectedPages = new List<int> { 1, 2, 3 };
            var pdfBarcodeOptions = new PdfBarcodeReaderOptions(selectedPages)
            {
                DPI = 150,
                Password = "barcode",
                Scale = 3.5,
                Speed = ReadingSpeed.Detailed,
                ExpectBarcodeTypes = BarcodeEncoding.Code93,
                ExpectMultipleBarcodes = true
            };
            
            var results = BarcodeReader.ReadPdf(@"pdf_a_filepath.pdf", pdfBarcodeOptions);
            foreach (var barcode in results)
            {
                Console.WriteLine(barcode.ToString());
            }
        }
    }
}
```

This snippet configures detailed settings in the `PdfBarcodeReaderOptions`, such as DPI adjustment, password handling, and scale factor setting to effectively read barcodes from a specified PDF file. Applying these advanced settings ensures optimal reading accuracy and efficiency.
# How to Stamp Barcodes on PDFs

***Based on <https://ironsoftware.com/how-to/create-and-stamp-barcode-pdf/>***


***

***

## Stamp Barcode on an Existing PDF Page

In addition to [Exporting Barcode as PDF](https://ironsoftware.com/csharp/barcode/how-to/create-barcode-as-pdf/), a key feature of IronBarcode is its capability to directly stamp a `GeneratedBarcode` into an existing PDF document. This can be accomplished by invoking the `StampToExistingPdfPage()` method on the `GeneratedBarcode` object. Below, we illustrate how to implement this method:

```cs
using IronBarCode;
using BarCode;
namespace ironbarcode.CreateAndStampBarcodePdf
{
    public class Section1
    {
        public void Run()
        {
            // Create a barcode
            GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.Code128, 200, 100);
            // Stamp the barcode on a PDF page
            myBarcode.StampToExistingPdfPage("pdf_file_path.pdf", x: 200, y: 100, pageNumber: 3, password: "password");
        }
    }
}
```
In the example above, the `StampToExistingPdfPage()` method stamps the `GeneratedBarcode` onto a specified PDF. The method accepts the following arguments:
- **FilePath**: A `System.String` indicating the path to the PDF file on the disk.
- **Coordinates**: These are `System.Int32` types representing the X and Y coordinates in pixels where the barcode should be stamped.
- **PageNumber**: Specifies which PDF page the barcode will be stamped on. Default is page 1 if not specified.
- **Password**: An optional parameter for password-protected PDF files. This can be omitted if no password protection is involved.

Executing the above code will directly stamp the `GeneratedBarcode` into the designated PDF document.

## Stamping a Barcode Across Multiple PDF Pages

At times, it might be necessary to stamp a barcode on several pages. Rather than repeating the same process, you can use the `StampToExistingPdfPages()` method from the `GeneratedBarcode` class to stamp across multiple pages at once. See the following code example for details:

```cs
using System.Collections.Generic;
using BarCode;
namespace ironbarcode.CreateAndStampBarcodePdf
{
    public class Section2
    {
        public void Run()
        {
            // Create a barcode
            GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.Code128, 200, 100);
            // List of pages to stamp
            List<int> pages = new List<int> { 1, 2, 3 };
            // Stamp the barcode on specified pages
            myBarcode.StampToExistingPdfPages("pdf_file_path.pdf", x: 200, y: 100, pages, "password");
        }
    }
}
```
The parameters used here are similar to those in the `StampToExistingPdfPage()` method, with the addition of:
- **Page**: This takes a `List` of integers representing the page numbers in the PDF document that will receive the barcode stamp. This method is 1-based, meaning the numbering starts from 1.

*Note: Be mindful of the method name spellings, as the method for stamping multiple pages includes an extra 's' to reflect its plurality.*
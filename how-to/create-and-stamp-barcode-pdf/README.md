# How to Stamp Barcodes on PDFs

---

---

## Stamping a Barcode on an Existing PDF Page

In addition to [converting a barcode into a PDF](https://ironsoftware.com/csharp/barcode/how-to/create-barcode-as-pdf/), a highly valued feature in IronBarcode is the capability to integrate a `GeneratedBarcode` into an existing PDF document. This is accomplished effortlessly by invoking the `StampToExistingPdfPage()` method on a `GeneratedBarcode` instance. Below, we delve into how this function is implemented:

```cs
using IronBarCode;

GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.Code128, 200, 100);
myBarcode.StampToExistingPdfPage("pdf_file_path.pdf", X: 200, Y: 100, Page: 3, Password: "password");
```
In the code example provided, we employ the `StampToExistingPdfPage()` function of the `GeneratedBarcode` instance to append the barcode directly onto a specific PDF file. The parameters accepted by this function include:
- **FilePath**: A `System.String` indicating the local disk path to the target PDF document.
- **Coordinates**: Two `System.Int32` inputs, `X` and `Y`, represent the pixel coordinates on the PDF page where the barcode will be placed.
- **PageNumber**: Defines the PDF page where the barcode will be stamped. If omitted, it defaults to the first page.
- **Password**: An optional `System.String` used if the PDF is password-protected. If there's no password, this parameter can be excluded.

Executing the provided code will instantaneously place the `GeneratedBarcode` into the specified location in the PDF, without a need to save changes manually.

## Stamping a Barcode Across Multiple PDF Pages

There are scenarios where a barcode needs to be imprinted on several pages within a single PDF document. Rather than applying a loop with the previously mentioned method, you can utilize `StampToExistingPdfPages()` from the `GeneratedBarcode` class. This method is designed for such a task. Here's an outline of how the method is used:

```cs
using IronBarCode;
using System.Collections.Generic;

GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.Code128, 200, 100);
List<int> pages = new List<int> { 1, 2, 3 };  // Pages to be stamped with the barcode
myBarcode.StampToExistingPdfPages("pdf_file_path.pdf", X: 200, Y: 100, Pages: pages, Password: "password");
``` 

The arguments for `StampToExistingPdfPages()` are quite similar to those of `StampToExistingPdfPage()`, involving **FilePath**, **coordinates**, and **password**. The distinction lies in:
- **Pages**: This accepts a `List<int>` specifying the sequence of page numbers to be stamped with the `GeneratedBarcode`. It operates in a 1-based index manner, where `1` refers to the first page.

**Note: When employing these methods, ensure the correct spelling is used, especially the pluralization for stamping multiple pages (`'s'` in `StampToExistingPdfPages`).**
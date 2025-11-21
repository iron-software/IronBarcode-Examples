# How to Stamp Barcodes on PDFs

***Based on <https://ironsoftware.com/how-to/create-and-stamp-barcode-pdf/>***


## Quickstart: Stamp a Barcode onto a PDF Page

This simple example illustrates how to create a barcode using `IronBarCode`'s method `CreateBarcode` and directly apply it onto a page of an existing PDF. This process is streamlined for immediate use: just specify the PDF file path, barcode placement coordinates, and the desired page number, and the barcode will be appended swiftly.

```cs
:title=Efficiently Apply Barcodes on PDFs
IronBarCode.BarcodeWriter.CreateBarcode("https://my.site", IronBarCode.BarcodeEncoding.QRCode, 150, 150)
    .StampToExistingPdfPage("report.pdf", x: 50, y: 50, pageNumber: 1);
```

## Apply a Barcode to a PDF Page

In addition to exporting barcodes as PDF, a key feature of IronBarcode is the capability to directly apply a `GeneratedBarcode` onto an existing PDF document. The code example below shows how you can do this.

```csharp
using IronBarCode;

GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.Code128, 200, 100);
myBarcode.StampToExistingPdfPage("pdf_file_path.pdf", x: 200, y: 100, pageNumber: 3, password: "password");
```

In the example provided, we employ the `StampToExistingPdfPage()` method with a `GeneratedBarcode` object to affix the barcode onto the specified PDF document. Here are the parameters explained:

* `pdfFilePath`: A **System.String** indicating the file path of the PDF document.
* `x`: A **System.Int32** denoting the horizontal coordinate on the PDF page in pixels.
* `y`: A **System.Int32** noting the vertical coordinate on the PDF page in pixels.
* `pageNumber`: A **System.Int32** representing the page number to stamp, starting from **1**.
* `password`: An optional **System.String** used for accessing password-protected PDFs. This parameter can be omitted if the PDF is not secured.

Executing the above code will immediately place the `GeneratedBarcode` within the specified PDF without needing to save the document first.

## Apply a Barcode to Multiple PDF Pages

At times, you might need to apply the same barcode on several pages of a PDF. Rather than repeating the stamping process for each page, the `StampToExistingPdfPages()` method from the `GeneratedBarcode` class facilitates this task in one go. Here’s how to implement it:

```csharp
using IronBarCode;
using System.Collections.Generic;

GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.Code128, 200, 100);
List<int> pages = new List<int> {1, 2, 3};
myBarcode.StampToExistingPdfPages("pdf_file_path.pdf", x: 200, y: 100, pages, password: "password");
```

The parameters for this method are as follows:

* `pdfFilePath`: A **System.String** indicating where the PDF document is stored.
* `x`: A **System.Int32** for the horizontal position on each PDF page.
* `y`: A **System.Int32** for the vertical position on each page.
* `pageNumbers`: An **IEnumerable<System.Int32>** specifying which pages will receive the barcode, indexed starting from **1**.
* `password`: Optional **System.String** for PDFs that require a password. If the PDF is not password-protected, this parameter can be omitted.
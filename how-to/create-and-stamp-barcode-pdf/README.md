# How to Apply Barcodes to PDF Documents

***Based on <https://ironsoftware.com/how-to/create-and-stamp-barcode-pdf/>***


---

---

<h2>Introduction to IronBarcode</h2>

## Adding a Barcode to an Existing PDF

Beyond simply <a href="https://ironsoftware.com/csharp/barcode/how-to/create-barcode-as-pdf/">creating a standalone PDF Barcode</a>, a highly sought-after feature in IronBarcode is its capability to integrate a `<code>GeneratedBarcode</code>` directly into an existing PDF file. This operation can be performed by invoking `<code>StampToExistingPdfPage()</code>` on the `<code>GeneratedBarcode</code>` instance. Here is how you can implement this method:

```cs
using IronBarCode;

GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.Code128, 200, 100);
myBarcode.StampToExistingPdfPage("pdf_file_path.pdf", x: 200, y: 100, 3, "password");
```

In the example provided, the `<code>StampToExistingPdfPage()</code>` method is called on the `<code>GeneratedBarcode</code>` instance to embed the barcode into the PDF. The method takes the following parameters:
<ul>
    <li><strong>FilePath</strong>: A `<code>System.String</code>` that specifies the location of the target PDF file on the disk.</li>
    <li><strong>Coordinates</strong>: Two `<code>System.Int32</code>` arguments (X and Y) that determine the position where the barcode will be placed within the PDF, measured in pixels.</li>
    <li><strong>PageNumber</strong>: Specifies the PDF page number where the barcode will appear. By default, this is set to page 1 if not otherwise specified.</li>
    <li><strong>Password</strong>: An optional argument used when the PDF is protected by a password. It can be omitted if no password protection is applied.</li>
</ul>

Executing the above code immediately places the barcode into the PDF without requiring a document save operation.

## Applying Barcodes Across Multiple PDF Pages

There are scenarios where you might need the same barcode on several pages of a PDF. Instead of repeating the stamping process for each page, you can use the `<code>StampToExistingPdfPages()</code>` method from the `<code>GeneratedBarcode</code>` class. Here's how:

```cs
using IronBarCode;
using System.Collections.Generic;

GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.Code128, 200, 100);
List<int> pages = new List<int> {1, 2, 3};
myBarcode.StampToExistingPdfPages("pdf_file_path.pdf", x: 200, y: 100, pages, "password");
```

The parameters for `<code>StampToExistingPdfPages()</code>` are very similar to those of `<code>StampToExistingPdfPage()</code>`, with the addition of:
<ul>
    <li><strong>Pages</strong>: A `<code>List</code>` of integers representing the pages in the PDF document where the barcode will be applied. The indexing is 1-based, meaning page number starts at 1, not 0. The provided list denotes pages 1 through 3.</li>
</ul>

<em>Note: Be attentive to the spelling when using these methods as the plural method name includes an additional 's' to indicate multiple pages are involved.</em>
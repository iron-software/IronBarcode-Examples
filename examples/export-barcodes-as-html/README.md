***Based on <https://ironsoftware.com/examples/export-barcodes-as-html/>***

IronBarcode offers a handy capability for exporting barcodes into self-contained HTML formats. This means there is no need for linked image files, as all necessary data is embedded within the HTML itself.

You can export the barcode in one of three ways: as an **HTML file**, an **HTML image tag**, or a **data URI**.

Let's walk through an example:

- First, a barcode is created using the `BarcodeWriter.CreateBarcode` method, where you define the data and the type of encoding.
- Next, several IronBarcode methods can be utilized to export this barcode:
  - `ToHtmlTag()` produces an HTML `<img>` tag that can easily be integrated into web pages.
  - `ToDataUri()` compiles a data URI string which can be employed as a source in `<img>` tags or in any setting where an image URL might be needed.
  - `SaveAsHtmlFile()` saves the barcode as an independent HTML file, embedding all the image data inline. This makes the file both portable and easy to distribute.
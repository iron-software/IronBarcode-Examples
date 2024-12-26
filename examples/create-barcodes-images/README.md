***Based on <https://ironsoftware.com/examples/create-barcodes-images/>***

In this demonstration, we explore how barcodes in various formats and sizes can be efficiently generated, modified, and stored—sometimes with just a simple line of code.

Through the use of the Fluent API, the barcode generation capabilities allow for setting margins, resizing, and adding annotations to barcodes. These barcodes can then be exported as images, with IronOCR intelligently determining the appropriate image format based on the file extension, such as **GIFs, HTML files, HTML tags, JPEGs, PDFs, PNGs, TIFFs, and Windows Bitmaps**.

Additionally, the `StampToExistingPdfPage` method facilitates the incorporation of barcodes into existing PDFs. This feature is particularly advantageous for modifying standard PDFs or inserting specific identification numbers into documents via barcodes.
***Based on <https://ironsoftware.com/examples/pdf-barcode-reader-settings-csharp/>***

The `PdfBarcodeReaderOptions` class in IronBarcode enriches the way barcodes are read from PDFs with tailored and enhanced settings. This functionality covers managing PDF passwords, selecting particular pages for scanning, defining the DPI for PDF parsing, and altering the image scale to boost barcode readability.

### Essential Details

1. **Setting up `PdfBarcodeReaderOptions`**:
   - You can customize how PDFs are processed by configuring an instance of `PdfBarcodeReaderOptions`:
     - `Dpi`: Adjusts the scanning resolution. A higher DPI setting leads to more precise barcode identification.
     - `PageNumbers`: Defines which pages of the PDF to examine, allowing for targeted scanning.
     - `Password`: Enables access to secured PDFs by providing the necessary password.
     - `ScaleToX` and `ScaleToY`: These parameters allow for the resizing of the PDF image, which can aid in more accurate barcode detection.
2. **Decoding Barcodes**:
   - Barcodes are extracted and decoded from the PDF utilizing the `ReadPdfBarcodes` function, which applies the previously set options.
3. **Reviewing and Presenting Results**:
   - A `foreach` loop cycles through the resulting barcodes, displaying each one's type and value in the console.
   - This process ensures every barcode found on the designated pages is reported, useful for checking accuracy or for downstream use.

[Learn how to read barcodes from PDFs with C#](https://ironsoftware.com/csharp/barcode/how-to/read-barcodes-from-pdf/)
using IronBarCode;

PdfBarcodeReaderOptions myPdfOptionsExample = new PdfBarcodeReaderOptions()
{

    // The password string to open the PDF if there is one.
    Password = "password123",

    // Pages of the PDF you want to scan
    PageNumbers = new[] { 1, 3 },

    // By default, all barcode formats are scanned for.
    // Specifying one or more, performance will increase.
    ExpectBarcodeTypes = BarcodeEncoding.AllOneDimensional,

    // The DPI (Dots per inch) to render each Barcode image.
    DPI = 72,

    // The scaling factor to scale the Width and Height when converting the PDF to Image.
    // Default is 3.5
    Scale = 4
};

// And, apply:
var results = BarcodeReader.ReadPdf("barcode.pdf", myPdfOptionsExample);

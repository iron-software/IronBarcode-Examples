using IronBarCode;

PdfBarcodeReaderOptions myPdfOptionsExample = new PdfBarcodeReaderOptions()
{
    // The password string to open the PDF if there is one
    Password = "password123",

    // Pages of the PDF you want to scan
    PageNumbers = new[] { 1, 3 },

    // By default, all barcode formats are scanned for
    // Specifying a subset of barcode types to search for would improve performance
    ExpectBarcodeTypes = BarcodeEncoding.AllOneDimensional,

    // The DPI (dots per inch) to render each barcode image for reading
    DPI = 72,

    // The scaling factor to scale the width and height when converting the PDF to image
    // Default is 3.5 for both dimensions
    Scale = 4
};

// Read the pdf with the options applied
var results = BarcodeReader.ReadPdf("barcode.pdf", myPdfOptionsExample);

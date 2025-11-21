using IronBarCode;
using System.Drawing;

// Reading a barcode is easy with IronBarcode!
var resultFromFile = BarcodeReader.Read(@"file/barcode.png"); // From a file
var resultFromBitMap = BarcodeReader.Read(new Bitmap("barcode.bmp")); // From a bitmap
var resultFromImage = BarcodeReader.Read(Image.FromFile("barcode.jpg")); // From an image
var resultFromPdf = BarcodeReader.ReadPdf(@"file/mydocument.pdf"); // From PDF use ReadPdf

// To configure and fine-tune barcode reading, utilize the BarcodeReaderOptions class
var myOptionsExample = new BarcodeReaderOptions
{
    // Choose a reading speed from: Faster, Balanced, Detailed, ExtremeDetail
    // There is a tradeoff in performance as more detail is set
    Speed = ReadingSpeed.Balanced,

    // Reader will stop scanning once a single barcode is found (if set to true)
    ExpectMultipleBarcodes = true,

    // By default, all barcode formats are scanned for
    // Specifying a subset of barcode types to search for would improve performance
    ExpectBarcodeTypes = BarcodeEncoding.AllOneDimensional,

    // Utilize multiple threads to read barcodes from multiple images in parallel
    Multithreaded = true,

    // Maximum threads for parallelized barcode reading
    // Default is 4
    MaxParallelThreads = 2,

    // The area of each image frame in which to scan for barcodes
    // Specifying a crop area will significantly improve performance and avoid noisy parts of the image
    CropArea = new Rectangle(),

    // Special setting for Code39 barcodes
    // If a Code39 barcode is detected, try to read with both the base and extended ASCII character sets
    UseCode39ExtendedMode = true
};

// Read with the options applied
var results = BarcodeReader.Read("barcode.png", myOptionsExample);

// Create a barcode with one line of code
var myBarcode = BarcodeWriter.CreateBarcode("12345", BarcodeWriterEncoding.EAN8);

// After creating a barcode, we may choose to resize
myBarcode.ResizeTo(400, 100);

// Save our newly-created barcode as an image
myBarcode.SaveAsImage("EAN8.jpeg");

Image myBarcodeImage = myBarcode.Image; // Can be used as Image
Bitmap myBarcodeBitmap = myBarcode.ToBitmap(); // Can be used as Bitmap

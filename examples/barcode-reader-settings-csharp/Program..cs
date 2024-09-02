using IronBarCode;

BarcodeReaderOptions myOptionsExample = new BarcodeReaderOptions()
{

    // Choose a speed from: Faster, Balanced, Detailed, ExtremeDetail
    // There is a tradeoff in performance as more Detail is set
    Speed = ReadingSpeed.Balanced,

    // Reader will stop scanning once a barcode is found, unless set to true
    ExpectMultipleBarcodes = true,

    // By default, all barcode formats are scanned for.
    // Specifying one or more, performance will increase.
    ExpectBarcodeTypes = BarcodeEncoding.AllOneDimensional,

    // Utilizes multiple threads to reads barcodes from multiple images in parallel.
    Multithreaded = true,

    // Maximum threads for parallel. Default is 4
    MaxParallelThreads = 2,

    // The area of each image frame in which to scan for barcodes.
    // Will improve performance significantly and avoid unwanted results and avoid noisy parts of the image.
    CropArea = new System.Drawing.Rectangle(),

    // Special Setting for Code39 Barcodes.
    // If a Code39 barcode is detected. Try to use extended mode for the full ASCII Character Set
    UseCode39ExtendedMode = true
};

// And, apply:
var results = BarcodeReader.Read("barcode.png", myOptionsExample);

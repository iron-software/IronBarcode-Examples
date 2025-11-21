using IronBarCode;

BarcodeReaderOptions myOptionsExample = new BarcodeReaderOptions()
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
    CropArea = new System.Drawing.Rectangle(),

    // Special setting for Code39 barcodes
    // If a Code39 barcode is detected, try to read with both the base and extended ASCII character sets
    UseCode39ExtendedMode = true
};

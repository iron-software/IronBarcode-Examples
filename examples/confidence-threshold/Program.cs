using IronBarCode;

BarcodeReaderOptions readerOptions = new BarcodeReaderOptions()
{
    ExpectMultipleBarcodes = true,

    // Set minimum confidence level
    ConfidenceThreshold = 0.3,
};

// Read with the options applied
var results = BarcodeReader.Read("barcode.png", readerOptions);

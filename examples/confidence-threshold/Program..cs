using IronBarCode;

BarcodeReaderOptions readerOptions = new BarcodeReaderOptions()
{
    ExpectMultipleBarcodes = true,

    // Set minimum confidence level
    ConfidenceThreshold = 0.3,
};

// And, apply:
var results = BarcodeReader.Read("barcode.png", readerOptions);

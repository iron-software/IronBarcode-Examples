using IronBarCode;

BarcodeReaderOptions myOptionsExample = new BarcodeReaderOptions()
{
    // Choose which filters are to be applied (in order)
    ImageFilters = new ImageFilterCollection() {
        new BinaryThresholdFilter(0.9f)
    },
};

// Apply options and read the barcode
BarcodeResults results = BarcodeReader.Read("sample.png", myOptionsExample);

// Export file to disk
results.ExportFilterImagesToDisk("binaryThreshold_0.9.png");
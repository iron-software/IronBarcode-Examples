using IronBarCode;

BarcodeReaderOptions myOptionsExample = new BarcodeReaderOptions()
{
    // Choose which filters are to be applied (in order)
    ImageFilters = new ImageFilterCollection() {
    new InvertFilter(),
    },
};

// Apply options and read the barcode
BarcodeResults results = BarcodeReader.Read("sample1.png", myOptionsExample);

// Export file to disk
results.ExportFilterImagesToDisk("invert.png");
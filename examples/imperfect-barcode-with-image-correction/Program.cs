using IronBarCode;
using IronSoftware.Drawing;

// Choose which filters are to be applied (in order)
// Set cacheAtEachIteration = true to save the intermediate image data after each filter is applied
var filtersToApply = new ImageFilterCollection(cacheAtEachIteration: true) {
    new SharpenFilter(),
    new InvertFilter(),
    new ContrastFilter(),
    new BrightnessFilter(),
    new AdaptiveThresholdFilter(),
    new BinaryThresholdFilter(),
    new GaussianBlurFilter(),
    new MedianBlurFilter(),
    new BilateralFilter()
};

BarcodeReaderOptions myOptionsExample = new BarcodeReaderOptions()
{
    // Set chosen filters in BarcodeReaderOptions
    ImageFilters = filtersToApply,

    Speed = ReadingSpeed.Balanced,
    ExpectMultipleBarcodes = true,
};

// Read with the options applied
BarcodeResults results = BarcodeReader.Read("screenshot.png", myOptionsExample);

AnyBitmap[] filteredImages = results.FilterImages();

// Export intermediate image files to disk
for (int i = 0 ; i < filteredImages.Length ; i++)
    filteredImages[i].SaveAs($"{i}_barcode.png");

// Or
results.ExportFilterImagesToDisk("filter-result.jpg");

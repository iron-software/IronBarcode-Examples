using IronBarCode;
using IronSoftware.Drawing;
using System.Linq;

// Choose which filters are to be applied (in order);
var filtersToApply = new ImageFilterCollection() {
    new SharpenFilter(),
    new InvertFilter(),
    new ContrastFilter(),
    new BrightnessFilter(),
    new AdaptiveThresholdFilter(),
    new BinaryThresholdFilter()
};

BarcodeReaderOptions myOptionsExample = new BarcodeReaderOptions()
{
    // Set chosen filters in BarcodeReaderOptions:
    ImageFilters = filtersToApply,

    // Other Barcode Reader Options:
    Speed = ReadingSpeed.Balanced,
    ExpectMultipleBarcodes = true,
};

// And, apply with a Read:
BarcodeResults results = BarcodeReader.Read("screenshot.png", myOptionsExample);

AnyBitmap[] filteredImages = results.FilterImages();

// Export file to disk
for (int i = 0 ; i < filteredImages.Length ; i++)
    filteredImages[i].SaveAs($"{i}_barcode.png");

// Or
results.ExportFilterImagesToDisk("filter-result.jpg");

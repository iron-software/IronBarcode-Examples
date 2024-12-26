using IronBarCode;
using BarCode;
namespace IronBarcode.Examples.HowTo.ImageCorrection
{
    public static class Section4
    {
        public static void Run()
        {
            BarcodeReaderOptions options = new BarcodeReaderOptions()
            {
                // Choose which filters are to be applied (in order)
                ImageFilters = new ImageFilterCollection(true) {
                    new BrightnessFilter(1.5f),
                },
            };
            
            // Apply options and read the barcode
            BarcodeResults results = BarcodeReader.Read("sample.png", options);
            
            // Export file to disk
            results.ExportFilterImagesToDisk("brightness_1.5.png");
        }
    }
}
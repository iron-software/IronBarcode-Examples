using IronBarCode;
using BarCode;
namespace IronBarcode.Examples.HowTo.ImageCorrection
{
    public static class Section2
    {
        public static void Run()
        {
            BarcodeReaderOptions options = new BarcodeReaderOptions()
            {
                // Choose which filters are to be applied (in order)
                ImageFilters = new ImageFilterCollection(true) {
                    new AdaptiveThresholdFilter(0.9f),
                },
            };
            
            // Apply options and read the barcode
            BarcodeResults results = BarcodeReader.Read("sample.png", options);
            
            // Export file to disk
            results.ExportFilterImagesToDisk("adaptiveThreshold_0.9.png");
        }
    }
}
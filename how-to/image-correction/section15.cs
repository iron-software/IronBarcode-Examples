using IronBarCode;
using BarCode;
namespace IronBarcode.Examples.HowTo.ImageCorrection
{
    public static class Section15
    {
        public static void Run()
        {
            BarcodeReaderOptions myOptionsExample = new BarcodeReaderOptions()
            {
                // Choose which filters are to be applied (in order)
                ImageFilters = new ImageFilterCollection(true) {
                    new SharpenFilter(3.5f),
                    new AdaptiveThresholdFilter(0.5f),
                    new ContrastFilter(2)
                },
            };
            
            // Apply options and read the barcode
            BarcodeResults results = BarcodeReader.Read("sample.webp", myOptionsExample);
            
            // Export file to disk
            results.ExportFilterImagesToDisk("filteredImage.png");
        }
    }
}
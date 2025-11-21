using IronBarCode;
using BarCode;
namespace IronBarcode.Examples.HowTo.ImageCorrection
{
    public static class Section12
    {
        public static void Run()
        {
            BarcodeReaderOptions myOptionsExample = new BarcodeReaderOptions()
            {
                // Choose which filters are to be applied (in order)
                ImageFilters = new ImageFilterCollection(true) {
                    new GaussianBlurFilter(3, 3, 3.0f),
                },
            };
            
            // Apply options and read the barcode
            BarcodeResults results = BarcodeReader.Read("sharpen.webp", myOptionsExample);
            
            // Export file to disk
            results.ExportFilterImagesToDisk("gaussianBlur.png");
        }
    }
}
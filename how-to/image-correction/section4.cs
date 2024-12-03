using IronBarCode;
using BarCode;
namespace ironbarcode.ImageCorrection
{
    public class Section4
    {
        public void Run()
        {
            BarcodeReaderOptions myOptionsExample = new BarcodeReaderOptions()
            {
                // Choose which filters are to be applied (in order)
                ImageFilters = new ImageFilterCollection() {
                new BrightnessFilter(1.5f),
                },
            };
            
            // Apply options and read the barcode
            BarcodeResults results = BarcodeReader.Read("sample.png", myOptionsExample);
            
            // Export file to disk
            results.ExportFilterImagesToDisk("brightness_1.5.png");
        }
    }
}
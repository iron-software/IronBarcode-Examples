using IronBarCode;
using BarCode;
namespace IronBarcode.Examples.Tutorial.ReadingBarcodes
{
    public static class Section3
    {
        public static void Run()
        {
            BarcodeReaderOptions options = new BarcodeReaderOptions()
            {
                // Choose which filters are to be applied (in order)
                ImageFilters = new ImageFilterCollection() {
                    new AdaptiveThresholdFilter(),
                },
            
                // Uses machine learning to auto rotate the barcode
                AutoRotate = true,
            };
            
            // Read barcode
            BarcodeResults results = BarcodeReader.Read("TryHarderQR.png", options);
        }
    }
}
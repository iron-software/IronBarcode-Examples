using System;
using BarCode;
namespace IronBarcode.Examples.HowTo.ImageCorrection
{
    public static class Section8
    {
        public static void Run()
        {
            BarcodeReaderOptions options = new BarcodeReaderOptions()
            {
                // Choose which filters are to be applied (in order)
                ImageFilters = new ImageFilterCollection(true) {
                    new SharpenFilter(0.5f),
                },
            };
            
            // Apply options and read the barcode
            BarcodeResults results = BarcodeReader.Read("sample.png", options);
            
            // Export file to disk
            results.ExportFilterImagesToDisk("sharpen_0.5.png");
        }
    }
}
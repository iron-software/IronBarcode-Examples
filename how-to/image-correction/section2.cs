using System;
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
                ImageFilters = new ImageFilterCollection()
                {
                    new SharpenFilter(3.5f),
                    new ContrastFilter(2)
                },
            };
            
            // Apply options and read the barcode
            BarcodeResults results = BarcodeReader.Read("sample.png", options);
            
            // Write the result value to console
            foreach (BarcodeResult result in results)
            {
                Console.WriteLine(result.Text);
            }
        }
    }
}
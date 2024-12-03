using System;
using BarCode;
namespace ironbarcode.ImageCorrection
{
    public class Section1
    {
        public void Run()
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
            
            // Export file to disk
            results.ExportFilterImagesToDisk("filteredSample.png");
            
            // Write the result value to console
            foreach (BarcodeResult result in results)
            {
                Console.WriteLine(result.Text);
            }
        }
    }
}
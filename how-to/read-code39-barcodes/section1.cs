using System;
using BarCode;
namespace IronBarcode.Examples.HowTo.ReadCode39Barcodes
{
    public static class Section1
    {
        public static void Run()
        {
            BarcodeReaderOptions options = new BarcodeReaderOptions()
            {
                // Tell the reader to only look for Code 39.
                ExpectBarcodeTypes = BarcodeEncoding.Code39
            };
            
            // Read barcode(s) from the image file using the specified options
            var results = BarcodeReader.Read("code39.png", options);
            
            // Loop through each BarcodeResult found in the image
            foreach (var result in results)
            {
                // Print the decoded string value of the standard Code 39 barcode
                Console.WriteLine(result.ToString());
            }
        }
    }
}
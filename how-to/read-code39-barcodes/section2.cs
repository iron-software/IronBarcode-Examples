using System;
using BarCode;
namespace IronBarcode.Examples.HowTo.ReadCode39Barcodes
{
    public static class Section2
    {
        public static void Run()
        {
            BarcodeReaderOptions options = new BarcodeReaderOptions()
            {
                // Enable extended Code 39 mode
                UseCode39ExtendedMode = true,
            
                // Specify that we are expecting Code 39 barcodes
                ExpectBarcodeTypes = BarcodeEncoding.Code39
            };
            
            // Read barcode(s) from the extended code 39 image
            var results = BarcodeReader.Read("code39extended.png", options);
            
            // Loop through each BarcodeResult found in the image
            foreach (var result in results)
            {
                // Print the fully decoded ASCII string (e.g., "Test-Data!")
                Console.WriteLine(result.ToString());
            }
        }
    }
}
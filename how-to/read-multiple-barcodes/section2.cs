using System;
using BarCode;
namespace IronBarcode.Examples.HowTo.ReadMultipleBarcodes
{
    public static class Section2
    {
        public static void Run()
        {
            // Set the option to read multiple barcodes
            BarcodeReaderOptions options = new BarcodeReaderOptions()
            {
                ExpectMultipleBarcodes = true,
                ExpectBarcodeTypes = BarcodeEncoding.AllOneDimensional,
            };
            
            // Read barcode
            var results = BarcodeReader.Read("testbc1.png", options);
            
            foreach (var result in results)
            {
                Console.WriteLine(result.ToString());
            }
        }
    }
}
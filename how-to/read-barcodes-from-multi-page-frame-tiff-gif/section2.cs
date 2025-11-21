using System;
using BarCode;
namespace IronBarcode.Examples.HowTo.ReadBarcodesFromMultiPageFrameTiffGif
{
    public static class Section2
    {
        public static void Run()
        {
            // Read barcode from TIF image
            BarcodeResults results = BarcodeReader.Read("sample.tif");
            
            // Output the barcodes value to console
            foreach (var result in results)
            {
                Console.WriteLine(result.Value);
            }
        }
    }
}
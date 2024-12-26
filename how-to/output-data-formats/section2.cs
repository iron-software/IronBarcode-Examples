using System;
using BarCode;
namespace IronBarcode.Examples.HowTo.OutputDataFormats
{
    public static class Section2
    {
        public static void Run()
        {
            // Read barcode from PNG
            BarcodeResults result = BarcodeReader.Read("bc3.png");
            
            // Output barcode type to console
            foreach (BarcodeResult barcode in result)
            {
                Console.WriteLine("The barcode value is " + barcode.ToString() + " and the barcode type is " + barcode.BarcodeType);
            }
        }
    }
}
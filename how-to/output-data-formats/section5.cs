using System;
using BarCode;
namespace IronBarcode.Examples.HowTo.OutputDataFormats
{
    public static class Section5
    {
        public static void Run()
        {
            // Read barcode from PDF
            BarcodeResults result = BarcodeReader.ReadPdf("test.pdf");
            
            // Output page number to console
            foreach (BarcodeResult barcode in result)
            {
                Console.WriteLine("The barcode value " + barcode.ToString() + " is found on page number " + barcode.PageNumber);
            }
        }
    }
}
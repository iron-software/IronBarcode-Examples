using System;
using BarCode;
namespace IronBarcode.Examples.HowTo.OutputDataFormats
{
    public static class Section8
    {
        public static void Run()
        {
            // Read barcode from PDF
            BarcodeResults result = BarcodeReader.ReadPdf("barcodestamped3.pdf");
            
            // Output text value to console
            foreach (BarcodeResult barcode in result)
            {
                Console.WriteLine(barcode.Value);
                Console.WriteLine(barcode.Text);
                Console.WriteLine(barcode.ToString());
            }
        }
    }
}
using System;
using BarCode;
namespace IronBarcode.Examples.HowTo.OutputDataFormats
{
    public static class Section7
    {
        public static void Run()
        {
            // Read barcode from PDF
            BarcodeResults result = BarcodeReader.ReadPdf("test.pdf");
            
            // Output page orientation and rotation to console
            foreach (BarcodeResult barcode in result)
            {
                Console.WriteLine(barcode.Value);
                Console.WriteLine(barcode.PageOrientation);
                Console.WriteLine(barcode.Rotation);
            }
        }
    }
}
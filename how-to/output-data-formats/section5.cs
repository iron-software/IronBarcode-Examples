using System;
using BarCode;
namespace ironbarcode.OutputDataFormats
{
    public class Section5
    {
        public void Run()
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
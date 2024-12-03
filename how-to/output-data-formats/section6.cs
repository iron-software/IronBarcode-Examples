using System;
using BarCode;
namespace ironbarcode.OutputDataFormats
{
    public class Section6
    {
        public void Run()
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
using System;
using BarCode;
namespace ironbarcode.OutputDataFormats
{
    public class Section7
    {
        public void Run()
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
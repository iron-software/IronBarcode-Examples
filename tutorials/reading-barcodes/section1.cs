using System;
using BarCode;
namespace ironbarcode.ReadingBarcodes
{
    public class Section1
    {
        public void Run()
        {
            // Read barcode
            BarcodeResults results = BarcodeReader.Read("GetStarted.png");
            
            // Log the result to Console Window
            foreach (BarcodeResult result in results)
            {
                if (result != null)
                {
                    Console.WriteLine("GetStarted was a success. Read Value: " + result.Text);
                }
            }
        }
    }
}
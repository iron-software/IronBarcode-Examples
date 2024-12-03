using System;
using BarCode;
namespace ironbarcode.ReadMultipleBarcodes
{
    public class Section1
    {
        public void Run()
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
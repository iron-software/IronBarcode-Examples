using System;
using BarCode;
namespace ironbarcode.ReadMultipleBarcodes
{
    public class Section2
    {
        public void Run()
        {
            // Set the option to read single barcode
            BarcodeReaderOptions options = new BarcodeReaderOptions()
            {
                ExpectMultipleBarcodes = false,
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
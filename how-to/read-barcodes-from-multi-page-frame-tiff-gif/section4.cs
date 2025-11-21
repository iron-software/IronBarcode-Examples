using System;
using BarCode;
namespace IronBarcode.Examples.HowTo.ReadBarcodesFromMultiPageFrameTiffGif
{
    public static class Section4
    {
        public static void Run()
        {
            // Configure filters
            ImageFilterCollection filters = new ImageFilterCollection()
            {
                new SharpenFilter(3.5f),
                new ContrastFilter(2)
            };
            
            // Configure options
            BarcodeReaderOptions options = new BarcodeReaderOptions()
            {
                ExpectBarcodeTypes = IronBarCode.BarcodeEncoding.QRCode,
                ImageFilters = filters,
                ExpectMultipleBarcodes = true,
                Speed = ReadingSpeed.Balanced
            };
            
            // Read barcode from TIF image
            BarcodeResults results = BarcodeReader.Read("sample.tif", options);
            
            // Output the barcodes value to console
            foreach (var result in results)
            {
                Console.WriteLine(result.Value);
            }
        }
    }
}
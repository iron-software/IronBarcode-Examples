using System.Collections.Generic;
using BarCode;
namespace IronBarcode.Examples.HowTo.OutputDataFormats
{
    public static class Section1
    {
        public static void Run()
        {
            // Read barcode from PDF file
            BarcodeResults result = BarcodeReader.ReadPdf("test.pdf");
            
            // Create list for barcodes
            List<AnyBitmap> barcodeList = new List<AnyBitmap>();
            
            foreach (BarcodeResult barcode in result)
            {
                barcodeList.Add(barcode.BarcodeImage);
            }
            
            // Create multi-page TIFF
            AnyBitmap.CreateMultiFrameTiff(barcodeList).SaveAs("barcodeImages.tif");
        }
    }
}
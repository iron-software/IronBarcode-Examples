using IronBarCode;
using BarCode;
namespace IronBarcode.Examples.HowTo.Create1BppBarcodeImages
{
    public static class Section3
    {
        public static void Run()
        {
            // Create a barcode with "12345" encoded in the EAN8 format
            var myBarcode = BarcodeWriter.CreateBarcode("12345", BarcodeWriterEncoding.EAN8);
            
            // Save the barcode as a 1bpp Bitmap
            myBarcode.SaveAs1BppBitmap("1bppImage.bmp");
        }
    }
}
using IronBarCode;
using BarCode;
namespace IronBarcode.Examples.HowTo.Create1BppBarcodeImages
{
    public static class Section2
    {
        public static void Run()
        {
            // Create a barcode with "12345" encoded in the EAN8 format
            var myBarcode = BarcodeWriter.CreateBarcode("12345", BarcodeWriterEncoding.EAN8);
            
            // Converts the barcode into a 1bpp image
            var anyBitmap = myBarcode.To1BppImage();
        }
    }
}
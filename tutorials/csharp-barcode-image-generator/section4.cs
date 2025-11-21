using IronSoftware.Drawing;
using BarCode;
namespace IronBarcode.Examples.Tutorial.CsharpBarcodeImageGenerator
{
    public static class Section4
    {
        public static void Run()
        {
            // Generate, style, and convert a barcode in a single statement
            string value = "https://ironsoftware.com/csharp/barcode";
            
            // Create PDF417 barcode with chained operations
            AnyBitmap barcodeBitmap = BarcodeWriter
                .CreateBarcode(value, BarcodeWriterEncoding.PDF417)  // Create PDF417 barcode
                .ResizeTo(300, 200)                                  // Set specific dimensions
                .SetMargins(10)                                      // Add 10px margins
                .ToBitmap();                                         // Convert to bitmap
            
            // Convert to System.Drawing.Bitmap for legacy compatibility
            System.Drawing.Bitmap legacyBitmap = barcodeBitmap;
        }
    }
}
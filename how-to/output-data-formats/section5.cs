using System.Linq;
using BarCode;
namespace IronBarcode.Examples.HowTo.OutputDataFormats
{
    public static class Section5
    {
        public static void Run()
        {
            // Read barcode from PNG
            BarcodeResults result = BarcodeReader.Read("multiple-barcodes.png");
            
            AnyBitmap bitmap = AnyBitmap.FromFile("multiple-barcodes.png");
            
            foreach (BarcodeResult barcode in result)
            {
                PointF[] barcodePoints = barcode.Points;
            
                float x1 = barcodePoints.Select(b => b.X).Min();
                float y1 = barcodePoints.Select(b => b.Y).Min();
            
                Rectangle rectangle = new Rectangle((int)x1, (int)y1, (int)barcode.Width!, (int)barcode.Height!);
            
                bitmap = bitmap.Redact(rectangle, Color.Magenta);
            
                // Save the image
                bitmap.SaveAs("redacted.png", AnyBitmap.ImageFormat.Png);
            }
        }
    }
}
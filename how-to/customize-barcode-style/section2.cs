using IronBarCode;
using BarCode;
namespace IronBarcode.Examples.HowTo.CustomizeBarcodeStyle
{
    public static class Section2
    {
        public static void Run()
        {
            // Create barcode
            GeneratedBarcode barcode = BarcodeWriter.CreateBarcode("12345", BarcodeEncoding.Codabar, 250, 100);
            
            // Export barcode
            barcode.SaveAsPng("output.png");
            
            // Resize and export the barcode
            barcode.ResizeToMil(20, .73, 200).SaveAsPng("useResizeToMil.png");
        }
    }
}
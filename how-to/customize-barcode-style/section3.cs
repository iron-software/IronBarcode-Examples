using IronSoftware.Drawing;
using BarCode;
namespace ironbarcode.CustomizeBarcodeStyle
{
    public class Section3
    {
        public void Run()
        {
            GeneratedBarcode barcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.Aztec);
            
            // Change barcode color
            barcode.ChangeBarCodeColor(Color.DarkKhaki);
            
            // Change barcode's background color
            barcode.ChangeBackgroundColor(Color.ForestGreen);
            
            barcode.SaveAsPng("coloredAztec2.png");
        }
    }
}
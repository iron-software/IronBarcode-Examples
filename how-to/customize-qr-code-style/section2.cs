using IronSoftware.Drawing;
using BarCode;
namespace IronBarcode.Examples.HowTo.CustomizeQrCodeStyle
{
    public static class Section2
    {
        public static void Run()
        {
            AnyBitmap qrlogo = AnyBitmap.FromFile("ironbarcode_top.webp");
            
            QRCodeLogo logo = new QRCodeLogo(qrlogo, 0, 0, 20f);
            
            IronSoftware.Drawing.Color ColorFromRgb = new IronSoftware.Drawing.Color(51, 51, 153);
            
            GeneratedBarcode QrCodeWithLogo = QRCodeWriter.CreateQrCodeWithLogo("https://ironsoftware.com/csharp/barcode/", logo, 250);
            GeneratedBarcode QrCodeWithLogoAndColor = QrCodeWithLogo.ChangeBarCodeColor(ColorFromRgb);
            QrCodeWithLogoAndColor.SaveAsPng("ColorQrCodeWithLogo.png");
        }
    }
}
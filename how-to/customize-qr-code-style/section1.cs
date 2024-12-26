using IronSoftware.Drawing;
using BarCode;
namespace IronBarcode.Examples.HowTo.CustomizeQrCodeStyle
{
    public static class Section1
    {
        public static void Run()
        {
            AnyBitmap qrlogo = AnyBitmap.FromFile("ironbarcode_top.webp");
            
            QRCodeLogo logo = new QRCodeLogo(qrlogo, 0, 0, 20f);
            
            GeneratedBarcode QrCodeWithLogo = QRCodeWriter.CreateQrCodeWithLogo("https://ironsoftware.com/csharp/barcode/", logo, 250);
            
            QrCodeWithLogo.SaveAsPng("QrCodeWLogo2.png");
        }
    }
}
using IronSoftware.Drawing;
using BarCode;
namespace IronBarcode.Examples.Tutorial.CsharpQrCodeGenerator
{
    public static class Section4
    {
        public static void Run()
        {
            // Load logo image
            QRCodeLogo qrCodeLogo = new QRCodeLogo("visual-studio-logo.png");
            
            // Create QR code with embedded logo
            GeneratedBarcode myQRCodeWithLogo = QRCodeWriter.CreateQrCodeWithLogo("https://ironsoftware.com/", qrCodeLogo);
            
            // Customize appearance
            myQRCodeWithLogo.ResizeTo(500, 500).SetMargins(10).ChangeBarCodeColor(Color.DarkGreen);
            
            // Save the branded QR code
            myQRCodeWithLogo.SaveAsPng("myQRWithLogo.png");
        }
    }
}
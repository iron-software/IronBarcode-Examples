using IronSoftware.Drawing;
using BarCode;
namespace ironbarcode.CsharpQrCodeGenerator
{
    public class Section2
    {
        public void Run()
        {
            // You may add styling with color, logo images or branding:
            QRCodeLogo qrCodeLogo = new QRCodeLogo("visual-studio-logo.png");
            GeneratedBarcode myQRCodeWithLogo = QRCodeWriter.CreateQrCodeWithLogo("https://ironsoftware.com/", qrCodeLogo);
            myQRCodeWithLogo.ResizeTo(500, 500).SetMargins(10).ChangeBarCodeColor(Color.DarkGreen);
            
            // Logo will automatically be sized appropriately and snapped to the QR grid.
            myQRCodeWithLogo.SaveAsPng("myQRWithLogo.png");
        }
    }
}
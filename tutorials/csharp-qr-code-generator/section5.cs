using System.Drawing;
using BarCode;
namespace IronBarcode.Examples.Tutorial.CsharpQrCodeGenerator
{
    public static class Section5
    {
        public static void Run()
        {
            // Create QR code with logo
            QRCodeLogo qrCodeLogo = new QRCodeLogo("visual-studio-logo.png");
            GeneratedBarcode myQRCodeWithLogo = QRCodeWriter.CreateQrCodeWithLogo("https://ironsoftware.com/", qrCodeLogo);
            
            // Apply custom styling
            myQRCodeWithLogo.ChangeBarCodeColor(Color.DarkGreen);
            
            // Export to multiple formats
            myQRCodeWithLogo.SaveAsPdf("MyQRWithLogo.pdf");      // PDF document
            myQRCodeWithLogo.SaveAsHtmlFile("MyQRWithLogo.html"); // Standalone HTML
            myQRCodeWithLogo.SaveAsPng("MyQRWithLogo.png");       // PNG image
            myQRCodeWithLogo.SaveAsJpeg("MyQRWithLogo.jpg");      // JPEG image
        }
    }
}
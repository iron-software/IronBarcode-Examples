using IronSoftware.Drawing;
using BarCode;
namespace IronBarcode.Examples.Overview.Quickstart
{
    public static class Section8
    {
        public static void Run()
        {
            QRCodeLogo qrCodeLogo = new QRCodeLogo("visual-studio-logo.png");
            GeneratedBarcode myQRCodeWithLogo = QRCodeWriter.CreateQrCodeWithLogo("https://ironsoftware.com/csharp/barcode/", qrCodeLogo);
            myQRCodeWithLogo.ChangeBarCodeColor(Color.DarkGreen).SaveAsPdf("MyQRWithLogo.pdf");
        }
    }
}
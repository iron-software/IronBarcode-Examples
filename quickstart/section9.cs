using IronSoftware.Drawing;
using BarCode;
namespace ironbarcode.Quickstart
{
    public class Section9
    {
        public void Run()
        {
            QRCodeLogo qrCodeLogo = new QRCodeLogo("visual-studio-logo.png");
            GeneratedBarcode myQRCodeWithLogo = QRCodeWriter.CreateQrCodeWithLogo("https://ironsoftware.com/csharp/barcode/", qrCodeLogo);
            myQRCodeWithLogo.ChangeBarCodeColor(Color.DarkGreen).SaveAsPdf("MyQRWithLogo.pdf");
        }
    }
}
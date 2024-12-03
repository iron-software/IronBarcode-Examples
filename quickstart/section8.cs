using IronBarCode;
using BarCode;
namespace ironbarcode.Quickstart
{
    public class Section8
    {
        public void Run()
        {
            QRCodeWriter.CreateQrCode("https://ironsoftware.com", 500, QRCodeWriter.QrErrorCorrectionLevel.Medium).SaveAsPdf("MyQR.pdf");
        }
    }
}
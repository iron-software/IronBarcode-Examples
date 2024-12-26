using IronBarCode;
using BarCode;
namespace IronBarcode.Examples.Overview.Quickstart
{
    public static class Section8
    {
        public static void Run()
        {
            QRCodeWriter.CreateQrCode("https://ironsoftware.com", 500, QRCodeWriter.QrErrorCorrectionLevel.Medium).SaveAsPdf("MyQR.pdf");
        }
    }
}
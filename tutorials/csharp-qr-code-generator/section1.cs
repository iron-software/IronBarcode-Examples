using BarCode;
namespace IronBarcode.Examples.Tutorial.CsharpQrCodeGenerator
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Generate QR in One Line—Try It Now
            var qr = QRCodeWriter.CreateQrCode("https://ironsoftware.com/", 500, QRCodeWriter.QrErrorCorrectionLevel.Medium); qr.SaveAsPng("MyQR.png");
        }
    }
}
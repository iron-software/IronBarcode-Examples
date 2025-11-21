using BarCode;
namespace IronBarcode.Examples.HowTo.ErrorCorrection
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Generate QR Code with Medium Error Correction Instantly
            var qr = IronBarCode.QRCodeWriter.CreateQrCode("https://ironsoftware.com", 500, IronBarCode.QRCodeWriter.QrErrorCorrectionLevel.Medium).SaveAsPng("qr.png");
        }
    }
}
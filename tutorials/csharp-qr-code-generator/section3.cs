using IronBarCode;
using BarCode;
namespace IronBarcode.Examples.Tutorial.CsharpQrCodeGenerator
{
    public static class Section3
    {
        public static void Run()
        {
            // Generate a QR code with text content
            var qrCode = QRCodeWriter.CreateQrCode("hello world", 500, QRCodeWriter.QrErrorCorrectionLevel.Medium);
            qrCode.SaveAsPng("MyQR.png");
        }
    }
}
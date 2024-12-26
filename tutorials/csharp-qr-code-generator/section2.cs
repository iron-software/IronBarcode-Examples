using IronBarCode;
using BarCode;
namespace IronBarcode.Examples.Tutorial.CsharpQrCodeGenerator
{
    public static class Section2
    {
        public static void Run()
        {
            // Generate a Simple BarCode image and save as PDF
            QRCodeWriter.CreateQrCode("hello world", 500, QRCodeWriter.QrErrorCorrectionLevel.Medium).SaveAsPng("MyQR.png");
        }
    }
}
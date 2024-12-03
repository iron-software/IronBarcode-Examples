using IronBarCode;
using BarCode;
namespace ironbarcode.CsharpQrCodeGenerator
{
    public class Section1
    {
        public void Run()
        {
            // Generate a Simple BarCode image and save as PDF
            QRCodeWriter.CreateQrCode("hello world", 500, QRCodeWriter.QrErrorCorrectionLevel.Medium).SaveAsPng("MyQR.png");
        }
    }
}
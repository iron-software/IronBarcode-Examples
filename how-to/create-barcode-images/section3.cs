using IronBarCode;
using BarCode;
namespace IronBarcode.Examples.HowTo.CreateBarcodeImages
{
    public static class Section3
    {
        public static void Run()
        {
            QRCodeWriter.CreateQrCode("IronBarcode1234", 250, QRCodeWriter.QrErrorCorrectionLevel.Medium, qrVersion: 0).SaveAsJpeg("QRMedium.jpeg");
        }
    }
}
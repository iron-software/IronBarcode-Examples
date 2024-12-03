using IronBarCode;
using BarCode;
namespace ironbarcode.CreateBarcodeImages
{
    public class Section2
    {
        public void Run()
        {
            QRCodeWriter.CreateQrCode("IronBarcode1234", 250, QRCodeWriter.QrErrorCorrectionLevel.Medium, qrVersion: 0).SaveAsJpeg("QRMedium.jpeg");
        }
    }
}
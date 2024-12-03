using IronBarCode;
using BarCode;
namespace ironbarcode.FaultTolerance
{
    public class Section1
    {
        public void Run()
        {
            GeneratedBarcode mediumCorrection = QRCodeWriter.CreateQrCode("https://ironsoftware.com/csharp/barcode/", 500, QRCodeWriter.QrErrorCorrectionLevel.Medium);
            mediumCorrection.SaveAsPng("mediumCorrection.png");
        }
    }
}
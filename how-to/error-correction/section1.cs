using IronBarCode;
using BarCode;
namespace IronBarcode.Examples.HowTo.ErrorCorrection
{
    public static class Section1
    {
        public static void Run()
        {
            GeneratedBarcode mediumCorrection = QRCodeWriter.CreateQrCode("https://ironsoftware.com/csharp/barcode/", 500, QRCodeWriter.QrErrorCorrectionLevel.Medium);
            mediumCorrection.SaveAsPng("mediumCorrection.png");
        }
    }
}
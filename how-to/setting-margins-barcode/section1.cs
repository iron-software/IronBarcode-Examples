using IronBarCode;
using BarCode;
namespace IronBarcode.Examples.HowTo.SettingMarginsBarcode
{
    public static class Section1
    {
        public static void Run()
        {
            // Create a QR code
            GeneratedBarcode qrcode = BarcodeWriter.CreateBarcode(
                "https://ironsoftware.com/csharp/barcode",
                BarcodeWriterEncoding.QRCode
            );
            
            // Set consistent margins around the QR code
            qrcode.SetMargins(100);
            // Save the QR code as a PNG image
            qrcode.SaveAsPng("QRCode.png");
        }
    }
}
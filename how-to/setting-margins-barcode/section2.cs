using IronBarCode;
using BarCode;
namespace IronBarcode.Examples.HowTo.SettingMarginsBarcode
{
    public static class Section2
    {
        public static void Run()
        {
            // Create a QR code
            GeneratedBarcode qrcode = BarcodeWriter.CreateBarcode(
                "https://ironsoftware.com/csharp/barcode",
                BarcodeWriterEncoding.QRCode
            );
            
            // Set the QR code dimensions 10 pixel on top and bottom, 5 pixels on left and right
            qrcode.SetMargins(10, 5, 10, 5);
            
            
            // Save the QR code as a PNG file
            qrcode.SaveAsPng("QRCodeValue.png");
        }
    }
}
using System.IO;
using BarCode;
namespace ironbarcode.ExportBarcodeAsStream
{
    public class Section2
    {
        public void Run()
        {
            // Create one-dimensional barcode
            GeneratedBarcode barcode = BarcodeWriter.CreateBarcode("IronBarcode1234", BarcodeEncoding.Code128);
            
            // Convert barcode to JPEG stream
            Stream barcodeStream = barcode.ToStream(AnyBitmap.ImageFormat.Jpeg);
            
            // Create QR code
            GeneratedBarcode qrCode = QRCodeWriter.CreateQrCode("IronBarcode1234");
            
            // Convert QR code to JPEG stream
            Stream qrCodeStream = qrCode.ToJpegStream();
        }
    }
}
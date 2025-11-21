using System.IO;
using BarCode;
namespace IronBarcode.Examples.HowTo.ExportBarcodeAsStream
{
    public static class Section2
    {
        public static void Run()
        {
            // Create one-dimensional barcode
            GeneratedBarcode barcode = BarcodeWriter.CreateBarcode("IronBarcode1234", BarcodeEncoding.Code128);
            
            // Convert barcode to stream
            Stream barcodeStream = barcode.ToStream();
            
            // Create QR code
            GeneratedBarcode qrCode = QRCodeWriter.CreateQrCode("IronBarcode1234");
            
            // Convert QR code to stream
            Stream qrCodeStream = qrCode.ToStream();
        }
    }
}
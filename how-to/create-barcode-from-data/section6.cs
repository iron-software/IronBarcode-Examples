using System;
using System.IO;
using IronBarCode;
namespace IronBarcode.Examples.HowTo.CreateBarcodeFromData
{
    public static class Section6
    {
        public static void Run()
        {
            // Example: Encoding binary data (like a small file) into QR Code
            byte[] binaryData = File.ReadAllBytes("document.pdf");
            string base64Data = Convert.ToBase64String(binaryData);

            // Create QR code with high error correction for binary data
            GeneratedBarcode binaryBarcode = QRCodeWriter.CreateQrCode(
                base64Data,
                errorCorrection: QRCodeWriter.QrErrorCorrectionLevel.High
            );

            // Save with appropriate size for data density
            binaryBarcode.ResizeTo(500, 500);
            binaryBarcode.SaveAsPng("binary-data-qr.png");
        }
    }
}

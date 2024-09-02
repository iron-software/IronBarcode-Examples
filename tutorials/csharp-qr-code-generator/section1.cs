using IronBarCode;

// Generate a Simple BarCode image and save as PDF
QRCodeWriter.CreateQrCode("hello world", 500, QRCodeWriter.QrErrorCorrectionLevel.Medium).SaveAsPng("MyQR.png");
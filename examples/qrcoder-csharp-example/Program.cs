using IronBarCode;

QRCodeWriter.CreateQrCode("hello world", 500, QRCodeWriter.QrErrorCorrectionLevel.Medium).SaveAsPng("TestQR.png");

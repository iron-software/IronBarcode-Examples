using IronBarCode;

QRCodeWriter.CreateQrCode("IronBarcode1234", 250, QRCodeWriter.QrErrorCorrectionLevel.Medium, QrVersion: 0).SaveAsJpeg("QRMedium.jpeg");
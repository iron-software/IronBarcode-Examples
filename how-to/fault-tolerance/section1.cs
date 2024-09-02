using IronBarCode;

GeneratedBarcode mediumCorrection = QRCodeWriter.CreateQrCode("https://ironsoftware.com/csharp/barcode/", 500, QRCodeWriter.QrErrorCorrectionLevel.Medium);
mediumCorrection.SaveAsPng("mediumCorrection.png");
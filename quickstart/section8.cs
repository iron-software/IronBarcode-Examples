using IronBarCode;

QRCodeWriter.CreateQrCode("https://ironsoftware.com", 500, QRCodeWriter.QrErrorCorrectionLevel.Medium).SaveAsPdf("MyQR.pdf");
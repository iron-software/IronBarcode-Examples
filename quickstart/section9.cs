using IronBarCode;
using IronSoftware.Drawing;

QRCodeLogo qrCodeLogo = new QRCodeLogo("visual-studio-logo.png");
GeneratedBarcode myQRCodeWithLogo = QRCodeWriter.CreateQrCodeWithLogo("https://ironsoftware.com/csharp/barcode/", qrCodeLogo);
myQRCodeWithLogo.ChangeBarCodeColor(Color.DarkGreen).SaveAsPdf("MyQRWithLogo.pdf");
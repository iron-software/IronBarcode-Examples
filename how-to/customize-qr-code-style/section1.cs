using IronBarCode;
using IronSoftware.Drawing;

AnyBitmap qrlogo = AnyBitmap.FromFile("ironbarcode_top.webp");

QRCodeLogo logo = new QRCodeLogo(qrlogo, 0, 0, 20f);

GeneratedBarcode QrCodeWithLogo = QRCodeWriter.CreateQrCodeWithLogo("https://ironsoftware.com/csharp/barcode/", logo, 250);

QrCodeWithLogo.SaveAsPng("QrCodeWLogo2.png");

using IronBarCode;
using IronSoftware.Drawing;

GeneratedBarcode myQRCode = QRCodeWriter.CreateQrCode("https://ironsoftware.com/");

// You may add annotation text
myQRCode.SetMargins(40, 10, 10, 10);
myQRCode.AddAnnotationTextAboveBarcode("Your code is: " + myQRCode.Value).SaveAsPng("ironsoftware.png");

// You may add styling with color, logo images or branding:
var qrCodeLogo = new QRCodeLogo("ironsoftware_logo.png");
GeneratedBarcode myQRCodeWithLogo = QRCodeWriter.CreateQrCodeWithLogo("https://ironsoftware.com/", qrCodeLogo);
myQRCodeWithLogo.ResizeTo(500, 500).SetMargins(10).ChangeBarCodeColor(Color.DarkGreen);

// Logo will automatically be sized appropriately and snapped to the QR grid.
myQRCodeWithLogo.SaveAsPng("myQRWithLogo.png");

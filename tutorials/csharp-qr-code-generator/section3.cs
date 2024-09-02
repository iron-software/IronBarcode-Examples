using IronBarCode;

// You may add styling with color, logo images or branding:
QRCodeLogo qrCodeLogo = new QRCodeLogo("visual-studio-logo.png");
GeneratedBarcode myQRCodeWithLogo = QRCodeWriter.CreateQrCodeWithLogo("https://ironsoftware.com/", qrCodeLogo);

myQRCodeWithLogo.ChangeBarCodeColor(System.Drawing.Color.DarkGreen);

// Save as PDF
myQRCodeWithLogo.SaveAsPdf("MyQRWithLogo.pdf");

// Also Save as HTML
myQRCodeWithLogo.SaveAsHtmlFile("MyQRWithLogo.html");
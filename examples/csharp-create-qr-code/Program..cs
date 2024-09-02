using IronBarCode;

// Simplest example of creating a QR Code with no settings:
GeneratedBarcode myQRCode = QRCodeWriter.CreateQrCode("https://ironsoftware.com/");

// Advanced Example to set all parameters:

// The value of the QR code as a string. Also suitable for URLS.
string value = "https://ironsoftware.com/";

// The error correction level of the QR code.
var correction = QRCodeWriter.QrErrorCorrectionLevel.Highest;

// The width and height of the QR code in pixels.
int size = 500;

// QR Version. Please read https://www.qrcode.com/en/about/version.html
int qrVersion = 0;

GeneratedBarcode myQRCodeComplex = QRCodeWriter.CreateQrCode(value, size, correction, qrVersion);

using IronBarCode;

// The value of the QR code as a string. Also suitable for URLS
string value = "https://ironsoftware.com/";

// Simplest example of creating a QR Code with no settings
GeneratedBarcode myQRCode = QRCodeWriter.CreateQrCode(value);

// Advanced example with all parameters exclusive to QR codes set:

// The error correction level of the QR code
var correction = QRCodeWriter.QrErrorCorrectionLevel.Highest;

// The width and height of the QR code in pixels
int size = 500;

// QR version.
// Please read https://www.qrcode.com/en/about/version.html to learn more about what QR version is
int qrVersion = 0;

GeneratedBarcode myQRCodeComplex = QRCodeWriter.CreateQrCode(value, size, correction, qrVersion);

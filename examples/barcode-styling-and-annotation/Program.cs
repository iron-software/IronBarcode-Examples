using IronBarCode;
using System;
using System.Drawing;

/*** STYLING GENERATED BARCODES  ***/

// BarcodeWriter.CreateBarcode creates a GeneratedBarcode object which allows the barcode to be styled and annotated.
GeneratedBarcode MyBarCode = BarcodeWriter.CreateBarcode("Iron Software", BarcodeWriterEncoding.QRCode);

// Any text (or commonly, the value of the barcode) can be added to the image in a default or specified font.
// Text positions are automatically centered, above or below. Fonts that are too large for a given image are automatically scaled down.
MyBarCode.AddBarcodeValueTextBelowBarcode();
MyBarCode.AddAnnotationTextAboveBarcode("This is My Barcode", new Font(new FontFamily("Arial"), 12, FontStyle.Regular, GraphicsUnit.Pixel), Color.DarkSlateBlue);

// Resize, add margins and check final image dimensions
MyBarCode.ResizeTo(300, 300); // Resize in pixels
MyBarCode.SetMargins(0, 20, 0, 20); // Set margins in pixels

int FinalWidth = MyBarCode.Width;
int FinalHeight = MyBarCode.Height;

// Recolor the barcode and its background
MyBarCode.ChangeBackgroundColor(Color.LightGray);
MyBarCode.ChangeBarCodeColor(Color.DarkSlateBlue);
if (!MyBarCode.Verify())
{
    Console.WriteLine("Color contrast should be at least 50% or a barcode may become unreadable. Test using GeneratedBarcode.Verify()");
}

// Finally, save the result
MyBarCode.SaveAsHtmlFile("StyledBarcode.html");

/*** STYLING BARCODES IN A SINGLE LINQ-STYLE EXPRESSION ***/

// Create a barcode in one line of code
BarcodeWriter.CreateBarcode("https://ironsoftware.com", BarcodeWriterEncoding.Aztec).ResizeTo(250, 250).SetMargins(10).AddBarcodeValueTextAboveBarcode().SaveAsImage("StyledBarcode.png");

/*** STYLING QR CODES WITH LOGO IMAGES OR BRANDING ***/

// Use the QRCodeWriter.CreateQrCodeWithLogo Method instead of BarcodeWriter.CreateBarcode
// Logo will automatically be sized appropriately and snapped to the QR grid.

var qrCodeLogo = new QRCodeLogo("ironsoftware_logo.png");
GeneratedBarcode myQRCodeWithLogo = QRCodeWriter.CreateQrCodeWithLogo("https://ironsoftware.com/", qrCodeLogo);
myQRCodeWithLogo.ResizeTo(500, 500).SetMargins(10).ChangeBarCodeColor(Color.DarkGreen);
myQRCodeWithLogo.ResizeTo(500, 500).SetMargins(10).ChangeBarCodeColor(Color.DarkGreen);
myQRCodeWithLogo.SaveAsPng("QRWithLogo.Png").SaveAsPdf("MyVerifiedQR.html"); // Save as 2 different formats

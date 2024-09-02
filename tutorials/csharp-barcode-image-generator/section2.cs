using IronBarCode;
using IronSoftware.Drawing;

// Styling a QR code and adding annotation text
GeneratedBarcode myBarCode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode", BarcodeWriterEncoding.QRCode);
myBarCode.AddAnnotationTextAboveBarcode("Product URL:");
myBarCode.AddBarcodeValueTextBelowBarcode();
myBarCode.SetMargins(100);
myBarCode.ChangeBarCodeColor(Color.Purple);

// Save as HTML
myBarCode.SaveAsHtmlFile("MyBarCode.html");
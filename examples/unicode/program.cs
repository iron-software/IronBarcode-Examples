using IronBarCode;

// Unicode text with chinese and Arabic characters
string text = "ABC 中国 العربيّة";

// Create a PDF417 barcode with the specified text
var myBarcode = BarcodeWriter.CreateBarcode(text, BarcodeWriterEncoding.PDF417);

// Save the barcode as an image
myBarcode.SaveAsImage("Unicode.jpeg");

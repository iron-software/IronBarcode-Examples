using IronBarCode;
using IronSoftware.Drawing;

// Create a barcode
var myBarcode = BarcodeWriter.CreateBarcode("12345", BarcodeWriterEncoding.EAN8);

// Resize in pixels
myBarcode.ResizeTo(400, 100);

// Set margins in pixels
myBarcode.SetMargins(5, 5, 5, 5);

// Set the color of the barcode
myBarcode.ChangeBarCodeColor(Color.Red);

// And save our barcode as an image:
myBarcode.SaveAsImage("EAN8.jpeg");

// Another supported feature is Mil Sizing
// Mil is a measurement unit used by the barcode scanner manufacturers to specify the minimum of one barcode bar, and at what distance the barcode can be scanned.
// It represents (1 / 1000)th of an inch
var barcodeResizeInMils = BarcodeWriter.CreateBarcode("5941623002802", BarcodeEncoding.Code128);

// This will resize the barcode width to 13 mil, at 96 DPI by default
barcodeResizeInMils.ResizeToMil(13);

// This will resize the barcode width to 10 mil and and the height to 1.5 inches, at 96 DPI by default
barcodeResizeInMils.ResizeToMil(10, 1.5);

// This will resize the barcode width to 7.5 mil and the height to 2 inches, with the DPI set to 200
barcodeResizeInMils.ResizeToMil(7.5, 2, 200);

using IronBarCode;
using IronSoftware.Drawing;

// Creating a barcode is as simple as:
var myBarcode = BarcodeWriter.CreateBarcode("12345", BarcodeWriterEncoding.EAN8);

// Resize:
myBarcode.ResizeTo(400, 100);

// Set Margins and Color for Barcode
myBarcode.SetMargins(5, 5, 5, 5);
myBarcode.ChangeBarCodeColor(Color.Red);

// And save our barcode as an image:
myBarcode.SaveAsImage("EAN8.jpeg");

// Another supported feature is MIL Sizing:
// Barcode mils are used by the bar code scanner manufactures to state the minimum bar code bar width of one bar, and at what distance the barcode can be scanned.
var barcodeResizeInMils = BarcodeWriter.CreateBarcode("5941623002802", BarcodeEncoding.Code128);

// This will resize the Barcode with the MIL size 13 and the default height of 1 inch and default DPI of 96
barcodeResizeInMils.ResizeToMil(13);
// This will resize the Barcode with the MIL size 10 and the expected height of 1.5 inch and default DPI of 96
barcodeResizeInMils.ResizeToMil(10, 1.5);
// This will resize the Barcode with the MIL size 7.5 and the expected height of 2 inch and expected DPI of 200
barcodeResizeInMils.ResizeToMil(7.5, 2, 200);

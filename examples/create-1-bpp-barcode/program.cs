using IronBarCode;

var myBarcode = BarcodeWriter.CreateBarcode("12345", BarcodeWriterEncoding.EAN8);

myBarcode.SaveAs1BppBitmap("1bppImage.bmp");
var byteData = myBarcode.To1BppBinaryData();
var anyBitmap = myBarcode.To1BppImage();

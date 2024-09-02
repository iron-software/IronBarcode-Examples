using IronBarCode;

// Create barcode
GeneratedBarcode barcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.PDF417, 300, 100);

// Export barcode
barcode.SaveAsPng("output.png");

// Resize and export the barcode
barcode.ResizeTo(250, 100).SaveAsPng("useResizeTo.png");
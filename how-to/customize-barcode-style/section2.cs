using IronBarCode;

// Create barcode
GeneratedBarcode barcode = BarcodeWriter.CreateBarcode("12345", BarcodeEncoding.Codabar, 250, 100);

// Export barcode
barcode.SaveAsPng("output.png");

// Resize and export the barcode
barcode.ResizeToMil(20, .73, 200).SaveAsPng("useResizeToMil.png");
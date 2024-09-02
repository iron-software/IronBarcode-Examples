using IronBarCode;

BarcodeWriter.CreateBarcode("IronBarcode123", BarcodeEncoding.Code128, 200, 100).SaveAsJpeg("OneDBarcode.jpeg");
using IronBarCode;
using System.IO;

// Create one-dimensional barcode
GeneratedBarcode barcode = BarcodeWriter.CreateBarcode("IronBarcode1234", BarcodeEncoding.Code128);

// Convert barcode to stream
Stream barcodeStream = barcode.ToStream();

// Create QR code
GeneratedBarcode qrCode = QRCodeWriter.CreateQrCode("IronBarcode1234");

// Convert QR code to stream
Stream qrCodeStream = qrCode.ToStream();
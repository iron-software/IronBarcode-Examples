using IronBarCode;

// Create a QR code
GeneratedBarcode qrcode = BarcodeWriter.CreateBarcode(
    "https://ironsoftware.com/csharp/barcode",
    BarcodeWriterEncoding.QRCode
);

// Set consistent margins around the QR code
qrcode.SetMargins(100);
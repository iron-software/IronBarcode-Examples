using IronBarCode;

// Read barcode from PNG
BarcodeResults result = BarcodeReader.Read("multiple-barcodes.png");

int i = 1;
foreach (BarcodeResult barcode in result)
{
    var binaryValue = barcode.BinaryValue;
    var barcodeType = IronBarCode.BarcodeEncoding.QRCode;

    // Create QR code
    GeneratedBarcode generatedBarcode = BarcodeWriter.CreateBarcode(binaryValue, barcodeType);

    // Export QR code
    generatedBarcode.SaveAsPng($"qrFromBinary{i}.png");
    i++;
}
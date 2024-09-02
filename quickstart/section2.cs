using IronBarCode;

BarcodeReaderOptions myOptionsExample = new BarcodeReaderOptions()
{
    ExpectMultipleBarcodes = false,
    ExpectBarcodeTypes = BarcodeEncoding.QRCode | BarcodeEncoding.Code128,
    CropArea = new System.Drawing.Rectangle(100, 200, 300, 400),
};

BarcodeResults result = BarcodeReader.Read("QuickStart.jpg", myOptionsExample);
if (result != null)
{
    Console.WriteLine(result.First().Text);
}
using IronBarCode;
using IronSoftware.Drawing;

GeneratedBarcode barcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.Aztec);

// Change barcode color
barcode.ChangeBarCodeColor(Color.DarkKhaki);

// Change barcode's background color
barcode.ChangeBackgroundColor(Color.ForestGreen);

barcode.SaveAsPng("coloredAztec2.png");
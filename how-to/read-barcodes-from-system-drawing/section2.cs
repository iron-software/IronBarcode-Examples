using IronBarCode;
using IronSoftware.Drawing;
using System;
using System.Collections.Generic;

List<AnyBitmap> barcodes = new List<AnyBitmap>();

System.Drawing.Bitmap bitmapFromBitmap = new System.Drawing.Bitmap("test1.jpg");
AnyBitmap barcode1 = bitmapFromBitmap;
barcodes.Add(barcode1);

System.Drawing.Image bitmapFromFile = System.Drawing.Image.FromFile("test2.png");
AnyBitmap barcode2 = bitmapFromFile;
barcodes.Add(barcode2);

foreach (var barcode in barcodes)
{
    // Read the barcode
    var results = BarcodeReader.Read(barcode);
    foreach (var result in results)
    {
        // Output the detected barcode value
        Console.WriteLine(result.Value);
    }
}
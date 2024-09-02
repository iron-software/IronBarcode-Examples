using IronSoftware.Drawing;
using System.Collections.Generic;

List<AnyBitmap> barcodes = new List<AnyBitmap>();

// Instantiate System.Drawing.Bitmap
System.Drawing.Bitmap bitmapFromBitmap = new System.Drawing.Bitmap("test1.jpg");

// Cast from System.Drawing.Bitmap to AnyBitmap
AnyBitmap barcode1 = bitmapFromBitmap;

barcodes.Add(barcode1);

// Instantiate System.Drawing.Bitmap
System.Drawing.Image bitmapFromFile = System.Drawing.Image.FromFile("test2.png");

// Cast from System.Drawing.Image to AnyBitmap
AnyBitmap barcode2 = bitmapFromFile;

barcodes.Add(barcode2);
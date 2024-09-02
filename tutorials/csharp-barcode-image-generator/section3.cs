using IronBarCode;
using IronSoftware.Drawing;

// Fluent API for Barcode Image generation.
string value = "https://ironsoftware.com/csharp/barcode";
AnyBitmap barcodeBitmap = BarcodeWriter.CreateBarcode(value, BarcodeEncoding.PDF417).ResizeTo(300, 200).SetMargins(100).ToBitmap();
System.Drawing.Bitmap barcodeLegacyBitmap = (System.Drawing.Bitmap)barcodeBitmap;
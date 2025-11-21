using IronBarCode;
using IronSoftware.Drawing;
using System.Drawing;
using System.IO;

// Reading a barcode is easy with IronBarcode

// From an image file
var resultFromFile = BarcodeReader.Read(@"file/barcode.png");

// From a Bitmap object
var resultFromBitMap = BarcodeReader.Read(new Bitmap("barcode.bmp"));

// From a IronSoftware.Drawing.AnyBitmap object
var resultFromAnyBitmap = BarcodeReader.Read(new AnyBitmap("barcode.bmp"));

// From an Image object
var resultFromImage = BarcodeReader.Read(Image.FromFile("barcode.jpg"));

// From a memory stream
MemoryStream imageMemoryStream = new MemoryStream();
var resultFromStream = BarcodeReader.Read(imageMemoryStream); // From a stream

// PDFs are more intricate and must be read using ReadPdf
var resultFromPdf = BarcodeReader.ReadPdf(@"file/mydocument.pdf");

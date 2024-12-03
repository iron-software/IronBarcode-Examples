using IronBarCode;
using IronSoftware.Drawing;
using System.Drawing;
using System.IO;

// Reading a barcode is easy with IronBarcode.
// Read from a File, Bitmap, Image, or Stream:

var resultFromFile = BarcodeReader.Read(@"file/barcode.png"); // From a file

var resultFromBitMap = BarcodeReader.Read(new Bitmap("barcode.bmp")); // From a bitmap

var resultFromAnyBitmap = BarcodeReader.Read(new AnyBitmap("barcode.bmp")); // From an Anybitmap

var resultFromImage = BarcodeReader.Read(Image.FromFile("barcode.jpg")); // From an image

var resultFromStream = BarcodeReader.Read(myStream); // From a stream

// PDFs are more intricate and must be read using ReadPdf:
var resultFromPdf = BarcodeReader.ReadPdf(@"file/mydocument.pdf");

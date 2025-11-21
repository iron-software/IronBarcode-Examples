using IronBarCode;
using System.Drawing;

/*** CREATING BARCODE IMAGES ***/

// Create and save a barcode in a single line of code
BarcodeWriter.CreateBarcode("12345", BarcodeWriterEncoding.EAN8).ResizeTo(400, 100).SaveAsImage("EAN8.jpeg");

/*****  IN-DEPTH BARCODE CREATION OPTIONS *****/

// BarcodeWriter.CreateBarcode creates a GeneratedBarcode which can be styled and exported as an Image object or file
GeneratedBarcode MyBarCode = BarcodeWriter.CreateBarcode("Any Number, String or Binary Value", BarcodeWriterEncoding.Code128);

// Style the Barcode in a fluent LINQ-style fashion
MyBarCode.ResizeTo(300, 150).SetMargins(20).AddAnnotationTextAboveBarcode("Example EAN8 Barcode").AddBarcodeValueTextBelowBarcode();
MyBarCode.ChangeBackgroundColor(Color.LightGoldenrodYellow);

// Save the barcode as an image file
MyBarCode.SaveAsImage("MyBarCode.png");
MyBarCode.SaveAsGif("MyBarCode.gif");
MyBarCode.SaveAsHtmlFile("MyBarCode.html");
MyBarCode.SaveAsJpeg("MyBarCode.jpg");
MyBarCode.SaveAsPdf("MyBarCode.Pdf");
MyBarCode.SaveAsPng("MyBarCode.png");
MyBarCode.SaveAsTiff("MyBarCode.tiff");
MyBarCode.SaveAsWindowsBitmap("MyBarCode.bmp");

// Save the barcode as a .NET native object
Image MyBarCodeImage = MyBarCode.Image;
Bitmap MyBarCodeBitmap = MyBarCode.ToBitmap();

byte[] PngBytes = MyBarCode.ToPngBinaryData();

using (System.IO.Stream PdfStream = MyBarCode.ToPdfStream())
{
    // Stream barcode image output also works for GIF, JPEG, PDF, PNG, BMP and TIFF
}

// Save MyBarCode as an HTML file or tag
MyBarCode.SaveAsHtmlFile("MyBarCode.Html");
string ImgTagForHTML = MyBarCode.ToHtmlTag();
string DataURL = MyBarCode.ToDataUrl();

// Save MyBarCode to a new PDF, or stamp it in any position on any page(s) of an existing document
MyBarCode.SaveAsPdf("MyBarCode.Pdf");
MyBarCode.StampToExistingPdfPage("ExistingPDF.pdf", 200, 50, 1);  // Position (200, 50) on page 1
MyBarCode.StampToExistingPdfPages("ExistingPDF.pdf", 200, 50, new[] { 1, 2, 3 }, "Password123");  // Multiple pages of an encrypted PDF

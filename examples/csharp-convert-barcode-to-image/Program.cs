﻿using IronBarCode;
using System.Drawing;

// BarcodeWriter.CreateBarcode creates a GeneratedBarcode which can be styled and exported as an Image object or File
GeneratedBarcode MyBarCode = BarcodeWriter.CreateBarcode("Any Number, String or Binary Value", BarcodeWriterEncoding.Code128);

// And save the Barcode as any image format:
MyBarCode.SaveAsImage("MyBarCode.png");
MyBarCode.SaveAsGif("MyBarCode.gif");
MyBarCode.SaveAsHtmlFile("MyBarCode.html");
MyBarCode.SaveAsJpeg("MyBarCode.jpg");
MyBarCode.SaveAsPdf("MyBarCode.Pdf");
MyBarCode.SaveAsPng("MyBarCode.png");
MyBarCode.SaveAsTiff("MyBarCode.tiff");
MyBarCode.SaveAsWindowsBitmap("MyBarCode.bmp");

// You may also choose to use Barcode as a native .NET object:
Image MyBarCodeImage = MyBarCode.Image;
Bitmap MyBarCodeBitmap = MyBarCode.ToBitmap();

// Saving the barcode as an HTML file or as tags:
MyBarCode.SaveAsHtmlFile("MyBarCode.Html");
string ImgTagForHTML = MyBarCode.ToHtmlTag();
string DataURL = MyBarCode.ToDataUrl();

// Save the barcode as a new PDF,
MyBarCode.SaveAsPdf("MyBarCode.Pdf");

// Or Stamp it in any position on any page of an existing PDF:
MyBarCode.StampToExistingPdfPage("ExistingPDF.pdf", 200, 50, 1);  // position 200x50 on page 1

// Or multiple pages of an encrypted PDF
MyBarCode.StampToExistingPdfPages("ExistingPDF.pdf", 200, 50, new[] { 1, 2, 3 }, "Password123"); // With password as Password123

// PDF Stream Example:
using (System.IO.Stream PdfStream = MyBarCode.ToPdfStream())
{
    // Stream barcode image output also works for GIF, JPEG, PDF, PNG, BMP and TIFF
}

// PNG Byte Array Example:
byte[] PngBytes = MyBarCode.ToPngBinaryData();

using IronBarCode;

var myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode", BarcodeEncoding.Code128);
myBarcode.SaveAsImage("myBarcode.png");
myBarcode.SaveAsGif("myBarcode.gif");
myBarcode.SaveAsHtmlFile("myBarcode.html");
myBarcode.SaveAsJpeg("myBarcode.jpg");
myBarcode.SaveAsPdf("myBarcode.Pdf");
myBarcode.SaveAsPng("myBarcode.png");
myBarcode.SaveAsTiff("myBarcode.tiff");
myBarcode.SaveAsWindowsBitmap("myBarcode.bmp");
Image myBarcodeImage = myBarcode.Image;
Bitmap myBarcodeBitmap = myBarcode.ToBitmap();
string dataUrl = myBarcode.ToDataUrl();
string imgTagForHtml = myBarcode.ToHtmlTag();
byte[] pngBytes = myBarcode.ToPngBinaryData();

// Binary barcode image output also works for GIF,JPEG, PDF, PNG, BMP and TIFF
using (System.IO.Stream pdfStream = myBarcode.ToPdfStream())
{
    // Stream barcode image output also works for GIF,JPEG, PDF, PNG, BMP and TIFF
}
myBarcode.StampToExistingPdfPage("ExistingPDF.pdf", 1, 200, 50);
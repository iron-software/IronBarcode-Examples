using IronSoftware.Drawing;
using BarCode;
namespace ironbarcode.CsharpBarcodeImageGenerator
{
    public class Section2
    {
        public void Run()
        {
            // Styling a QR code and adding annotation text
            GeneratedBarcode myBarCode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode", BarcodeWriterEncoding.QRCode);
            myBarCode.AddAnnotationTextAboveBarcode("Product URL:");
            myBarCode.AddBarcodeValueTextBelowBarcode();
            myBarCode.SetMargins(100);
            myBarCode.ChangeBarCodeColor(Color.Purple);
            
            // Save as HTML
            myBarCode.SaveAsHtmlFile("MyBarCode.html");
        }
    }
}
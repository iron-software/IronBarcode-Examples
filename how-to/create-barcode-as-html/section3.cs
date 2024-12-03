using IronBarCode;
using BarCode;
namespace ironbarcode.CreateBarcodeAsHtml
{
    public class Section3
    {
        public void Run()
        {
            GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.QRCode);
            myBarcode.SaveAsHtmlFile("myBarcode.html");
        }
    }
}
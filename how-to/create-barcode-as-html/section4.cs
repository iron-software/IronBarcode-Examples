using IronBarCode;
using BarCode;
namespace IronBarcode.Examples.HowTo.CreateBarcodeAsHtml
{
    public static class Section4
    {
        public static void Run()
        {
            GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.QRCode);
            myBarcode.SaveAsHtmlFile("myBarcode.html");
        }
    }
}
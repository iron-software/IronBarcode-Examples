using IronBarCode;
using BarCode;
namespace IronBarcode.Examples.Overview.Quickstart
{
    public static class Section6
    {
        public static void Run()
        {
            GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode", BarcodeEncoding.Code128);
            myBarcode.AddAnnotationTextAboveBarcode("Product URL:");
            myBarcode.AddBarcodeValueTextBelowBarcode();
            myBarcode.SaveAsImage("myBarcode.png");
        }
    }
}
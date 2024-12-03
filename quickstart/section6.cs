using IronBarCode;
using BarCode;
namespace ironbarcode.Quickstart
{
    public class Section6
    {
        public void Run()
        {
            GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode", BarcodeEncoding.Code128);
            myBarcode.AddAnnotationTextAboveBarcode("Product URL:");
            myBarcode.AddBarcodeValueTextBelowBarcode();
            myBarcode.SaveAsImage("myBarcode.png");
        }
    }
}
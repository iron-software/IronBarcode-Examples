using IronBarCode;
using BarCode;
namespace ironbarcode.Quickstart
{
    public class Section7
    {
        public void Run()
        {
            GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode", BarcodeEncoding.Code128);
            myBarcode.AddAnnotationTextAboveBarcode("Product URL:");
            myBarcode.AddBarcodeValueTextBelowBarcode();
            myBarcode.SetMargins(100);
            myBarcode.ChangeBarCodeColor(IronSoftware.Drawing.Color.Purple);
            
            // All major image formats supported as well as PDF and HTML
            myBarcode.SaveAsPng("myBarcode.png");
        }
    }
}
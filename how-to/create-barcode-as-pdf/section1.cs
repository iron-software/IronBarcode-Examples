using IronBarCode;
using BarCode;
namespace ironbarcode.CreateBarcodeAsPdf
{
    public class Section1
    {
        public void Run()
        {
            GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.DataMatrix);
            myBarcode.SaveAsPdf("myBarcode.pdf");
        }
    }
}
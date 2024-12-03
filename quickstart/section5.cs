using IronBarCode;
using BarCode;
namespace ironbarcode.Quickstart
{
    public class Section5
    {
        public void Run()
        {
            GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode", BarcodeEncoding.Code128);
            myBarcode.SaveAsImage("myBarcode.png");
        }
    }
}
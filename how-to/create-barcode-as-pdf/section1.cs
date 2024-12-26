using IronBarCode;
using BarCode;
namespace IronBarcode.Examples.HowTo.CreateBarcodeAsPdf
{
    public static class Section1
    {
        public static void Run()
        {
            GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.DataMatrix);
            myBarcode.SaveAsPdf("myBarcode.pdf");
        }
    }
}
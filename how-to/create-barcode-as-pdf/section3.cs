using IronBarCode;
using BarCode;
namespace IronBarcode.Examples.HowTo.CreateBarcodeAsPdf
{
    public static class Section3
    {
        public static void Run()
        {
            GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.DataMatrix);
            byte[] myBarcodeByte = myBarcode.ToPdfBinaryData();
        }
    }
}
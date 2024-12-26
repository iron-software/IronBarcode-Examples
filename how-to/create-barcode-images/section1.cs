using IronBarCode;
using BarCode;
namespace IronBarcode.Examples.HowTo.CreateBarcodeImages
{
    public static class Section1
    {
        public static void Run()
        {
            BarcodeWriter.CreateBarcode("IronBarcode123", BarcodeEncoding.Code128, 200, 100).SaveAsJpeg("OneDBarcode.jpeg");
        }
    }
}
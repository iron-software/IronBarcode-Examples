using IronBarCode;
using BarCode;
namespace IronBarcode.Examples.HowTo.CreateBarcodeImages
{
    public static class Section2
    {
        public static void Run()
        {
            BarcodeWriter.CreateBarcode("IronBarcode123", BarcodeEncoding.Code128, 200, 100).SaveAsJpeg("OneDBarcode.jpeg");
        }
    }
}
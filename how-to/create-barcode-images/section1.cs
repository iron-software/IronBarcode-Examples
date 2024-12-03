using IronBarCode;
using BarCode;
namespace ironbarcode.CreateBarcodeImages
{
    public class Section1
    {
        public void Run()
        {
            BarcodeWriter.CreateBarcode("IronBarcode123", BarcodeEncoding.Code128, 200, 100).SaveAsJpeg("OneDBarcode.jpeg");
        }
    }
}
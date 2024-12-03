using IronBarCode;
using BarCode;
namespace ironbarcode.CreateBarcodeAsPdf
{
    public class Section2
    {
        public void Run()
        {
            GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.DataMatrix);
            byte[] myBarcodeByte = myBarcode.ToPdfBinaryData();
        }
    }
}
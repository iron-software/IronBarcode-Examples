using System.IO;
using BarCode;
namespace ironbarcode.CreateBarcodeAsPdf
{
    public class Section3
    {
        public void Run()
        {
            GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.DataMatrix);
            Stream myBarcodeStream = myBarcode.ToPdfStream();
        }
    }
}
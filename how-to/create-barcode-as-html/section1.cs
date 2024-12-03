using System;
using BarCode;
namespace ironbarcode.CreateBarcodeAsHtml
{
    public class Section1
    {
        public void Run()
        {
            GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.QRCode);
            var dataUrl = myBarcode.ToDataUrl();
            Console.WriteLine(dataUrl);
        }
    }
}
using System;
using BarCode;
namespace ironbarcode.CreateBarcodeAsHtml
{
    public class Section2
    {
        public void Run()
        {
            GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.QRCode);
            var htmlTag = myBarcode.ToHtmlTag();
            Console.WriteLine(htmlTag);
        }
    }
}
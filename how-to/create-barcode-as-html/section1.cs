using System;
using BarCode;
namespace IronBarcode.Examples.HowTo.CreateBarcodeAsHtml
{
    public static class Section1
    {
        public static void Run()
        {
            GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.QRCode);
            var dataUrl = myBarcode.ToDataUrl();
            Console.WriteLine(dataUrl);
        }
    }
}
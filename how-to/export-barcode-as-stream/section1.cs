using BarCode;
namespace IronBarcode.Examples.HowTo.ExportBarcodeAsStream
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Generate Barcode Stream in One Line
            var stream = BarcodeWriter.CreateBarcode("Quick123", BarcodeEncoding.Code128).ToStream();
        }
    }
}
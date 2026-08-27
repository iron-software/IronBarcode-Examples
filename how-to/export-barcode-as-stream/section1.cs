using IronBarCode;
namespace IronBarcode.Examples.HowTo.ExportBarcodeAsStream
{
    public static class Section1
    {
        public static void Run()
        {
            var stream = BarcodeWriter.CreateBarcode("Quick123", BarcodeEncoding.Code128).ToStream();
        }
    }
}
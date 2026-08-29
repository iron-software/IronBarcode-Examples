using IronBarCode;
namespace IronBarcode.Examples.HowTo.CreateBarcodeFromData
{
    public static class Section1
    {
        public static void Run()
        {
            var barcode = IronBarCode.BarcodeWriter.CreateBarcode("Order123", IronBarCode.BarcodeWriterEncoding.Code128);
        }
    }
}
using IronBarCode;
namespace IronBarcode.Examples.HowTo.Create1BppBarcodeImages
{
    public static class Section1
    {
        public static void Run()
        {
            var img = IronBarCode.BarcodeWriter.CreateBarcode("12345", IronBarCode.BarcodeWriterEncoding.EAN8).To1BppImage();
        }
    }
}
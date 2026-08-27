using IronBarCode;
namespace IronBarcode.Examples.Tutorial.CsharpBarcodeImageGenerator
{
    public static class Section1
    {
        public static void Run()
        {
            IronBarCode.BarcodeWriter.CreateBarcode("Hello123", BarcodeWriterEncoding.Code128, 200, 100).SaveAsPng("barcode.png");
        }
    }
}
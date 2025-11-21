using BarCode;
namespace IronBarcode.Examples.Tutorial.CsharpBarcodeImageGenerator
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Generate Barcode Image in One Line
            IronBarCode.BarcodeWriter.CreateBarcode("Hello123", BarcodeWriterEncoding.Code128, 200, 100).SaveAsPng("barcode.png");
        }
    }
}
using BarCode;
namespace IronBarcode.Examples.HowTo.CreateBarcodeImages
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Generate Barcode Image Instantly
            IronBarCode.BarcodeWriter.CreateBarcode("Sample123", BarcodeEncoding.Code128, 250, 100).SaveAsPng("Barcode.png");
        }
    }
}
using BarCode;
namespace IronBarcode.Examples.HowTo.ImageOrientationCorrection
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Fix Barcodes Fast with AutoRotate
            var result = IronBarCode.BarcodeReader.Read("rotatedImage.png", new IronBarCode.BarcodeReaderOptions { AutoRotate = true });
        }
    }
}
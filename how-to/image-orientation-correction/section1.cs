using IronBarCode;
namespace IronBarcode.Examples.HowTo.ImageOrientationCorrection
{
    public static class Section1
    {
        public static void Run()
        {
            var result = IronBarCode.BarcodeReader.Read("rotatedImage.png", new IronBarCode.BarcodeReaderOptions { AutoRotate = true });
        }
    }
}
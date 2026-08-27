using IronBarCode;
namespace IronBarcode.Examples.HowTo.ReadingSpeedOptions
{
    public static class Section1
    {
        public static void Run()
        {
            var results = IronBarCode.BarcodeReader.Read("path/to/image.png", new IronBarCode.BarcodeReaderOptions { Speed = IronBarCode.ReadingSpeed.Balanced });
        }
    }
}
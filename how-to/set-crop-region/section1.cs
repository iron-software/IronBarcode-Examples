using BarCode;
namespace IronBarcode.Examples.HowTo.SetCropRegion
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Set Crop Region in One Line—Boost Read Speed Instantly
            var results = IronBarCode.BarcodeReader.Read("image.png", new IronBarCode.BarcodeReaderOptions { CropArea = new IronSoftware.Drawing.Rectangle(x: 50, y: 100, width: 300, height: 150) });
        }
    }
}
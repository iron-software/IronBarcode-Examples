using BarCode;
namespace IronBarcode.Examples.HowTo.ImageCorrection
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Boost Barcode Readability — Try Image Correction Now
            BarcodeResults results = IronBarCode.BarcodeReader.Read("input.png", new IronBarCode.BarcodeReaderOptions { ImageFilters = new IronBarCode.ImageFilterCollection() { new IronBarCode.SharpenFilter(3.5f), new IronBarCode.ContrastFilter(2.0f) } });
        }
    }
}
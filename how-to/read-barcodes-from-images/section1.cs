using IronBarCode;
namespace IronBarcode.Examples.HowTo.ReadBarcodesFromImages
{
    public static class Section1
    {
        public static void Run()
        {
            var results = IronBarCode.BarcodeReader.Read("path/to/image.png");
        }
    }
}
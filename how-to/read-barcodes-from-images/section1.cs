using BarCode;
namespace IronBarcode.Examples.HowTo.ReadBarcodesFromImages
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Read Barcodes in One Easy Line
            var results = IronBarCode.BarcodeReader.Read("path/to/image.png");
        }
    }
}
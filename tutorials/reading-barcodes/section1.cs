using IronBarCode;
namespace IronBarcode.Examples.Tutorial.ReadingBarcodes
{
    public static class Section1
    {
        public static void Run()
        {
            var results = IronBarCode.BarcodeReader.Read("path/to/barcode.png");
        }
    }
}
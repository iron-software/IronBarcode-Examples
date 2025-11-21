using BarCode;
namespace IronBarcode.Examples.Tutorial.ReadingBarcodes
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Scan Barcodes in One Line – Try It Now!
            var results = IronBarCode.BarcodeReader.Read("path/to/barcode.png");
        }
    }
}
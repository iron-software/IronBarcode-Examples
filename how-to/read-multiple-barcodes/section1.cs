using BarCode;
namespace IronBarcode.Examples.HowTo.ReadMultipleBarcodes
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Read Multiple Barcodes Instantly
            var results = IronBarCode.BarcodeReader.Read("image.png", new IronBarCode.BarcodeReaderOptions { ExpectMultipleBarcodes = true, ExpectBarcodeTypes = IronBarCode.BarcodeEncoding.AllOneDimensional });
        }
    }
}
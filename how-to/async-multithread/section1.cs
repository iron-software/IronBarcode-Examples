using BarCode;
namespace IronBarcode.Examples.HowTo.AsyncMultithread
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Start Async & Multithreaded Barcode Reads Fast
            var results = await IronBarCode.BarcodeReader.ReadAsync(imagePaths, new IronBarCode.BarcodeReaderOptions { Multithreaded = true, MaxParallelThreads = 4, ExpectMultipleBarcodes = true });
        }
    }
}
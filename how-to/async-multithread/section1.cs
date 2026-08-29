using System.Collections.Generic;
using System.Threading.Tasks;
using IronBarCode;
namespace IronBarcode.Examples.HowTo.AsyncMultithread
{
    public static class Section1
    {
        public static async Task Run()
        {
            var imagePaths = new List<string> { "image1.png", "image2.png" };

            var results = await IronBarCode.BarcodeReader.ReadAsync(imagePaths, new IronBarCode.BarcodeReaderOptions { Multithreaded = true, MaxParallelThreads = 4, ExpectMultipleBarcodes = true });
        }
    }
}
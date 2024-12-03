using System.Linq;
using BarCode;
namespace ironbarcode.CsharpQrCodeGenerator
{
    public class Section7
    {
        public void Run()
        {
            BarcodeReaderOptions options = new BarcodeReaderOptions
            {
                Speed = ReadingSpeed.Faster,
                ExpectMultipleBarcodes = false,
                ExpectBarcodeTypes = BarcodeEncoding.All,
                Multithreaded = false,
                MaxParallelThreads = 0,
                CropArea = null,
                UseCode39ExtendedMode = false,
                RemoveFalsePositive = false,
                ImageFilters = null
            };
            
            BarcodeResults result = BarcodeReader.Read("QR.png", options);
            if (result != null)
            {
                Console.WriteLine(result.First().Value);
            }
        }
    }
}
using System.Linq;
using BarCode;
namespace IronBarcode.Examples.Tutorial.CsharpQrCodeGenerator
{
    public static class Section9
    {
        public static void Run()
        {
            // Configure advanced reading options
            BarcodeReaderOptions options = new BarcodeReaderOptions
            {
                Speed = ReadingSpeed.Faster,           // Optimize for speed
                ExpectMultipleBarcodes = false,        // Single QR code expected
                ExpectBarcodeTypes = BarcodeEncoding.QRCode, // QR codes only
                Multithreaded = true,                  // Enable parallel processing
                MaxParallelThreads = 4,                // Utilize multiple CPU cores
                RemoveFalsePositive = true,            // Filter out false detections
                ImageFilters = new ImageFilterCollection() // Apply preprocessing
                {
                    new AdaptiveThresholdFilter(),    // Handle varying lighting
                    new ContrastFilter(),              // Enhance contrast
                    new SharpenFilter()                // Improve edge definition
                }
            };
            
            // Read with advanced configuration
            BarcodeResults result = BarcodeReader.Read("QR.png", options);
        }
    }
}
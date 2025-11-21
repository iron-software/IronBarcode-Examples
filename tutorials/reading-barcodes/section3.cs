using IronBarCode;
using BarCode;
namespace IronBarcode.Examples.Tutorial.ReadingBarcodes
{
    public static class Section3
    {
        public static void Run()
        {
            // Configure advanced reading options for difficult barcodes
            BarcodeReaderOptions options = new BarcodeReaderOptions
            {
                // Speed settings: Faster, Balanced, Detailed, ExtremeDetail
                // ExtremeDetail performs deep analysis for challenging images
                Speed = ReadingSpeed.ExtremeDetail,
            
                // Specify expected formats to improve performance
                // Use bitwise OR (|) to combine multiple formats
                ExpectBarcodeTypes = BarcodeEncoding.QRCode | BarcodeEncoding.Code128,
                
                // Maximum number of barcodes to find (0 = unlimited)
                MaxParallelThreads = 4,
                
                // Crop region for faster processing of specific areas
                CropArea = null // Or specify a Rectangle
            };
            
            // Apply options when reading
            BarcodeResults results = BarcodeReader.Read("TryHarderQR.png", options);
            
            // Process detected barcodes
            foreach (var barcode in results)
            {
                Console.WriteLine($"Format: {barcode.BarcodeType}, Value: {barcode.Text}");
            }
        }
    }
}
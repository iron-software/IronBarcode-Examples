using IronBarCode;
namespace IronBarcode.Examples.Tutorial.ReadingBarcodes
{
    public static class Section4
    {
        public static void Run()
        {
            BarcodeReaderOptions options = new BarcodeReaderOptions
            {
                // Apply image processing filters to enhance readability
                ImageFilters = new ImageFilterCollection
                {
                    new AdaptiveThresholdFilter(0.01f),     // Handles varying lighting
                    new ContrastFilter(2.0f),               // Increases contrast
                    new SharpenFilter()                     // Reduces blur
                },
            
                // Automatically rotate to find barcodes at any angle
                AutoRotate = true,
                
                // Use multiple CPU cores for faster processing
                Multithreaded = true
            };
            
            BarcodeResults results = BarcodeReader.Read("TryHarderQR.png", options);
            
            foreach (var result in results)
            {
                Console.WriteLine($"Detected {result.BarcodeType}: {result.Text}");

                // Points holds the corners of the barcode; the first is top-left
                // in image coordinates.
                var corner = result.Points[0];
                Console.WriteLine($"Position: X={corner.X}, Y={corner.Y}");
            }
        }
    }
}
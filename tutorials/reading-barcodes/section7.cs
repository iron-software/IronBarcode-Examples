using IronBarCode;
using BarCode;
namespace IronBarcode.Examples.Tutorial.ReadingBarcodes
{
    public static class Section7
    {
        public static void Run()
        {
            // TIFF files are processed similarly to regular images
            // Each frame is scanned automatically
            BarcodeResults multiFrameResults = BarcodeReader.Read("Multiframe.tiff");
            
            foreach (var result in multiFrameResults)
            {
                // Access frame-specific information
                int frameNumber = result.PageNumber; // Frame number in TIFF
                string barcodeValue = result.Text;
                
                Console.WriteLine($"Frame {frameNumber}: {barcodeValue}");
                
                // Save individual barcode images if needed
                result.BarcodeImage?.Save($"barcode_frame_{frameNumber}.png");
            }
        }
    }
}
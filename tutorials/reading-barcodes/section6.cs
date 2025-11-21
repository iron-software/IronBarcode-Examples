using BarCode;
namespace IronBarcode.Examples.Tutorial.ReadingBarcodes
{
    public static class Section6
    {
        public static void Run()
        {
            // Read only specific pages to improve performance
            BarcodeReaderOptions pdfOptions = new BarcodeReaderOptions
            {
                // Scan pages 1-5 only
                PageNumbers = new[] { 1, 2, 3, 4, 5 },
                
                // PDF-specific settings
                PdfDpi = 300, // Higher DPI for better accuracy
                ReadBehindVectorGraphics = true
            };
            
            BarcodeResults results = BarcodeReader.ReadPdf("document.pdf", pdfOptions);
        }
    }
}
using IronBarCode;
namespace IronBarcode.Examples.Tutorial.ReadingBarcodes
{
    public static class Section6
    {
        public static void Run()
        {
            // Read only specific pages to improve performance
            PdfBarcodeReaderOptions pdfOptions = new PdfBarcodeReaderOptions
            {
                // Scan pages 1-5 only
                PageNumbers = new[] { 1, 2, 3, 4, 5 },
                
                // Render the pages at a higher DPI for small or dense barcodes
                DPI = 300
            };
            
            BarcodeResults results = BarcodeReader.ReadPdf("document.pdf", pdfOptions);
        }
    }
}
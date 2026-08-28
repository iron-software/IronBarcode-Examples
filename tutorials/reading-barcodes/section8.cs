using IronBarCode;
namespace IronBarcode.Examples.Tutorial.ReadingBarcodes
{
    public static class Section8
    {
        public static void Run()
        {
            // List of documents to process - mix of formats supported
            var documentBatch = new[] 
            { 
                "invoice1.pdf", 
                "shipping_label.png", 
                "inventory_sheet.tiff",
                "product_catalog.pdf"
            };
            
            // Configure for batch processing
            BarcodeReaderOptions batchOptions = new BarcodeReaderOptions
            {
                // Enable parallel processing across documents
                Multithreaded = true,
                
                // Limit threads if needed (0 = use all cores)
                MaxParallelThreads = Environment.ProcessorCount,
                
                // Apply consistent settings to all documents
                Speed = ReadingSpeed.Balanced,
                ExpectBarcodeTypes = BarcodeEncoding.All
            };
            
            // Process all documents in parallel
            BarcodeResults batchResults = BarcodeReader.Read(documentBatch, batchOptions);
            
            // BarcodeResult does not carry the source file name, so group by the
            // page the barcode was found on.
            var resultsByPage = batchResults.GroupBy(r => r.PageNumber);
            
            foreach (var pageGroup in resultsByPage.OrderBy(g => g.Key))
            {
                Console.WriteLine($"\nPage {pageGroup.Key}");
                foreach (var barcode in pageGroup)
                {
                    Console.WriteLine($"  - {barcode.BarcodeType}: {barcode.Text}");
                }
            }
        }
    }
}
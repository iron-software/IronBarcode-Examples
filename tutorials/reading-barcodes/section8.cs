using IronBarCode;
using BarCode;
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
            
            // Group results by source document
            var resultsByDocument = batchResults.GroupBy(r => r.Filename);
            
            foreach (var docGroup in resultsByDocument)
            {
                Console.WriteLine($"\nDocument: {docGroup.Key}");
                foreach (var barcode in docGroup)
                {
                    Console.WriteLine($"  - {barcode.BarcodeType}: {barcode.Text}");
                }
            }
        }
    }
}
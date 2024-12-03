using IronBarCode;
using BarCode;
namespace ironbarcode.ReadingBarcodes
{
    public class Section6
    {
        public void Run()
        {
            // The Multithreaded property allows for faster barcode scanning across multiple images or PDFs. All threads are automatically managed by IronBarCode.
            var ListOfDocuments = new[] { "image1.png", "image2.JPG", "image3.pdf" };
            
            BarcodeReaderOptions options = new BarcodeReaderOptions()
            {
                // Enable multithreading
                Multithreaded = true,
            };
            
            BarcodeResults batchResults = BarcodeReader.Read(ListOfDocuments, options);
        }
    }
}
using IronBarCode;
using BarCode;
namespace IronBarcode.Examples.Tutorial.ReadingBarcodes
{
    public static class Section5
    {
        public static void Run()
        {
            try
            {
                // Scan all pages of a PDF for barcodes
                BarcodeResults results = BarcodeReader.ReadPdf("MultipleBarcodes.pdf");
            
                if (results != null && results.Count > 0)
                {
                    foreach (var barcode in results)
                    {
                        // Access barcode data and metadata
                        string value = barcode.Text;
                        int pageNumber = barcode.PageNumber;
                        BarcodeEncoding format = barcode.BarcodeType;
                        byte[] binaryData = barcode.BinaryValue;
                        
                        // Extract barcode image if needed
                        System.Drawing.Bitmap barcodeImage = barcode.BarcodeImage;
                        
                        Console.WriteLine($"Found {format} on page {pageNumber}: {value}");
                    }
                }
                else
                {
                    Console.WriteLine("No barcodes found in the PDF.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading PDF: {ex.Message}");
            }
        }
    }
}
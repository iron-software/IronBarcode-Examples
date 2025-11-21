using System;
using BarCode;
namespace IronBarcode.Examples.Tutorial.ReadingBarcodes
{
    public static class Section2
    {
        public static void Run()
        {
            // Read barcodes from the image file - supports PNG, JPG, BMP, GIF, and more
            BarcodeResults results = BarcodeReader.Read("GetStarted.png");
            
            // Check if any barcodes were detected
            if (results != null && results.Count > 0)
            {
                // Process each barcode found in the image
                foreach (BarcodeResult result in results)
                {
                    // Extract the text value from the barcode
                    Console.WriteLine("Barcode detected! Value: " + result.Text);
                    
                    // Additional properties available:
                    // result.BarcodeType - The format (Code128, QR, etc.)
                    // result.BinaryValue - Raw binary data if applicable
                    // result.Confidence - Detection confidence score
                }
            }
            else
            {
                Console.WriteLine("No barcodes detected in the image.");
            }
        }
    }
}
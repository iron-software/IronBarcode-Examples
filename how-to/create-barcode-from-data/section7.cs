using System.Collections.Generic;
using System.IO;
using System.Text;
using IronBarCode;
namespace IronBarcode.Examples.HowTo.CreateBarcodeFromData
{
    public static class Section7
    {
        public static void Run()
        {
            // Example: Processing multiple barcodes in a batch using streams
            static List<Stream> GenerateBarcodeStreams(List<string> dataItems)
            {
                var barcodeStreams = new List<Stream>();

                foreach (var item in dataItems)
                {
                    // Convert string to stream
                    var dataStream = new MemoryStream(Encoding.UTF8.GetBytes(item));

                    // Generate barcode from stream
                    var barcode = BarcodeWriter.CreateBarcode(dataStream, BarcodeEncoding.Code128);

                    // Export barcode back to stream
                    var outputStream = barcode.ToStream();
                    outputStream.Position = 0; // Reset position for reading

                    barcodeStreams.Add(outputStream);
                }

                return barcodeStreams;
            }

            // Usage example
            var orderNumbers = new List<string> { "ORD-001", "ORD-002", "ORD-003" };
            var barcodes = GenerateBarcodeStreams(orderNumbers);
        }
    }
}

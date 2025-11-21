using System.IO;
using BarCode;
namespace IronBarcode.Examples.HowTo.ReadBarcodesFromPdf
{
    public static class Section3
    {
        public static void Run()
        {
            // Get all PDF files from a directory and add to list
            string folderPath = @"PATH_TO_YOUR_FOLDER";
            List<string> docs = new List<string>(Directory.GetFiles(folderPath, "*.pdf"));
            
            // Read barcodes from all PDFs
            var docResult = BarcodeReader.ReadPdfs(docs);
            
            // Print results
            foreach (var doc in docResult)
            {
                foreach (var item in doc)
                {
                    Console.WriteLine("Barcode " + item.ToString() + " found at page " + item.PageNumber);
                }
            }
        }
    }
}
using System.IO;
using IronBarCode;
namespace IronBarcode.Examples.HowTo.ReadBarcodesFromStreams
{
    public static class Section3
    {
        public static void Run()
        {
            using FileStream document = File.OpenRead(@"file_path.pdf");
            
            var myBarcode = BarcodeReader.ReadPdf(document);
            
            foreach (var value in myBarcode)
            {
                Console.WriteLine(value.ToString());
            }
        }
    }
}
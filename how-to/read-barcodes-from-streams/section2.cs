using System.IO;
using BarCode;
namespace IronBarcode.Examples.HowTo.ReadBarcodesFromStreams
{
    public static class Section2
    {
        public static void Run()
        {
            MemoryStream document = PdfDocument.FromFile(@"file_path.pdf").Stream;
            
            var myBarcode = BarcodeReader.ReadPdf(document);
            
            foreach (var value in myBarcode)
            {
                Console.WriteLine(value.ToString());
            }
        }
    }
}
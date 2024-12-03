using System.IO;
using BarCode;
namespace ironbarcode.ReadBarcodesFromStreams
{
    public class Section2
    {
        public void Run()
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
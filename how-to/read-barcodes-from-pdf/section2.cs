using System.Collections.Generic;
using BarCode;
namespace IronBarcode.Examples.HowTo.ReadBarcodesFromPdf
{
    public static class Section2
    {
        public static void Run()
        {
            List<String> docs = new List<String>();
            docs.Add(@"pdf_a.pdf");
            docs.Add(@"pdf_b.pdf");
            
            var myBarcode = BarcodeReader.ReadPdfs(docs);   //can also accept individual PDF document file path as argument
            
            foreach (var value in myBarcode)
            {
                Console.WriteLine(value.ToString());
            }
        }
    }
}
using System.Collections.Generic;
using BarCode;
namespace ironbarcode.ReadBarcodesFromPdf
{
    public class Section1
    {
        public void Run()
        {
            List<String> docs = new List<String>();
            docs.Add(@"pdf_a.pdf");
            docs.Add(@"pdf_b.pdf");
            
            var myBarcode = BarcodeReader.ReadPdf(docs);   //can also accept individual PDF document file path as argument
            
            foreach (var value in myBarcode)
            {
                Console.WriteLine(value.ToString());
            }
        }
    }
}
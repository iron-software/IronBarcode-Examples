using System.Collections.Generic;
using BarCode;
namespace IronBarcode.Examples.HowTo.ReadBarcodesFromPdf
{
    public static class Section5
    {
        public static void Run()
        {
            List<int> pageNumber = new List<int>() { 1, 2, 3 };
            
            PdfBarcodeReaderOptions PdfOptions = new PdfBarcodeReaderOptions(pageNumber)
            {
                DPI = 150,
                //PageNumbers = pageNumber,      //this property is not needed if page numbers has been specified as the argument in PdfBarcodeReaderOptions
                Password = "barcode",
                Scale = 3.5,
                //properties below are some of the properties inherited from BarcodeReaderOptions
                Speed = ReadingSpeed.Detailed,
                ExpectBarcodeTypes = BarcodeEncoding.Code93,
                ExpectMultipleBarcodes = true
            };
            
            var myBarcode = BarcodeReader.ReadPdf(@"pdf_a_filepath.pdf", PdfOptions);
            foreach (var value in myBarcode)
            {
                Console.WriteLine(value.ToString());
            }
        }
    }
}
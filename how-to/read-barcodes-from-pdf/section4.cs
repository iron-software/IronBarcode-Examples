using System.Collections.Generic;
using BarCode;
namespace IronBarcode.Examples.HowTo.ReadBarcodesFromPdf
{
    public static class Section4
    {
        public static void Run()
        {
            List<int> pageNumber = new List<int>() { 1, 2, 3 };
            
            PdfBarcodeReaderOptions PdfOptions = new PdfBarcodeReaderOptions(pageNumber)  // can also use individual page number as argument
            {
                // Properties of PDF Barcode reader options
            };
        }
    }
}
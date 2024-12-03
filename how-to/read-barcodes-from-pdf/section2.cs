using System.Collections.Generic;
using BarCode;
namespace ironbarcode.ReadBarcodesFromPdf
{
    public class Section2
    {
        public void Run()
        {
            List<int> pageNumber = new List<int>() { 1, 2, 3 };
            
            PdfBarcodeReaderOptions PdfOptions = new PdfBarcodeReaderOptions(pageNumber)  // can also use individual page number as argument
            {
                // Properties of PDF Barcode reader options
            };
        }
    }
}
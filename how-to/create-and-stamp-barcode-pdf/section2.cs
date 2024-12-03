using System.Collections.Generic;
using BarCode;
namespace ironbarcode.CreateAndStampBarcodePdf
{
    public class Section2
    {
        public void Run()
        {
            GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.Code128, 200, 100);
            List<int> pages = new List<int>();
            pages.Add(1);
            pages.Add(2);
            pages.Add(3);
            myBarcode.StampToExistingPdfPages("pdf_file_path.pdf", x: 200, y: 100, pages, "password");
        }
    }
}
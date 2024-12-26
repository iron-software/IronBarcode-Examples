using IronBarCode;
using BarCode;
namespace IronBarcode.Examples.HowTo.CreateAndStampBarcodePdf
{
    public static class Section1
    {
        public static void Run()
        {
            GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.Code128, 200, 100);
            myBarcode.StampToExistingPdfPage("pdf_file_path.pdf", x: 200, y: 100, 3, "password");
        }
    }
}
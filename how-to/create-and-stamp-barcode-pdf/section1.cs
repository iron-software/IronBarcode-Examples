using IronBarCode;
namespace IronBarcode.Examples.HowTo.CreateAndStampBarcodePdf
{
    public static class Section1
    {
        public static void Run()
        {
            IronBarCode.BarcodeWriter.CreateBarcode("https://my.site", IronBarCode.BarcodeEncoding.QRCode, 150, 150)
                .StampToExistingPdfPage("report.pdf", x: 50, y: 50, pageNumber: 1);
        }
    }
}
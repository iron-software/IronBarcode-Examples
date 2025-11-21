using BarCode;
namespace IronBarcode.Examples.HowTo.ReadBarcodesFromPdf
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Read PDF Barcodes in One Line
            var results = IronBarCode.BarcodeReader.ReadPdf("invoice.pdf");
        }
    }
}
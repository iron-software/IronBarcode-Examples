using IronBarCode;
namespace IronBarcode.Examples.HowTo.ReadBarcodesFromPdf
{
    public static class Section1
    {
        public static void Run()
        {
            var results = IronBarCode.BarcodeReader.ReadPdf("invoice.pdf");
        }
    }
}
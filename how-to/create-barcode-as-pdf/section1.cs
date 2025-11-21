using BarCode;
namespace IronBarcode.Examples.HowTo.CreateBarcodeAsPdf
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Generate PDF Barcode in One Line
            var pdfBytes = IronBarCode.BarcodeWriter.CreateBarcode("FastPDF", IronBarCode.BarcodeWriterEncoding.Code128).ToPdfBinaryData();
        }
    }
}
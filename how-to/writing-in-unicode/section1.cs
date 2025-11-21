using BarCode;
namespace IronBarcode.Examples.HowTo.WritingInUnicode
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Generate Unicode Barcode in One Easy Line
            var barcode = IronBarCode.BarcodeWriter.CreateBarcode("123 英語 اللغة العربية", IronBarCode.BarcodeWriterEncoding.DataMatrix);
            barcode.SaveAsImage("unicode.png");
        }
    }
}
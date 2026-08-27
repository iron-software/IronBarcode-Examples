using IronBarCode;
namespace IronBarcode.Examples.HowTo.WritingInUnicode
{
    public static class Section1
    {
        public static void Run()
        {
            var barcode = IronBarCode.BarcodeWriter.CreateBarcode("123 英語 اللغة العربية", IronBarCode.BarcodeWriterEncoding.DataMatrix);
            barcode.SaveAsImage("unicode.png");
        }
    }
}
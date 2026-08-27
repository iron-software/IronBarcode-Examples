using IronBarCode;
namespace IronBarcode.Examples.HowTo.CreateBarcodeAsHtml
{
    public static class Section1
    {
        public static void Run()
        {
            var htmlTag = BarcodeWriter.CreateBarcode("1234567890", BarcodeWriterEncoding.Code128).ToHtmlTag();
        }
    }
}
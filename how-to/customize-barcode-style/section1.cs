using BarCode;
namespace IronBarcode.Examples.HowTo.CustomizeBarcodeStyle
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Style Barcodes in Seconds
            IronBarCode.BarcodeWriter.CreateBarcode("HELLO123", IronBarCode.BarcodeEncoding.Code128)
                .ChangeBarCodeColor(IronSoftware.Drawing.Color.Blue)
                .ChangeBackgroundColor(IronSoftware.Drawing.Color.White)
                .SaveAsImage("styled.png");
        }
    }
}
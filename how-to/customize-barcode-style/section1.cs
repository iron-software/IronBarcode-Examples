using IronBarCode;
namespace IronBarcode.Examples.HowTo.CustomizeBarcodeStyle
{
    public static class Section1
    {
        public static void Run()
        {
            IronBarCode.BarcodeWriter.CreateBarcode("HELLO123", IronBarCode.BarcodeEncoding.Code128)
                .ChangeBarCodeColor(IronSoftware.Drawing.Color.Blue)
                .ChangeBackgroundColor(IronSoftware.Drawing.Color.White)
                .SaveAsImage("styled.png");
        }
    }
}
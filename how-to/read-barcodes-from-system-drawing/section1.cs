using IronBarCode;
namespace IronBarcode.Examples.HowTo.ReadBarcodesFromSystemDrawing
{
    public static class Section1
    {
        public static void Run()
        {
            var results = IronBarCode.BarcodeReader.Read((AnyBitmap)(new System.Drawing.Bitmap("yourImage.png")));
        }
    }
}
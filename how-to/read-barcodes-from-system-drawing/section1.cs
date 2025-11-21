using BarCode;
namespace IronBarcode.Examples.HowTo.ReadBarcodesFromSystemDrawing
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Quickly Decode a Barcode from System.Drawing
            var results = IronBarCode.BarcodeReader.Read((AnyBitmap)(new System.Drawing.Bitmap("yourImage.png")));
        }
    }
}
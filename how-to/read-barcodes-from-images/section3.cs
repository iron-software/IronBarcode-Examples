using IronBarCode;
namespace IronBarcode.Examples.HowTo.ReadBarcodesFromImages
{
    public static class Section3
    {
        public static void Run()
        {
            // Crop to the region of the image the barcode sits in
            int x = 50, y = 100, width = 400, height = 200;
            var cropArea = new IronSoftware.Drawing.Rectangle(x, y, width, height);
        }
    }
}
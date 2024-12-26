using IronBarCode;
using BarCode;
namespace IronBarcode.Examples.HowTo.SetCropRegion
{
    public static class Section1
    {
        public static void Run()
        {
            int x1 = 62;
            int y1 = 29;
            int x2 = 345;
            int y2 = 522;
            
            IronSoftware.Drawing.Rectangle crop1 = new IronSoftware.Drawing.Rectangle(x: x1, y: y1, width: x2-x1, height: y2-y1);
        }
    }
}
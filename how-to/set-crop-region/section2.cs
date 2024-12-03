using System;
using BarCode;
namespace ironbarcode.SetCropRegion
{
    public class Section2
    {
        public void Run()
        {
            int x1 = 62;
            int y1 = 29;
            int x2 = 345;
            int y2 = 522;
            
            IronSoftware.Drawing.Rectangle crop1 = new IronSoftware.Drawing.Rectangle(x: x1, y: y1, width: x2 - x1, height: y2 - y1);
            
            BarcodeReaderOptions options = new BarcodeReaderOptions()
            {
                CropArea = crop1
            };
            
            var result = BarcodeReader.Read("sample.png", options);
            foreach (var item in result)
            {
                Console.WriteLine(item.Value);
            }
        }
    }
}
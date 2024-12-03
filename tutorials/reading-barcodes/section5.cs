using IronBarCode;
using BarCode;
namespace ironbarcode.ReadingBarcodes
{
    public class Section5
    {
        public void Run()
        {
            // Multi frame TIFF and GIF images can also be scanned
            BarcodeResults multiFrameResults = BarcodeReader.Read("Multiframe.tiff");
            
            foreach (var pageResult in multiFrameResults)
            {
                //...
            }
        }
    }
}
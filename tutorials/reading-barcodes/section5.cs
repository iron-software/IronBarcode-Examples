using IronBarCode;
using BarCode;
namespace IronBarcode.Examples.Tutorial.ReadingBarcodes
{
    public static class Section5
    {
        public static void Run()
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
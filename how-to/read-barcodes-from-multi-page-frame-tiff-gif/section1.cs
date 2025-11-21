using BarCode;
namespace IronBarcode.Examples.HowTo.ReadBarcodesFromMultiPageFrameTiffGif
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Read Barcodes from Multi-Page Images in One Call
            IronBarCode.BarcodeResults results = IronBarCode.BarcodeReader.Read("multiPageImage.tiff");
        }
    }
}
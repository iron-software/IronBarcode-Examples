using IronBarCode;
namespace IronBarcode.Examples.HowTo.ReadBarcodesFromMultiPageFrameTiffGif
{
    public static class Section1
    {
        public static void Run()
        {
            IronBarCode.BarcodeResults results = IronBarCode.BarcodeReader.Read("multiPageImage.tiff");
        }
    }
}
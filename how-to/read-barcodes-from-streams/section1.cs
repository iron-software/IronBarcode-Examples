using BarCode;
namespace IronBarcode.Examples.HowTo.ReadBarcodesFromStreams
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Easily Read Barcodes from Streams
            var result = IronBarCode.BarcodeReader.Read(myImageStream);
            Console.WriteLine(result[0].Text);
        }
    }
}
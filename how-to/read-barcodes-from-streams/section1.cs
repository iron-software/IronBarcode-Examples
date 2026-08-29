using IronBarCode;
namespace IronBarcode.Examples.HowTo.ReadBarcodesFromStreams
{
    public static class Section1
    {
        public static void Run()
        {
            using var myImageStream = System.IO.File.OpenRead("barcode.png");
            
            var result = IronBarCode.BarcodeReader.Read(myImageStream);
            Console.WriteLine(result[0].Text);
        }
    }
}
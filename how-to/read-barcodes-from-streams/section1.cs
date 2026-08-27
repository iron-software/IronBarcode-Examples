using IronBarCode;
namespace IronBarcode.Examples.HowTo.ReadBarcodesFromStreams
{
    public static class Section1
    {
        public static void Run()
        {
            var result = IronBarCode.BarcodeReader.Read(myImageStream);
            Console.WriteLine(result[0].Text);
        }
    }
}
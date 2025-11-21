using BarCode;
namespace IronBarcode.Examples.HowTo.OutputDataFormats
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Grab Barcode Text & Type Instantly
            var result = IronBarCode.BarcodeReader.Read("input.png");
            Console.WriteLine($"Value: {result[0].Value}, Type: {result[0].BarcodeType}");
        }
    }
}
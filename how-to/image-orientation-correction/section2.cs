using System;
using BarCode;
namespace IronBarcode.Examples.HowTo.ImageOrientationCorrection
{
    public static class Section2
    {
        public static void Run()
        {
            BarcodeReaderOptions myOptionsExample = new BarcodeReaderOptions()
            {
                // Turn on auto rotation in ML detection
                AutoRotate = true,
            };
            
            var results = BarcodeReader.Read("rotate20.png", myOptionsExample);
            
            // Print out the value
            Console.WriteLine(results[0].Value);
        }
    }
}
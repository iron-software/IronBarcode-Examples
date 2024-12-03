using System;
using BarCode;
namespace ironbarcode.ImageOrientationCorrection
{
    public class Section1
    {
        public void Run()
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
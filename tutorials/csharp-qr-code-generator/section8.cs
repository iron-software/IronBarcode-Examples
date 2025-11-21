using System.Linq;
using BarCode;
namespace IronBarcode.Examples.Tutorial.CsharpQrCodeGenerator
{
    public static class Section8
    {
        public static void Run()
        {
            // Read QR code with optimized settings
            BarcodeResults result = BarcodeReader.Read("QR.png", new BarcodeReaderOptions() { 
                ExpectBarcodeTypes = BarcodeEncoding.QRCode 
            });
            
            // Extract and display the decoded value
            if (result != null && result.Any())
            {
                Console.WriteLine(result.First().Value);
            }
            else
            {
                Console.WriteLine("No QR codes found in the image.");
            }
        }
    }
}
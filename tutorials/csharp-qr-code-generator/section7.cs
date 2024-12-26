using System.Linq;
using BarCode;
namespace IronBarcode.Examples.Tutorial.CsharpQrCodeGenerator
{
    public static class Section7
    {
        public static void Run()
        {
            BarcodeResults result = BarcodeReader.Read("QR.png", new BarcodeReaderOptions() { ExpectBarcodeTypes = BarcodeEncoding.QRCode });
            if (result != null)
            {
                Console.WriteLine(result.First().Value);
            }
        }
    }
}
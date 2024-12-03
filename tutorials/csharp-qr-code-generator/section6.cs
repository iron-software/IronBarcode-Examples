using System.Linq;
using BarCode;
namespace ironbarcode.CsharpQrCodeGenerator
{
    public class Section6
    {
        public void Run()
        {
            BarcodeResults result = BarcodeReader.Read("QR.png", new BarcodeReaderOptions() { ExpectBarcodeTypes = BarcodeEncoding.QRCode });
            if (result != null)
            {
                Console.WriteLine(result.First().Value);
            }
        }
    }
}
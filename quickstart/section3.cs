using IronBarCode;
using BarCode;
namespace ironbarcode.Quickstart
{
    public class Section3
    {
        public void Run()
        {
            BarcodeResults results = BarcodeReader.Read("MultipleBarcodes.png");
            
            // Loop through the results
            foreach (BarcodeResult result in results)
            {
                string value = result.Value;
                Bitmap img = result.BarcodeImage;
                BarcodeEncoding barcodeType = result.BarcodeType;
                byte[] binary = result.BinaryValue;
                Console.WriteLine(result.Value);
            }
        }
    }
}
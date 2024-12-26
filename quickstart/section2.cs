using IronBarCode;
using BarCode;
namespace IronBarcode.Examples.Overview.Quickstart
{
    public static class Section2
    {
        public static void Run()
        {
            BarcodeReaderOptions myOptionsExample = new BarcodeReaderOptions()
            {
                ExpectMultipleBarcodes = false,
                ExpectBarcodeTypes = BarcodeEncoding.QRCode | BarcodeEncoding.Code128,
                CropArea = new System.Drawing.Rectangle(100, 200, 300, 400),
            };
            
            BarcodeResults result = BarcodeReader.Read("QuickStart.jpg", myOptionsExample);
            if (result != null)
            {
                Console.WriteLine(result.First().Text);
            }
        }
    }
}
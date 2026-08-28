using IronBarCode;
namespace IronBarcode.Examples.Overview.Quickstart
{
    public static class Section3
    {
        public static void Run()
        {
            BarcodeResults results = BarcodeReader.Read("MultipleBarcodes.png");
            
            // Loop through the results
            foreach (BarcodeResult result in results)
            {
                string value = result.Value;
                IronSoftware.Drawing.AnyBitmap img = result.BarcodeImage;
                BarcodeEncoding barcodeType = result.BarcodeType;
                byte[] binary = result.BinaryValue;
                Console.WriteLine(result.Value);
            }
        }
    }
}
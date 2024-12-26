using IronBarCode;
using BarCode;
namespace IronBarcode.Examples.Tutorial.ReadingBarcodes
{
    public static class Section2
    {
        public static void Run()
        {
            BarcodeReaderOptions options = new BarcodeReaderOptions()
            {
                // Choose a speed from: Faster, Balanced, Detailed, ExtremeDetail
                // There is a tradeoff in performance as more Detail is set
                Speed = ReadingSpeed.ExtremeDetail,
            
                // By default, all barcode formats are scanned for.
                // Specifying one or more, performance will increase.
                ExpectBarcodeTypes = BarcodeEncoding.QRCode | BarcodeEncoding.Code128,
            };
            
            // Read barcode
            BarcodeResults results = BarcodeReader.Read("TryHarderQR.png", options);
        }
    }
}
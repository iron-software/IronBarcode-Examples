using BarCode;
namespace IronBarcode.Examples.Tutorial.CsharpBarcodeImageGenerator
{
    public static class Section5
    {
        public static void Run()
        {
            // Generate and verify a barcode
            GeneratedBarcode myBarcode = BarcodeWriter
                .CreateBarcode("TEST123", BarcodeWriterEncoding.Code128)
                .ResizeTo(200, 100)
                .ChangeBarCodeColor(Color.DarkBlue);
            
            // Verify the barcode is still readable after modifications
            bool isReadable = myBarcode.Verify();
            Console.WriteLine($"Barcode verification: {(isReadable ? "PASS" : "FAIL")}");
        }
    }
}
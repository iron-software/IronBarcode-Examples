using IronBarCode;
using BarCode;
namespace IronBarcode.Examples.Tutorial.CsharpBarcodeImageGenerator
{
    public static class Section2
    {
        public static void Run()
        {
            // Create a barcode with your desired content and encoding type
            GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode", BarcodeWriterEncoding.Code128);
            
            // Save the barcode as a PNG image file
            myBarcode.SaveAsPng("myBarcode.png");
            
            // Optional: Open the generated image in your default viewer
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("myBarcode.png") { UseShellExecute = true });
        }
    }
}
using IronBarCode;
using BarCode;
namespace IronBarcode.Examples.Tutorial.CsharpBarcodeImageGenerator
{
    public static class Section1
    {
        public static void Run()
        {
            // Generate a Simple BarCode image and save as PNG
            GeneratedBarcode myBarcode = IronBarCode.BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode", BarcodeWriterEncoding.Code128);
            myBarcode.SaveAsPng("myBarcode.png");
            
            // This line opens the image in your default image viewer
            System.Diagnostics.Process.Start("myBarcode.png");
        }
    }
}
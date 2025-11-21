using IronSoftware.Drawing;
using BarCode;
namespace IronBarcode.Examples.Tutorial.CsharpBarcodeImageGenerator
{
    public static class Section3
    {
        public static void Run()
        {
            // Create a QR code with advanced styling options
            GeneratedBarcode myBarCode = BarcodeWriter.CreateBarcode(
                "https://ironsoftware.com/csharp/barcode", 
                BarcodeWriterEncoding.QRCode
            );
            
            // Add descriptive text above the barcode
            myBarCode.AddAnnotationTextAboveBarcode("Product URL:");
            
            // Display the encoded value below the barcode
            myBarCode.AddBarcodeValueTextBelowBarcode();
            
            // Set consistent margins around the barcode
            myBarCode.SetMargins(100);
            
            // Customize the barcode color (purple in this example)
            myBarCode.ChangeBarCodeColor(Color.Purple);
            
            // Export as an HTML file for web integration
            myBarCode.SaveAsHtmlFile("MyBarCode.html");
        }
    }
}
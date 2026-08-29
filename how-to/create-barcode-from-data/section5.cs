using IronSoftware.Drawing;
using IronBarCode;
namespace IronBarcode.Examples.HowTo.CreateBarcodeFromData
{
    public static class Section5
    {
        public static void Run()
        {
            // Create a barcode with custom styling
            GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("PRODUCT-12345", BarcodeEncoding.Code128);

            // Apply custom styling
            myBarcode.ResizeTo(300, 100);
            myBarcode.SetMargins(10);
            myBarcode.ChangeBarCodeColor(Color.DarkBlue);

            // Add text annotations
            myBarcode.AddBarcodeValueTextBelowBarcode();
            myBarcode.AddAnnotationTextAboveBarcode("Product SKU", new Font("Arial"), Color.Black, 12);

            // Save the customized barcode
            myBarcode.SaveAsPng("customized-barcode.png");
        }
    }
}

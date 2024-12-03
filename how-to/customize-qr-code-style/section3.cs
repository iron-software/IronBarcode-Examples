using IronSoftware.Drawing;
using BarCode;
namespace ironbarcode.CustomizeQrCodeStyle
{
    public class Section3
    {
        public void Run()
        {
            AnyBitmap qrlogo = AnyBitmap.FromFile("ironbarcode_top.webp");
            
            QRCodeLogo logo = new QRCodeLogo(qrlogo, 0, 0, 20f);
            
            Color colorForBarcode = new Color(51, 51, 153); // color from RGB
            Color annotationAboveBarcodeColor = new Color("#176feb");  // color from Hex
            Font annotationAboveBarcodeFont = new Font("Candara", FontStyle.Bold, 15);
            Color barcodeValueBelowBarcodeColor = new Color("#6e53bb");
            Font barcodeValueBelowBarcodeFont = new Font("Cambria", FontStyle.Regular, 15);
            
            GeneratedBarcode qrCodeWithLogo = QRCodeWriter.CreateQrCodeWithLogo("https://ironsoftware.com/csharp/barcode/", logo, 250);
            GeneratedBarcode qrCodeWithLogoAndColor = qrCodeWithLogo.ChangeBarCodeColor(colorForBarcode);
            GeneratedBarcode qrCodeWithAnnotation = qrCodeWithLogoAndColor.AddAnnotationTextAboveBarcode("IronBarcodeRocks!", annotationAboveBarcodeFont, annotationAboveBarcodeColor, 2).AddBarcodeValueTextBelowBarcode(barcodeValueBelowBarcodeFont, barcodeValueBelowBarcodeColor, 2);
            qrCodeWithAnnotation.SaveAsPng("QRCodeWithAnnotation.png");
        }
    }
}
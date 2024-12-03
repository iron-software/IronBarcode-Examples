# Enhancing and Branding QR Codes with Logos

***Based on <https://ironsoftware.com/how-to/customize-qr-code-style/>***


QR codes have become preferable over traditional barcodes due to their ability to hold more data and their user-friendly scanning process. They are particularly appreciated in marketing for their adaptability, such as adding logos, altering colors, and integrating branding elements.

To cater to these needs, IronBarcode provides an extensive range of customization features. It allows the creation of QR codes embedded with logos, tailored color schemes, and additional annotations. These features are supported by [IronDrawing](https://ironsoftware.com/open-source/csharp/drawing/docs/), which is a robust, freely available library.

## Example: Adding a Logo to a QR Code

For embedding a logo in a QR code, we utilize the **QRCodeLogo** class. The `CreateQrCodeWithLogo` method facilitates the generation of QR codes with an embedded logo.

```cs
using IronSoftware.Drawing;
using BarCode;
namespace ironbarcode.CustomizeQrCodeStyle
{
    public class Section1
    {
        public void Run()
        {
            AnyBitmap qrlogo = AnyBitmap.FromFile("ironbarcode_top.webp");
            
            QRCodeLogo logo = new QRCodeLogo(qrlogo, 0, 0, 20f);
            
            GeneratedBarcode QrCodeWithLogo = QRCodeWriter.CreateQrCodeWithLogo("https://ironsoftware.com/csharp/barcode/", logo, 250);
            
            QrCodeWithLogo.SaveAsPng("EnhancedQrCode.png");
        }
    }
}
```
<div class="content-img-align-center">
    <div class="center-image-wrapper" style="width: 35%;">
         <img src="https://ironsoftware.com/static-assets/barcode/how-to/customize-qr-code-style/QrCodeWithLogo.webp" alt="QR Code With Logo" class="img-responsive add-shadow">
    </div>
</div>

The resulting QR code displays a central logo with rounded edges. To customize the logo, the **QRCodeLogo** class offers configuration for:
- Image Sourcing: Import images via **AnyBitmap**, **Stream**, **Byte Array**, paths, or **URI**.
- Image Sizing: Define width and height of the image logo in pixels. Oversized images will trigger an exception. Set to 0 for auto-sizing.
- Corner Radii: Specify rounded corners using a radius value or use 0 for sharp corners.

Exporting the QR code can be done through various formats including [image files](https://ironsoftware.com/csharp/barcode/how-to/create-barcode-as-html/), [streams](https://ironsoftware.com/csharp/barcode/how-to/export-barcode-as-stream/), [HTML](https://ironsoftware.com/csharp/barcode/how-to/create-barcode-images/), and [PDF](https://ironsoftware.com/csharp/barcode/how-to/create-barcode-as-pdf/).

## Example: Modifying QR Code Colors

IronBarcode also allows color customization of QR codes using the [IronDrawing](https://ironsoftware.com/open-source/csharp/drawing/docs/) library, which can accept RGB values or Hex codes.

```cs
using IronSoftware.Drawing;
using BarCode;
namespace ironbarcode.CustomizeQrCodeStyle
{
    public class Section2
    {
        public void Run()
        {
            AnyBitmap qrlogo = AnyBitmap.FromFile("ironbarcode_top.webp");
            
            QRCodeLogo logo = new QRCodeLogo(qrlogo, 0, 0, 20f);
            
            IronSoftware.Drawing.Color customColor = new IronSoftware.Drawing.Color(51, 51, 153);
            
            GeneratedBarcode QrCodeWithLogo = QRCodeWriter.CreateQrCodeWithLogo("https://ironsoftware.com/csharp/barcode/", logo, 250);
            GeneratedBarcode ColoredQR = QrCodeWithLogo.ChangeBarCodeColor(customColor);
            ColoredQR.SaveAsPng("ColoredLogoQR.png");
        }
    }
}
```

<div class="content-img-align-center">
    <div class="center-image-wrapper" style="width: 35%;">
         <img src="https://ironsoftware.com/static-assets/barcode/how-to/customize-qr-code-style/coloredQrCodeWithLogo.webp" alt="QR Code With Custom Logo and Color" class="img-responsive add-shadow">
    </div>
</div>

Learn to create custom colors in our ["Create Color"](https://ironsoftware.com/open-source/csharp/drawing/examples/create-color/) guide. 

## Example: Adding Annotations to QR Codes

Annotations provide a platform within the QR code image for adding promotional or informational text.

```cs
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
            
            Color marketingMessageColor = new Color("#176feb");
            Font marketingMessageFont = new Font("Candara", FontStyle.Bold, 15);
            
            GeneratedBarcode qrCodeEnhanced = QRCodeWriter.CreateQrCodeWithLogo("https://ironsoftware.com/csharp/barcode/", logo, 250);
            qrCodeEnhanced.ChangeBarCodeColor(new Color(51, 51, 153));
            GeneratedBarcode qrCodeWithAnnotations = qrCodeEnhanced.AddAnnotationTextAboveBarcode("IronBarcodeRocks!", marketingMessageFont, marketingMessageColor, 2).AddBarcodeValueTextBelowBarcode(new Font("Cambria", FontStyle.Regular, 15), new Color("#6e53bb"), 2);
            
            qrCodeWithAnnotations.SaveAsPng("AnnotatedQRCode.png");
        }
    }
}
```

<div class="content-img-align-center">
    <div class="center-image-wrapper" style="width: 35%;">
         <img src="https://ironsoftware.com/static-assets/barcode/how-to/customize-qr-code-style/qrCodeWithAnnotation.webp" alt="QR Code With Annotation" class="img-responsive add-shadow">
    </div>
</div>

IronBarcode simplifies QR code creation and customization, integrating seamlessly with IronDrawing for enhanced image processing capabilities.
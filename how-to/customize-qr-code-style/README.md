# How to Customize and Add Logos to QR Codes

QR codes have become increasingly popular over traditional barcodes due to their ability to store more data and their simplicity in scanning. These features make them highly useful in marketing, offering various customization options such as adding logos, altering color schemes, and integrating other branding elements.

To cater to these needs, IronBarcode provides a comprehensive set of tools for QR code customization. Using <a href='https://ironsoftware.com/open-source/csharp/drawing/docs/'>IronDrawing</a>, a free and open-source library, users can enhance QR codes by embedding logos, modifying colors, and appending annotations.

---

---

## Example of Creating QR Codes with a Logo

To integrate a logo within a QR code, you'll utilize a **QRCodeLogo** object. Here’s how you can use the `CreateQrCodeWithLogo` method to accomplish this:

```cs
using IronBarCode;
using IronSoftware.Drawing;

// Load logo image
AnyBitmap qrlogo = AnyBitmap.FromFile("ironbarcode_top.webp");

// Configure logo settings
QRCodeLogo logo = new QRCodeLogo(qrlogo, 0, 0, 20f);

// Generate QR code with embedded logo
GeneratedBarcode QrCodeWithLogo = QRCodeWriter.CreateQrCodeWithLogo("https://ironsoftware.com/csharp/barcode/", logo, 250);

// Save the QR code as PNG
QrCodeWithLogo.SaveAsPng("QrCodeWLogo2.png");
```
<div class="content-img-align-center">
    <div class="center-image-wrapper" style="width: 35%;">
         <img src="https://ironsoftware.com/static-assets/barcode/how-to/customize-qr-code-style/QrCodeWithLogo.webp" alt="QR Code With Logo" class="img-responsive add-shadow">
    </div>
</div>

The resulting QR code, as seen above, displays a centered logo with rounded corners.

For customizing the logo, the **QRCodeLogo** object needs certain parameters to be specified:

- **Importing Image**: Images can be uploaded using different methods such as **AnyBitmap**, **Stream**, **Byte Array**, filepath, or URI.
- **Image Dimensions**: Define the logo’s dimensions in pixels. Oversized logos may render the QR unreadable; setting width and height to 0 allows automatic adjustment.
- **Image Corners**: Adjust the corner radius of the logo; a value of 0 results in square corners.

The final step involves exporting the QR code. IronBarcode offers several methods for saving your QR codes, such as as image files, streams, HTML, and PDF, available through guideline links like <a href='https://ironsoftware.com/csharp/barcode/how-to/create-barcode-as-html/'>here</a> and <a href='https://ironsoftware.com/csharp/barcode/how-to/export-barcode-as-stream/'>here</a>.

## Example of Changing QR Code Color

IronBarcode also supports color customization for QR codes. Leveraging the <a href='https://ironsoftware.com/open-source/csharp/drawing/docs/'>IronDrawing</a> library, users can define custom colors using RGB or Hex codes to personalize their QR codes further. Here is an example that demonstrates coloring the QR code:

```cs
using IronBarCode;
using IronSoftware.Drawing;

// Repeat the logo loading
AnyBitmap qrlogo = AnyBitmap.FromFile("ironbarcode_top.webp");
QRCodeLogo logo = new QRCodeLogo(qrlogo, 0, 0, 20f);

// Create customized color
IronSoftware.Drawing.Color ColorFromRgb = new IronSoftware.Drawing.Color(51, 51, 153);

// Generate and modify QR code color
GeneratedBarcode QrCodeWithLogo = QRCodeWriter.CreateQrCodeWithLogo("https://ironsoftware.com/csharp/barcode/", logo, 250);
GeneratedBarcode QrCodeWithLogoAndColor = QrCodeWithLogo.ChangeBarCodeColor(ColorFromRgb);

// Save the QR code
QrCodeWithLogoAndColor.SaveAsPng("ColorQrCodeWithLogo.png");
```

<div class="content-img-align-center">
    <div class="center-image-wrapper" style="width: 35%;">
         <img src="https://ironsoftware.com/static-assets/barcode/how-to/customize-qr-code-style/coloredQrCodeWithLogo.webp" alt="QR Code With Custom Logo and Color" class="img-responsive add-shadow">
    </div>
</div>

The method `ChangeBarCodeColor`, which modifies the color of the QR code, accepts an **IronSoftware.Drawing.Color** object. You can create this object using RGB or Hex values. Explore the ["Create Color"](https://ironsoftware.com/open-source/csharp/drawing/examples/create-color/) example for more insights on creating custom colors.

## Example of Adding QR Code Annotation

Enhancing QR codes with annotations is another facet of customization. This includes adding either the barcode value itself or customized text for promotion. Here’s how to implement these modifications:

```cs
using IronBarCode;
using IronSoftware.Drawing;

// Load the logo
AnyBitmap qrlogo = AnyBitmap.FromFile("ironbarcode_top.webp");
QRCodeLogo logo = new QRCodeLogo(qrlogo, 0, 0, 20f);

// Define custom colors and fonts
Color colorForBarcode = new Color(51, 51, 153);  // RGB color
Color annotationAboveBarcodeColor = new Color("#176feb");  // Hex color
Font annotationAboveBarcodeFont = new Font("Candara", FontStyle.Bold, 15);
Color barcodeValueBelowBarcodeColor = new Color("#6e53bb");
Font barcodeValueBelowBarcodeFont = new Font("Cambria", FontStyle.Regular, 15);

// Generate, annotate, and save the QR code
GeneratedBarcode qrCodeWithLogo = QRCodeWriter.CreateQrCodeWithLogo("https://ironsoftware.com/csharp/barcode/", logo, 250);
GeneratedBarcode qrCodeWithLogoAndColor = qrCodeWithLogo.ChangeBarCodeColor(colorForBarcode);
GeneratedBarcode qrCodeWithAnnotation = qrCodeWithLogoAndColor.AddAnnotationTextAboveBarcode("IronBarcodeRocks!", annotationAboveBarcodeFont, annotationAboveBarcodeColor, 2).AddBarcodeValueTextBelowBarcode(barcodeValueBelowBarcodeFont, barcodeValueBelowBarcodeColor, 2);
qrCodeWithAnnotation.SaveAsPng("QRCodeWithAnnotation.png");
```

<div class="content-img-align-center">
    <div class="center-image-wrapper" style="width: 35%;">
         <img src="https://ironsoftware.com/static-assets/barcode/how-to/customize-qr-code-style/QRCodeWithAnnotation.webp" alt="QR Code With Annotation" class="img-responsive add-shadow">
    </div>
</div>

IronBarcode provides several methods like `AddAnnotationTextAboveBarcode` and `AddAnnotationTextBelowBarcode` to specify text positioning, fonts, and colors for annotations on the QR code. These functionalities offer essential flexibility for tailored branding in QR code applications, making IronBarcode an indispensable tool for marketers and developers alike.
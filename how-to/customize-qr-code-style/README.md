# How to Customize and Add Logos to QR Codes

***Based on <https://ironsoftware.com/how-to/customize-qr-code-style/>***


QR codes are increasingly favored over traditional barcodes due to their ability to hold more data and their simplicity in scanning. Their adaptability in marketing is particularly appreciated, offering the ability to include logos, alter color schemes, and integrate additional branding elements.

IronBarcode, a prominent tool in this space, provides extensive features for QR code customization. Users can effortlessly incorporate logos into QR codes, modify color themes, and append annotations, all facilitated by the open-source [IronDrawing](https://www.nuget.org/packages/IronPdf/) library.

## Quickstart: Embed a Branded QR Code Seamlessly

Jump right into action by crafting a branded QR code complete with your logo, a unique color, and a custom message—all through a single line of code from IronBarcode, perfect for developers looking for a quick, professional solution.

```cs
:title=Craft Your Custom QR in a Snap
IronBarCode.QRCodeWriter.CreateQrCodeWithLogo("https://example.com", new IronBarCode.QRCodeLogo("logo.png"), 300).ChangeBarCodeColor(IronSoftware.Drawing.Color.DeepSkyBlue).AddAnnotationTextAboveBarcode("Scan Me!", new IronSoftware.Drawing.Font("Arial",12), IronSoftware.Drawing.Color.White, 5).SaveAsPng("brandedQR.png");
```

## Detailed Guide on Creating QR Codes With Logos

To include a logo in your QR code, initiate a **QRCodeLogo** instance. Utilize the `CreateQrCodeWithLogo` method to generate a QR code that incorporates a custom logo.

```csharp
using IronBarCode;
using IronSoftware.Drawing;

AnyBitmap qrLogo = AnyBitmap.FromFile("ironbarcode_top.webp");
QRCodeLogo logo = new QRCodeLogo(qrLogo, 0, 0, 20f);

GeneratedBarcode qrCodeCustomLogo = QRCodeWriter.CreateQrCodeWithLogo("https://ironsoftware.com/csharp/barcode/", logo, 250);
qrCodeCustomLogo.SaveAsPng("QrCodeWithCustomLogo.png");
```

<div class="content-img-align-center">
    <div class="center-image-wrapper" style="width: 35%;">
         <img src="https://ironsoftware.com/static-assets/barcode/how-to/customize-qr-code-style/QrCodeWithLogo.webp" alt="Enhanced QR Code With Logo" class="img-responsive add-shadow">
    </div>
</div>

The showcased QR code prominently displays a centrally placed logo with soft rounded corners.

When establishing a **QRCodeLogo**, here are the parameters to consider:

- **Importing Image**: Import images via various modes such as **AnyBitmap**, **Stream**, **Byte Array**, relative **filepath**, or **URI**.
- **Image Dimensions**: Define the width and height of the logo in pixels. Oversized images will render the QR unreadable, hence a size of 0 auto-adjusts to the maximum viable dimensions.
- **Image Corners**: Opt to round the corners of your image by setting the radius, or choose zero for sharp corners.

To save the final QR code, simply use a suitable save method available for images, streams, HTML files, or PDFs.

## Modifying QR Code Color

IronBarcode further allows color adjustments on your QR code via the IronDrawing library. Here's an example to demonstrate how you can apply your chosen color:

```csharp
using IronBarCode;
using IronSoftware.Drawing;

AnyBitmap qrLogo = AnyBitmap.FromFile("ironbarcode_top.webp");
QRCodeLogo logo = new QRCodeLogo(qrLogo, 0, 0, 20f);

IronSoftware.Drawing.Color customColor = new IronSoftware.Drawing.Color(63, 63, 223);

GeneratedBarcode coloredQrCode = QRCodeWriter.CreateQrCodeWithLogo("https://ironsoftware.com/csharp/barcode/", logo, 250);
GeneratedBarcode coloredQrCodeEnhanced = coloredQrCode.ChangeBarCodeColor(customColor);
coloredQrCodeEnhanced.SaveAsPng("CustomColoredQrCode.png");
```

<div class="content-img-align-center">
    <div class="center-image-wrapper" style="width: 35%;">
         <img src="https://ironsoftware.com/static-assets/barcode/how-to/customize-qr-code-style/coloredQrCodeWithLogo.webp" alt="QR Code with Custom Logo and Color" class="img-responsive add-shadow">
    </div>
</div>

This snippet extends a previous example by demonstrating the `ChangeBarCodeColor` method, which accepts an **IronSoftware.Drawing.Color** instance as input. This instance can be defined using RGB values, Hex codes, or predefined color enums. More insights can be found in our ["Create Color"](https://nuget.org/packages/IronPdf/) tutorial.

## Annotation Integration in QR Codes

Enhancing a QR code with annotations allows for added text elements either for marketing or informational purposes. Here's how you can implement this:

```csharp
using IronBarCode;
using IronSoftware.Drawing;

AnyBitmap qrLogo = AnyBitmap.FromFile("ironbarcode_top.webp");
QRCodeLogo logo = new QRCodeLogo(qrLogo, 0, 0, 20f);

Color baseColor = new Color(61, 61, 223); // RGB color
Color annotationColor = new Color("#1976D2");  // Hex color
Font annotationFont = new Font("Segoe UI", FontStyle.Bold, 14);
Color valueColor = new Color("#8E44AD");
Font valueFont = new Font("Georgia", FontStyle.Italic, 14);

GeneratedBarcode annotatedQrCode = QRCodeWriter.CreateQrCodeWithLogo("https://ironsoftware.com/csharp/barcode/", logo, 250);
GeneratedBarcode enhancedQrCode = annotatedQrCode.ChangeBarCodeColor(baseColor);
GeneratedBarcode finalQrCode = enhancedQrCode.AddAnnotationTextAboveBarcode("Top Text", annotationFont, annotationColor, 3).AddBarcodeValueTextBelowBarcode(valueFont, valueColor, 3);
finalQrCode.SaveAsPng("FullyAnnotatedQR.png");
```

<div class="content-img-align-center">
    <div class="center-image-wrapper" style="width: 35%;">
         <img src="https://ironsoftware.com/static-assets/barcode/how-to/customize-qr-code-style/qrCodeWithAnnotation.webp" alt="QR Code With Detailed Annotation" class="img-responsive add-shadow">
    </div>
</div>

This method facilitates positioning annotations strategically above or below the QR code while allowing customization of font type, color, and margin. IronBarcode's comprehensive capabilities, reinforced by IronDrawing, make it an unparalleled choice for generating tailored QR codes.
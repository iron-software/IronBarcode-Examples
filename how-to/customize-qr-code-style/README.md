# Enhancing QR Codes with Logos and Custom Styles

***Based on <https://ironsoftware.com/how-to/customize-qr-code-style/>***


QR codes are surpassing traditional barcodes in terms of popularity due to their considerable data capacity and ease in scanning. An important feature that makes them highly valued in marketing and branding efforts is their ability to be customized. This includes options such as embedding logos, modifying colors, and integrating other branding elements.

IronBarcode provides a robust set of functionalities for such customizations through the use of <a href='https://ironsoftware.com/open-source/csharp/drawing/docs/'>IronDrawing</a>, an open-source library that allows extensive manipulations of QR codes.

<h3>Introduction to IronBarcode</h3>

---

---

---

## Example: Adding Logos to QR Codes

To incorporate a logo into a QR code, a **QRCodeLogo** object needs to be used alongside the `CreateQrCodeWithLogo` method.

```cs
using IronBarCode;
using IronSoftware.Drawing;

AnyBitmap qrLogo = AnyBitmap.FromFile("ironbarcode_top.webp");

QRCodeLogo logo = new QRCodeLogo(qrLogo, 0, 0, 20f);

GeneratedBarcode qrCodeWithLogo = QRCodeWriter.CreateQrCodeWithLogo("https://ironsoftware.com/csharp/barcode/", logo, 250);

qrCodeWithLogo.SaveAsPng("CustomizedQrCode.png");
```
<div class="content-img-align-center">
    <div class="center-image-wrapper" style="width: 35%;">
         <img src="https://ironsoftware.com/static-assets/barcode/how-to/customize-qr-code-style/QrCodeWithLogo.webp" alt="Customized QR Code with Logo">
    </div>
</div>

The resulting QR code proudly displays a centrally placed logo, surrounded by smoothly rounded edges.

To tailor the logo to your needs, populate the following parameters upon creating a **QRCodeLogo** object:
- Importing Image: Load images using various methods like **AnyBitmap**, **Stream**, **Byte Array**, file paths, or **URLs**.
- Image Dimensions: Define the dimensions in pixels. Oversized images will render the QR unreadable. Utilizing `0` auto-adjusts the image to suit the QR code's size.
- Corners of Image: Determine whether the logo's corners should be rounded or square.

To export your QR creation, make use of different methods which include exporting to <a href='https://ironsoftware.com/csharp/barcode/how-to/create-barcode-as-html/'>image files</a>, <a href='https://ironsoftware.com/csharp/barcode/how-to/export-barcode-as-stream/'>Streams</a>, <a href='https://ironsoftware.com/csharp/barcode/how-to/create-barcode-images/'>HTML</a>, or <a href='https://ironsoftware.com/csharp/barcode/how-to/create-barcode-as-pdf/'>PDF</a>.

## Customizing QR Code Colors

IronBarcode also allows for the alteration of QR codes' colors to reflect company branding better. This is facilitated through the versatile <a href='https://ironsoftware.com/open-source/csharp/drawing/docs/'>IronDrawing</a> library.

```cs
using IronBarCode;
using IronSoftware.Drawing;

AnyBitmap qrLogo = AnyBitmap.FromFile("ironbarcode_top.webp");

QRCodeLogo logo = new QRCodeLogo(qrLogo, 0, 0, 20f);

Color customColor = new IronSoftware.Drawing.Color(51, 51, 153);

GeneratedBarcode coloredQrCode = QRCodeWriter.CreateQrCodeWithLogo("https://ironsoftware.com/csharp/barcode/", logo, 250);
GeneratedBarcode finalColoredQrCode = coloredQrCode.ChangeBarCodeColor(customColor);
finalColoredQrCode.SaveAsPng("ColorCustomizedQrCode.png");
```

<div class="content-img-align-center">
    <div class="center-image-wrapper" style="width: 35%;">
         <img src="https://ironsoftware.com/static-assets/barcode/how-to/customize-qr-code-style/coloredQrCodeWithLogo.webp" alt="Colored QR Code with Custom Logo">
    </div>
</div>

To learn about custom color creation, visit our <a href="https://ironsoftware.com/open-source/csharp/drawing/examples/create-color/">"Create Color"</a> guide.

## Annotating QR Codes

Adding annotations serves an important role, especially for promotions or informational purposes within QR codes.

```cs
using IronBarCode;
using IronSoftware.Drawing;

AnyBitmap qrLogo = AnyBitmap.FromFile("ironbarcode_top.webp");

QRCodeLogo logo = new QRCodeLogo(qrLogo, 0, 0, 20f);

Color mainColor = new Color(51, 51, 153);
Color annotationColor = new Color("#176feb");
Font annotationFont = new Font("Candara", FontStyle.Bold, 15);
Color valueColor = new Color("#6e53bb");
Font valueFont = new Font("Cambria", FontStyle.Regular, 15);

GeneratedBarcode qrCodeAnnotated = QRCodeWriter.CreateQrCodeWithLogo("https://ironsoftware.com/csharp/barcode/", logo, 250);
GeneratedBarcode qrCodeFinal = qrCodeAnnotated.ChangeBarCodeColor(mainColor).AddAnnotationTextAboveBarcode("IronBarcode Innovates!", annotationFont, annotationColor, 2).AddBarcodeValueTextBelowBarcode(valueFont, valueColor, 2);
qrCodeFinal.SaveAsPng("AnnotatedQrCode.png");
```

<div class="content-img-align-center">
    <div class="center-image-wrapper" style="width: 35%;">
         <img src="https://ironsoftware.com/static-assets/barcode/how-to/customize-qr-code-style/qrCodeWithAnnotation.webp" alt="Annotated QR Code">
    </div>
</div>

Methods like `AddAnnotationTextAboveBarcode` are used for placing text above or below the QR code, allowing for high customizability in terms of the font and color used.

In conclusion, IronBarcode excels at creating and customizing QR codes, with additional support from the internally developed IronDrawing library for image processing, which ensures reliability and stability in customizations.
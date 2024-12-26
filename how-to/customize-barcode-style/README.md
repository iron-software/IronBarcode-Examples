# Customizing and Styling Barcodes

***Based on <https://ironsoftware.com/how-to/customize-barcode-style/>***


Barcodes have become increasingly common across various applications over time, serving as a means to encode data, identification, or URLs. With their integration into consumer products, the desire to customize how these barcodes appear has grown substantially. Barcode types such as **PDF417**, **Aztec**, **IntelligentMail**, **MaxiCode**, and **DataMatrix** each possess distinct styles, but customization doesn't end there.

IronBarcode offers further customization through its features, allowing adjustments in **barcode colors**, **resizing**, and **background colors**. This is facilitated by the [IronDrawing](https://ironsoftware.com/open-source/csharp/drawing/docs/) library.

### Dive into IronBarcode

---

## Example: Resizing a Barcode

### Employing the `ResizeTo` Method

Customizing the size of a barcode is straightforward with IronBarcode's `ResizeTo` method. By specifying new **width** and **height** in **pixels**, users can re-render the barcode without loss of quality.

Here's an example where sizes that are too small to maintain readability are automatically disregarded:

```cs
using IronBarCode;

// Instantiate a barcode
GeneratedBarcode barcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.PDF417, 300, 100);

// Save the original size barcode
barcode.SaveAsPng("output.png");

// Resize the barcode and save the new image
barcode.ResizeTo(250, 100).SaveAsPng("resizedBarcode.png");
```

### Barcode Images: Before and After Resizing

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/barcode/how-to/customize-barcode-style/im.webp" alt="Barcode before resize" class="img-responsive add-shadow">
         <p class="competitors__download-link" style="color: #181818; font-style: italic; margin-bottom: 20px;">Before Resize</p>
    </div>
</div>

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/barcode/how-to/customize-barcode-style/im2.webp" alt="Barcode after resize" class="img-responsive add-shadow">
         <p class="competitors__download-link" style="color: #181818; font-style: italic; margin-bottom: 20px;">After Resize</p>
    </div>
</div>

### Using the `ResizeToMil` Method

The `ResizeToMil` method offers precision resizing for 1D barcodes, adjusting elements such as element thickness (in mils), barcode height (inches), and resolution (DPI).

Example code snippet:

```cs
using IronBarCode;

// Generate a barcode
GeneratedBarcode barcode = BarcodeWriter.CreateBarcode("12345", BarcodeEncoding.Codabar, 250, 100);

// Save the initial barcode
barcode.SaveAsPng("initialOutput.png");

// Rescale the barcode and save
barcode.ResizeToMil(20, .73, 200).SaveAsPng("rescaledOutput.png");
```

### Visualization of Barcode Sizing Changes

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/barcode/how-to/customize-barcode-style/oned.webp" alt="Barcode before ResizeToMil" class="img-responsive add-shadow">
         <p class="competitors__download-link" style="color: #181818; font-style: italic; margin-bottom: 20px;">Before ResizeToMil</p>
    </div>
</div>

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/barcode/how-to/customize-barcode-style/onedresizetomil.webp" alt="Barcode after ResizeToMil" class="img-responsive add-shadow">
         <p class="competitors__download-link" style="color: #181818; font-style: italic; margin-bottom: 20px;">After ResizeToMil</p>
    </div>
</div>

## Modifying Barcode and Background Colors

A popular feature of IronBarcode, enabled by IronDrawing, is the modification of barcode and background colors. Below is a demonstration:

```cs
using IronBarCode;
using IronSoftware.Drawing;

GeneratedBarcode barcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.Aztec);

// Adjust barcode color
barcode.ChangeBarCodeColor(Color.DarkKhaki);

// Adjust background color
barcode.ChangeBackgroundColor(Color.ForestGreen);

// Save the customized barcode
barcode.SaveAsPng("colorCustomizedBarcode.png");
```

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/barcode/how-to/customize-barcode-style/coloredAztec2.webp" alt="Barcode with customized colors" class="img-responsive add-shadow">
    </div>
</div>

## Example: Adding Barcode Annotations

IronBarcode also supports the addition of styled annotations, utilizing IronDrawing for adjustments in color and font styling:

```cs
using IronBarCode;
using IronSoftware.Drawing;

GeneratedBarcode barcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.Aztec, 500, 500);

// Modify colors
barcode.ChangeBarCodeColor(Color.DarkCyan);
barcode.ChangeBackgroundColor(Color.PeachPuff);

// Set up annotation font
Font annotationFont = new Font("Candara", FontStyle.Bold, 70);

// Add annotation above the barcode
barcode.AddAnnotationTextAboveBarcode("IronBarcode Rocks!", annotationFont, Color.DarkOrange);

// Set up value font
Font valueFont = new Font("Cambria", FontStyle.Regular, 70);

// Add barcode value below
barcode.AddBarcodeValueTextBelowBarcode(valueFont, Color.SandyBrown);

// Save the final annotated barcode
barcode.SaveAsPng("annotatedCustomizedBarcode.png");
```

<div class="content-img-align-center">
    <div class="center-image-wrapper" style="width: 40%;">
         <img src="https://ironsoftware.com/static-assets/barcode/how-to/customize-barcode-style/annotationAndBarcodeValue.webp" alt="Colored barcode with annotations" class="img-responsive add-shadow">
    </div>
</div>

IronBarcode broadly expands the possibilities for barcode customization. For detailed tutorials on enhancing QR codes, visit "[How to Customize and Add Logos to QR Codes](https://ironsoftware.com/csharp/barcode/how-to/customize-qr-code-style/)".
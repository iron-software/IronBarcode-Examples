# Tailoring and Styling Barcodes

***Based on <https://ironsoftware.com/how-to/customize-barcode-style/>***


Barcodes have seen a surge in popularity over recent years, finding their applications in various domains from storing URLs to IDs and more. As barcodes frequently appear on products, the need for styling and customization has grown. Specific barcode types like **PDF417, Aztec, IntelligentMail, MaxiCode,** and **DataMatrix** have unique styles to meet these demands.

IronBarcode enriches this customization by offering enhanced styling capabilities such as changing **barcode colors**, resizing barcodes, and modifying **background colors**. These are supported by the [IronDrawing library](https://ironsoftware.com/open-source/csharp/drawing/docs/).

## Resize Barcode Example

### Use `ResizeTo` Method

IronBarcode allows for effortless customization of barcodes' dimensions. By employing the `ResizeTo` method, users can specify new dimensions for the barcode in **pixels (px)**. This method ensures a lossless transformation of the barcode, disregarding dimensions that compromise readability.

```cs
using IronBarCode;
using BarCode;
namespace ironbarcode.CustomizeBarcodeStyle
{
    public class Section1
    {
        public void Run()
        {
            // Generate a barcode
            GeneratedBarcode barcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.PDF417, 300, 100);
            
            // Save the barcode as PNG
            barcode.SaveAsPng("output.png");
            
            // Resize the barcode and save again
            barcode.ResizeTo(250, 100).SaveAsPng("useResizeTo.png");
        }
    }
}
```

Below are images showcasing the barcode before and after resizing:

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

### Use `ResizeToMil` Method

For resizing requirements specific to 1D barcodes, `ResizeToMil` adjusts barcode elements in thousandths of an inch (mil), height in inches, and resolution in DPI.

```cs
using IronBarCode;
using BarCode;
namespace ironbarcode.CustomizeBarcodeStyle
{
    public class Section2
    {
        public void Run()
        {
            // Generate a barcode for Codabar
            GeneratedBarcode barcode = BarcodeWriter.CreateBarcode("12345", BarcodeEncoding.Codabar, 250, 100);
            
            // Export barcode as PNG
            barcode.SaveAsPng("output.png");
            
            // Apply ResizeToMil and export again
            barcode.ResizeToMil(20, .73, 200).SaveAsPng("useResizeToMil.png");
        }
    }
}
```

Images below display the barcode transformations applied by `ResizeToMil`:

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

## Adjusting Barcode Colors

A highly demanded customization feature for barcodes is the ability to alter barcode and background colors. This is achieved using `ChangeBarCodeColor` and `ChangeBackgroundColor` methods, which are supported by the [IronDrawing library](https://ironsoftware.com/open-source/csharp/drawing/docs/).

```cs
using IronSoftware.Drawing;
using BarCode;
namespace ironbarcode.CustomizeBarcodeStyle
{
    public class Section3
    {
        public void Run()
        {
            GeneratedBarcode barcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.Aztec);
            
            // Modify colors
            barcode.ChangeBarCodeColor(Color.DarkKhaki);
            barcode.ChangeBackgroundColor(Color.ForestGreen);
            
            // Save the colored barcode as PNG
            barcode.SaveAsPng("coloredAztec2.png");
        }
    }
}
```

Below is an image of a colored Aztec barcode:

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/barcode/how-to/customize-barcode-style/coloredAztec2.webp" alt="Barcode with color" class="img-responsive add-shadow">
    </div>
</div>

## Adding Annotations

IronBarcode also supports adding styled annotations, with IronDrawing providing the required functionality for text editing regarding color and fonts.

```cs
using BarCode;
namespace ironbarcode.CustomizeBarcodeStyle
{
    public class Section4
    {
        public void Run()
        {
            ﻿using IronBarCode;
            using IronSoftware.Drawing;
            
            GeneratedBarcode barcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.Aztec, 500, 500);
            
            // Alter barcode and background color
            barcode.ChangeBarCodeColor(Color.DarkCyan);
            barcode.ChangeBackgroundColor(Color.PeachPuff);
            
            // Specify fonts for annotations
            Font annotationFont = new Font("Candara", FontStyle.Bold, 70);
            
            // Add annotations
            barcode.AddAnnotationTextAboveBarcode("IronBarcodeRocks!", annotationFont, Color.DarkOrange);
            
            Font barcodeValueFont = new Font("Cambria", FontStyle.Regular, 70);
            
            // Add barcode value display below
            barcode.AddBarcodeValueTextBelowBarcode(barcodeValueFont, Color.SandyBrown);
            
            barcode.SaveAsPng("annotationAndBarcodeValue.png");
        }
    }
}
```

Below is the barcode with color and annotations:

<div class="content-img-align-center">
    <div class="center-image-wrapper" style="width: 40%;">
         <img src="https://ironsoftware.com/static-assets/barcode/how-to/customize-barcode-style/annotationAndBarcodeValue.webp" alt="Colored barcode with annotations" class="img-responsive add-shadow">
    </div>
</div>

IronBarcode offers extensive opportunities for customizing and styling barcodes, only limited by creativity. For more information on styling QR codes, check out "[How to Customize and Add Logos to QR Codes](https://ironsoftware.com/csharp/barcode/how-to/customize-qr-code-style/)".
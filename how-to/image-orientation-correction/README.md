# Correcting Barcode Orientation

***Based on <https://ironsoftware.com/how-to/image-orientation-correction/>***


Barcode orientation describes the angle at which a barcode appears on a product or document. It's possible to adjust this to different angles to suit various design and layout needs. Horizontal orientation is the most common, with the barcode running from left to right. This is the standard and most frequently used alignment. However, barcodes with any angle other than zero can present challenges for detection and decoding. IronBarcode simplifies this process by offering features that automatically correct the orientation of both barcodes and QR codes.

### Getting Started with IronBarcode

---

## Example: Correcting Barcode Orientation

To enable automatic orientation correction, you simply need to enable the **AutoRotate** property within `BarcodeReaderOptions`. By default, this property is already set to true, meaning you often won't need to make any adjustments for it to function. This allows for seamless reading of barcodes regardless of their orientation.

Consider the following example images. You can download these images to see how the correction works: [20° rotated image](https://ironsoftware.com/static-assets/barcode/how-to/image-orientation-correction/rotate20.png) and [45° rotated image](https://ironsoftware.com/static-assets/barcode/how-to/image-orientation-correction/rotate45.png).

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/barcode/how-to/image-orientation-correction/rotate20.png" alt="20° Rotation" class="img-responsive add-shadow" >
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">20° Rotation</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/barcode/how-to/image-orientation-correction/rotate45.png" alt="45° Rotation" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">45° Rotation</p>
    </div>
</div>

### Implementing Code

```cs
using IronBarCode;
using System;

// Setup barcode reader options with auto rotation enabled
BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    AutoRotate = true, // Enables automatic rotation detection
};

var barcodeResults = BarcodeReader.Read("rotate20.png", options);

// Output the decoded value from the barcode
Console.WriteLine(barcodeResults[0].Value);
```

In certain situations, merely adjusting the rotation might not be enough, and additional image filtering might be needed. To dive deeper into using image filters, refer to the following guide: [Using Image Correction Filters](https://ironsoftware.com/how-to/image-orientation-correction/).
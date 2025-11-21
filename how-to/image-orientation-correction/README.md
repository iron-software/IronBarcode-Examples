# Adjusting Barcode Orientation

***Based on <https://ironsoftware.com/how-to/image-orientation-correction/>***


Barcode orientation pertains to the angle at which a barcode is printed or shown on a product or document. This orientation can be modified to various degrees to suit different design and layout needs. Horizontally aligned barcodes, extending from left to right, represent the most recognized and prevalent orientation. However, barcodes positioned at any other angle may present detection challenges, which IronBarcode skillfully handles with its automatic orientation correction feature for both barcodes and QR codes.

## Quickstart: Simplify Image Correction with Auto-rotate

IronBarcode simplifies the task of correcting barcode orientation via its one-line code solution, utilizing the default-enabled `AutoRotate` option, ensuring accurate barcode readings regardless of image rotation.

```cs
var result = IronBarCode.BarcodeReader.Read("rotatedImage.png", new IronBarCode.BarcodeReaderOptions { AutoRotate = true });
```

## Example: Automatically Correcting Barcode Orientation

To leverage automatic orientation correction, simply ensure that the `AutoRotate` property in `BarcodeReaderOptions` is set to true, which it is by default. This will facilitate the seamless reading of barcodes with any orientation right out of the box.

Consider the following example images. Download the provided [20° rotation](https://ironsoftware.com/static-assets/barcode/how-to/image-orientation-correction/rotate20.png) and [45° rotation](https://ironsoftware.com/static-assets/barcode/how-to/image-orientation-correction/rotate45.png) samples for practice.

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

### Implementing the Code

```csharp
using IronBarCode;
using System;

BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    AutoRotate = true, // Enable automated rotation for ML detection
};

var results = BarcodeReader.Read("rotate20.png", options);

Console.WriteLine(results[0].Value); // Display the decoded value
```

In some situations, merely correcting the orientation may not be enough, and additional image filtering might be necessary. For insights on applying image filters, refer to the article: "[How to use Image Correction Filters](https://ironsoftware.com/csharp/ocr/how-to/image-orientation-correction/)."
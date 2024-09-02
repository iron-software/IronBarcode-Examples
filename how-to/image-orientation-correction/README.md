# Adjusting Barcode Orientation

Barcode orientation refers to the specific angle at which a barcode is printed or displayed on an item, which may vary to comply with different layout and design specifications. A horizontal orientation, aligning the barcode from left to right, is the most familiar and frequently utilized configuration. Variations in this orientation can introduce challenges for their detection and interpretation. IronBarcode, however, excels by offering automatic correction functionality that efficiently identifies and processes barcodes and QR codes of any non-standard orientation.

## Example of Correcting Barcode Orientation

To engage automatic orientation correction, simply ensure the **AutoRotate** property in `BarcodeReaderOptions` is set to true. By default, this property is enabled, so additional configuration is usually unnecessary. With this setting active, scanning barcodes oriented at any angle other than zero should function seamlessly.

Consider the following example utilizing the sample images provided. You can download the 20° and 45° rotated images here: [20° rotation](https://ironsoftware.com/static-assets/barcode/how-to/image-orientation-correction/rotate20.png) and [45° rotation](https://ironsoftware.com/static-assets/barcode/how-to/image-orientation-correction/rotate45.png).

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/barcode/how-to/image-orientation-correction/rotate20.png" alt="20° Rotation" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">20° Rotation</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/barcode/how-to/image-orientation-correction/rotate45.png" alt="45° Rotation" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">45° Rotation</p>
    </div>
</div>

### Sample Code

```cs
using IronBarCode;
using System;

BarcodeReaderOptions options = new BarcodeReaderOptions() 
{
    AutoRotate = true, // Enables automatic recognition and correction of barcode orientation
};

// Decoding the barcode with automatic orientation correction
var results = BarcodeReader.Read("rotate20.png", options);

// Displaying the decoded value from the barcode
Console.WriteLine(results[0].Value);
```

In some situations, merely adjusting for rotation isn't enough, and additional image filtering might be necessary. Explore further about using image filters in the following guide: "[How to Use Image Correction Filters](https://ironsoftware.com/how-to/image-orientation-correction/)."
# Correcting Barcode Orientation

***Based on <https://ironsoftware.com/how-to/image-orientation-correction/>***


Barcode orientation pertains to the angle at which a barcode appears on a product or document. It can vary widely to accommodate different layout and design preferences. The standard orientation is horizontal, extending from left to right. Orientations differing from zero degrees can pose detection challenges for reading libraries. IronBarcode, however, seamlessly enables automatic orientation adjustments for barcodes and QR codes.

## Example of Barcode Orientation Adjustment

To utilize automatic orientation correction, you should activate the **AutoRotate** feature in `BarcodeReaderOptions`. This setting is enabled by default, ensuring that barcodes at any orientation are readable right out of the box.

Consider the following examples. You can download these sample images for a [20° rotation](https://ironsoftware.com/static-assets/barcode/how-to/image-orientation-correction/rotate20.png) and a [45° rotation](https://ironsoftware.com/static-assets/barcode/how-to/image-orientation-correction/rotate45.png).

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

### Sample Code

```cs
using System;
using BarCode;
namespace ironbarcode.ImageOrientationCorrection
{
    public class BarcodeOrientationExampler
    {
        public void Execute()
        {
            BarcodeReaderOptions options = new BarcodeReaderOptions()
            {
                AutoRotate = true, // Enable automatic rotation
            };
            
            var barcodeResults = BarcodeReader.Read("rotate20.png", options);
            
            // Output the scanned value
            Console.WriteLine(barcodeResults[0].Value);
        }
    }
}
```

Adjusting orientation might often need to be supplemented by additional filtering. For details on utilizing image filters for further refinement, see the related guide on "[How to use Image Correction Filters](https://ironsoftware.com/how-to/image-orientation-correction/)."
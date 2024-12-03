# How to Specify Barcode Crop Regions for Enhanced Scanning

***Based on <https://ironsoftware.com/how-to/set-crop-region/>***


One of the standout features in IronBarcode is the capability for users to define specific **Crop Regions**. This function enables IronBarcode to focus on predetermined areas or specific barcodes within an image, utilizing the `IronSoftware.Drawing.Rectangle` object. Employing this feature not only minimizes reading errors but also boosts performance.

## Identifying Crop Region Coordinates and Dimensions in an Image

To ascertain the coordinates for a Crop Region, various methods can be utilized. A straightforward approach is to use the computer's 'Paint' application. Begin by loading the image, then hover the mouse at the desired starting point which represents the top-left corner of the `Rectangle` and note the x,y coordinates displayed at the bottom left of the screen. Continue by selecting the opposite corner which will be the bottom-right corner of the `Rectangle`. The following image offers a visual guide to better understand this setup.

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/barcode/how-to/set-crop-region/cropregion.png" alt="CropRegion reference" class="img-responsive add-shadow">
         <p class="competitors__download-link" style="color: #181818; font-style: italic; margin-bottom: 20px;">Illustration of CropRegion setup</p>
    </div>
</div>

These coordinates are then assigned as properties to the `Rectangle` object. The object's **width** can be calculated with the formula *x2 - x1* and the **height** by *y2 - y1*.

```cs
using IronBarCode;
using BarCode;

namespace ironbarcode.SetCropRegion
{
    public class Section1
    {
        public void Run()
        {
            int x1 = 62;
            int y1 = 29;
            int x2 = 345;
            int y2 = 522;
            
            IronSoftware.Drawing.Rectangle crop1 = new IronSoftware.Drawing.Rectangle(x: x1, y: y1, width: x2 - x1, height: y2 - y1);
            // Creating a new rectangle for crop area
        }
    }
}
```

## Implementing the CropRegion for Barcode Reading

After determining the CropRegion, it needs to be integrated within the `BarcodeReaderOptions` as the `CropArea` property. This configured object is then passed as a parameter in the `BarcodeReader.Read()` method to enable focused barcode reading within the specified region. Below, we demonstrate this implementation:

```cs
using System;
using BarCode;

namespace ironbarcode.SetCropRegion
{
    public class Section2
    {
        public void Run()
        {
            int x1 = 62;
            int y1 = 29;
            int x2 = 345;
            int y2 = 522;
            
            IronSoftware.Drawing.Rectangle crop1 = new IronSoftware.Drawing.Rectangle(x: x1, y: y1, width: x2 - x1, height: y2 - y1);
            // Define the rectangle crop area with specified coordinates
            
            BarcodeReaderOptions options = new BarcodeReaderOptions()
            {
                CropArea = crop1
            };
            // Incorporating the crop area into the reader options
            
            var result = BarcodeReader.Read("sample.png", options);
            foreach (var item in result)
            {
                Console.WriteLine(item.Value);
                // Outputs each barcode value found within the crop area
            }
        }
    }
}
```

From the code snippets provided, we can see that the `Rectangle` object is utilized as the `CropArea` property within the `BarcodeReaderOptions`, which directs the barcode reader to constrain its scanning area to the predefined region. This ensures efficient and error-free reading.
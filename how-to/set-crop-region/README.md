# Defining a Crop Region to Enhance Barcode Reading Speed

***Based on <https://ironsoftware.com/how-to/set-crop-region/>***


One of the standout features of IronBarcode is its ability to set specific **Crop Regions** using the `IronSoftware.Drawing.Rectangle` object. This functionality allows IronBarcode to focus on predefined areas of an image, enhancing accuracy and speed of barcode reading by ignoring irrelevant areas.

### Get started with IronBarcode


------

## Identifying Crop Region Coordinates and Size in an Image

To find crop region coordinates, users can utilize several methods, one of which is using the computer’s 'Paint' application. Load the image in Paint, and navigate to the desired top-left corner of the Crop Region. Note the x and y coordinates displayed at the bottom-left corner of the screen for this first point. Then, determine the second point at the bottom right corner of the `Rectangle`. The image below provides a visual guide for this process.

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/barcode/how-to/set-crop-region/cropregion.png" alt="CropRegion reference" class="img-responsive add-shadow">
         <p class="competitors__download-link" style="color: #181818; font-style: italic; margin-bottom: 20px;">Setting CropRegion reference</p>
    </div>
</div>

Utilize these coordinates to establish the `Rectangle` object properties. The **width** is calculated as *x2 - x1*, and the **height** as *y2 - y1*.

```cs
using IronBarCode;

// Define coordinates
int x1 = 62;
int y1 = 29;
int x2 = 345;
int y2 = 522;

// Create a Rectangle using determined coordinates and size
IronSoftware.Drawing.Rectangle crop1 = new IronSoftware.Drawing.Rectangle(x: x1, y: y1, width: x2-x1, height: y2-y1);
```

## Applying the Crop Region and Reading the Barcode

With the CropRegion defined, it’s time to leverage this in IronBarcode's settings. Below, see how to include the crop region within `BarcodeReaderOptions`, which can significantly enhance the reading process when used with the `BarcodeReader.Read()` method.

```cs
using IronBarCode;
using System;

// Define coordinates
int x1 = 62;
int y1 = 29;
int x2 = 345;
int y2 = 522;

// Create a Rectangle for the crop area
IronSoftware.Drawing.Rectangle crop1 = new IronSoftware.Drawing.Rectangle(x: x1, y: y1, width: x2 - x1, height: y2 - y1);

// Define barcode reading options with specified crop area
BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    CropArea = crop1
};

// Read barcodes from an image using defined crop area
var result = BarcodeReader.Read("sample.png", options);
foreach (var item in result)
{
    Console.WriteLine(item.Value);
}
```

In this demonstration, we apply the instantiated `Rectangle` in the `BarcodeReaderOptions` object's `CropArea` property. The `BarcodeReader.Read()` method then utilizes these settings to read barcodes precisely from the specified area in the image.
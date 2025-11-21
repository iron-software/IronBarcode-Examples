# Defining Crop Regions for Efficient Barcode Scanning

***Based on <https://ironsoftware.com/how-to/set-crop-region/>***


A key functionality available in IronBarcode is its capability to set **Crop Regions**. This is particularly useful for focusing the barcode reading process on specific sections of an image. By defining a `IronSoftware.Drawing.Rectangle`, users can significantly minimize errors and enhance the barcode scanning speed.

## Getting Started: Quickly Apply Crop Regions for Enhanced Reading Speed

Easily define a crop rectangle and integrate it with IronBarcode—a streamlined process without any additional hassle. Below is a simple demonstration of how to focus the barcode scanning on an exact area using `BarcodeReaderOptions`.

```cs
// Example: Setting the Crop Area with One Line of Code to Improve Reading Speed
var results = IronBarCode.BarcodeReader.Read("image.png", new IronBarCode.BarcodeReaderOptions { CropArea = new IronSoftware.Drawing.Rectangle(x: 50, y: 100, width: 300, height: 150) });
```

## Identifying Crop Region Coordinates in an Image

Users have several techniques at their disposal to determine image coordinates suitable for a crop region. For instance, opening the image in the 'Paint' application allows one to obtain the coordinates. Position the cursor at the top-left corner of the desired crop area, note the x, y coordinates from the screen's bottom left. Similarly, determine the coordinates for the bottom-right corner of the crop region.

Refer to the image below for an illustrative guide on setting up a Crop Region:

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/barcode/how-to/set-crop-region/cropregion.png" alt="CropRegion reference" class="img-responsive add-shadow">
         <p class="competitors__download-link" style="color: #181818; font-style: italic; margin-bottom: 20px;">Setting CropRegion reference</p>
    </div>
</div>

These coordinates serve as properties to set the dimensions of the `Rectangle` where **width** is determined by *x2 - x1* and **height** by *y2 - y1*.

```cs
using IronBarCode;

int x1 = 62;
int y1 = 29;
int x2 = 345;
int y2 = 522;

IronSoftware.Drawing.Rectangle crop1 = new IronSoftware.Drawing.Rectangle(x: x1, y: y1, width: x2-x1, height: y2-y1);
```

## Implementing the Crop Region for Barcode Decoding

Having configured the `Rectangle` to define the Crop Region, it can be integrated into the `BarcodeReaderOptions`. These options are then passed to the `BarcodeReader.Read()` method to apply the Crop Region and decode the barcode within:

```cs
using IronBarCode;
using System;

int x1 = 62;
int y1 = 29;
int x2 = 345;
int y2 = 522;

IronSoftware.Drawing.Rectangle crop1 = new IronSoftware.Drawing.Rectangle(x: x1, y: y1, width: x2 - x1, height: y2 - y1);

BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    CropArea = crop1
};

var result = BarcodeReader.Read("sample.png", options);
foreach (var item in result)
{
    Console.WriteLine(item.Value);
}
```

From the code snippet above, we see how to use the `Rectangle` in the `BarcodeReaderOptions` as the `CropArea` property, and how to employ these settings to precision-scan barcodes within a specified area.
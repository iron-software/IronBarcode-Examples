# Enhancing Barcode Read Speed by Defining Crop Regions in IronBarcode

IronBarcode includes a standout feature that allows developers to define **Crop Regions** for selective reading within an image. Leveraging the `IronSoftware.Drawing.Rectangle` object, users can specify exact areas with barcodes that need reading. This focused approach not only boosts the efficiency and speed of readings but also minimizes errors.

## Determining Crop Region Coordinates

To pinpoint the coordinates on any given image, several methods are available. A straightforward tool is the 'Paint' application on your computer. Begin by loading your image into Paint and click on the desired starting point of the `Rectangle` — this will usually be the top left corner. The x,y coordinate will appear at the bottom left of the application. Find and record the opposite point, which will be the bottom right corner of the `Rectangle`, as illustrated in the following image:

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/barcode/how-to/set-crop-region/cropregion.png" alt="CropRegion reference" class="img-responsive add-shadow">
         <p class="competitors__download-link" style="color: #181818; font-style: italic; margin-bottom: 20px;">Reference for setting CropRegion</p>
    </div>
</div>

Using these coordinates, you can define the **width** and **height** of the `Rectangle` as *x2 - x1* and *y2 - y1*, respectively.

```cs
using IronBarCode;

int x1 = 62;
int y1 = 29;
int x2 = 345;
int y2 = 522;

IronSoftware.Drawing.Rectangle crop1 = new IronSoftware.Drawing.Rectangle(x: x1, y: y1, width: x2-x1, height: y2-y1);
// Rectangle with specific coordinates to represent the Crop Region
```

## Implementing the Crop Region and Reading Barcodes

After defining the Crop Region, the next step is to integrate this region into the barcode reading process. This is achieved by assigning our `Rectangle` object as a property to the `BarcodeReaderOptions` object. We can then pass this configured options object to the `BarcodeReader.Read()` method to restrict scanning within the specified area.

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
    CropArea = crop1 // Assigning the custom Crop Area
};

var result = BarcodeReader.Read("sample.png", options);
foreach (var item in result)
{
    Console.WriteLine(item.Value); // Output the values of barcodes read within the Crop Area
}
```

By defining and implementing the Crop Region, IronBarcode is directed to focus on specified portions of images, thereby making the barcode reading process more efficient and accurate.
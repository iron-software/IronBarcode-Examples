# How to Read Barcodes from Multi-Page/Frame GIF and TIFF

***Based on <https://ironsoftware.com/how-to/read-barcodes-from-multi-page-frame-tiff-gif/>***


IronBarcode seamlessly handles reading from various image formats, including **multi-page and multi-frame GIF and TIFF**. Users benefit from the convenience of processing images without needing to separate the frames or pages manually. Here's how to efficiently utilize IronBarcode for handling these specific formats.

### Quickstart: Reading Barcodes Completely from Multipage TIFF or GIF Files

With a straightforward method invocation, IronBarcode effortlessly handles multipage TIFFs or animated GIFs, decoding all embedded barcodes. There’s no need for frame separation or intricate preprocessing—simply supply the file path to `BarcodeReader.Read` for immediate results.

```csharp
:title=Effortlessly Extract Barcodes from Multi-Page Images
IronBarCode.BarcodeResults results = IronBarCode.BarcodeReader.Read("multiPageImage.tiff");
```

## Reading Multi-Frame GIF and TIFF Images

IronBarcode simplifies the reading of multi-frame GIF and TIFF images just as if they were single-frame ones. The library intelligently manages the complexities internally, requiring no preliminary image manipulation by the user.

Below is a demonstration on reading from multipage GIF and TIFF formats:

```csharp
using IronBarCode;
using System;

// Decode barcodes from TIFF image
BarcodeResults results = BarcodeReader.Read("example.tif");

// Print detected barcodes
foreach (var result in results)
{
    Console.WriteLine(result.Value);
}
```

## Convert Images into GIF and TIFF

Transform images into multipage TIFF and GIF formats using the versatile [IronDrawing](https://ironsoftware.com/open-source/csharp/drawing/docs/) library. The following code snippet guides you through the creation of multipage images.

```csharp
using IronBarCode;
using IronSoftware.Drawing;
using System.Collections.Generic;

// Load individual images
List<AnyBitmap> images = new List<AnyBitmap>()
{
    AnyBitmap.FromFile("image1.png"),
    AnyBitmap.FromFile("image2.png"),
    AnyBitmap.FromFile("image3.png"),
    AnyBitmap.FromFile("image4.jpg"),
    AnyBitmap.FromFile("image5.jpg")
};

// Create a multipage TIFF from the images
AnyBitmap tiffImage = AnyBitmap.CreateMultiFrameTiff(images);

// Save the TIFF
tiffImage.SaveAs("combinedImages.tiff");

// Create a multipage GIF from the images
AnyBitmap gifImage = AnyBitmap.CreateMultiFrameGif(images);

// Save the GIF
gifImage.SaveAs("combinedAnimation.gif");
```

In this code, multiple single-frame image files are imported into a `List<AnyBitmap>`. This list is then used to generate a multipage TIFF and a multipage GIF using `AnyBitmap.CreateMultiFrameTiff` and `AnyBitmap.CreateMultiFrameGif` methods, respectively.

While both GIF and TIFF formats support multiple images in a single file, there are notable differences between them as highlighted in the table below:

<table class="table">
    <tr style="background-color: rgb(241, 249, 251);">
        <th>Attribute</th>
        <th>Multipage GIF</th>
        <th>Multipage TIFF</th>
    </tr>
    <tr>
        <td>Compression</td>
        <td>Employs lossless compression, typically resulting in larger file sizes.</td>
        <td>Offers both lossy and lossless compression methods to effectively manage file size and image quality.</td>
    </tr>
    <tr>
        <td>Color Depth</td>
        <td>Limited to 256 colors, which may affect the detail and color accuracy.</td>
        <td>Supports a broader range of color depths, enhancing the potential for detail preservation.</td>
    </tr>
    <tr>
        <td>Transparency</td>
        <td>Supports only binary transparency, which can cause jagged edges in images.</td>
        <td>Provides sophisticated transparency options such as alpha channel, enabling better image integrity.</td>
    </tr>
    <tr>
        <td>Animation</td>
        <td>Enables simple animations, a feature extensively utilized on the web.</td>
        <td>Lacks inherent support for animation, focusing more on capturing individual high-quality images.</td>
    </tr>
</table>

## Advanced Barcode Reading

To tap into the full potential of IronBarcode for particularly challenging images, one might consider configuring the `BarcodeReaderOptions` class. Detailed information is available in the '[Reading Barcodes from Various Image Files](https://ironsoftware.com/csharp/barcode/how-to/read-barcodes-from-images/#advance-barcode-read-from-image)' guide.

Here’s an example setup involving customized barcode reading options:

```csharp
using IronBarCode;
using System;

// Setup image enhancement filters
ImageFilterCollection filters = new ImageFilterCollection()
{
    new SharpenFilter(3.5f),
    new ContrastFilter(2)
};

// Configure advanced settings
BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    ExpectBarcodeTypes = IronBarCode.BarcodeEncoding.QRCode,
    ImageFilters = filters,
    ExpectMultipleBarcodes = true,
    Speed = ReadingSpeed.Balanced
};

// Enhanced barcode reading from TIFF
BarcodeResults results = BarcodeReader.Read("detailedExample.tif", options);

// Display all detected barcode values
foreach (var result in results)
{
    Console.WriteLine(result.Value);
}
```

By adjusting properties such as `ExpectBarcodeTypes`, `ImageFilters`, and `Speed`, users can fine-tune IronBarcode’s engine to efficiently handle complex barcode scenarios. While these enhancements are optional, they significantly elevate the accuracy and efficiency of the barcode extraction process, ensuring optimal results even from intricate image files.
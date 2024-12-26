# Reading Barcodes from System.Drawing Objects

***Based on <https://ironsoftware.com/how-to/read-barcodes-from-system-drawing/>***


System.Drawing objects have traditionally been integral to .NET developers for image-related operations. However, with Microsoft’s phasing out of [support for System.Drawing](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only) on platforms other than Windows, those utilizing IronBarcode on MacOS or Linux have encountered several difficulties. The use of System.Drawing in barcode processing typically involves elements such as **graphics**, **images**, and **fonts**.

To counter these challenges, Iron Software has developed [IronDrawing](https://ironsoftware.com/open-source/csharp/drawing/docs/), a **free** and **open-source** tool that enhances cross-platform functionality, making it easier to use on non-Windows systems. Following the installation of IronBarcode via NuGet, IronDrawing is automatically integrated into your project.

### Initialize IronBarcode

---

## Transform System.Drawing to AnyBitmap

The task of reading barcodes from System.Drawing objects is streamlined by simply converting the object into an AnyBitmap. IronDrawing is crafted to ease this conversion process. It seamlessly allows for implicit conversions of image objects from **System.Drawing** to **IronSoftware.Drawing** via **AnyBitmap**.

Additionally, the library facilitates the conversion of other image types, including:

- **System.Drawing.Bitmap**
- **System.Drawing.Image**
- **SkiaSharp.SKBitmap**
- **SkiaSharp.SKImage**
- **SixLabors.ImageSharp**

For detailed guidance on this transformation, view this [coding example](https://ironsoftware.com/open-source/csharp/drawing/examples/cast-to-anybitmap/). Below, a sample code illustrates the transition of barcode images from **System.Drawing objects** to **IronSoftware.Drawing.AnyBitmap**.

```cs
using IronSoftware.Drawing;
using System.Collections.Generic;

List<AnyBitmap> barcodeList = new List<AnyBitmap>();

// Create a new Bitmap
System.Drawing.Bitmap sourceBitmap = new System.Drawing.Bitmap("test1.jpg");

// Convert System.Drawing.Bitmap to AnyBitmap
AnyBitmap barcodeFromBitmap = sourceBitmap;

barcodeList.Add(barcodeFromBitmap);

// Load an Image
System.Drawing.Image imageFromfile = System.Drawing.Image.FromFile("test2.png");

// Convert System.Drawing.Image to AnyBitmap
AnyBitmap barcodeFromImage = imageFromfile;

barcodeList.Add(barcodeFromImage);
```

In the sample above, we initiated instances of **System.Drawing.Bitmap** and **System.Drawing.Image**, then transformed these into AnyBitmap. These were subsequently stored in a list of AnyBitmap items.

## Barcode Recognition with AnyBitmap

IronBarcode seamlessly integrates with **IronSoftware.Drawing.AnyBitmap** for barcode recognition across different platforms, supporting images that were previously restricted on systems other than Windows. The following code demonstrates how to execute this:

```cs
using IronBarCode;
using IronSoftware.Drawing;
using System.Collections.Generic;

List<AnyBitmap> barcodeImageList = new List<AnyBitmap>();

System.Drawing.Bitmap imageAsBitmap = new System.Drawing.Bitmap("test1.jpg");
AnyBitmap convertedBarcode1 = imageAsBitmap;
barcodeImageList.Add(convertedBarcode1);

System.Drawing.Image imageAsImage = System.Drawing.Image.FromFile("test2.png");
AnyBitmap convertedBarcode2 = imageAsImage;
barcodeImageList.Add(convertedBarcode2);

foreach (AnyBitmap barcode in barcodeImageList)
{
    // Decode the barcode
    var decodingResults = BarcodeReader.Read(barcode);
    foreach (var result in decodingResults)
    {
        // Display the decoded barcode value
        Console.WriteLine(result.Value);
    }
}
```

The follow-up code builds upon the conversion example, populating an AnyBitmap collection, iterating through it, and extracting barcodes using the `Read` method, thus obtaining **IronBarcode.BarcodeResults**.

Additionally, **IronSoftware.Drawing** has broader applications, not just for image transformations but for modifying other aspects like **colors** and **fonts**. These features are valuable for styling barcodes and QR codes, which can be further explored in [customizing and appending logos to QR codes](https://ironsoftware.com/csharp/barcode/how-to/customize-qr-code-style/).
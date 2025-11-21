# How to Process Barcodes with System.Drawing Objects

***Based on <https://ironsoftware.com/how-to/read-barcodes-from-system-drawing/>***


System.Drawing objects are commonly utilized by .NET developers for image processing tasks. However, it's important to note that Microsoft has [ceased supporting System.Drawing](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only) on platforms other than **Windows**, such as **MacOS** and **Linux**. This change has posed challenges for developers using IronBarcode on these non-Windows platforms, particularly when dealing with **graphics**, **images**, and **fonts** associated with barcodes.

To overcome these challenges, IronSoftware has introduced [IronDrawing](https://ironsoftware.com/open-source/csharp/drawing/docs/), a **free**, **open-source** library intended to facilitate compatibility on non-Windows operating systems. When you install IronBarcode via NuGet, IronDrawing is seamlessly integrated into your project.

## Quickstart: Decode a Barcode With AnyBitmap In a Single Step

The following example illustrates the straightforward process of using IronBarcode to decode a barcode from a `System.Drawing.Bitmap`, which is automatically handled as `AnyBitmap` without complicated setups, ensuring ease of use across different operating systems.

```cs
:title=Efficient Barcode Decoding from System.Drawing
var barcodeResult = IronBarCode.BarcodeReader.Read((AnyBitmap)(new System.Drawing.Bitmap("yourImage.png")));
```

## Transform System.Drawing to AnyBitmap

To decode barcodes from `System.Drawing`, you can directly cast the image object to `AnyBitmap`. IronDrawing simplifies this process, allowing for implicit conversions from `System.Drawing` image objects to `IronSoftware.Drawing.AnyBitmap`.

Beyond `System.Drawing`, IronDrawing also supports conversions from:

- **`System.Drawing.Bitmap`**
- **`System.Drawing.Image`**
- **`SkiaSharp.SKBitmap`**
- **`SkiaSharp.SKImage`**
- **`SixLabors.ImageSharp`**

For detailed instructions on how to implement these conversions, refer to the following [code sample](https://ironsoftware.com/open-source/csharp/drawing/examples/cast-to-anybitmap/). Here’s a simplified example demonstrating the conversion of barcode images from `System.Drawing` objects to `AnyBitmap`:

```csharp
using IronSoftware.Drawing;
using System.Collections.Generic;

List<AnyBitmap> barcodeList = new List<AnyBitmap>();

// Load from System.Drawing.Bitmap
System.Drawing.Bitmap initialBitmap = new System.Drawing.Bitmap("image1.jpg");
AnyBitmap convertedBarcode1 = initialBitmap;
barcodeList.Add(convertedBarcode1);

// Load from System.Drawing.Image
System.Drawing.Image initialImage = System.Drawing.Image.FromFile("image2.png");
AnyBitmap convertedBarcode2 = initialImage;
barcodeList.Add(convertedBarcode2);
```

Here, we've loaded barcode images as `System.Drawing.Bitmap` and `System.Drawing.Image`, then easily converted them to `AnyBitmap` and added to a list of `AnyBitmap` objects.

## Decoding Barcodes from AnyBitmap

IronBarcode effortlessly integrates with `IronSoftware.Drawing.AnyBitmap` for barcode decoding, eliminating the need for extensive configuration. Here's how you can read barcodes from the list of `AnyBitmap`:

```csharp
using IronBarCode;
using IronSoftware.Drawing;
using System;
using System.Collections.Generic;

List<AnyBitmap> barcodes = new List<AnyBitmap>();

System.Drawing.Bitmap bitmapToConvert1 = new System.Drawing.Bitmap("example1.jpg");
AnyBitmap anyBitmap1 = bitmapToConvert1;
barcodes.Add(anyBitmap1);

System.Drawing.Image imageToConvert1 = System.Drawing.Image.FromFile("example2.png");
AnyBitmap anyBitmap2 = imageToConvert1;
barcodes.Add(anyBitmap2);

foreach (var singleBarcode in barcodes)
{
    // Decode barcode
    var decodedResults = BarcodeReader.Read(singleBarcode);
    foreach (var result in decodedResults)
    {
        // Display barcode content
        Console.WriteLine(result.Value);
    }
}
```

In this continuation of the previous example, after populating the `AnyBitmap` list, we iterate through, decode each barcode, and print the detected barcode values to the console.

Exploring other functionalities of **IronSoftware.Drawing** can enhance your image processing tasks, including working with **colors** and **fonts** to style barcodes and QR codes. Discover more about using IronDrawing to [personalize and integrate logos](https://ironsoftware.com/csharp/barcode/how-to/customize-qr-code-style/) into QR codes.
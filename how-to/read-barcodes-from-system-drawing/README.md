# Reading Barcodes from System.Drawing Objects Using IronSoftware Libraries

Developers use `.NET` System.Drawing objects for various image manipulation tasks. Unfortunately, Microsoft has [ceased support for System.Drawing](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only) across non-Windows operating systems like macOS and Linux, positioning it as exclusive to **Windows**. This has presented challenges for developers working with barcodes in environments other than Windows due to reliance on components such as **graphics**, **images**, and **fonts**.

To overcome these obstacles, IronSoftware has developed [IronDrawing](https://ironsoftware.com/open-source/csharp/drawing/docs/), a **free** and **open-source** library designed to extend support to non-Windows operating systems. This solution enhances usability across various platforms. Installing IronBarcode through NuGet will automatically incorporate IronDrawing into your project, seamlessly integrating it for immediate use.


## Transforming System.Drawing to AnyBitmap

To decode barcodes from System.Drawing, one needs to convert the object to AnyBitmap. IronDrawing facilitates this transformation with minimal code, allowing implicit conversion from **System.Drawing** to **IronSoftware.Drawing** represented by the term **AnyBitmap**.

Conversion is also supported for many object types, including:

- **System.Drawing.Bitmap**
- **System.Drawing.Image**
- **SkiaSharp.SKBitmap**
- **SkiaSharp.SKImage**
- **SixLabors.ImageSharp**

Please see the following [casting example](https://ironsoftware.com/open-source/csharp/drawing/examples/cast-to-anybitmap/) for a detailed guide. Here’s a brief code snippet illustrating how to cast barcode images from **System.Drawing objects** to **IronSoftware.Drawing.AnyBitmap**:

```cs
using IronSoftware.Drawing;
using System.Collections.Generic;

var barcodes = new List<AnyBitmap>();

// Create a System.Drawing.Bitmap
var bitmapFromBitmap = new System.Drawing.Bitmap("test1.jpg");

// Convert System.Drawing.Bitmap to AnyBitmap
var barcode1 = bitmapFromBitmap;
barcodes.Add(barcode1);

// Create another System.Drawing.Image from a file
var bitmapFromFile = System.Drawing.Image.FromFile("test2.png");

// Convert System.Drawing.Image to AnyBitmap
var barcode2 = bitmapFromFile;
barcodes.Add(barcode2);
```

This example demonstrates loading and converting images from **System.Drawing.Bitmap** and **System.Drawing.Image** to AnyBitmap, subsequently adding these instances to a list of AnyBitmap objects.

## Barcode Decoding from AnyBitmap Objects

IronBarcode integrates seamlessly with **IronSoftware.Drawing.AnyBitmap**, allowing developers straightforward decoding capabilities straight from AnyBitmap objects — no extra configurations needed. Below is a demonstration of how to utilize this functionality:

```cs
using IronBarCode;
using IronSoftware.Drawing;
using System;
using System.Collections.Generic;

var barcodes = new List<AnyBitmap>();

var bitmapFromBitmap = new System.Drawing.Bitmap("test1.jpg");
var barcode1 = bitmapFromBitmap;
barcodes.Add(barcode1);

var bitmapFromFile = System.Drawing.Image.FromFile("test2.png");
var barcode2 = bitmapFromFile;
barcodes.Add(barcode2);

foreach (var barcode in barcodes)
{
    // Decode the barcode from the AnyBitmap
    var results = BarcodeReader.Read(barcode);
    foreach (var result in results)
    {
        // Display the decoded barcode value
        Console.WriteLine(result.Value);
    }
}
```

Here, after populating our list of AnyBitmap objects, we utilize a loop to read and output the values of each detected barcode using the `Read` method.

**IronSoftware.Drawing** is a versatile library, not restricted solely to image conversions. It also excels in other image processing tasks involving colors and fonts, which are essential for styling barcodes and QR codes. Discover more about how IronDrawing can be utilized to style custom QR codes and integrate logos by visiting [customize and add logos to QR codes](https://ironsoftware.com/csharp/barcode/how-to/customize-qr-code-style/).
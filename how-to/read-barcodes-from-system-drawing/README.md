# How to Extract Barcodes From System.Drawing Objects

***Based on <https://ironsoftware.com/how-to/read-barcodes-from-system-drawing/>***


.NET developers heavily employ System.Drawing for image-related tasks. Nevertheless, as Microsoft has [ended its support for System.Drawing on non-Windows operating systems](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only), developers on platforms like **MacOS** and **Linux** face challenges when utilizing IronBarcode. The absence of support stems from the fact that barcoding typically utilizes graphics, images, and fonts.

To address these challenges, Iron Software presents [IronDrawing](https://ironsoftware.com/open-source/csharp/drawing/docs/), a **free** and **open-source** library designed to facilitate the processing tasks on non-Windows platforms. Upon incorporating IronBarcode into your project via NuGet, IronDrawing becomes readily available.

## Transform System.Drawing to AnyBitmap

With IronDrawing, converting a System.Drawing object into an AnyBitmap, a type defined within **IronSoftware.Drawing**, is straightforward. This functionality extends to various image classes, enabling seamless casting from:
- **System.Drawing.Bitmap**
- **System.Drawing.Image**
- **SkiaSharp.SKBitmap**
- **SkiaSharp.SKImage**
- **SixLabors.ImageSharp**

For guidance on casting these objects, consult the [example](https://ironsoftware.com/open-source/csharp/drawing/examples/cast-to-anybitmap/). Below is an illustrative example of how to transform System.Drawing objects into AnyBitmap instances for barcoding:

```cs
using System.Collections.Generic;
using BarCode;
namespace ironbarcode.ReadBarcodesFromSystemDrawing
{
    public class Section1
    {
        public void Run()
        {
            List<AnyBitmap> barcodes = new List<AnyBitmap>();

            // Create a new bitmap from file
            System.Drawing.Bitmap bitmapFromBitmap = new System.Drawing.Bitmap("test1.jpg");

            // Convert to AnyBitmap
            AnyBitmap barcode1 = bitmapFromBitmap;

            barcodes.Add(barcode1);

            // Load an image from file
            System.Drawing.Image bitmapFromFile = System.Drawing.Image.FromFile("test2.png");

            // Convert to AnyBitmap
            AnyBitmap barcode2 = bitmapFromFile;

            barcodes.Add(barcode2);
        }
    }
}
```

The above code snippet showcases loading barcode images as **System.Drawing.Bitmap** and **System.Drawing.Image**, which are effortlessly cast to AnyBitmap instances. These are then compiled into a list of AnyBitmap objects.

## Barcode Detection with AnyBitmap

IronBarcode readily accepts **IronSoftware.Drawing.AnyBitmap** objects across all functionalities, simplifying developers' efforts when dealing with unsupported System.Drawing objects on various operating systems. The following code demonstrates its usage:

```cs
using System.Collections.Generic;
using BarCode;
namespace ironbarcode.ReadBarcodesFromSystemDrawing
{
    public class Section2
    {
        public void Run()
        {
            List<AnyBitmap> barcodes = new List<AnyBitmap>();

            System.Drawing.Bitmap bitmapFromBitmap = new System.Drawing.Bitmap("test1.jpg");
            AnyBitmap barcode1 = bitmapFromBitmap;
            barcodes.Add(barcode1);

            System.Drawing.Image bitmapFromFile = System.Drawing.Image.FromFile("test2.png");
            AnyBitmap barcode2 = bitmapFromFile;
            barcodes.Add(barcode2);

            foreach (var barcode in barcodes)
            {
                // Perform barcode read
                var results = BarcodeReader.Read(barcode);
                foreach (var result in results)
                {
                    // Display the decoded barcode information
                    Console.WriteLine(result.Value);
                }
            }
        }
    }
}
```

Following the barcode list preparation, each AnyBitmap object is processed to extract and print barcode data, demonstrating the practical application of IronBarcode with AnyBitmap objects.

Beyond casting and barcode reading, **IronSoftware.Drawing** also facilitates other imaging functions, such as adjusting **colors** and **fonts** that are crucial for styling barcodes and QR codes effectively. Discover more about our customization capabilities for QR codes with added logos [here](https://ironsoftware.com/csharp/barcode/how-to/customize-qr-code-style/).
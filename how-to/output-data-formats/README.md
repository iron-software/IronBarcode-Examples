# Exploring Output Data Formats with IronBarcode

***Based on <https://ironsoftware.com/how-to/output-data-formats/>***


IronBarcode is more than just a tool for scanning and identifying barcodes; it also offers numerous output formats, providing users with extensive flexibility for processing barcode read results. These output formats include a variety of properties such as barcode image, barcode type, `BinaryValue`, coordinates, and dimensions, along with additional data like page number, orientation, and the textual values associated with the barcode.

In the following sections, we'll delve into these properties, explaining how they can be utilized within applications and showcasing relevant use cases.

## Understanding and Utilizing Output Formats

The `BarcodeResult` encapsulates a range of helpful properties, which include:

- `BarcodeImage`
- `BarcodeType`
- `BinaryValue`
- Coordinates, Height, and Width
- `PageNumber`
- Barcode and `PageOrientation`
- Text & Value

### Working with Barcode Images

When IronBarcode scans a barcode from an image, it stores each found barcode as a `BarcodeImage` property within the `BarcodeResult`, using the `AnyBitmap` type. This allows users to easily process or store these images without needing additional code to extract them.

Below is an example demonstrating how to process and convert these barcode images into a multi-page TIFF format:

```cs
using System.Collections.Generic;
using BarCode;

namespace IronBarcode.OutputDataFormats
{
    public class Section1
    {
        public void Run()
        {
            // Decode barcodes from a PDF
            BarcodeResults results = BarcodeReader.ReadPdf("test.pdf");
            List<AnyBitmap> barcodeImages = new List<AnyBitmap>();

            // Store each found barcode image in a list
            foreach (BarcodeResult barcode in results)
            {
                barcodeImages.Add(barcode.BarcodeImage);
            }

            // Generate a multi-page TIFF from barcode images
            AnyBitmap.CreateMultiFrameTiff(barcodeImages).SaveAs("barcodeImages.tif");
        }
    }
}
```

This example highlights the methodology to scan a PDF for barcodes, capture their images, and subsequently compile these into a multi-page TIFF file.

### Determining Barcode Types

The `BarcodeType` property is crucial for identifying the type of barcode scanned. This property is useful when working with specific barcode types that are compatible with IronBarcode. [Learn more about supported barcode types.](https://ironsoftware.com/csharp/barcode/how-to/read-barcodes-from-images/#expectbarcodetypes)

Here's how you can print the barcode types alongside their values to the console:

```cs
using System;
using BarCode;

namespace IronBarcode.OutputDataFormats
{
    public class Section2
    {
        public void Run()
        {
            // Decode barcodes from an image
            BarcodeResults results = BarcodeReader.Read("bc3.png");

            // Display type and value of each barcode
            foreach (BarcodeResult barcode in results)
            {
                Console.WriteLine($"The barcode value is {barcode} and the type is {barcode.BarcodeType}");
            }
        }
    }
}
```

### Accessing Binary Barcode Data

With IronBarcode, it's also possible to access the binary data of barcodes using the `BinaryValue` property. This lets you handle the barcode data directly at the byte level.

Consider this sample for reading barcode data as binary and converting it into QR codes:

```cs
using IronBarCode;
using BarCode;

namespace IronBarcode.OutputDataFormats
{
    public class Section3
    {
        public void Run()
        {
            // Decode barcodes from an image
            BarcodeResults results = BarcodeReader.Read("multiple-barcodes.png");

            int counter = 1;
            foreach (BarcodeResult barcode in results)
            {
                byte[] binaryValue = barcode.BinaryValue;
                BarcodeEncoding barcodeType = BarcodeEncoding.QRCode;

                // Generate a new QR code from the binary value
                GeneratedBarcode newBarcode = BarcodeWriter.CreateBarcode(binaryValue, barcodeType);

                // Save the QR code as an image
                newBarcode.SaveAsPng($"qrFromBinary{counter++}.png");
            }
        }
    }
}
```

In the provided example, the application decodes a series of barcodes from an image, converts each to a QR code, and saves them as individual PNG files.

### Analyzing Barcode Position and Dimensions

The positional coordinates and dimensions of a barcode can be accessed through properties like **X1**, **Y1**, **X2**, **Y2**, as well as **Height** and **Width**. These properties are particularly useful for applications requiring precise placement or analysis of barcodes within an image or document.

Here we illustrate using barcode dimensions to redact images, demonstrating the application of scanned data:

```cs
using System.Linq;
using BarCode;

namespace IronBarcode.OutputDataFormats
{
    public class Section4
    {
        public void Run()
        {
            // Decode barcodes from an image
            BarcodeResults results = BarcodeReader.Read("multiple-barcodes.png");
            AnyBitmap image = AnyBitmap.FromFile("multiple-barcodes.png");

            foreach (BarcodeResult barcode in results)
            {
                // Calculate the rectangle for redaction
                PointF[] points = barcode.Points;
                float minX = points.Select(p => p.X).Min();
                float minY = points.Select(p => p.Y).Min();
                Rectangle areaToRedact = new Rectangle((int)minX, (int)minY, (int)barcode.Width, (int)barcode.Height);

                // Redact the barcode area
                image = image.Redact(areaToRedact, Color.Magenta);

                // Save the modified image
                image.SaveAs("redacted.png", AnyBitmap.ImageFormat.Png);
            }
        }
    }
}
```

![Before Redaction](https://ironsoftware.com/static-assets/barcode/how-to/output-data-formats/multiple-barcodes.png)
![After Redaction](https://ironsoftware.com/static-assets/barcode/how-to/output-data-formats/redacted.png)

### Other Output Formats and Uses

Other functional properties include `PageNumber`, which helps in identifying barcode locations within multipage documents, and `PageOrientation` and `Rotation` for understanding the positioning and orientation of the barcode. Additionally, properties like `Text` and `Value` provide the textual content and value of the barcode, essential for data processing and user feedback systems.

Through these varied output formats and use cases, IronBarcode facilitates flexible and powerful handling of barcode data within .NET applications.
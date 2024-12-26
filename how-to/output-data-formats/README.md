# Output Data Formats with IronBarcode

***Based on <https://ironsoftware.com/how-to/output-data-formats/>***


IronBarcode is not only adept at reading barcodes but also excels in offering a variety of output formats that enable users to extensively manipulate the read results. The output formats encompass a range of properties such as `BarcodeImage`, `BarcodeType`, `BinaryValue`, coordinates, height, width, `PageNumber`, barcode, page orientation, text, and value.

Below, we delve into how to leverage these properties effectively within various programming scenarios.

## Getting Started with IronBarcode

---

## Output Formats and Practical Applications

The `BarcodeResult` serves as a repository for numerous valuable properties, including:

- `BarcodeImage`
- `BarcodeType`
- `BinaryValue`
- Coordinates, Height & Width
- `PageNumber`
- Barcode and `PageOrientation`
- Text & Value

### Managing Barcode Images

After IronBarcode processes an image to detect barcodes, it stores each found barcode as an `AnyBitmap` object within the `BarcodeImage` property. This enables efficient image processing or storage without necessitating additional coding efforts to extract the images.

Consider the sample code below, which is tailored to generating a multi-page TIFF from barcodes within a PDF:

```cs
using IronBarCode;
using IronSoftware.Drawing;
using System.Collections.Generic;

// Initialize barcode reading from a PDF
BarcodeResults results = BarcodeReader.ReadPdf("test.pdf");

// Gathering barcodes into a list
List<AnyBitmap> barcodeImages = new List<AnyBitmap>();

foreach (BarcodeResult barcode in results)
{
    barcodeImages.Add(barcode.BarcodeImage);
}

// Saving as a multi-page TIFF
AnyBitmap.CreateMultiFrameTiff(barcodeImages).SaveAs("barcodeImages.tif");
```

This code first scans a PDF for barcodes, then compiles the barcode images into a list, and finally creates a multi-page TIFF file.

### Identifying Barcode Types

The `BarcodeType` property allows identification of the barcode type within an image or document. Here is how you can display barcode types and their values:

```cs
using IronBarCode;
using System;

// Extract barcodes from a PNG
BarcodeResults results = BarcodeReader.Read("bc3.png");

// Displaying barcode types and values
foreach (BarcodeResult barcode in results)
{
    Console.WriteLine("The barcode value is " + barcode.ToString() + " and the barcode type is " + barcode.BarcodeType);
}
```

This segment reads barcodes from a PNG file, then iterates over the results to print each barcode's type and value to the console.

### Working with Binary Values

IronBarcode lets you access the binary data of a barcode through the `BinaryValue` property, facilitating further data manipulation within your application. Here's how you can use this feature:

```cs
using IronBarCode;

// Reading barcodes from a PNG
BarcodeResults results = BarcodeReader.Read("multiple-barcodes.png");

int i = 1;
foreach (BarcodeResult barcode in results)
{
    var binaryValue = barcode.BinaryValue;
    var barcodeType = IronBarCode.BarcodeEncoding.QRCode;

    // Generating and saving new QR codes
    GeneratedBarcode generatedBarcode = BarcodeWriter.CreateBarcode(binaryValue, barcodeType);
    generatedBarcode.SaveAsPng($"qrFromBinary{i}.png");
    i++;
}
```

This script reads multiple barcodes from an image, converts each barcode's binary data into a new QR code, and saves each new QR code as a PNG image.

### Extracting Barcode Coordinates, Height & Width

Here is how you can use barcode dimensions and locations to your advantage:

```cs
using IronBarCode;
using IronSoftware.Drawing;
using System.Linq;

// Extracting barcodes from a PNG
BarcodeResults results = BarcodeReader.Read("multiple-barcodes.png");

AnyBitmap bitmap = AnyBitmap.FromFile("multiple-barcodes.png");

foreach (BarcodeResult barcode in results)
{
    PointF[] barcodePoints = barcode.Points;

    float x1 = barcodePoints.Select(b => b.X).Min();
    float y1 = barcodePoints.Select(b => b.Y).Min();
    Rectangle rectangle = new Rectangle((int)x1, (int)y1, (int)barcode.Width, (int)barcode.Height);

    bitmap.Redact(rectangle, Color.Magenta);

    // Save modified image
    bitmap.SaveAs("redacted.png", AnyBitmap.ImageFormat.Png);
}
```

The script above reads barcodes from a PNG, then uses IronDrawing to redact each barcode on the image, indicating their position and size.

### Retrieving Page Numbers

Page number retrieval is vital when dealing with documents containing multiple barcodes:

```cs
using IronBarCode;
using System;

// Reading barcodes from a PDF
BarcodeResults results = BarcodeReader.ReadPdf("test.pdf");

// Displaying page numbers
foreach (BarcodeResult barcode in results)
{
    Console.WriteLine("The barcode value " + barcode.ToString() + " is found on page number " + barcode.PageNumber);
}
```

This example demonstrates how to extract barcodes and their respective page numbers from a multi-page PDF, aiding in document navigation and processing.

### Determining Barcode and Page Orientation

IronBarcode can determine both barcode rotation and the orientation of the page on which the barcode is found:

```cs
using IronBarCode;
using System;

// Reading from a PDF
BarcodeResults results = BarcodeReader.ReadPdf("test.pdf");

// Outputting page orientation and barcode rotation
foreach (BarcodeResult barcode in results)
{
    Console.WriteLine(barcode.Value);
    Console.WriteLine(barcode.PageOrientation);
    Console.WriteLine(barcode.Rotation);
}
```

The above script reads a PDF, extracting each barcode's orientation and rotation, useful for debugging or processing orientation-specific data.

### Text and Barcode Values

Retrieving the text or value from a barcode is straightforward with IronBarcode:

```cs
using IronBarCode;
using System;

// Reading a PDF for barcodes
BarcodeResults results = BarcodeReader.ReadPdf("barcodestamped3.pdf");

// Printing barcode text and values
foreach (BarcodeResult barcode in results)
{
    Console.WriteLine(barcode.Value);
    Console.WriteLine(barcode.Text);
    Console.WriteLine(barcode.ToString());
}
```

This example demonstrates how simple it is to obtain and print the value or text from each detected barcode in a document.

IronBarcode proves invaluable in a multitude of scenarios involving barcode processing and data extraction, providing robust support for various data formats and properties through the `BarcodeResult` object.
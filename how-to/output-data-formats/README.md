# Generating Various Data Outputs with IronBarcode

IronBarcode extends beyond mere barcode detection and value logging. It supports a range of output formats that empower users to process and utilize barcode scan results effectively. These outputs span several useful properties like the barcode image, type, `BinaryValue`, coordinates, dimensions, page details, orientation, textual data, and the raw value itself.

This write-up will guide you through how to leverage these properties and where they might prove beneficial in your applications.

## Available Output Formats and Their Practical Applications

The `BarcodeResult` object in IronBarcode encapsulates a suite of valuable attributes:

- `BarcodeImage`
- `BarcodeType`
- `BinaryValue`
- Coordinates along with Height and Width
- `PageNumber`
- `Barcode` and `PageOrientation`
- Text & Value

### Barcode Image

IronBarcode processes scanned barcodes into a manageable `BarcodeImage` property of type `AnyBitmap`. This property captures the images and allows for further manipulation or permanent storage without additional coding.

Consider the illustrated code example where a multi-page TIFF image is created from barcodes recognized within a PDF:

```cs
using IronBarCode;
using IronSoftware.Drawing;
using System.Collections.Generic;

// Barcode scanning from a PDF document
BarcodeResults results = BarcodeReader.ReadPdf("test.pdf");

// Storing scanned barcodes
List<AnyBitmap> barcodes = new List<AnyBitmap>();

foreach (BarcodeResult barcode in results)
{
    barcodes.Add(barcode.BarcodeImage);
}

// Generating a multi-page TIFF image from the collected barcodes
AnyBitmap.CreateMultiFrameTiff(barcodes).SaveAs("generatedBarcodeImages.tif");
```

This code snippet primarily showcases the creation of a TIFF image file comprising the barcodes extracted from a PDF document.

### Barcode Type

The `BarcodeType` property assists in identifying the barcode format present in the scanned data, provided it's supported by IronBarcode. More details on unlockable barcode types are available [here](https://ironsoftware.com/csharp/barcode/how-to/read-barcodes-from-images/#expectbarcodetypes).

Below is an example to retrieve and display barcode types:

```cs
using IronBarCode;
using System;

// Scanning barcode from a PNG image
BarcodeResults results = BarcodeReader.Read("bc3.png");

// Displaying barcode type and value
foreach (BarcodeResult barcode in results)
{
    Console.WriteLine($"The barcode value is {barcode.ToString()} and the type is {barcode.BarcodeType}");
}
```

This snippet reads a barcode and outputs both the barcode's value and type to the console, illustrating the straightforward accessibility of this data.

### Binary Value

IronBarcode allows access to barcodes as byte arrays via the `BinaryValue` property, which can be pivotal for data conversion or handling purposes.

Example use case demonstrating this feature:

```cs
using IronBarCode;

// Barcode scanning from a PNG image
BarcodeResults results = BarcodeReader.Read("multiple-barcodes.png");

int counter = 1;
foreach (BarcodeResult barcode in results)
{
    var binaryValue = barcode.BinaryValue;
    var barcodeType = IronBarCode.BarcodeEncoding.QRCode;

    // Generating QR codes from binary data
    GeneratedBarcode generated = BarcodeWriter.CreateBarcode(binaryValue, barcodeType);

    // Saving generated QR codes as PNG images
    generated.SaveAsPng($"convertedQR{counter}.png");
    counter++;
}
```

In this example, each barcode extracted from an image is converted into a QR code.

### Barcode Coordinates, Height & Width

Accessing a barcode's spatial and dimensional properties is readily available through specific attributes in the `BarcodeResult` object. Below is an example of using these properties to redact parts of an image:

```cs
using IronBarCode;
using IronSoftware.Drawing;
using System.Linq;

// Reading barcodes from a PNG
BarcodeResults results = BarcodeReader.Read("multiple-barcodes.png");

AnyBitmap image = AnyBitmap.FromFile("multiple-barcodes.png");

foreach (BarcodeResult barcode in results)
{
    PointF[] points = barcode.Points;

    float x1 = points.Select(p => p.X).Min();
    float y1 = points.Select(p => p.Y).Min();

    Rectangle area = new Rectangle((int)x1, (int)y1, (int)barcode.Width!, (int)barcode.Height!);

    // Applying redaction
    image = image.Redact(area, Color.Magenta);

    // Saving the altered image
    image.SaveAs("redactedBarcodes.png", AnyBitmap.ImageFormat.Png);
}
```

This script retrieves each barcode's location and dimensions to apply a magenta redaction before saving the redacted image.

<div style="display: flex; gap: 1rem;">

<div style="flex: 1;">
    <img src="https://ironsoftware.com/static-assets/barcode/how-to/output-data-formats/multiple-barcodes.png" alt="Original image with multiple barcodes" />
    <p style="text-align: center;">Before redaction</p>
</div>

<div style="flex: 1;">
    <img src="https://ironsoftware.com/static-assets/barcode/how-to/output-data-formats/redacted.png" alt="Image after redacting barcodes" />
    <p style="text-align: center;">After redaction</p>
</div>

</div>

### Page Number

IronBarcode can also retrieve the specific page number on which a barcode appears within a multipage document. This is particularly useful when dealing with complex documents with embedded barcodes across several pages:

```cs
using IronBarCode;
using System;

// Scanning barcodes from a PDF file
BarcodeResults results = BarcodeReader.ReadPdf("test.pdf");

// Displaying barcode values and their corresponding page numbers
foreach (BarcodeResult barcode in results)
{
    Console.WriteLine($"Barcode {barcode.ToString()} found on page {barcode.PageNumber}");
}
```

This code snippet highlights the retrieval of barcodes from a multipage PDF along with the page numbers, aiding in document navigation and processing.

### Barcode Rotation and Page Orientation

IronBarcode facilitates detection of the barcode and page orientations, which is vital for correctly aligning and interpreting scanned data:

```cs
using IronBarCode;
using System;

// Reading a barcode from a PDF
BarcodeResults results = BarcodeReader.ReadPdf("test.pdf");

// Displaying orientation and rotation data
foreach (BarcodeResult barcode in results)
{
    Console.WriteLine(barcode.Value);
    Console.WriteLine("Page Orientation: " + barcode.PageOrientation);
    Console.WriteLine("Barcode Rotation: " + barcode.Rotation + " degrees");
}
```

This script inputs a PDF, extracts barcodes, and logs their orientation and rotation, useful for advanced data manipulation or quality checks.

### Text and Value

Finally, the primary properties most users seek from a barcode: its `Value` and `Text`. These generally hold similar or identical data and can be accessed simply:

```cs
using IronBarCode;
using System;

// Extracting barcodes from a PDF
BarcodeResults results = BarcodeReader.ReadPdf("barcodestamped3.pdf");

// Printing the barcode data to the console
foreach (BarcodeResult barcode in results)
{
    Console.WriteLine($"Value: {barcode.Value}, Text: {barcode.Text}");
}
```

This example demonstrates how straightforward it is to access and output the text and value data from barcodes within a PDF.

In conclusion, IronBarcode stands as a robust API equipped to handle various barcode-related operations, not just decoding them. With these multifaceted output options, developers can significantly expand the functionality and usability of their applications.
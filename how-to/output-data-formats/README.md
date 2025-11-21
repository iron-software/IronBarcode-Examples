# Guide to Handling Different Data Formats with IronBarcode

***Based on <https://ironsoftware.com/how-to/output-data-formats/>***


IronBarcode is not just about reading barcodes and displaying the results—it offers a variety of output formats to utilize the extracted data effectively. Some of these formats include barcode image, barcode type, `BinaryValue`, coordinates, and dimensions. Users can interact with these properties, adapting them as needed within their applications. Below, we'll delve into how these properties can be leveraged in various scenarios.

## Quickstart: Extracting Barcode Value and Type Effortlessly

The following example demonstrates the simplicity of extracting a barcode's value and type from an image using IronBarcode. This one-liner is ideal for quick starts.

```csharp
// Read an image, fetch barcode details, and print the value and type.
var readResult = IronBarCode.BarcodeReader.QuicklyReadOneBarcode("input.png");
Console.WriteLine($"Value: {readResult[0].Value}, Type: {readResult[0].BarcodeType}");
```

## Detailed Output Formats and Practical Use Cases

`BarcodeResult` encompasses several significant properties:

- `BarcodeImage`
- `BarcodeType`
- `BinaryValue`
- Dimensions and Coordinates
- `PageNumber`
- `Barcode` and `PageOrientation`
- Text & Value

### Managing Barcode Images

After decoding a barcode, `BarcodeResult` houses each image as a `BarcodeImage`. This feature enables users to manipulate and save these images, streamlining the process without requiring complex coding.

Here's how you can use this effectively:

```csharp
using IronBarCode;
using IronSoftware.Drawing;
using System.Collections.Generic;

// Decode barcodes from a PDF document
BarcodeResults pdfResults = BarcodeReader.ReadPdf("test.pdf");
List<AnyBitmap> imagesFromBarcodes = new List<AnyBitmap>();

// Extract and store each barcode's image
foreach (BarcodeResult barcode in pdfResults) {
    imagesFromBarcodes.Add(barcode.BarcodeImage);
}

// Combine and save them as a multi-frame TIFF file
AnyBitmap.CreateMultiFrameTiff(imagesFromBarcodes).SaveAs("collectedBarcodes.tif");
```

This script efficiently creates a TIFF file from images of barcodes found in a PDF, demonstrating practical use of the `BarcodeImage` property.

### Determining Barcode Types

`BarcodeType` assists in identifying the type of barcode decoded. This functionality is limited to the barcode types that IronBarcode recognizes. For more information, visit [Supported Barcode Types](https://ironsoftware.com/csharp/barcode/how-to/read-barcodes-from-images/#expectbarcodetypes).

Example of determining and displaying barcode types:

```csharp
using IronBarCode;

// Decode a barcode from an image
BarcodeResults singleResult = BarcodeReader.Read("barcodeExample.png");

// Display the barcode type
foreach (BarcodeResult result in singleResult)
{
    Console.WriteLine($"Barcode: {result}, Type: {result.BarcodeType}");
}
```

### Accessing Binary Values

IronBarcode grants access to a barcode’s binary data through the `BinaryValue` property, allowing for advanced manipulation within programs.

Example demonstrating binary data handling:

```csharp
using IronBarCode;

// Decode barcodes from an image
BarcodeResults multipleResults = BarcodeReader.Read("example-barcodes.png");

int identifier = 1;
foreach (BarcodeResult result in multipleResults)
{
    byte[] binaryData = result.BinaryValue;
    BarcodeEncoding codeType = IronBarCode.BarcodeEncoding.QRCode;

    // Generate and save a QR code from each binary value
    GeneratedBarcode newQR = BarcodeWriter.CreateBarcode(binaryData, codeType);
    newQR.SaveAsPng($"newQRCode{identifier}.png");
    identifier++;
}
```

### Handling Barcode Location and Size

The properties concerning a barcode's location (`X1`, `Y1`, `X2`, `Y2`) and its dimensions (`Height`, `Width`) are invaluable when addressing the position and area of the barcode within a document or image.

Illustrating the process of redacting barcodes from an image:

```csharp
using IronBarCode;
using IronSoftware.Drawing;

// Decode barcodes from an image and load the image
BarcodeResults imageResults = BarcodeReader.Read("barcodePositions.png");
AnyBitmap imageToManipulate = AnyBitmap.FromFile("barcodePositions.png");

// Apply redactions based on barcode positions
foreach (BarcodeResult result in imageResults)
{
    Rectangle redactionArea = new Rectangle((int)result.X1, (int)result.Y1, (int)result.Width, (int)result.Height);
    imageToManipulate = imageToManipulate.Redact(redactionArea, Color.Magenta);
}

// Save the redacted image
imageToManipulate.SaveAs("redactedBarcodes.png", AnyBitmap.ImageFormat.Png);
```

### Retrieving Page Numbers

This feature is particularly useful in multi-page documents, where locating a barcode's exact page can streamline processing and verification tasks.

Example demonstrating page number retrieval:

```csharp
using IronBarCode;

// Read barcodes from a multi-page PDF
BarcodeResults fromPdf = BarcodeReader.ReadPdf("comprehensiveDocument.pdf");

// Displaying barcode values and their corresponding page numbers
foreach (BarcodeResult barcode in fromPdf)
{
    Console.WriteLine($"Barcode: {barcode}, found on page: {barcode.PageNumber}");
}
```

### Addressing Barcode and Page Orientation

IronBarcode can discern the orientation of barcodes and the pages they are on, which can be crucial for sorting or reorienting scanned documents.

Extracting orientation information:

```csharp
using IronBarCode;

// Decode a barcode from a PDF file
BarcodeResults pdfResults = BarcodeReader.ReadPdf("orientedDocument.pdf");

// Output orientation details
foreach (BarcodeResult barcode in pdfResults)
{
    Console.WriteLine("Value: " + barcode.Value);
    Console.WriteLine("Page orientation: " + barcode.PageOrientation);
    Console.WriteLine("Barcode rotation: " + barcode.Rotation);
}
```

### Extracting Text and Value

Finally, the `Text` and `Value` properties are often used to access the data encoded in the barcode. IronBarcode simplifies this process through its API.

Here's an example:

```csharp
using IronBarCode;

// Decode barcodes embedded in a PDF
BarcodeResults documentResults = BarcodeReader.ReadPdf("detailedDocument.pdf");

// Output the text and value of each barcode
foreach (BarcodeResult barcode in documentResults)
{
    Console.WriteLine("Text: " + barcode.Text);
    Console.WriteLine("Value: " + barcode.Value);
    Console.WriteLine("Barcode string: " + barcode.ToString());
}
```

IronBarcode supports a variety of data output formats, enabling users to harness barcode data to its fullest potential in numerous applications and scenarios.
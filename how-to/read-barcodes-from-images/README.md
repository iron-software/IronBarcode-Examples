# How to Read Barcodes From Image Files (JPEG, PNG, GIF, TIFF, SVG, BMP)

***Based on <https://ironsoftware.com/how-to/read-barcodes-from-images/>***


IronBarcode makes it simple to read barcodes from various image formats directly. Supported image formats include:

- JPEG (Joint Photographic Experts Group)
- PNG (Portable Network Graphics)
- GIF (Graphics Interchange Format)
- TIFF (Tagged Image File Format)
- SVG (Scalable Vector Graphics)
- BMP (Bitmap Image File)

This capability is enhanced by our open source library, **IronDrawing**.

## Quick Start: Effortlessly Read Barcodes from an Image

To decode barcodes from image files such as PNG, JPEG, GIF, BMP, and TIFF, you need to make a single method call to `IronBarCode.BarcodeReader.Read()`, enabling rapid extraction of barcode data with no complex configuration necessary.

```cs
// Simplified Barcodes Reading From an Image
var results = IronBarCode.BarcodeReader.Read("path/to/image.png");
```

## Direct Barcode Reading from Images

Here’s how you can utilize IronBarcode for reading barcodes:

```csharp
using IronBarCode;
using System;

var myBarcode = BarcodeReader.Read(@"image_file_path.jpg"); // Specify the image path

foreach (var item in myBarcode)
{
    Console.WriteLine(item.ToString());
}
```

![Sample test QR code](https://ironsoftware.com/static-assets/barcode/how-to/read-barcodes-from-images/QRcodeintro.jpeg)
*Sample test QR code*

![Sample test barcode](https://ironsoftware.com/static-assets/barcode/how-to/read-barcodes-from-images/Code128intro.jpeg)
*Sample test barcode*

*Curious about the barcode values in these samples? Decode them using the provided code!*

To use IronBarcode, first integrate the IronBarcode library into your project using NuGet package manager in Microsoft Visual Studio. This setup will enable you to access the `BarcodeReader.Read()` function for processing barcode images by just specifying the **file name** or **file path**. For file paths, it's recommended to use a verbatim string literal (`@`) to avoid the need for escape characters (`\\`).

Attach the `Values()` method to the end of the `BarcodeReader.Read()` method call to extract barcode values as a `System.String[]`.

IronBarcode supports reading various 1-Dimensional and 2-Dimensional barcode formats such as QR Codes, Data Matrix, and various common linear barcodes across different image types.

## Customizing Barcode Reader Settings

If you encounter issues such as slow read times, small unreadable barcodes, or need to read specific barcode types or areas of an image, `BarcodeReaderOptions` offers a variety of settings to optimize the reading process.

### CropArea

The `CropArea` property lets you specify a particular area for barcode reading, improving speed and accuracy by ignoring the rest of the image:

```csharp
// Set a specific area to scan for barcodes
var cropArea = new IronSoftware.Drawing.Rectangle(x, y, width, height);
```

### ExpectBarcodeTypes

Boost performance by specifying which barcode types to scan, avoiding the need to check for all types:

Here are examples of setting up expected barcode types for optimized scanning.

### ExpectMultipleBarcodes

If you're only interested in the first found barcode, set `ExpectMultipleBarcodes` to **false**, which can enhance the reader's speed by stopping after the first detection.

### ImageFilters

Applying image filters via `ImageFilter` collection in `BarcodeReaderOptions` helps in pre-processing images making barcodes more discernible.

### MaxParallelThreads

Configure the `MaxParallelThreads` to adjust the parallel operations, enhancing speed based on your system’s capability.

### Multithreaded

This setting allows IronBarcode to handle multiple images simultaneously, optimizing batch processing tasks.

### RemoveFalsePositive

Activating `RemoveFalsePositive` prevents incorrect barcode readings, increasing the accuracy of the results.

### ScanMode

IronBarcode features several reading modes, each tailored for different barcode reading needs - from `Auto` for general use to specialized settings like `MachineLearningScan` for sophisticated analyses.

### Reading Speed

Adjust the `Speed` setting to balance between quick reading and accuracy, with options ranging from `Faster` to `ExtremeDetail` for different complexities and quality of input images.

### UseCode39ExtendedMode

For Code39 barcodes, enabling `UseCode39ExtendedMode` ensures comprehensive decoding using the full ASCII character set.

## Advanced Barcode Reading Customization

By mastering the adjustable settings in `BarcodeReaderOptions`, you can significantly enhance both the performance and precision of barcode reading from images. Here's how to apply these options in your coding practice:

```csharp
// Example of customized barcode reading setup
// This sample includes key settings adjustments
```

We’ve now covered how applying `BarcodeReaderOptions` can drastically influence the effectiveness of reading barcodes from images, adjusting properties as needed, and using these configurations when invoking the `BarcodeReader.Read()` function alongside the specified image.
# Read Barcodes in C&#x23;

***Based on <https://ironsoftware.com/tutorials/reading-barcodes/>***


IronBarcode offers a robust, state-of-the-art, and effective .NET library for barcode recognition.

## Installation

IronBarcode is a comprehensive, state-of-the-art library designed for barcode reading within .NET environments.

Initially, you'll need to install Iron Barcode. This can be conveniently done through our NuGet package. Alternatively, you might opt to directly integrate the [DLL](https://ironsoftware.com/csharp/barcode/packages/IronBarCode.zip) into your project or global assembly cache. IronBarcode is excellent for creating a C# barcode scanner application.

```shell
Install-Package BarCode
```

## Read Your First Barcode

Using the .NET framework, reading either a Barcode or a QR Code becomes remarkably straightforward with the help of the IronBarcode library.

<center>
![Scanned Code128 Barcode Image](https://ironsoftware.com/img/tutorials/reading-barcodes/GetStarted.png)
</center>

From this operation, we can capture its value, associated image, encoding type, and any binary data before displaying it on the console.

```cs
using IronBarCode;
using System;

// Barcode reading process
BarcodeResults results = BarcodeReader.Read("GetStarted.png");

// Output the result to the console
foreach (BarcodeResult result in results)
{
    if (result != null)
    {
        Console.WriteLine("Scanning of GetStarted succeeded. Read Value: " + result.Text);
    }
}
```

### Try Harder and Be Specific

Here, we will enhance a barcode scanning feature to handle difficult images. The `ExtremeDetail` setting in the `Speed` enum allows for a more intensive scan of poorly visible, damaged, or angled barcodes.

```cs
using IronBarCode;

BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    Speed = ReadingSpeed.ExtremeDetail, // Select speed: Faster, Balanced, Detailed, ExtremeDetail
    ExpectBarcodeTypes = BarcodeEncoding.QRCode | BarcodeEncoding.Code128, // Define specific barcode types for efficiency
};

// Enhanced barcode reading
BarcodeResults results = BarcodeReader.Read("TryHarderQR.png", options);
```

This method will accurately scan the following rotated QR Code:

<center>
![Rotated QR code scan](https://ironsoftware.com/img/tutorials/reading-barcodes/TryHarderQR.png)
</center>

This example illustrates how specifying certain barcode encodings—or combinations thereof—enhances scanning efficiency and precision. Using `ImageFilters` and the `AutoRotate` features could further refine the results.

```cs
using IronBarCode;

BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    ImageFilters = new ImageFilterCollection() {
        new AdaptiveThresholdFilter(),
    },
    AutoRotate = true, // Automatically adjusts barcode orientation
};

// Reading the barcode
BarcodeResults results = BarcodeReader.Read("TryHarderQR.png", options);
```

<hr>

## Reading Multiple Barcodes

### PDF Documents

Let's explore how to extract barcodes from a [scanned PDF document](https://ironsoftware.com/img/tutorials/reading-barcodes/MultipleBarcodes.pdf) and discern all the one-dimensional barcodes present.

```cs
using IronBarCode;
using System;

// Scan multiple barcodes from a PDF
BarcodeResults results = BarcodeReader.ReadPdf("MultipleBarcodes.pdf");

// Process and display the results
foreach (var pageResult in results)
{
    Console.WriteLine(pageResult.Value + " found on page " + pageResult.PageNumber);
}
```

The following image shows detected barcodes across different pages.

<center>
![Read barcodes from PDF](https://ironsoftware.com/img/tutorials/reading-barcodes/MultipleBarcodes.png)
</center>

### Scanning TIFFs

Similarly, the same result can be expected when scanning multi-frame TIFF images, processed in a manner akin to PDFs.

<center>
![Reading from a multi-frame TIFF](https://ironsoftware.com/img/tutorials/reading-barcodes/Multiframe.tiff.overview.png)
</center>

```cs
using IronBarCode;

// Scanning from multi-frame TIFF
BarcodeResults multiFrameResults = BarcodeReader.Read("Multiframe.tiff");

// Further processing can be included here
//...
```

### MultiThreading

For reading multiple documents or images, IronBarcode’s multithreading capabilities enhance the speed and efficiency of the barcode scanning operation.

```cs
using IronBarCode;

// Activate multithreading
var ListOfDocuments = new[] { "image1.png", "image2.JPG", "image3.pdf" };

BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    Multithreaded = true,
};

BarcodeResults batchResults = BarcodeReader.Read(ListOfDocuments, options);
```

## Summary

IronBarcode is a versatile .NET software library and C# QR code generator capable of accurately reading a variety of barcode formats from both pristine and suboptimal sources, like screen captures or real-world images.

### Further Reading

To deepen your understanding of IronBarcode, consider exploring additional tutorials and examples available on our website. These resources are usually ample for getting started.

For an in-depth exploration, visit our [API Reference](https://ironsoftware.com/csharp/barcode/object-reference/), where you’ll find comprehensive details on the **BarcodeReader** class and the **BarcodeEncoding** enum.

### Source Code Downloads

We encourage you to download this tutorial’s source code or clone our repository to experience it firsthand:
* [Tutorial Github Repository](https://github.com/iron-software/Iron-Barcode-Reading-Barcodes-In-CSharp)
* [Download the C# Source Code](https://ironsoftware.com/downloads/assets/tutorials/reading-barcodes/Iron-Barcode-Reading-Barcodes-In-CSharp.zip)
# Adjusting Barcode Reading Speed

***Based on <https://ironsoftware.com/how-to/reading-speed-options/>***


When it comes to scalability and processing vast arrays of barcodes, the accuracy of a barcode reader is paramount. However, the efficiency of resource allocation and the method by which the barcode reader processes these images are equally crucial. It's vital for developers to strategize the barcode reading approach based on the quality and clarity of the input images. Decisions might range from foregoing image preprocessing for high-quality images to adopting more resource-intensive methods to enhance accuracy for lower-quality images.

IronBarCode equips you with the tools to customize the processing speed and accuracy of barcode reading, enabling precise adjustments tailored to the specific requirements of your images and resource availability.

The guidelines provided in this article aim to assist in selecting the optimal reading speed, with practical examples using a sample set of QR codes to demonstrate how adjustments in reading speed can impact outcomes.

## Quickstart: Optimize Barcode Reading Speed

Utilize IronBarcode's `BarcodeReaderOptions` to adjust the `Speed` setting easily for your scans. This example demonstrates how to quickly read barcodes using the `Balanced` speed setting for efficient and reliable results.

```cs
// Title: Optimize Barcode Reading Speed with IronBarcode
var results = IronBarCode.BarcodeReader.Read("path/to/image.png", new IronBarCode.BarcodeReaderOptions { Speed = IronBarCode.ReadingSpeed.Balanced });
```

## Exploring Reading Speeds

IronBarCode offers four settings for `ReadingSpeed`: `Faster`, `Balanced`, `Detailed`, and `ExtremeDetail`. This section explores each setting with examples and benchmarks using a set of both high-quality and degraded barcode images. These benchmarks provide insights into how different `ReadingSpeed` settings affect both performance and output.

### Faster Speed Option

The `Faster` setting optimizes for speed, using minimal resources to achieve the quickest read possible. While this mode skips image preprocessing and is best suited for already clear images, it does compromise on accuracy.

Here, we apply the `Faster` setting and evaluate its performance on a directory of barcode images:

```cs
// Importing necessary libraries
using IronBarCode;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

// Configure options for faster reading
var optionsFaster = new BarcodeReaderOptions
{
    Speed = ReadingSpeed.Faster
};

// Define the directory path containing target files
string folderPath = @"YOUR_FILE_PATH";

// Retrieve all jpg files
var pdfFiles = Directory.GetFiles(folderPath, "*.jpg");

int countFaster = 0;
var stopwatch = Stopwatch.StartNew();
foreach (var file in pdfFiles)
{
    // Perform barcode reading
    var results = BarcodeReader.Read(file, optionsFaster);

    if (results.Any())
    {
        Console.WriteLine($"Barcode(s) detected in: {Path.GetFileName(file)}");
        foreach (var result in results)
        {
            Console.WriteLine($"  Value: {result.Value}, Type: {result.BarcodeType}");
            countFaster++;
        }
    }
    else
    {
        Console.WriteLine($"No barcode detected in: {Path.GetFileName(file)}");
    }
}

stopwatch.Stop();

// Display results
Console.WriteLine($"Faster read = {countFaster} out of {pdfFiles.Length} in {stopwatch.ElapsedMilliseconds}ms");
```

`Faster` successfully identifies 146 out of 430 barcodes within 25 seconds, translating to about 33.95% accuracy. Its efficiency shines in cases with high-quality images.

### Balanced Speed Option

The `Balanced` mode is a middle ground that applies moderate image processing to enhance readability without significant time delay, making it suitable for most images.

To illustrate, consider the same setup with the `Balanced` option activated:

```cs
// Code setup remains similar to the Faster option with changes only in the speed setting
var optionsBalanced = new BarcodeReaderOptions
{
    Speed = ReadingSpeed.Balanced
};

// Remaining code structure is identical
```

Using `Balanced`, 237 out of 430 barcodes are deciphered in 43 seconds, showing a 55.11% accuracy rate. This setting is usually the best starting point given its effective balance.

### Detailed and ExtremeDetail Speed Option

These settings are tailored for challenging scenarios where barcodes are heavily distorted. `Detailed` adds significant image processing, while `ExtremeDetail` is the most resource-intensive, suitable for the poorest quality inputs.

```cs
// Example of Detailed setting
var optionsDetailed = new BarcodeReaderOptions
{
    Speed = ReadingSpeed.Detailed
};

// Example of ExtremeDetail setting
var optionsExtreme = new BarcodeReaderOptions
{
    Speed = ReadingSpeed.ExtremeDetail
};

// Additional implementation detail reflecting above changes
```

`Detailed` and `ExtremeDetail` provide more thorough processing, beneficial in specific circumstances but at the cost of increased processing time and resource usage.

### Summary

This overview of settings emphasizes the importance of choosing the correct adjustment level based on image quality and desired accuracy, with `Balanced` typically recommended for general use. For further enhancements, image preprocessing techniques can be utilized before barcode reading, as detailed [here](https://ironsoftware.com/csharp/barcode/how-to/image-correction/).

### Decision Chart

To help visualize the decision-making process, refer to the following chart:

<div class="content-img-align-center">
  <div class="center-image-wrapper">
    <img src="https://ironsoftware.com/static-assets/barcode/how-to/reading-speed/flowchart.webp" alt="Decision Flowchart" class="img-responsive add-shadow">
  </div>
</div>

By understanding the trade-offs between different settings, developers can more effectively harness the capabilities of IronBarCode to suit specific operational needs.
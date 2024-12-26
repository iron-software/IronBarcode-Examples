# How to Decode Barcodes from Various Image Formats (jpg, png, gif, tiff, svg, bmp)

***Based on <https://ironsoftware.com/how-to/read-barcodes-from-images/>***


IronBarcode offers a seamless capability to identify barcodes across a range of common image file formats. This functionality not only extends to newer file types like Scalable Vector Graphics (SVG) and Portable Network Graphics (PNG), but also to traditional ones like the Bitmap Image File (BMP), Tagged Image File Format (TIFF), Graphics Interchange Format (GIF), and Joint Photographic Experts Group (JPEG). This diverse compatibility is supported by the robust, open-source library, **IronDrawing**, which aids in the smooth decoding of barcodes from these formats. 

Explore how easy it is to extract barcode information using IronBarcode with the illustrated example in the code snippet below. The process involves simply reading an image and iterating over detected barcodes to display their values:

```cs
using IronBarCode;
using System;

var myBarcode = BarcodeReader.Read(@"image_file_path.jpg"); // Specify the path of the image

foreach (var item in myBarcode)
{
    Console.WriteLine(item.ToString());
}
```

Here are a couple of sample barcodes for you to test the functionality:

<figure>
    <img src="https://ironsoftware.com/static-assets/barcode/how-to/read-barcodes-from-images/QRcodeintro.jpeg"/>
    <figcaption>Example of a QR Code</figcaption>
</figure>

<figure>
    <img src="https://ironsoftware.com/static-assets/barcode/how-to/read-barcodes-from-images/Code128intro.jpeg"/>
    <figcaption>Example of a Code 128 Barcode</figcaption>
</figure>

Curious about the content these barcodes hold? Deploy the provided code snippet to reveal the encoded values in these images.

To begin using IronBarcode, first ensure that the library is added to your project via the Microsoft Visual Studio NuGet package manager. Once installed, you'll gain direct access to the `BarcodeReader.Read()` method, which simplifies reading barcodes by allowing the input of either file name or full path string directly as the method parameter. Remember, it's best practice to precede file paths with the verbatim string literal `@`, preventing the need for escape characters.

By appending the `Values()` method to your `BarcodeReader.Read()` invocation, you can fetch the barcode's content as a `System.String[]` object. To effectively output these values, loop through the array with a `foreach` loop and print each item using `Console.WriteLine()`.

The versatility of IronBarcode is not limited to 1D barcodes like Codabar or Code128; it efficiently reads 2D formats such as QR Codes and Data Matrix codes as well. This tool is powerful enough to adapt to various image file formats while maintaining a straightforward and accessible approach for developers.

## Direct Barcode Reading from Images

IronBarcode is renowned for its seamless capability to instantly read barcodes from various image formats directly. It supports a wide array of formats including:

- Scalable Vector Graphics (SVG)
- Joint Photographic Experts Group (JPEG)
- Portable Network Graphics (PNG)
- Graphics Interchange Format (GIF)
- Tagged Image File Format (TIFF)
- Bitmap Image File (BMP)

Thanks to the support from our freely available library, **IronDrawing**, IronBarcode effortlessly handles these formats. Let's explore how you can utilize IronBarcode to decode barcodes from a couple of example images as shown in the following code example.

Here's a paraphrased version of the provided section:

```cs
using IronBarCode;
using System;

// Load the barcode from the specified image file.
var barcodeData = BarcodeReader.Read(@"image_file_path.jpg"); // Modify the path to your image file.

// Loop through each barcode found and print its value.
foreach (var barcode in barcodeData)
{
    Console.WriteLine(barcode.ToString());
}
```

<figure>
    <img src="/static-assets/barcode/how-to/read-barcodes-from-images/QRcodeintro.jpeg"/>
    <figcaption>Sample test QR code</figcaption>
</figure>

<figure>
    <img src="/static-assets/barcode/how-to/read-barcodes-from-images/Code128intro.jpeg"/>
    <figcaption>Sample test barcode</figcaption>
</figure>

<i>Want to know what are the barcode values in the samples? Try it with the code snippet!!</i>

Begin by integrating the IronBarcode library into your project using the Microsoft Visual Studio NuGet package manager. This initial step permits the utilization of the `BarcodeReader.Read()` method, vital for decoding barcode images directly.

In the provided code sample, IronBarcode enhances user convenience by simplifying the process to read image files that are already integrated into the project. You can pass either the `file name` string or the `file path` string to the method. It's recommended to prefix file paths with the "@" symbol to handle file paths as verbatim string literals, which avoids the need for multiple escape characters "\\".

Enhance the functionality of the `BarcodeReader.Read()` by appending the `Values()` method. This addition extracts the barcode values and returns them as a `System.String[]`.

To display these values in the console, iterate through the `string[]` using a `foreach` loop. Within the loop, apply the `Console.WriteLine()` method, passing each value to be printed out.

The versatility of this method extends beyond reading traditional 1-Dimensional barcodes such as Codabar, Code128, Code39, Code93, EAN13, EAN18, ITF, MSI, UPCA, and UPCE; it is equally adept at decoding 2-Dimensional formats, including Aztec, DataMatrix, and QRCode, across a variety of image formats.

## Customizing Barcode Reader Settings

If you're encountering issues with slow barcode reading, difficulty with small barcodes, or want to specifically target certain areas or types of barcodes within an image, IronBarcode has got you covered.

The `BarcodeReaderOptions` class provides a flexible way to tailor the barcode reader's behavior to better suit your specific needs. Let's explore each configurable property within `BarcodeReaderOptions` to help you optimize your barcode reading tasks.

### CropArea Configuration

The `CropArea` attribute, part of the `BarcodeReaderOptions` and defined by the type `IronSoftware.Drawing.CropRectangle`, enables users to define a specific segment of an image for IronBarcode's analysis. This targeted approach not only boosts the efficiency of the scanning process by eliminating the need to examine the entire image but also enhances accuracy by focusing on a predefined area.

To configure the `CropArea`, you initiate a new `Rectangle` object and delineate the desired area by setting the coordinates, along with the rectangle's width and height in pixels (px).

<code>CropArea = new IronSoftware.Drawing.Rectangle(x, y, width, height)</code>

### Barcode Type Expectations

IronBarcode scans every supported barcode in an image by default. But, if you already know which barcode types are present or desired in an image, specifying just those types in the `ExpectBarcodeTypes` property can significantly enhance both the efficiency and accuracy of the scanning process. This optimization occurs because the reader avoids unnecessary iterations over unrecognized barcode formats.

To specify which types of barcodes to scan, assign the desired barcode types from the `BarcodeEncoding` enumeration to the `ExpectBarcodeTypes` property. Here's an overview of all the barcode types supported by IronBarcode, along with examples for each type:

<ul>

- **AllOneDimensional**: Refers to linear barcode types encompassing Codabar, Code128, Code39, Code93, EAN13, EAN18, ITF, MSI, UPCA, and UPCE.

- **AllTwoDimensional**: Pertains to barcodes that are represented in grid, matrix, or stacked formats. This category includes Aztec, DataMatrix, and QRCode barcodes.
```

<li><strong>Aztec</strong> : Aztec 2D barcode format. Aztec Code is a type of 2D barcode invented by Andrew Longacre, Jr. and Robert Hussey in 1995. Named after the resemblance of the central finder pattern to an Aztec pyramid, Aztec code has the potential to use less space than other matrix barcodes because it does not require a surrounding blank "quiet zone". Below is an example of an Aztec Barcode </li>
    <figure>
        <img src="/static-assets/barcode/how-to/read-barcodes-from-images/Aztec.jpeg" alt="Aztec barcode sample">
        <figcaption>Aztec Barcode</figcaption>
    </figure>
    <li><strong>Codabar</strong> : Codabar is a linear barcode symbology developed in 1972 by Pitney Bowes Corp. Codabar encodes <u>numerical data (digits) only</u>. Below is an example of Codabar barcode </li>
        <figure>
            <img src="/static-assets/barcode/how-to/read-barcodes-from-images/Codabar.jpeg" alt="Codabar barcode sample">
            <figcaption>Codabar Barcode</figcaption>
        </figure>
    <li><strong>Code128</strong> :  Code 128 is a high-density linear barcode symbology defined in ISO/IEC 15417:2007. It is used for <u>alphanumeric or numeric-only</u> barcodes. Below is an example of Code128 barcode </li>
        <figure>
            <img src="/static-assets/barcode/how-to/read-barcodes-from-images/Code128.jpeg" alt="Code128 barcode sample">
            <figcaption>Code128 Barcode</figcaption>
        </figure>
    <li><strong>Code39</strong> : Code 39 is a variable length, discrete barcode symbology. The Code 39 specification <u>defines 43 characters, consisting of uppercase letters</u> (A through Z). Below is an example of a Code39 barcode</li>
         <figure>
            <img src="/static-assets/barcode/how-to/read-barcodes-from-images/Code39.jpeg" alt="Code39 barcode sample">
            <figcaption>Code39 Barcode</figcaption>
        </figure>
    <li><strong>Code93</strong> : Code 93 1D barcode format. Code 93 is a barcode symbology designed in 1982 by Intermec to provide a higher density and data security enhancement to Code 39. Code 93 supports encoding of <u>only the following ASCII characters</u>: A B C D E F G H I J K L M N O P Q R S T U V W X Y Z 0 1 2 3 4 5 6 7 8 9 - . $ / + % SPACE. Below is an example of a Code93 barcode</li>
         <figure>
            <img src="/static-assets/barcode/how-to/read-barcodes-from-images/Code93.jpeg" alt="Code93 barcode sample">
            <figcaption>Code93 Barcode</figcaption>
        </figure>
    <li><strong>DataMatrix</strong> : A Data Matrix is a two-dimensional barcode consisting of black and white "cells" or modules arranged in either a square or rectangular pattern, also known as a matrix. The information to be encoded can be <u>text or numeric data</u>. Usual data size is from a few bytes up to 1556 bytes. Below is an example of a DataMatrix barcode </li>
         <figure>
            <img src="/static-assets/barcode/how-to/read-barcodes-from-images/DM.jpeg" alt="DataMatrix barcode sample">
            <figcaption>DataMatrix Barcode</figcaption>
        </figure>
    <li><strong>EAN13</strong> : The International Article Number (also known as European Article Number or EAN) is a standard describing a barcode symbology and numbering system used in global trade to identify a specific retail product type, in a specific packaging configuration, from a specific manufacturer. EAN-13 may <u>only encode numerical (digits) content of length 12 or 13 digits long</u>. Shorter Barcodes will have trailing zeros (000) prepended to the start of the number automatically. Below is an example of EAN13 barcode </li>
         <figure>
            <img src="/static-assets/barcode/how-to/read-barcodes-from-images/EAN13.jpeg" alt="EAN13 barcode sample">
            <figcaption>EAN13 Barcode</figcaption>
        </figure>                
    <li><strong>EAN8</strong> :  An EAN-8 is an EAN/UPC symbology barcode and is derived from the longer International Article Number (EAN-13) code. EAN-8 may <u>only encode numerical (digits) content of length 7 or 8 digits long</u>. Shorter Barcodes will have trailing zeros (000) prepended to the start of the number automatically. Below is an example of EAN8 barcode </li>
         <figure>
            <img src="/static-assets/barcode/how-to/read-barcodes-from-images/EAN8.jpeg" alt="EAN8 barcode sample">
            <figcaption>EAN8 Barcode</figcaption>
        </figure>
    <li><strong>IntelligentMail</strong> : Intelligent Mail 2D barcode format. The Intelligent Mail Barcode (Also known as "IM Barcode" or "USPS OneCode Barcodes" or "IMB") is a 65-bar barcode for use on mail in the United States. The term "Intelligent Mail" refers to services offered by the United States Postal Service for domestic mail delivery. The IM barcode is intended to provide greater information and functionality than its predecessors POSTNET and PLANET. Please note that IronBarcode can <strong> only READ</strong> this type of barcode. Below is an example of barcode of this type </li>
         <figure>
            <img src="/static-assets/barcode/how-to/read-barcodes-from-images/IM.png" alt="IntelligentMail barcode sample">
            <figcaption>IntelligentMail Barcode</figcaption>
        </figure>
    <li><strong>ITF</strong> :  ITF-14 is the GS1 implementation of an Interleaved 2 of 5 (ITF) bar code to encode a Global Trade Item Number. ITF-14 symbols are generally used on packaging levels of a product, such as a case box of 24 cans of soup. The ITF-14 will always encode 14 digits. ITF encodes <u>numerical data only</u>. If the number if digits is not even, a '0' will automatically be prepended. Below is an example of ITF barcode </li>
         <figure>
            <img src="/static-assets/barcode/how-to/read-barcodes-from-images/ITF.jpeg" alt="ITF barcode sample">
            <figcaption>ITF Barcode</figcaption>
        </figure>
    <li><strong>MaxiCode</strong> : MaxiCode 2D barcode format. MaxiCode is a public domain, machine-readable symbol system originally created and used by United Parcel Service. Suitable for tracking and managing the shipment of packages, it resembles a barcode, but uses dots arranged in a hexagonal grid instead. Please note that IronBarcode can <strong> only READ</strong> this type of barcode. Below is an example of barcode of this type </li> 
         <figure>
            <img src="/static-assets/barcode/how-to/read-barcodes-from-images/Maxicode.png" alt="MaxiCode barcode sample">
            <figcaption>MaxiCode Barcode</figcaption>
        </figure>
    <li><strong>MSI</strong> : MSI is a barcode symbology developed by the MSI Data Corporation, based on the original Plessey Code symbology. This type of barcode <u>only accepts numeric values</u>. Below is an example of an MSI type barcode </li>
        <figure>
            <img src="/static-assets/barcode/how-to/read-barcodes-from-images/MSI.jpeg" alt="MSI barcode sample">
            <figcaption>MSI Barcode</figcaption>
        </figure>
    <li><strong>PDF417</strong> : PDF417 is a stacked linear barcode symbol format used in a variety of applications, primarily transport, identification cards, and inventory management. PDF stands for Portable Data File. The 417 signifies that each pattern in the code consists of 4 bars and spaces, and that each pattern is 17 units long. The PDF417 symbology was invented by Dr. Ynjiun P. Wang at Symbol Technologies in 1991. (Wang 1993) It is ISO standard 15438. Below is an example of PDF417 barcode </li>
        <figure>
            <img src="/static-assets/barcode/how-to/read-barcodes-from-images/pdf417.jpeg" alt="PDF417 barcode sample">
            <figcaption>PDF417 Barcode</figcaption>
        </figure>
    <li><strong>PharmaCode</strong> : Pharmaceutical Binary Code. A reading fault tolerant binary barcode standard used in the medical industry. Please note that IronBarcode can <strong> only READ</strong> this type of barcode. Below is an example of a PharmaCode barcode </li>
        <figure>
            <img src="/static-assets/barcode/how-to/read-barcodes-from-images/pharmacode.png" alt="PharmaCode barcode sample">
            <figcaption>PharmaCode Barcode</figcaption>
        </figure>
    <li><strong>Plessey</strong> : Plessey Code is a 1D linear barcode symbology based on pulse width modulation, developed in 1971 by The Plessey Company PLC, a British-based company. This barcode type <u>only accepts numeric values</u>. Below is an example of a Plessey barcode </li>
        <figure>
            <img src="/static-assets/barcode/how-to/read-barcodes-from-images/plessey.jpeg" alt="Plessey barcode sample">
            <figcaption>Plessey Barcode</figcaption>
        </figure>
    <li><strong>QRCode</strong> :  QR code (abbreviated from Quick Response Code) is the trademark for a type of matrix barcode (or two-dimensional barcode) first designed in 1994 for the automotive industry in Japan. A barcode is a machine-readable optical label that contains information about the item to which it is attached. A QR code uses four standardized encoding modes (numeric, alphanumeric, byte/binary, and kanji) to efficiently store data; extensions may also be used. Below is an example of a QR code barcode </li>
        <figure>
            <img src="/static-assets/barcode/how-to/read-barcodes-from-images/QRcodeintro.jpeg" alt="QRCode barcode sample">
            <figcaption>QRCode Barcode</figcaption>
        </figure>
    <li><strong>Rss14</strong> : Reduce Space Symbology 14 barcode format. May represent a 1D barcode or Stacked 2D barcode. RSS 14 barcode (Reduce Space Symbology) encodes the full 14-digit EAN.UCC item identification in a symbol that can be omni-directionally scanned by suitably configured point-of-sale laser scanners. It is the latest barcode types for space-constrained identification from EAN International and the Uniform Code Council, Inc. RSS barcodes have been identified to target the grocery industry and in healthcare, where items are too small to allow for other barcode symbologies. Please note that IronBarcode can <strong> only READ</strong> this type of barcode. Below is an example of Rss14 barcode </li>
        <figure>                                                                        
            <img src="/static-assets/barcode/how-to/read-barcodes-from-images/1drss14.png" alt="1D Rss14 barcode sample">
            <figcaption>1 Dimensional Rss14 Barcode</figcaption>
        </figure>
        <figure>
            <img src="/static-assets/barcode/how-to/read-barcodes-from-images/2Drss14.png" alt="2D Rss14 barcode sample">
            <figcaption>2 Dimensional Rss14 Barcode</figcaption>
        </figure>
    <li><strong>UPCA</strong> : The Universal Product Code (UPC) is a barcode symbology that is widely used in the United States, Canada, United Kingdom, Australia, New Zealand, in Europe and other countries for tracking trade items in stores. UPC (technically refers to UPC-A) consists of 12 numeric digits, that are uniquely assigned to each trade item. Along with the related EAN barcode, the UPC is the barcode mainly used for scanning of trade items at the point of sale, per GS1 specifications. UPCA may <u>only encode numerical (digits) content of length 12 or 13 digits long</u>. Shorter Barcodes will have trailing zeros (000) prepended to the start of the number automatically. Below is an example of a UPCA barcode </li>
        <figure>
            <img src="/static-assets/barcode/how-to/read-barcodes-from-images/UPCAbarcode.png" alt="UPCA barcode sample">
            <figcaption>UPCA Barcode</figcaption>
        </figure>
    <li><strong>UPCE</strong> : To allow the use of UPC barcodes on smaller packages, where a full 12-digit barcode may not fit, a 'zero-suppressed' version of UPC was developed, called UPC-E, in which the number system digit, all trailing zeros in the manufacturer code, and all leading zeros in the product code, are suppressed. UPCE may <u>only encode numerical (digits) content of length 7 or 8 digits long</u>. Below is an example of UPCE barcode </li>
        <figure>
            <img src="/static-assets/barcode/how-to/read-barcodes-from-images/UPCEbarcode.jpg" alt="UPCE barcode sample">
            <figcaption>UPCE Barcode</figcaption>
        </figure>
</ul>

### ExpectMultipleBarcodes

By default, IronBarcode scans every barcode present in an image, processing the entire file and storing each detected barcode value in a string array. For applications where only the first detected barcode is needed, the `ExpectMultipleBarcodes` property can be set to `false`. This adjustment directs IronBarcode to halt scanning after identifying the first barcode, enhancing both the efficiency and the speed of the barcode reading process.

### Image Filters

An essential feature of the `BarcodeReaderOptions` is the ability to incorporate a collection of image filters. These filters are crucial for preprocessing the raw image before it is processed by Iron Barcode. To utilize these image filters, one must initialize and define the `ImageFilter` collection within the `BarcodeReaderOptions`.

### MaxParallelThreads

IronBarcode enables customization of parallel thread execution to enhance processing speed and efficiency. This feature involves running multiple threads concurrently across different processor cores. By default, IronBarcode sets the `MaxParallelThread` property to 4, but users can modify this setting to align with their system's capabilities and resource availability.

### Multithreaded Capability

The `Multithreaded` setting in IronBarcode is crafted to facilitate the parallel processing of multiple images. By default, the `Multithreaded` property is set to `True`. This configuration ensures that IronBarcode efficiently manages concurrent threads to enhance the throughput when handling batch operations for barcode reading.

### RemoveFalsePositive

The `RemoveFalsePositive` property is designed to eliminate instances where incorrect barcode values are mistakenly recognized as valid, known as false positive reads. These misreads can be attributed to various errors during the barcode generation or scanning process, including mistakes in the sequence or mishaps in barcode labeling or preparation. By configuring `RemoveFalsePositive` to `true`, users can effectively filter out these inaccurate readings, thereby enhancing the precision of barcode scans. Conversely, if the priority is to optimize performance despite potential compromises in accuracy, setting this attribute to `false` may be beneficial. The default setting for this property is `true`.

### Adjusting the Speed Setting

The `Speed` setting in IronBarcode allows users to fine-tune the barcode reader's performance. Just like the `RemoveFalsePositive` option, adjusting this setting can either improve performance or impact accuracy. Users have four levels of speed settings to choose from, detailed as follows:

* **ReadingSpeed.Faster**
  
  Opting for the `Speed` setting to `ReadingSpeed.Faster` prioritizes speed over accuracy. While this mode completes tasks quickly, it may result in missing barcode data if the image hasn't undergone any preprocessing. This setting is ideal for users with high-quality, clear images and need fast results.
  
* **ReadingSpeed.Balanced**
  
  The `ReadingSpeed.Balanced` is the preferred setting for most users. It offers a balance between speed and accuracy by applying light processing to enhance the visibility of the barcode region. This generally provides reliable results without extensive image processing.

* **ReadingSpeed.Detailed**
  
  When the balanced setting does not yield the desired barcode values, the `ReadingSpeed.Detailed` can be used. This mode performs medium-level image processing to make the barcode clearer and more detectable. It is particularly useful for images with small or low-contrast barcodes.
  
  Note that this setting is more demanding on CPU resources and may slow down the reading process. Users are advised to try other settings first; using `ReadingSpeed.Detailed` in combination with `RemoveFalsePositive` set to `True` might trigger a console warning, but it will not hinder the operation.

* **ReadingSpeed.ExtremeDetail**
  
  The `ReadingSpeed.ExtremeDetail` provides the deepest level of processing to ensure that barcodes can be read from the most challenging images. However, this is the least recommended setting due to its heavy demand on CPU usage and significant reduction in performance.
  
  It is advisable to preprocess the image or use filters before choosing this setting to mitigate performance issues. Despite its intensity, experimenting with other less demanding settings first is recommended.

By carefully choosing the appropriate `Speed` setting, users can optimize the IronBarcode's performance to fit their specific needs for accuracy and processing speed.

### Utilizing Code39 Extended Mode

The `UseCode39ExtendedMode` configuration provides a capability to enhance the interpretation of Code39 barcodes using the extended ASCII character set. By activating this feature with `UseCode39ExtendedMode = true`, the accuracy of Code39 barcode readings is significantly improved.

## Advanced Barcode Reading from Images

After exploring the various customization options available for enhancing both the accuracy and performance of barcode reading, let's look at how these settings can be practically implemented in your coding projects. Below is an illustrative code example to guide you through this process.

```cs
using IronBarCode;
using System;

// Instantiate and configure the BarcodeReaderOptions
BarcodeReaderOptions options = new BarcodeReaderOptions() {
    ExpectBarcodeTypes = BarcodeEncoding.AllOneDimensional, // Choose between AllOneDimensional or AllTwoDimensional
    ExpectMultipleBarcodes = true, // Default is to expect multiple barcodes
    MaxParallelThreads = 2, // Reduce from the default of 4 for this example
    Speed = ReadingSpeed.Detailed, // Opt for detailed processing for better accuracy
    CropArea = new IronSoftware.Drawing.Rectangle(x: 242, y: 1124, width: 359, height: 378), // Target specific area in pixels
    ImageFilters = new ImageFilterCollection { new BinaryThresholdFilter() }, // Add appropriate image filters
    Multithreaded = true, // Leverage multithreading
    UseCode39ExtendedMode = true, // Ensure more accurate Code39 reading
};

// Read the barcode from an image file with applied settings
var barcodeResults = BarcodeReader.Read(@"image_file_path.jpg", options);

// Iterate through each detected barcode and print the result
foreach (var result in barcodeResults) {
    Console.WriteLine(result.ToString());
}
```

This sample demonstrates how to integrate and fine-tune the advanced options provided in `BarcodeReaderOptions` to optimize barcode scanning in your application, ensuring that all configurations are effectively applied when reading barcodes from an image.

```cs
using IronBarCode;
using System;

// Initialize the options for reading the barcodes with customized settings
BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    ExpectBarcodeTypes = BarcodeEncoding.AllOneDimensional, // Choose either AllOneDimensional or AllTwoDimensional based on barcode type
    ExpectMultipleBarcodes = true, // Reads multiple barcodes by default
    MaxParallelThreads = 2, // Reduced from the default of 4 for more control over processing
    Speed = ReadingSpeed.Detailed, // Set to Detailed for more precise barcode readings
    CropArea = new IronSoftware.Drawing.Rectangle(242, 1124, 359, 378), // Focus the reading to a specific region in pixels
    ImageFilters = new ImageFilterCollection { new BinaryThresholdFilter() }, // Apply specific image filters to improve barcode detection
    Multithreaded = true, // Enables parallel image processing
    UseCode39ExtendedMode = true, // Enhances reading by using the full ASCII Character Set for Code 39 barcodes
};

// Read the barcode from the specified image file using the configured options
var resultBarcode = BarcodeReader.Read(@"image_file_path.jpg", options); // Specify the correct path to the image file

// Output the results from the barcode reading
foreach (var barcode in resultBarcode)
{
    Console.WriteLine(barcode.ToString());
}
```

From the provided code sample, it's evident that you must first initialize an instance of the `BarcodeReaderOptions`. You can then tailor its properties to meet specific needs as outlined in the prior sections. Once configured, this options object can then be passed as a parameter to the `BarcodeReader.Read()` method, alongside the path of the image file. This integration ensures that your specified settings are actively utilized during the barcode reading process from the image.


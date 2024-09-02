# Extracting Barcodes from Various Image Formats (jpg, png, gif, tiff, svg, bmp)

IronBarcode excels in extracting barcode information directly from a variety of image formats. It supports:

- Scalable Vector Graphics (SVG)
- Joint Photographic Experts Group (JPEG)
- Portable Network Graphics (PNG)
- Graphics Interchange Format (GIF)
- Tagged Image File Format (TIFF)
- Bitmap Image File (BMP)

This functionality is empowered by the robust open-source library, **IronDrawing**. Here, we will demonstrate how to utilize IronBarcode to seamlessly decode barcodes from images as illustrated in the ensuing code example.

```cs
using IronBarCode;
using System;

var myBarcode = BarcodeReader.Read(@"image_file_path.jpg"); // Specify the image file path

foreach (var item in myBarcode)
{
    Console.WriteLine(item.ToString());
}
```

<figure>
    <img src="https://ironsoftware.com/static-assets/barcode/how-to/read-barcodes-from-images/QRcodeintro.jpeg"/>
    <figcaption>Example of a QR code</figcaption>
</figure>

<figure>
    <img src="https://ironsoftware.com/static-assets/barcode/how-to/read-barcodes-from-images/Code128intro.jpeg"/>
    <figcaption>Example of a Code128 barcode</figcaption>
</figure>

<i>Curious about the values embedded within these barcodes? Implement the provided code snippet to discover!</i>

Start by incorporating the IronBarcode library into your project through the Microsoft Visual Studio NuGet package manager. This enables access to the `BarcodeReader.Read()` method for immediate barcode reading capabilities directly from an image file, using either a filename or full pathname as input. For best practices in file path entries, use the verbatim string literal "@" to avoid the necessity for escape characters "\\".

Appending the `Values()` method after calling `BarcodeReader.Read()` method allows retrieval of barcode values as a `System.String[]` object. Use a `foreach` loop to traverse through each barcode value, and print them using `Console.WriteLine()` method within the loop.

IronBarcode not only reads standard 1-Dimensional barcode types like Codabar, Code128, and UPC variants but also 2-Dimensional types such as QR Codes and Data Matrix codes in various image formats.

## Decoding Barcodes Directly from Various Image Formats

IronBarcode excels in its innate ability to seamlessly decode barcodes from a diverse range of image formats right out of the box, including:

- Scalable Vector Graphics (SVG)
- Joint Photographic Experts Group (JPEG)
- Portable Network Graphics (PNG)
- Graphics Interchange Format (GIF)
- Tagged Image File Format (TIFF)
- Bitmap Image File (BMP)

This capability is enhanced by our open-source library, **IronDrawing**. Let's explore how to utilize IronBarcode for extracting barcode information from a couple of sample images, as shown in the following code example.

Here is the paraphrased section of the provided article:

```cs
using IronBarCode;
using System;

// Read a barcode from a specified image file
var barcodeResult = BarcodeReader.Read(@"image_file_path.jpg"); // Replace with your actual image path

// Iterate through each barcode detected in the image
foreach (var barcode in barcodeResult)
{
    // Print the barcode data to the console
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

To begin utilizing IronBarcode, start by integrating the IronBarcode library into your project through the NuGet package manager in Microsoft Visual Studio. This step enables the use of the `BarcodeReader.Read()` method for seamlessly scanning barcodes from images.

The simplicity of IronBarcode is evident, as it allows developers to straightforwardly employ the `BarcodeReader.Read()` method to process an image file already included in the project by simply providing either the **file name** or the **file path** as an argument. It is advisable to prefix file paths with `@` to treat them as verbatim string literals, thereby avoiding the necessity to use escape characters (`\`) frequently in the file path.

To extract barcode values as a `System.String []`, append the `Values()` method to the `BarcodeReader.Read()` call.

To display the results in the console, implement a `foreach` loop to iterate through the `string []` array. Within the loop, utilize the `Console.WriteLine()` with the iteration variable to print each barcode value.

IronBarcode is versatile, capable of decoding both one-dimensional barcode types such as Codabar, Code128, Code39, Code93, EAN13, EAN18, ITF, MSI, UPCA, and UPCE, as well as two-dimensional formats including Aztec, DataMatrix, and QRCode across various image encodings.

## Configuring Barcode Reader Options

Are you experiencing slow barcode reading speeds? Is the barcode too tiny in the image for IronBarcode to detect? Do you wish to focus on specific regions or specific types of barcodes within a multi-barcode image? Looking to boost your overall reading efficiency? Say goodbye to these worries!

The `BarcodeReaderOptions` class provides a flexible way to modify the behavior of the barcode reader, effectively addressing the challenges mentioned above. Here, we will explore each of the configurable properties of `BarcodeReaderOptions` in detail:

### CropArea

The `CropArea` property, available within the `BarcodeReaderOptions` and represented by the type `IronSoftware.Drawing.CropRectangle`, enables you to define a specific region within an image that IronBarcode should focus on for barcode scanning. By pinpointing a target area, this significantly enhances scan performance and accuracy because the scanner doesn't expend time and resources scanning the entire image.

To configure the `CropArea`, create a new `Rectangle` object and input the desired coordinates along with the rectangle's width and height. Measurements for these dimensions should be provided in pixels (px).

<code>CropArea = new System.Drawing.Rectangle(x, y, width, height)</code>

### ExpectBarcodeTypes

IronBarcode is designed to scan all recognized barcodes in an image by default. Yet, if you are aware of which types of barcodes are present or need to be scanned in your image, you can configure the `ExpectBarcodeTypes` property. This optimizes both the speed and accuracy of barcode reading by avoiding unnecessary scanning of all barcode formats.

To effectively utilize this feature, assign the `ExpectBarcodeTypes` property a specific value from the `BarcodeEncoding` enumeration. Let's explore the various barcode types that IronBarcode supports, along with examples for each type.

<ul>

<li><strong>AllOneDimensional</strong>: These are linear barcode types, covering varieties such as Codabar, Code128, Code39, Code93, EAN13, EAN18, ITF, MSI, UPCA, and UPCE.</li><br>

<li><strong>AllTwoDimensional</strong>: Encompasses Grid, Matrix, and Stacked Barcodes. 2D barcodes included under this category are Aztec, DataMatrix, and QRCode.</li><br>
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

By default, IronBarcode is programmed to detect and scan every barcode present in an image. This process involves reading the entire image and cataloging each barcode value into a string array. Nonetheless, in scenarios where scanning multiple barcodes is unnecessary, users have the ability to configure this property to `false`. This adjustment causes the barcode scanner to halt as soon as it identifies the first barcode value, thereby enhancing IronBarcode's efficiency and scanning speed.

### Image Filters Configuration

The `BarcodeReaderOptions` includes a feature that allows the incorporation of image filters. These filters play a crucial role in preprocessing the images before they are processed by Iron Barcode. To utilize these filters, users need to initialize an `ImageFilter` collection within the `BarcodeReaderOptions`. This setup ensures that the images are adequately prepared, enhancing the effectiveness of the barcode reading process.

### MaxParallelThreads

IronBarcode offers a feature that enhances processing speed and efficiency by allowing adjustments to the number of parallel threads utilized during execution. This feature facilitates the simultaneous running of multiple threads across various processor cores. The default setting for the `MaxParallelThread` property is 4, however, users can modify this setting according to the performance capabilities and resources available on their systems.

### Multithreaded Capability

The `Multithreaded` attribute in IronBarcode boosts efficiency by allowing simultaneous processing of multiple images. Set to **True** by default, it utilizes multiple threads to enhance speed, greatly aiding in batch processing of barcode images.

### Eliminate False Positives

The `RemoveFalsePositive` attribute is essential for excluding erroneous barcode scans which are falsely identified as valid. Such errors may arise from issues during the barcode sequencing or from inaccuracies in barcode labeling or preparation. Activating this attribute by setting `RemoveFalsePositive` to `True` enhances the precision of barcode scans by filtering out these inaccuracies. Conversely, for users prioritizing performance over accuracy, deactivating this feature by setting it to `False` can increase processing speed. This attribute is enabled by default, with its setting as `True`.

### Speed Optimization in Barcode Reading

The `Speed` property of IronBarcode allows users to fine-tune the barcode reader’s performance. Adjusting this setting impacts the trade-off between speed and accuracy, available in four distinct levels:

* **ReadingSpeed.Faster**

  Configuring the `Speed` parameter to `ReadingSpeed.Faster` significantly accelerates barcode reading. However, this swift processing could compromise accuracy, potentially leading to absent barcode results. This setting is advisable only when working with high-quality, unambiguous images as no preprocessing of the image occurs.

* **ReadingSpeed.Balanced**

  The `ReadingSpeed.Balanced` option is the preferred setting for most use cases. It offers a middle ground by lightly processing the input image, enhancing the visibility of barcodes for more reliable detection and reading. Typically, this setting yields accurate barcode readings for reasonably clear images.

* **ReadingSpeed.Detailed**

  For cases where `ReadingSpeed.Balanced` does not capture all barcode values effectively, `ReadingSpeed.Detailed` should be considered. This setting conducts a more thorough processing to delineate the barcode areas more distinctly, especially useful for smaller or blurry barcodes. Note that this enhanced detail level requires more CPU resources and could affect overall performance. Testing with different settings before settling on this one is recommended, especially since activating this in conjunction with `RemoveFalsePositive` set to `True` could lead to warnings, though these do not hinder the reading process.

* **ReadingSpeed.ExtremeDetail**

  The `ReadingSpeed.ExtremeDetail` setting is generally not recommended unless absolutely necessary due to its extensive resource demands. This mode performs the most intensive processing to ensure barcode readability even in challenging conditions. However, it significantly slows down the reading process. Preprocessing the image with suitable filters before employing this setting is strongly advised. Users should also be prepared for potential performance impacts and consider experimenting with lighter settings initially. In conjunction with `RemoveFalsePositive` set to `True`, this setting may trigger console warnings, but these do not impact the functionality. 

These adjustments provide flexibility in managing the balance between speed and accuracy according to the specific needs of your application.

### Utilizing Extended Mode for Code39 Barcodes

The `UseCode39ExtendedMode` configuration enables the interpretation of Code39 barcodes using the extended ASCII character set. By activating this feature and setting `UseCode39ExtendedMode` to **True**, users can enhance the precision of Code39 barcode readings.

## Advanced Barcode Reading from Images

Having explored various customizable options provided by IronBarcode that enhance both the accuracy and performance of barcode reading, let's move on to practical implementation in code. Here's a detailed example that shows you how:

```cs
using IronBarCode;
using System;

// Configure the scanner with advanced options
BarcodeReaderOptions advancedOptions = new BarcodeReaderOptions()
{
    ExpectBarcodeTypes = BarcodeEncoding.AllOneDimensional, // Target all 1D barcodes
    ExpectMultipleBarcodes = true, // By default, it's true
    MaxParallelThreads = 2, // Reduce from default of 4 for this example
    Speed = ReadingSpeed.Detailed, // Opt for a more detailed reading speed
    CropArea = new IronSoftware.Drawing.Rectangle(x: 242, y: 1124, width: 359, height: 378), // Define the crop area in pixels
    ImageFilters = new ImageFilterCollection { new BinaryThresholdFilter() }, // Include a binary threshold filter
    Multithreaded = true, // Enable multithreading
    UseCode39ExtendedMode = true, // Enhance the reading of Code39 barcodes
};

// Read the barcode from an image using the specified options
var detectedBarcodes = BarcodeReader.Read(@"image_file_path.jpg", advancedOptions); // Use the path of your image here

// Output the results to the console
foreach (var barcode in detectedBarcodes)
{
    Console.WriteLine(barcode.ToString());
}
```

This code segment beautifully illustrates how to initialize the `BarcodeReaderOptions`, set its properties based on your specific needs, and employ those settings to effectively read barcodes from an image.

Here's the paraphrased section:

```cs
using IronBarCode;
using System;

// Setup the barcode reading configuration using specified options
BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    ExpectBarcodeTypes = BarcodeEncoding.AllOneDimensional,  // Can be set to AllTwoDimensional
    ExpectMultipleBarcodes = true,  // Enables reading of multiple barcodes
    MaxParallelThreads = 2,  // Adjusted from default 4 for better performance
    Speed = ReadingSpeed.Detailed,  // Select a detailed speed level, default is Balanced
    CropArea = new IronSoftware.Drawing.Rectangle(x: 242, y: 1124, width: 359, height: 378), // Specify scanning area in pixels
    ImageFilters = new ImageFilterCollection { new BinaryThresholdFilter() },  // Add image pre-processing filters
    Multithreaded = true,  // Utilize multiple threads
    UseCode39ExtendedMode = true,  // Activate extended mode for Code39 barcodes
};

// Read the barcode from specified image path using the options
var barcodes = BarcodeReader.Read(@"image_file_path.jpg", options); // Provide the image file path

// Output each decoded barcode value
foreach (var barcode in barcodes)
{
    Console.WriteLine(barcode.ToString());
}
``` 

This rewrite maintains the same functionality as demonstrated in the original code snippet, focusing on applying the advanced settings of the `BarcodeReaderOptions` class to optimize barcode reading from an image file.

In the provided code snippet, it's evident how to utilize the `BarcodeReaderOptions`. Initially, we create an instance of `BarcodeReaderOptions`, after which we configure its settings based on the previously described properties. This configured instance is subsequently passed as a parameter in the `BarcodeReader.Read()` method, together with the path of the image file. By doing so, the `BarcodeReaderOptions` settings are effectively applied during the barcode reading process from the specified image.


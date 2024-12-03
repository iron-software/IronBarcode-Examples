# Extracting Barcodes from Various Image Formats (jpg, png, gif, tiff, svg, bmp)

***Based on <https://ironsoftware.com/how-to/read-barcodes-from-images/>***


---

IronBarcode excels at extracting barcodes directly from a variety of image formats effortlessly. Supported formats include:

* SVG (Scalable Vector Graphics)
* JPEG (Joint Photographic Experts Group)
* PNG (Portable Network Graphics)
* GIF (Graphics Interchange Format)
* TIFF (Tagged Image File Format)
* BMP (Bitmap Image File)

Utilizing the open-source library IronDrawing, IronBarcode seamlessly reads barcodes from images. Below, we demonstrate how to employ IronBarcode to decode barcodes from images using the provided code snippet.

```cs
using System;
using BarCode;
namespace ironbarcode.ReadBarcodesFromImages
{
    public class Section1
    {
        public void Run()
        {
            var myBarcode = BarcodeReader.Read(@"image_file_path.jpg"); // Specify the path to the image file
            
            foreach (var item in myBarcode)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
```
Included are sample barcode images for you to test the functionality:

<figure>
    <img src="https://ironsoftware.com/static-assets/barcode/how-to/read-barcodes-from-images/QRcodeintro.jpeg"/>
    <figcaption>Example of a QR Code</figcaption>
</figure>

<figure>
    <img src="https://ironsoftware.com/static-assets/barcode/how-to/read-barcodes-from-images/Code128intro.jpeg"/>
    <figcaption>Example of a Code 128 Barcode</figcaption>
</figure>

Curious about the barcode content in these samples? Implement the code above and discover their values!

Starting with IronBarcode is straightforward. Simply add the IronBarcode library to your project via the NuGet package manager in Microsoft Visual Studio. This provides access to the `BarcodeReader.Read()` method, which reads the barcode image when passed a string denoting the file name or path. It's advisable to employ a verbatim string literal, '@', when specifying paths to avoid the need for escape characters.

By appending the `Values()` method to the `BarcodeReader.Read()` call, you receive barcode data as a `System.String []`. Display these results in the console using a `foreach` loop, iterating over the barcode values array and using `Console.WriteLine()` to output each value.

IronBarcode not only reads 1-dimensional barcodes like Codabar, Code128, and others but also deciphers 2-dimensional types such as QR Codes, DataMatrix, and more across various supported image formats.

## Direct Barcode Reading from Images

One of IronBarcode's standout features is its capability to directly extract barcode information from a variety of image formats right out of the box. Supported formats include:

- Scalable Vector Graphics (SVG)
- Joint Photographic Experts Group (JPEG)
- Portable Network Graphics (PNG)
- Graphics Interchange Format (GIF)
- Tagged Image File Format (TIFF)
- Bitmap Image File (BMP)

This functionality is enabled through our open-source library, **IronDrawing**. Let's explore how to utilize IronBarcode to decode barcodes from two attached barcode images, as illustrated in the following code snippet.

Here is the paraphrased section from the article, with updated code comments and the relative URL paths resolved:

```cs
using System;
using BarCode;
namespace ironbarcode.ReadBarcodesFromImages
{
    public class BarcodeScanner
    {
        public void Execute()
        {
            // Reads a barcode from a specified image path
            var barcodes = BarcodeReader.Read(@"image_file_path.jpg"); 

            // Iterating through each barcode found in the image
            foreach (var barcode in barcodes)
            {
                // Outputs the barcode data to the console
                Console.WriteLine(barcode.ToString());
            }
        }
    }
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

To begin working with IronBarcode, initiate by integrating the IronBarcode library into your project using the Microsoft Visual Studio NuGet package manager. This installation grants you access to the critical feature of IronBarcode, the `BarcodeReader.Read()` method, which enables direct reading from barcode images embedded in your project.

IronBarcode simplifies operations by allowing the use of `BarcodeReader.Read()`, which necessitates just a file path or file name to function. It is highly recommended to use a verbatim string literal "@" to designate file paths accurately. This approach avoids the need for additional escape characters "\\" typically required in file paths.

Moreover, appending the `Values()` method subsequent to `BarcodeReader.Read()` extracts the actual barcode values, capturing them as a `System.String[]` array.

To display these values in the console, employ a `foreach` loop to iterate over the `string[]` data structure, printing each item with `Console.WriteLine()`.

IronBarcode is adept at processing not only one-dimensional barcode formats like Codabar, Code128, Code39, Code93, EAN13, EAN8, ITF, MSI, UPCA, and UPCE but also excels in two-dimensional types such as Aztec, DataMatrix, and QR Code, supporting a broad range of image formats.

## Configuring Barcode Reader Settings

Are you experiencing slow barcode scanning speeds, or is IronBarcode unable to detect small barcodes in images? Perhaps you're looking to target specific areas or specific types of barcodes among a variety of others within the same image? If you’re aiming to enhance the reading efficiency overall, you’ve come to the right place!

The `BarcodeReaderOptions` class offers you the flexibility to customize how the barcode reader functions to address all these concerns and more. Let’s explore each of the configurable options available within `BarcodeReaderOptions` in detail:

### CropArea

The `CropArea` attribute within `BarcodeReaderOptions` is a feature that utilizes the `IronSoftware.Drawing.CropRectangle` type to designate a specific segment of an image for barcode detection by IronBarcode. This targeted approach not only enhances the speed by limiting the scanning area but also heightens the accuracy of barcode recognition.

To configure the `CropArea`, create a new instance of a Rectangle object, inputting the necessary coordinates along with the desired width and height of the rectangle. Specify these measurements in pixels (px).

<code>CropArea = new IronSoftware.Drawing.Rectangle(x, y, width, height)</code>

### ExpectBarcodeTypes

IronBarcode is designed to scan every supported barcode when reading from an image by default. Yet, if users are aware of which barcode types are present or necessary for their application, they can optimize the reading process. By specifying only required barcode types using this property, both the precision and speed of barcode reading improve significantly, because IronBarcode avoids scanning for unnecessary barcode types.

To configure this, simply assign the desired types to the `ExpectBarcodeTypes` property using the `BarcodeEncoding` enum. This allows for tailored barcode reading, enhancing both efficiency and accuracy. Now, let's explore the different types of barcodes supported by IronBarcode and view examples of each.

<ul>

- **AllOneDimensional**: This category encompasses linear barcode types. It comprises Codabar, Code128, Code39, Code93, EAN13, EAN18, ITF, MSI, UPCA, and UPCE barcodes.

- **AllTwoDimensional**: Encompassing Grid, Matrix, and Stacked barcodes, this category includes 2-dimensional barcode formats such as Aztec, DataMatrix, and QRCode.
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

### Reading Multiple Barcodes

By default, IronBarcode scans and detects all barcodes present within an image, processing the entire image file to extract barcode values into an array. If you prefer not to scan for multiple barcodes within the same image, you can adjust the `ExpectMultipleBarcodes` property to `false`. This modification causes the scanner to halt once it identifies the first barcode, enhancing both the speed and performance of the IronBarcode.

### Image Filters

Within the `BarcodeReaderOptions`, there's an essential feature of image filters that help in preprocessing the raw image fed into Iron Barcode. To utilize image filters, you initially need to create and define the `ImageFilter` collection within the `BarcodeReaderOptions`.

### MaxParallelThreads

IronBarcode provides functionality for configuring the number of concurrent thread executions, optimizing the speed and resource utilization during the process. Executing multiple threads in parallel across different processor cores is what this setting controls. The default setting for the `MaxParallelThread` property in IronBarcode is set to 4, but this can be modified to match the performance capabilities and resources available on the user's machine.

### Multithreaded Capability

The `Multithreaded` setting in IronBarcode allows the simultaneous processing of several images. By default, this property is set to `True`, meaning that IronBarcode automatically manages multiple threads. This enhances efficiency, particularly when handling bulk barcode reading operations. Utilizing this feature can significantly speed up operations without manual thread management.

### RemoveFalsePositive Property

The `RemoveFalsePositive` property is designed to eliminate incorrect barcode scans that are mistakenly classified as valid. Typically, these errors arise during the barcode sequencing or because of issues in labeling or preparation. Setting the `RemoveFalsePositive` property to `true` effectively filters out these inaccuracies, enhancing the reliability of barcode readings. On the contrary, prioritizing performance over precision can be achieved by setting this property to `false`. The default setting for this property is `true`, ensuring accuracy in standard scenarios.

### Speed Tuning in IronBarcode

The `Speed` property in the IronBarcode library facilitates performance optimization when reading barcodes. Similar to the `RemoveFalsePositive` option, adjusting this setting can enhance speed but may reduce accuracy. There are four distinct levels of operation for this property:

* **ReadingSpeed.Faster**

  Selecting `ReadingSpeed.Faster` accelerates the barcode reading process. However, this is often at the cost of accuracy. When set to this level, the barcode reader works with the images as they are provided, without any preprocessing step. Therefore, proper results are only guaranteed if the provided images are clear and well-defined. It is advisable to only select this speed level when the input images are of high quality.

* **ReadingSpeed.Balanced**

  The `ReadingSpeed.Balanced` setting is the default and recommended option. It offers a compromise between speed and accuracy, employing minimal image processing to make the barcode stand out sufficiently for reliable detection. This mode typically ensures successful barcode reads with accurate results.

* **ReadingSpeed.Detailed**

  If results from the `ReadingSpeed.Balanced` setting prove insufficient, the `ReadingSpeed.Detailed` level might be appropriate. This setting employs a moderate level of image processing to further clarify the barcode zone, enhancing the likelihood of accurate detection, especially helpful with smaller or poorly defined barcodes.

  It's important to note that this setting is more demanding on CPU resources, which could impact overall performance. Users are encouraged to try other settings before using this one. If combined with `RemoveFalsePositive` set to `True`, a console warning may show, but it will not impede the function of the read.

* **ReadingSpeed.ExtremeDetail**

  The highest level of processing, `ReadingSpeed.ExtremeDetail`, involves intensive image processing to decode the barcodes. This setting should be used sparingly, as it significantly lowers processing speed due to the heavy computation required.

  Users are advised to preprocess the images or apply filters beforehand to reduce the computational load. Despite being resource-intensive, experimenting with other settings is recommended before settling on this one. Similar to the detailed setting, using this with `RemoveFalsePositive` set to `True` may trigger console warnings, which do not affect the function.

### UseCode39ExtendedMode Feature

This option enables the extended mode reading of Code39 barcodes which supports the entire ASCII character set. By setting the `UseCode39ExtendedMode` to **True**, it enhances the accuracy with which Code39 barcodes are interpreted.

## Enhanced Barcode Scanning Implementation

Having explored the various options available for customizing barcode reading for improved precision and performance, we can now integrate these configurations in our coding practice. Below is an illustrative example of how to apply these settings:

```cs
using System;
using BarCode;
namespace ironbarcode.ReadBarcodesFromImages
{
    public class Section2
    {
        public void Run()
        {
            // Initialize barcode reader options with detailed adjustments
            BarcodeReaderOptions myOptions = new BarcodeReaderOptions()
            {
                ExpectBarcodeTypes = BarcodeEncoding.AllOneDimensional, // Specify expected barcode types
                ExpectMultipleBarcodes = true, // Enable reading multiple barcodes
                MaxParallelThreads = 2, // Reduce the number of parallel threads for resource management
                Speed = ReadingSpeed.Detailed, // Opt for a detailed processing speed
                CropArea = new IronSoftware.Drawing.Rectangle(x: 242, y: 1124, width: 359, height: 378), // Focus scan area to enhance accuracy
                ImageFilters = new ImageFilterCollection { new BinaryThresholdFilter() }, // Apply binary threshold filtering
                Multithreaded = true, // Enable multithreaded processing
                UseCode39ExtendedMode = true, // Utilize extended mode for Code39 for comprehensive data capture
            };

            // Read the barcode from image with specified options
            var myBarcode = BarcodeReader.Read(@"image_file_path.jpg", myOptions); // Path to image file

            // Output the scanned barcode values to the console
            foreach (var item in myBarcode)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
``` 

In this example, `BarcodeReaderOptions` are configured to tailor the barcode reading process to specific needs. This ensures that the scanner performs optimally under given conditions, demonstrating the flexibility and power of IronBarcode in handling barcode reading tasks.

Here is the paraphrased section of code with all relative URL paths resolved to ironsoftware.com:

```cs
using System;
using BarCode;
namespace ironbarcode.ReadBarcodesFromImages
{
    public class SettingsDemo
    {
        public void Execute()
        {
            // Configure the reader with desired settings
            BarcodeReaderOptions options = new BarcodeReaderOptions()
            {
                ExpectBarcodeTypes = BarcodeEncoding.AllOneDimensional, // To read all 1D barcodes; alternative is AllTwoDimensional
                ExpectMultipleBarcodes = true, // Ensures multiple barcodes can be read (default setting)
                MaxParallelThreads = 2, // Modifies default parallel processing threads count from 4 to 2
                Speed = ReadingSpeed.Detailed, // Choosing detailed processing for better accuracy (standard is Balanced)
                CropArea = new IronSoftware.Drawing.Rectangle(x: 242, y: 1124, width: 359, height: 378), // Specifying the crop area in pixels
                ImageFilters = new ImageFilterCollection { new BinaryThresholdFilter() }, // Applying binary threshold filter to the image
                Multithreaded = true, // Permitting multithreaded reading (default enabled)
                UseCode39ExtendedMode = true, // Activating extended mode for Code39 barcode types (default enabled)
            };

            // Read barcodes from the specified image path using the configured options
            var detectedBarcodes = BarcodeReader.Read(@"image_file_path.jpg", options); 

            // Output all detected barcode values
            foreach (var barcode in detectedBarcodes)
            {
                Console.WriteLine(barcode.ToString());
            }
        }
    }
}
```

As demonstrated in the provided code example, the first step is to initialize the `BarcodeReaderOptions`. After initialization, it's possible to modify its properties as described previously. These adjustments are then passed as parameters within the `BarcodeReader.Read()` method, accompanied by the specified image file path. This approach ensures that the specified settings within `BarcodeReaderOptions` are actively applied during the barcode reading process from the image.


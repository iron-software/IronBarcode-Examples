# How to Generate Barcode Images in C# .NET Applications

***Based on <https://ironsoftware.com/tutorials/csharp-barcode-image-generator/>***


Learn how to swiftly create professional-grade barcode images in your .NET applications using IronBarcode. This guide will take you through the process from the most basic implementations to more advanced techniques that allow you to fully customize the appearance of your barcodes.

## Quickstart: Create and Save a Barcode Image Instantly

IronBarcode enables you to generate and save a barcode image swiftly with a single method call. Use the `CreateBarcode` method with your desired text, select a format and dimensions, and then save it using `SaveAsPng`. It's that simple, no complex configurations required.

```cs
:title=One-Line Barcode Generation
// Generating and saving a barcode image in a single line of code
IronBarCode.BarcodeWriter.CreateBarcode("Hello123", BarcodeWriterEncoding.Code128, 200, 100).SaveAsPng("quick-barcode.png");
```

## Setting Up Your Barcode Generator

Add IronBarcode to your project in just moments with the NuGet Package Manager. You can incorporate it via the Package Manager Console or manually download the DLL.

```shell
Install-Package BarCode
```

<div class="article-img tutorial-img">
<img src="https://ironsoftware.com/img/tutorials/csharp-barcode-image-generator/banner.jpg" alt="IronBarcode enhances .NET app developments with robust barcode functionalities and intuitive APIs">
<em>IronBarcode brings robust barcode generation features to .NET developers</em>
</div>

## Generating a Simple Barcode in C#

Your first barcode generation is straightforward—only two lines of code. Below, we create a typical Code128 barcode and save it as an image file.

```csharp
using IronBarCode;

// Initializing a barcode with specified content and format
GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode", BarcodeWriterEncoding.Code128);

// Saving the generated barcode as a PNG file
myBarcode.SaveAsPng("simpleBarcode.png");

// Optionally, open the generated image in the default viewer
System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("simpleBarcode.png") { UseShellExecute = true });
```

`BarcodeWriter.CreateBarcode()` is the method that kicks off your barcode generation journey, taking the data to encode and the desired format. IronBarcode supports a plethora of formats, including Code128, Code39, and QR codes, among others.

Once your barcode is generated, the `GeneratedBarcode` object provides various export options such as saving as different image formats or even exporting to PDF.

<center>
<img src="https://ironsoftware.com/img/tutorials/csharp-barcode-image-generator/render-a-simple-barcode.png" alt="Example of a Code128 barcode produced by IronBarcode in C#"  class="img-responsive add-shadow img-margin" style="max-width:50%">
<em>A simple Code128 barcode showcasing a URL, crafted with IronBarcode</em>
</center>

## Customizing Barcode Appearance

IronBarcode extends a vast array of customization settings to enhance your barcode's look significantly. These allow you to add text annotations, adjust colors, alter margins, and control various aesthetic aspects of your barcode.

```csharp
using IronBarCode;
using IronSoftware.Drawing;

// Establishing a QR code with customized styling settings
GeneratedBarcode myBarCode = BarcodeWriter.CreateBarcode(
    "https://ironsoftware.com/csharp/barcode", 
    BarcodeWriterEncoding.QRCode
);

// Embedding descriptive text above the barcode
myBarCode.AddAnnotationTextAboveBarcode("Product URL:");

// Showing the encoded data beneath the barcode
myBarCode.AddBarcodeValueTextBelowBarcode();

// Configuring uniform margins around the barcode
myBarCode.SetMargins(100);

// Personalizing the barcode color to purple
myBarCode.ChangeBarCodeColor(Color.Purple);

// Saving as an HTML file suitable for web use
myBarCode.SaveAsHtmlFile("styledBarCode.html");
```

The `GeneratedBarcode` class offers a rich toolkit for customizations:

- **Text Annotations**: Integrate labels or instructions around your barcode using `AddAnnotationTextAboveBarcode()` and `AddAnnotationTextBelowBarcode()`.
- **Data Display**: Present encoded data in an easily readable form with `AddBarcodeValueTextBelowBarcode()`.
- **Margins**: Adjust whitespace around the barcode using `SetMargins()` to guarantee optimal scanning results.
- **Color Adjustments**: Modify barcode colors via `ChangeBarCodeColor()`.

<center><img src="https://ironsoftware.com/img/tutorials/csharp-barcode-image-generator/advanced-barcode-creation.png" alt="A customized purple QR code adorned with annotation texts, produced using IronBarcode features" class="img-responsive add-shadow img-margin" style="max-width:33%">
<em>A customized QR code with unique color and annotations, generated using IronBarcode</em></center>

Explore the [Class documentation for `GeneratedBarcode`](https://ironsoftware.com/csharp/barcode/object-reference/api/IronBarCode.GeneratedBarcode.html) for a full overview of all customization techniques and properties.

## Streamlined Barcode Creation with One Line of Code

IronBarcode's API embraces a fluent design pattern, which encourages method chaining for more streamlined and readable code—ideal for applying multiple transformations to a barcode.

```csharp
using IronBarCode;
using IronSoftware.Drawing;

// Seamless generation, styling, and conversion of a barcode in one go
string URL = "https://ironsoftware.com/csharp/barcode";

// Initiating a PDF417 barcode with chained operations
AnyBitmap barcodeBitmap = BarcodeWriter
    .CreateBarcode(URL, BarcodeWriterEncoding.PDF417)  // Generating a barcode with specific type
    .ResizeTo(300, 200)                                // Assigning custom dimensions
    .SetMargins(10)                                    // Setting a margin
    .ToBitmap();                                       // Converting to bitmap format

// Adapting to System.Drawing.Bitmap for compatibility requirements
System.Drawing.Bitmap compatibleBitmap = barcodeBitmap;
```

This model enhances:

- **Readability**: Chain methods in a sequence that flows logically, resembling natural English.
- **Efficiency**: Minimizes the need for multiple variable declarations and intermediary steps.
- **Flexibility**: Easily adjust or append operations without revamping your code base.

<center>
<img src="https://ironsoftware.com/img/tutorials/csharp-barcode-image-generator/fluent-generated-barcode.png" alt="An intricately generated PDF417 barcode exemplifying IronBarcode's fluent API in action"  class="img-responsive add-shadow img-margin" style="max-width:40%">
<em>A sophisticated PDF417 barcode composed with the fluent API of IronBarcode</em>
</center>

## Supported Barcode Formats by IronBarcode

IronBarcode offers comprehensive support for numerous barcode formats through its `BarcodeWriterEncoding` enum:

**1D Barcodes**: such as Code128, UPCA, and EAN8.
**2D Barcodes**: like QRCode, DataMatrix.
**Specialized formats**: Including IntelligentMail and various GS1 standards.

Select the ideal format for your use case - QR codes are excellent for web URLs, whereas EAN13 is commonly used for retail products. Discover more about [selecting the appropriate barcode format](https://ironsoftware.com/csharp/barcode/get-started/supported-barcode-formats/) for your needs.

## Ensuring Barcode Readability

Ensuring your barcode remains scannable is crucial. IronBarcode integrates a verification mechanism to ascertain the usability of your barcodes post-transformation:

```csharp
// Code to generate and verify a barcode's readability
GeneratedBarcode verifiedBarcode = BarcodeWriter
    .CreateBarcode("TEST123", BarcodeWriterEncoding.Code128)
    .ResizeTo(200, 100)
    .ChangeBarCodeColor(Color.DarkBlue);

// Checking if the barcode is still readable after modifications
bool readabilityStatus = verifiedBarcode.Verify();
Console.WriteLine($"Barcode verification: {(readabilityStatus ? "PASS" : "FAIL")}");
```

The `Verify()` function evaluates if your barcode remains machine-readable after changes, which is vital when employing unusual colors or sizes.

## Expanding Your Barcode Generation Skills

Enhance your barcode generating skills by exploring additional resources:

### Source Code and Examples

Download the complete source code for this tutorial:

- [GitHub Repository](https://github.com/iron-software/Iron-Barcode-CSharp-Barcode-Image-Generator-Tutorial)
- [C# Source Code ZIP](https://ironsoftware.com/downloads/assets/tutorials/csharp-barcode-image-generator/Iron-Barcode-CSharp-Barcode-Image-Generator-Tutorial.zip) 

### Advanced Topics

- [Generate QR Codes with Logos](https://ironsoftware.com/csharp/barcode/examples/csharp-create-qr-code/) - Incorporate branding elements into your QR codes.
- [Barcode Styling Guide](https://ironsoftware.com/csharp/barcode/how-to/customize-barcode-style/) - Master the advanced techniques for customization.
- [Reading Barcodes from Images](https://ironsoftware.com/csharp/barcode/how-to/read-barcodes-from-images/) - Learn about barcode scanning capabilities.
- [Batch Barcode Generation](https://ironsoftware.com/csharp/barcode/how-to/create-barcode-images/) - Efficient methods for producing multiple barcodes.

### API Documentation

- [`BarcodeWriter` Class](https://ironsoftware.com/csharp/barcode/object-reference/api/IronBarCode.BarcodeWriter.html) - Complete method documentation.
- [`GeneratedBarcode` Class](https://ironsoftware.com/csharp/barcode/object-reference/api/IronBarCode.GeneratedBarcode.html) - All available customizations.
- [`BarcodeWriterEncoding` Enum](https://ironsoftware.com/csharp/barcode/object-reference/api/IronBarCode.BarcodeWriterEncoding.html) - Overview of supported formats.

## Ready to Generate Professional Barcodes in Your Application?

IronBarcode simplifies barcode creation while offering the flexibility needed for complex designs. From straightforward product codes to intricate 2D barcodes with advanced styling, IronBarcode manages it efficiently.

[Download IronBarcode now](download-modal) and start crafting barcodes swiftly. Need help selecting the appropriate license? Explore our [licensing options](https://ironsoftware.com/csharp/barcode/licensing/) or [request a free trial key](trial-license) to integrate IronBarcode seamlessly into your production environment.
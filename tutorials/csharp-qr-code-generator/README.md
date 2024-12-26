# C# QR Code Generator for .NET

***Based on <https://ironsoftware.com/tutorials/csharp-qr-code-generator/>***


<div class="alert alert-info iron-variant-1" role="alert">
	<a href="https://ironsoftware.com/csharp/qr/">IronQR</a> introduces a revolutionary .NET library for QR code functionalities by Iron Software. Utilize advanced machine learning algorithms to accurately decode QR codes from various angles with a success rate of nearly 100%. Easily generate and tailor new QR codes according to your needs! <a href="https://ironsoftware.com/csharp/qr/tutorials/csharp-qr-code-generator/">Explore IronQR</a> today!
</div>

If you're acquainted with the basics from the introductory tutorial on barcode creation, you'll know how straightforward it is to generate, style, and export barcodes as images using IronBarcode, often in a single line of code.

This tutorial delves deeper into QR codes, which are gaining widespread use in several sectors including retail and industrial settings.

## Install QR Code Generator Library in C#

First, we'll need to install the necessary library by retrieving the **BarCode** NuGet Package.

```shell
Install-Package BarCode
```

[Discover the package on NuGet](https://www.nuget.org/packages/BarCode/)

Alternatively, you can [download the IronBarCode.Dll](https://ironsoftware.com/csharp/barcode/packages/IronBarCode.zip) directly and include it in your project as a reference from your [.NET Barcode DLL].

### Importing Namespaces

Ensure your class files import IronBarCode alongside the usual system assemblies for this tutorial.

```cs
using IronBarCode;
using System;
using System.Drawing;
using System.Linq;
```

<br>

## Create a QR Code with 1 Line of Code

This example shows how to generate a straightforward barcode containing text, measuring 500 pixels in diameter, with medium error correction for better real-world resilience.

```cs
using IronBarCode;

// Generate a simple QR barcode image and save it as a PNG file
QRCodeWriter.CreateQrCode("hello world", 500, QRCodeWriter.QrErrorCorrectionLevel.Medium).SaveAsPng("MyQR.png");
```

## Adding a Logo

Many businesses now add logos to their QR codes. In the following example, see how simple it is to add a logo using the `QRCodeWriter.CreateQRCodeWithLogo` method.

```cs
using IronBarCode;
using IronSoftware.Drawing;

// Customize your QR code's appearance with color, logos, or branding elements:
QRCodeLogo qrCodeLogo = new QRCodeLogo("visual-studio-logo.png");
GeneratedBarcode myQRCodeWithLogo = QRCodeWriter.CreateQrCodeWithLogo("https://ironsoftware.com/", qrCodeLogo);
myQRCodeWithLogo.ResizeTo(500, 500).SetMargins(10).ChangeBarCodeColor(Color.DarkGreen);

// Logo is automatically resized and aligned on the QR grid
myQRCodeWithLogo.SaveAsPng("myQRWithLogo.png");
```

<div class="content-img-align-center">
	<img src="https://ironsoftware.com/img/tutorials/creating-qr-barcodes-in-dot-net/qr-code-with-logo.png" alt="C# Create QR Code With Logo Image "  class="img-responsive add-shadow img-margin" style="max-width:33%"  >
</div>

### Save as Image, PDF, or HTML

Additionally, you can export your stylized QR code as PDF or HTML files, which can be viewed in your browser as shown in the final lines of this snippet.

```cs
using IronBarCode;

// Customization using colors and logo images continues:
QRCodeLogo qrCodeLogo = new QRCodeLogo("visual-studio-logo.png");
GeneratedBarcode myQRCodeWithLogo = QRCodeWriter.CreateQrCodeWithLogo("https://ironsoftware.com/", qrCodeLogo);

myQRCodeWithLogo.ChangeBarCodeColor(System.Drawing.Color.DarkGreen);

// Save as PDF
myQRCodeWithLogo.SaveAsPdf("MyQRWithLogo.pdf");

// Save as HTML
myQRCodeWithLogo.SaveAsHtmlFile("MyQRWithLogo.html");
```

## Verifying QR Codes

Ensuring readability of stylized QR codes is essential. Here, we verify if a light blue QR code remains readable and adjust if necessary.

```cs
using IronBarCode;
using IronSoftware.Drawing;
using System;

// Check QR Code readability
QRCodeLogo qrCodeLogo = new QRCodeLogo("visual-studio-logo.png");
GeneratedBarcode MyVerifiedQR = QRCodeWriter.CreateQrCodeWithLogo("https://ironsoftware.com/", qrCodeLogo);

MyVerifiedQR.ChangeBarCodeColor(System.Drawing.Color.LightBlue);

if (!MyVerifiedQR.Verify())
{
    Console.WriteLine("\t LightBlue is not dark enough to be read accurately. Let's try DarkBlue");
    MyVerifiedQR.ChangeBarCodeColor(Color.DarkBlue);
}
MyVerifiedQR.SaveAsHtmlFile("MyVerifiedQR.html");

// Open the barcode HTML file in your default web browser
System.Diagnostics.Process.Start("MyVerifiedQR.html");
```

<div class="content-img-align-center">
	<img src="https://ironsoftware.com/img/tutorials/creating-qr-barcodes-in-dot-net/verified-qr-code.png" alt="C# read and write QR"  class="img-responsive add-shadow img-margin" style="max-width:33%"  >
</div>
 

## Reading and Writing Binary Data

QR codes excel at handling binary data, which is often more compact or suitable than text data. Here we demonstrate reading and writing binary content using IronBarcode.

```cs
using IronBarCode;
using System;
using System.Linq;

// Handling binary data as QR content
byte[] BinaryData = System.Text.Encoding.UTF8.GetBytes("https://ironsoftware.com/csharp/barcode/");

// Write QR with binary data
QRCodeWriter.CreateQrCode(BinaryData, 500).SaveAsImage("MyBinaryQR.png");

// Read QR with binary content and verify accuracy
var MyReturnedData = BarcodeReader.Read("MyBinaryQR.png").First();
if (BinaryData.SequenceEqual(MyReturnedData.BinaryValue))
{
    Console.WriteLine("\t Binary Data Read and Written Perfectly");
}
else
{
    throw new Exception("Corrupted Data");
}
```

<div class="content-img-align-center">
	<img src="https://ironsoftware.com/img/tutorials/creating-qr-barcodes-in-dot-net/binary-data-as-qr-code.png" alt="C# read and write binary data as a QR Code"  class="img-responsive add-shadow img-margin" style="max-width:33%"  >
</div>

## Further Steps

For a closer look at this tutorial or to explore more about QR codes in C#, consider forking our project on GitHub or downloading the source from our site.

### Source Code and More

* [GitHub Repository](https://github.com/iron-software/Iron-Barcode-Generating-QR-Codes-In-CSharp-Tutorial)
* [Downloadable Source Code](https://ironsoftware.com/downloads/assets/tutorials/creating-qr-barcodes-in-dot-net/Generating-QR-Codes-In-CSharp.zip)

### Additional Documentation

Discover detailed documentation on classes like `QRCodeWriter` and `BarcodeReader` in our comprehensive API Reference. Explore IronBarcode, a versatile [VB.NET Barcode Generator](https://ironsoftware.com/csharp/barcode/use-case/vb-net-barcode/), beyond what a single tutorial can cover.
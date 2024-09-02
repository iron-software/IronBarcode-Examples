# .NET QR Code Generation Using C#

<div class="alert alert-info iron-variant-1" role="alert">
	Iron Software's latest tool, <a href="https://ironsoftware.com/csharp/qr/">IronQR</a>, is a potent .NET library for QR code management. Utilize advanced machine learning algorithms to decode QR codes from any direction with near-perfect accuracy of 99.99%. Effortlessly create and tailor QR codes to your heart’s content! <a href="https://ironsoftware.com/csharp/qr/tutorials/csharp-qr-code-generator/">Explore IronQR today</a>!
</div>

If you've delved into our introductory tutorial on barcode creation, you already know how easy it is to craft, style, and export barcodes into images using IronBarcode, often in a single line of code.

This section delves deeper into QR codes, which are seeing augmented usage across industrial and retail sectors.

## Install the QR Code Generator Library for C#

First, let's install the necessary tool, the <strong>BarCode</strong> NuGet Package.

```shell
Install-Package BarCode
```

<a class="js-modal-open" href="https://www.nuget.org/packages/BarCode/" target="_blank" data-modal-id="trial-license-after-download">https://www.nuget.org/packages/BarCode/</a>

Alternatively, you can <a class="js-modal-open" href="https://ironsoftware.com/csharp/barcode/packages/IronBarCode.zip" data-modal-id="trial-license-after-download">download the IronBarCode DLL here</a>, and include it in your project directly from [.NET Barcode DLL].

### Including Necessary Namespaces

For this tutorial, include references to the IronBarCode library and some fundamental system namespaces in your class files.

```cs
using IronBarCode;
using System;
using System.Drawing;
using System.Linq;
```

## Generating a QR Code in a Single Line of Code

The following example illustrates how to generate a basic QR code containing simple text, set to a dimension of 500 pixels square, with a medium error correction level.

```cs
using IronBarCode;

// Generate a BarCode image and save it as PNG
QRCodeWriter.CreateQrCode("hello world", 500, QRCodeWriter.QrErrorCorrectionLevel.Medium).SaveAsPng("MyQR.png");
```

Error correction parameters define the readability of the QR code under various conditions. High levels of error correction generate larger, more complex QR codes.

<div class="content-img-align-center">
	<img src="https://ironsoftware.com/img/tutorials/creating-qr-barcodes-in-dot-net/csharp-rendered-qrcode.png" alt="C# Create QR Code Image" class="img-responsive add-shadow img-margin" style="max-width:33%">
</div>

## Enhancing QR Codes with Logos

In this next example, we incorporate a logo into the QR code—a frequent requirement in contemporary marketing. The `CreateQrCodeWithLogo` method simplifies this process.

```cs
using IronBarCode;
using IronSoftware.Drawing;

// Additional styling options including color and images:
QRCodeLogo qrCodeLogo = new QRCodeLogo("visual-studio-logo.png");
GeneratedBarcode myQRCodeWithLogo = QRCodeWriter.CreateQrCodeWithLogo("https://ironsoftware.com/", qrCodeLogo);
myQRCodeWithLogo.ResizeTo(500, 500).SetMargins(10).ChangeBarCodeColor(Color.DarkGreen);

// Automatically adjust logo size and position
myQRCodeWithLogo.SaveAsPng("myQRWithLogo.png");
```

This script applies the Visual Studio logo to the QR code, automatically resizing and aligning it within the grid to ensure readability.

<div class="content-img-align-center">
	<img src="https://ironsoftware.com/img/tutorials/creating-qr-barcodes-in-dot-net/qr-code-with-logo.png" alt="C# Create QR Code With Logo Image" class="img-responsive add-shadow img-margin" style="max-width:33%">
</div>

### Saving QR Codes as Different File Formats

The final steps involve saving the customized QR code as a PDF and opening it with a default PDF viewer for convenience.

```cs
using IronBarCode;

// Additional style settings:
QRCodeLogo qrCodeLogo = new QRCodeLogo("visual-studio-logo.png");
GeneratedBarcode myQRCodeWithLogo = QRCodeWriter.CreateQrCodeWithLogo("https://ironsoftware.com/", qrCodeLogo);

myQRCodeWithLogo.ChangeBarCodeColor(System.Drawing.Color.DarkGreen);

// Save as a PDF
myQRCodeWithLogo.SaveAsPdf("MyQRWithLogo.pdf");

// Also save as HTML
myQRCodeWithLogo.SaveAsHtmlFile("MyQRWithLogo.html");
```

## Verifying the Readability of QR Codes

It's crucial to verify that any stylistic modifications do not compromise the QR code’s usability.

```cs
using IronBarCode;
using IronSoftware.Drawing;
using System;

// Verify QR Code readability
QRCodeLogo qrCodeLogo = a new QRCodeLogo("visual-studio-logo.png");
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
	<img src="https://ironsoftware.com/img/tutorials/creating-qr-barcodes-in-dot-net/verified-qr-code.png" alt="C# read and write QR" class="img-responsive add-shadow img-margin" style="max-width:33%">
</div>

## Encoding and Decoding Binary Data with QR Codes

QR codes are highly efficient for handling binary data due to their space efficiency.

```cs
using IronBarCode;
using System;
using System.Linq;

// Handling Binary Data with QR Codes
byte[] BinaryData = System.Text.Encoding.UTF8.GetBytes("https://ironsoftware.com/csharp/barcode/");

// Encoding and saving binary data into QR Code
QRCodeWriter.CreateQrCode(BinaryData, 500).SaveAsImage("MyBinaryQR.png");

// Reading binary data from QR Code
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
	<img src="https://ironsoftware.com/img/tutorials/creating-qr-barcodes-in-dot-net/binary-data-as-qr-code.png" alt="C# read and write binary data as a QR Code" class="img-responsive add-shadow img-margin" style="max-width:33%">
</div>

To further your knowledge in this area, consider engaging with more detailed resources:

### Source Code and Documentation

* Explore this QR Code generator tutorial and download the source code:
  * [GitHub Repository](https://github.com/iron-software/Iron-Barcode-Generating-QR-Codes-In-CSharp-Tutorial)
  * [Source Code Zip](https://ironsoftware.com/downloads/assets/tutorials/creating-qr-barcodes-in-dot-net/Generating-QR-Codes-In-CSharp.zip)

* Additional Documentation on QR Code-related classes:
  * [QRCodeWriter Documentation](https://ironsoftware.com/csharp/barcode/object-reference/api/IronBarCode.QRCodeWriter.html)
  * [BarcodeReader Details](https://ironsoftware.com/csharp/barcode/object-reference/api/IronBarCode.BarcodeWriter.html)

Further explore the capabilities of IronBarcode, a powerful [VB.NET Barcode Generator](https://ironsoftware.com/csharp/barcode/use-case/vb-net-barcode/), through comprehensive study and experimentation.
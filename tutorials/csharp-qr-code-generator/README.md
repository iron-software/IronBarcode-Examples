# C# QR Code Generator for .NET

***Based on <https://ironsoftware.com/tutorials/csharp-qr-code-generator/>***


<div class="alert alert-info iron-variant-1" role="alert">
	<a href="https://ironsoftware.com/csharp/qr/">IronQR</a> is Iron Software's innovative .NET QR Code library that utilizes advanced machine learning techniques to accurately read QR codes from any orientation with 99.99% precision. Create and customize QR codes effortlessly! <a href="https://ironsoftware.com/csharp/qr/tutorials/csharp-qr-code-generator/">Start using IronQR</a> today!
</div>

Creating, styling, and exporting barcodes as images using IronBarcode can often be accomplished in just a simple line of code, as demonstrated in our introductory tutorial on Creating a Barcode.

This guide delves deeper into the increasingly popular QR codes, which are gaining traction in both industry and retail settings.

## Install QR Code Generator

Before beginning, it's necessary to install the **BarCode** NuGet Package.

```shell
Install-Package BarCode
```

<a class="js-modal-open" href="https://www.nuget.org/packages/BarCode/" target="_blank" data-modal-id="trial-license-after-download">https://www.nuget.org/packages/BarCode/</a>

Alternatively, you can download the <a class="js-modal-open" href="https://ironsoftware.com/csharp/barcode/packages/IronBarCode.zip" data-modal-id="trial-license-after-download">IronBarCode.Dll</a> and include it in your project as a reference.

### Importing NameSpaces

Make sure that your class files are referencing IronBarCode and the necessary system assemblies for this tutorial.

```cs
using IronBarCode;
using System;
using System.Drawing;
using System.Linq;
```

## Generate a QR Code with a Single Line of Code

Our initial example demonstrates generating a basic barcode with straightforward text, a 500-pixel square size, and medium error correction.

```cs
using IronBarCode;
using BarCode;
namespace ironbarcode.CsharpQrCodeGenerator
{
    public class Section1
    {
        public void Run()
        {
            // Create a simple QR code and save it as a PNG image
            QRCodeWriter.CreateQrCode("hello world", 500, QRCodeWriter.QrErrorCorrectionLevel.Medium).SaveAsPng("MyQR.png");
        }
    }
}
```

Error correction dictates the readability of a QR code under normal conditions. Increasing the error correction level results in a larger, more complex QR code.

<div class="content-img-align-center">
	<img src="https://ironsoftware.com/img/tutorials/creating-qr-barcodes-in-dot-net/csharp-rendered-qrcode.png" alt="C# Create QR Code Image " class="img-responsive add-shadow img-margin" style="max-width:33%">
</div>

## Adding a Logo

The following example addresses a common scenario: incorporating a logo within a QR code. This is done effortlessly with the `QRCodeWriter.CreateQRCodeWithLogo` method as shown below.

```cs
using IronSoftware.Drawing;
using BarCode;
namespace ironbarcode.CsharpQrCodeGenerator
{
    public class Section2
    {
        public void Run()
        {
            // Enhancing the QR with a logo and style:
            QRCodeLogo qrCodeLogo = new QRCodeLogo("visual-studio-logo.png");
            GeneratedBarcode myQRCodeWithLogo = QRCodeWriter.CreateQrCodeWithLogo("https://ironsoftware.com/", qrCodeLogo);
            myQRCodeWithLogo.ResizeTo(500, 500).SetMargins(10).ChangeBarCodeColor(Color.DarkGreen);
            
            // Logo is automatically adjusted to fit within the QR grid
            myQRCodeWithLogo.SaveAsPng("myQRWithLogo.png");
        }
    }
}
```

This example features the Visual Studio logo within the barcode. The logo is automatically resized to fit while keeping the code readable, and then the barcode color is adjusted to dark green, but the logo remains unaffected.

<div class="content-img-align-center">
	<img src="https://ironsoftware.com/img/tutorials/creating-qr-barcodes-in-dot-net/qr-code-with-logo.png" alt="C# Create QR Code With Logo Image " class="img-responsive add-shadow img-margin" style="max-width:33%">
</div>

### Save as Image, PDF or HTML

The generated QR code is then saved as a PDF and as an HTML file for direct access through your default PDF viewer.

```cs
using IronBarCode;
using BarCode;
namespace ironbarcode.CsharpQrCodeGenerator
{
    public class Section3
    {
        public void Run()
        {
            // Apply style and branding:
            QRCodeLogo qrCodeLogo = new QRCodeLogo("visual-studio-logo.png");
            GeneratedBarcode myQRCodeWithLogo = QRCodeWriter.CreateQrCodeWithLogo("https://ironsoftware.com/", qrCodeLogo);
            
            myQRCodeWithLogo.ChangeBarCodeColor(System.Drawing.Color.DarkGreen);
            
            // Export as PDF
            myQRCodeWithLogo.SaveAsPdf("MyQRWithLogo.pdf");
            
            // Also save as HTML for web display
            myQRCodeWithLogo.SaveAsHtmlFile("MyQRWithLogo.html");
        }
    }
}
```

## Validating QR Code Readability

Ensuring the QR code remains scannable despite aesthetic modifications is crucial. By using the `GeneratedBarcode.Verify()` method, we can evaluate whether the QR could still be effectively read.

```cs
using System;
using BarCode;
namespace ironbarcode.CsharpQrCodeGenerator
{
    public class Section4
    {
        public void Run()
        {
            // QR Code verification
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
        }
    }
}
```

<div class="content-img-align-center">
	<img src="https://ironsoftware.com/img/tutorials/creating-qr-barcodes-in-dot-net/verified-qr-code.png" alt="C# read and write QR" class="img-responsive add-shadow img-margin" style="max-width:33%">
</div>

## Handling Binary Data with QR Codes

QR codes are adept at managing binary data, as they can be more space-efficient compared to text. This capability sets IronBarcode apart from many other barcode libraries, as illustrated below where we encode, write, and read binary data within a QR code.

```cs
using System.Linq;
using BarCode;
namespace ironbarcode.CsharpQrCodeGenerator
{
    public defaultCenter
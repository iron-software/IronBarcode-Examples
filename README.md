![Nuget Version](https://img.shields.io/nuget/v/BarCode?color=informational&label=latest) ![Nuget Installs](https://img.shields.io/nuget/dt/BarCode?color=informational&label=installs&logo=nuget) ![Build Status](https://img.shields.io/badge/build-%20%E2%9C%93%20413%20tests%20passed%20(0%20failed)%20-107C10?logo=visualstudio) [![Windows Support](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=windows)](https://ironsoftware.com/csharp/barcode/docs/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topshield) [![macOS Support](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=apple)](https://ironsoftware.com/csharp/barcode/docs/questions/macos/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topshield) [![Linux Support](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=linux&logoColor=white)](https://ironsoftware.com/csharp/barcode/docs/questions/linux/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topshield) [![Docker Support](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=docker&logoColor=white)](https://ironsoftware.com/csharp/barcode/docs/questions/docker-linux/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topshield) ![AWS Support](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=amazonaws) [![Azure Support](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=microsoftazure)](https://ironsoftware.com/csharp/barcode/docs/questions/azure-support/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topshield) [![Live Support](https://img.shields.io/badge/Live%20Chat-8%20Engineers%20Active%20Today-purple?logo=googlechat&logoColor=white)](https://ironsoftware.com/csharp/barcode/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topshield#helpscout-support)

## Introducing IronBarcode - The Essential Library for Barcode & QR Code Operations in C# 

[![IronBarcode NuGet Trial Banner](https://raw.githubusercontent.com/iron-software/iron-nuget-assets/main/IronBarcode-readme/nuget-trial-banner.png)](https://ironsoftware.com/csharp/barcode/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topbanner#trial-license)

[Begin Your Journey](https://ironsoftware.com/csharp/barcode/docs/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=navigation) | [Explore Features](https://ironsoftware.com/csharp/barcode/features/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=navigation) | [View Code Samples](https://ironsoftware.com/csharp/barcode/examples/barcode-quickstart/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=navigation) | [Read About Licensing](https://ironsoftware.com/csharp/barcode/licensing/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=navigation) | [Start a Free Trial](https://ironsoftware.com/csharp/barcode/docs/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=navigation#trial-license)

IronBarcode by Iron Software is a comprehensive tool designed for .NET Developers enabling easy integration of barcode and QR code functionalities into their applications. This library simplifies the process, often requiring just a single line of code to either read or generate barcodes.

#### Highlights of IronBarcode include:

- Efficient recognition of multiple Barcodes and QR Codes from various image sources or PDF files.
- Advanced image processing to correct issues related to skew, orientation, noise, and more.
- Facilitates the creation of barcodes which can then be added to images or PDFs.
- Allows embedding of barcodes into HTML.
- Provides extensive customization options for barcode styling and text addition.
- Enhanced QR Code Creation that supports custom logos, colors, and precise alignment.

#### Supported environments of IronBarcode:

- **.NET 8**, .NET 7, .NET 6, .NET 5, Core 2x & 3x, Standard 2, and .NET Framework 4x
- Platforms including Windows, MacOS, Linux, Docker, Azure, and AWS

[![IronBarcode Compatibility Image](https://raw.githubusercontent.com/iron-software/iron-nuget-assets/main/IronBarcode-readme/cross-platform-compatibility.png)](https://ironsoftware.com/csharp/barcode/docs/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=crossplatformbanner)

Discover our [API documentation](https://ironsoftware.com/csharp/barcode/object-reference/api/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs) and [complete licensing details](https://ironsoftware.com/csharp/barcode/licensing/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs#trial-license) available on our website.

### Getting Started with IronBarcode

To install the IronBarcode NuGet package and begin integrating barcode capabilities in your applications, execute:

```bash
PM> Install-Package BarCode
```

Once the package is installed, add `using IronBarCode;` to the top of your C# file. Below is an example demonstrating basic barcode generation, reading, and saving functionalities:

```csharp
using IronBarCode;

// Create a barcode with ease:
var myBarcode = BarcodeWriter.CreateBarcode("12345", BarcodeWriterEncoding.EAN8);

// Reading a barcode from a file or PDF is straightforward with IronBarcode:
var resultFromFile = BarcodeReader.Read(@"file/barcode.png");
var resultFromPdf = BarcodeReader.ReadPdf(@"file/mydocument.pdf");

// Easily adjust size and save the created barcode:
myBarcode.ResizeTo(400, 100);
myBarcode.SaveAsImage("myBarcodeResized.jpeg");
```

### Comprehensive Features Overview

[![IronBarcode Feature Table](https://raw.githubusercontent.com/iron-software/iron-nuget-assets/main/IronBarcode-readme/features-table.png)](https://ironsoftware.com/csharp/barcode/features/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=featuresbanner)

IronBarcode supports a wide variety of barcode and QR standards such as Code 39/93/128, UPC A/E, EAN 8/13, and many more. Its reading engine is robust, equipped with features to manage imperfect scans efficiently. This includes a multithreading capability for fast, accurate multi-page document processing.

The writing API provides error-checking mechanisms to prevent encoding mistakes and allows detailed customizations such as resizing, adding borders, and incorporating text annotations.

##### Supported Barcode Standards:

- **QR & 2D Matrix:** QR (Styled QRs included), Aztec, Data Matrix, MaxiCode (Read only), USPS IM Barcode (Read only)
- **Modern Linear Barcodes:** Code 39, Code 128, PDF417, RSS14 (Read only), RSS Expanded (Read only)
- **Classic Linear Barcodes:** UPC-A, UPC-E, EAN-8, EAN-13, Codabar, ITF, MSI, Plessey (Write only)

##### Barcode Reading Capabilities:

- Reads from extensive image formats: JPG, PNG, GIF, TIFF, SVG, BMP, and more
- Offers numerous image filters to enhance the reading process
- Adjust settings for accuracy and performance, including specifying crop regions

##### Barcode Writing Features:

- Output options include images, HTML, and PDFs
- Supports encoding of various data types: text, URLs, IDs, and binary data
- Customizable error handling with detailed messaging

### Available Licensing & Support

For in-depth tutorials, coding examples, and more information, visit our [IronSoftware Barcode Library](https://ironsoftware.com/csharp/barcode/).

For direct support, contact us via email at developers@ironsoftware.com.

### Helpful Documentation Links

- [Code Samples](https://ironsoftware.com/csharp/barcode/examples/barcode-quickstart/)
- [API Documentation](https://ironsoftware.com/csharp/barcode/object-reference/api/)
- [Tutorials](https://ironsoftware.com/csharp/barcode/tutorials/csharp-barcode-image-generator/)
- [Licensing Information](https://ironsoftware.com/csharp/barcode/licensing/)
- [Live Chat Support](https://ironsoftware.com/csharp/barcode/#helpscout-support)

For detailed support from our development team, including assistance with commercial projects, please contact us at developers@ironsoftware.com.
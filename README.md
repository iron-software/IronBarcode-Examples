![Nuget](https://img.shields.io/nuget/v/BarCode?color=informational&label=latest)![Installs](https://img.shields.io/nuget/dt/BarCode?color=informational&label=installs&logo=nuget)![Passed](https://img.shields.io/badge/build-%20%E2%9C%93%20413%20tests%20passed%20(0%20failed)%20-107C10?logo=visualstudio)[![windows](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=windows)](https://ironsoftware.com/csharp/barcode/docs/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topshield)[![macOS](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=apple)](https://ironsoftware.com/csharp/barcode/docs/questions/macos/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topshield)[![linux](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=linux&logoColor=white)](https://ironsoftware.com/csharp/barcode/docs/questions/linux/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topshield)[![docker](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=docker&logoColor=white)](https://ironsoftware.com/csharp/barcode/docs/questions/docker-linux/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topshield)![aws](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=amazonaws)[![microsoftazure](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=microsoftazure)](https://ironsoftware.com/csharp/barcode/docs/questions/azure-support/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topshield)[![livechat](https://img.shields.io/badge/Live%20Chat-8%20Engineers%20Active%20Today-purple?logo=googlechat&logoColor=white)](https://ironsoftware.com/csharp/barcode/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topshield#helpscout-support)

## IronBarcode - The C# Barcode & QR Code Library

[![IronBarcode NuGet Trial Banner Image](https://raw.githubusercontent.com/iron-software/iron-nuget-assets/main/IronBarcode-readme/nuget-trial-banner.png)](https://ironsoftware.com/csharp/barcode/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topbanner#trial-license)

[Get Started](https://ironsoftware.com/csharp/barcode/docs/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=navigation) | [Features](https://ironsoftware.com/csharp/barcode/features/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=navigation) | [Code Examples](https://ironsoftware.com/csharp/barcode/examples/barcode-quickstart/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=navigation) | [Licensing](https://ironsoftware.com/csharp/barcode/licensing/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=navigation) | [Free Trial](https://ironsoftware.com/csharp/barcode/docs/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=navigation#trial-license)

IronBarcode is an essential toolkit provided by Iron Software for C# developers to efficiently work with Barcodes and QR Codes within .NET apps. It streamlines the process of barcode generation and decoding with merely a single line of code.

#### IronBarcode showcases robust capabilities for:

  * Detecting and decoding single or multiple barcodes and QR codes from various file formats such as images or PDFs.
  * Adjustments for image flaws like skew, orientation, noise, and resolution issues.
  * Generation and incorporation of barcodes into images or PDF files.
  * Embedding of barcodes within HTML pages.
  * Customization options for barcode styling and adding texts as annotations.
  * Creation of stylized QR codes, supporting logo integration, color variations, and precise alignments.

#### IronBarcode supports multiple platforms and frameworks:

  * **.NET 8**, .NET 7, .NET 6, .NET 5, Core 2x & 3x, Standard 2, and Framework 4x
  * Compatible with Windows, macOS, Linux, Docker, Azure, and AWS environments

[![IronBarcode Cross Platform Compatibility Support Image](https://raw.githubusercontent.com/iron-software/iron-nuget-assets/main/IronBarcode-readme/cross-platform-compatibility.png)](https://ironsoftware.com/csharp/barcode/docs/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=crossplatformbanner)

Find detailed [API documentation](https://ironsoftware.com/csharp/barcode/object-reference/api/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs) and [complete license information](https://ironsoftware.com/csharp/barcode/licensing/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs#trial-license) directly on our website.

### Utilizing IronBarcode

To integrate IronBarcode into your project, simply execute:

    PM> Install-Package BarCode
    

Post installation, incorporate `using IronBarCode` at the beginning of your C# files. Below is an example to demonstrate barcode generation, reading, and saving:

    using IronBarCode;
    
    // Generate a barcode with ease:
    var myBarcode = BarcodeWriter.CreateBarcode("12345", BarcodeWriterEncoding.EAN8);
    
    // Simple barcode reading:
    var resultFromFile = BarcodeReader.Read(@"file/barcode.png"); // From an image file
    var resultFromPdf = BarcodeReader.ReadPdf(@"file/mydocument.pdf"); // From a PDF document
    
    // Resizing and saving a created barcode:
    myBarcode.ResizeTo(400, 100);
    myBarcode.SaveAsImage("myBarcodeResized.jpeg");
    

### Features Overview

[![IronBarcode Features](https://raw.githubusercontent.com/iron-software/iron-nuget-assets/main/IronBarcode-readme/features-table.png)](https://ironsoftware.com/csharp/barcode/features/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=featuresbanner)

IronBarcode supports a broad range of Barcode and QR standards like code 39/93/128, UPC A/E, EAN 8/13, and others. The technology includes automatic image correction and detection for seamless reading from imperfect sources. Additional features include multithreading, cropping, and batch scanning for fast, precise document handling.

Barcode creation is sophisticated yet user-friendly, ensuring correct encodings and allowing extensive customization options like styling, resizing, and text annotation.

##### Supported Barcode Types:

  * QR & 2D Matrix: Various styles and types
  * Modern Linear Barcodes: Variety of standards
  * Older Linear Barcodes: Comprehensive support

##### Barcode Operation Modes:

  * Supported image formats for reading
  * Image enhancements for optimal reading
  * Extensive output options and detailed format settings

##### Barcode Creation Features:

  * Various document and data types support
  * Comprehensive error checking mechanisms
  * Flexible styling and customization options including QR logo additions

### Licensing & Customer Support

For practical examples, detailed guides, and extensive documentation visit [IronSoftware](https://ironsoftware.com/csharp/barcode/).

For more information and personalized assistance, please contact us at developers@ironsoftware.com. We provide robust licensing options and comprehensive support for all your deployment needs.

### Resource Links

  * [Code Examples](https://ironsoftware.com/csharp/barcode/examples/barcode-quickstart/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs)
  * [API Reference](https://ironsoftware.com/csharp/barcode/object-reference/api/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs)
  * [Tutorials](https://ironsoftware.com/csharp/barcode/tutorials/csharp-barcode-image-generator/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs)
  * [Licensing Details](https://ironsoftware.com/csharp/barcode/licensing/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs)
  * [Live Chat Support](https://ironsoftware.com/csharp/barcode/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs#helpscout-support)

For direct support, email us at developers@ironsoftware.com for expert help. We offer extensive licensing and comprehensive support for your commercial deployment projects.
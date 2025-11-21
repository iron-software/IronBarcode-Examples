# Exporting Barcodes as HTML Using IronBarcode

***Based on <https://ironsoftware.com/how-to/create-barcode-as-html/>***


IronBarcode enhances flexibility by allowing users to export the `GeneratedBarcode` in several formats, including HTML. This capability ensures that users can incorporate the output directly into their applications or websites without the need to store it on a disk. Let's explore how to utilize IronBarcode to export barcodes as HTML in various ways: as a Data URL, an HTML Tag, or an HTML File.

### Quick Guide: Creating and Exporting a Barcode as an HTML Tag in One Step

IronBarcode simplifies the generation and exportation of a barcode into an HTML tag through a concise and fluent line of code. This functionality is ideal for quick integrations, eliminating the need for handling external image files or assets.

```cs
:title=Instant HTML Barcode Generation
var htmlTag = BarcodeWriter.CreateBarcode("1234567890", BarcodeWriterEncoding.Code128).ToHtmlTag();
```

## Exporting a Barcode as a Data URL

A **Data URL** or **Data URI** is a unique type of Uniform Resource Identifier (URI) which integrates data directly within a URL, bypassing the need for external files. This method is efficient for embedding different data formats, such as text, images, or videos, directly into webpages. The following example illustrates how to transform a `GeneratedBarcode` into a Data URL.

```csharp
using IronBarCode;
using System;

GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.QRCode);
var dataUrl = myBarcode.ToDataUrl();
Console.WriteLine(dataUrl);
```

The code above demonstrates converting a `GeneratedBarcode` to a Data URL using `ToDataUrl()` attached to the barcode object created with `CreateBarcode()`.

## Exporting a Barcode as an HTML Tag

For direct HTML integration, the `ToHtmlTag()` method can convert the `GeneratedBarcode` into a usable HTML tag. This method bypasses the need for additional JavaScript, CSS, or external image links, facilitating seamless integration.

```csharp
using IronBarCode;
using System;

GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.QRCode);
var htmlTag = myBarcode.ToHtmlTag();
Console.WriteLine(htmlTag);
```

The example provides a straightforward approach to obtaining an HTML tag from a `GeneratedBarcode`.

## Saving a Barcode as an HTML File

Alternatively, IronBarcode allows saving the `GeneratedBarcode` as an HTML file. Utilizing `SaveAsHtmlFile()`, users can create standalone HTML documents containing the barcode.

```csharp
using IronBarCode;

GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.QRCode);
myBarcode.SaveAsHtmlFile("myBarcode.html");
```

The produced HTML file will encompass the barcode within standard HTML structure tags (`<html>`, `<head>`, `<body>`), thus creating a self-contained document. This method is particularly useful for creating downloadable or distributable HTML barcode representations.
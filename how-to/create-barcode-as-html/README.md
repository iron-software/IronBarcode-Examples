# Exporting Barcodes in HTML Format with IronBarcode

***Based on <https://ironsoftware.com/how-to/create-barcode-as-html/>***


---

## Introduction to IronBarcode

A top-tier API should offer enough flexibility for developers to integrate its outputs directly into their applications without necessitating file storage. IronBarcode excels in this by providing various methods for exporting a `GeneratedBarcode`, including converting these barcodes into HTML format.

Let's delve into the options available for converting a `GeneratedBarcode` into HTML, which include Data URL, HTML Tag, and HTML File formats, and explore each option in detail.

## Generating a Data URL from a Barcode

A Data URL, also known as a data URI, serves as a Uniform Resource Identifier that embeds data directly into a URL string. This data can be anything from text and images to audio and video formats. These URLs can be seamlessly integrated into web pages, appearing as external resources. Below, you'll find an example of how to transform a `GeneratedBarcode` into a Data URL.

```cs
using IronBarCode;
using System;

GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.QRCode);
var dataUrl = myBarcode.ToDataUrl();
Console.WriteLine(dataUrl);
```

In the code above, we begin by generating a barcode using `BarcodeWriter.CreateBarcode()`, which requires a barcode value and the desired barcode encoding. Then, by attaching `ToDataUrl()` to the `GeneratedBarcode`, we retrieve the Data URL, which can either be used directly within HTML or viewed using `Console.WriteLine()`. 

## Converting Barcodes to HTML Tags

To directly inject a barcode into an HTML document, you may use the `ToHtmlTag()` method, which outputs the `GeneratedBarcode` as a complete HTML image tag, free from any dependencies such as JavaScript, CSS, or external image files. The following code sample demonstrates this process:

```cs
using IronBarCode;
using System;

GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.QRCode);
var htmlTag = myBarcode.ToHtmlTag();
Console.WriteLine(htmlTag);
```

By invoking `ToHtmlTag()` on a `GeneratedBarcode`, the barcode is turned into an HTML tag, which includes src attributes pointing at the Data URL and specifies the image size. This tag can be directly embedded in larger HTML documents.

## Saving a Barcode as an HTML File

For those preferring to work with files, `GeneratedBarcode` can also be saved as an HTML file using the `SaveAsHtmlFile()` method. This is shown in the code snippet below:

```cs
using IronBarCode;

GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.QRCode);
myBarcode.SaveAsHtmlFile("myBarcode.html");
```

This method requires a pathname as an argument and saves the file to disk. The resulting HTML file encapsulates the barcode within HTML, HEAD, and BODY tags constructing a complete HTML document.

## Conclusion

IronBarcode provides versatility and robust options for using `GeneratedBarcode` in HTML formats, making it valuable for developers who integrate barcode functionalities into web pages and web applications. Each method discussed provides a straightforward solution for handling barcodes in different scenarios, maximizing flexibility and efficiency in development environments.
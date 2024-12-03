# How to Convert Barcodes to HTML Formats

***Based on <https://ironsoftware.com/how-to/create-barcode-as-html/>***


***

IronBarcode excels at offering multiple export options for its `GeneratedBarcode` object, ensuring it fits seamlessly into various applications without necessarily saving to disk. One of the notable capabilities is converting barcodes to HTML, which includes formats like **Data URL**, **HTML Tag**, and **HTML File**. Let’s explore each method.

## Convert Barcode to Data URL

A data URL, or data URI, embeds data directly into a URL string, acting like external resources within web pages. This could include various data formats such as text, and even images. Below is how you can convert a `GeneratedBarcode` into a **Data URL** using IronBarcode.

```cs
using System;
using BarCode;

namespace ironbarcode.CreateBarcodeAsHtml
{
    class ExampleDataUrl
    {
        public void Execute()
        {
            // Create a QR Code barcode
            GeneratedBarcode barcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.QRCode);
            string dataUrl = barcode.ToDataUrl();
            Console.WriteLine(dataUrl);  // Print out the data URL
        }
    }
}
```

This snippet begins by creating a QR Code using `CreateBarcode()`, specifying the type via `BarcodeEncoding`. The `ToDataUrl()` method then converts this barcode into a data URL, which can be easily embedded into web pages or used further in applications.

## Convert Barcodes to HTML Tag

Exporting a `GeneratedBarcode` as an HTML tag is straightforward with the `ToHtmlTag()` method. This generates a self-contained HTML image element, requiring no external scripts or dependencies.

```cs
using System;
using BarCode;

namespace ironbarcode.CreateBarcodeAsHtml
{
    class ExampleHtmlTag
    {
        public void Execute()
        {
            GeneratedBarcode barcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.QRCode);
            string htmlTag = barcode.ToHtmlTag();  // Generate HTML image tag
            Console.WriteLine(htmlTag);  // Output the HTML tag
        }
    }
}
```

In this example, the `ToHtmlTag()` method extends the `GeneratedBarcode`, crafting an HTML tag that embeds the barcode directly into HTML content using a data URL.

## Save Barcode as HTML File

Alternatively, IronBarcode allows saving the `GeneratedBarcode` directly as an HTML file using `SaveAsHtmlFile()` method.

```cs
using IronBarCode;
using BarCode;

namespace ironbarcode.CreateBarcodeAsHtml
{
    class ExampleHtmlFile
    {
        public void Execute()
        {
            GeneratedBarcode barcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.QRCode);
            barcode.SaveAsHtmlFile("myBarcode.html");  // Save the barcode as an HTML file
        }
    }
}
```

This method saves the barcode inside a fully structured HTML file, including the necessary HTML structure tags like `<html>`, `<head>`, and `<body>`. It's a convenient option if you need to distribute or display the barcode as a standalone HTML page.

IronBarcode's versatility in exporting barcodes as HTML formats is designed to enhance utility in web applications, providing developers with robust options for integrating barcodes into different digital environments.
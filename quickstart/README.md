# Barcodes & QR Codes in C# & VB.NET Applications

Leveraging Iron Barcode, a software library from Iron Software, allows for straightforward barcode reading and writing in C# and other .NET languages.

## Install IronBarcode

You can initiate your project by installing Iron Barcode either through the NuGet package or by [downloading the DLL](https://ironsoftware.com/csharp/barcode/packages/IronBarCode.zip) directly from our site. The relevant classes are accessible within the `IronBarcode` namespace.

Using the NuGet Package Manager in Visual Studio is the most straightforward method for installation:
The package to search for is named “Barcode”.

```shell
Install-Package BarCode
```

[Barcode Package on NuGet](https://www.nuget.org/packages/Barcode/)


## Reading Barcodes and QR Codes

To read a barcode using Iron Barcode, you only need a simple snippet of code.

```cs
using IronBarCode;

BarcodeResults results = BarcodeReader.Read("QuickStart.jpg");
if (results != null)
{
    foreach (BarcodeResult result in results)
    {
        Console.WriteLine(result.Text);
    }
}
```

For enhanced performance and accuracy during barcode reading, it's possible to specify the barcode type and a specific region on the image to scan.

```cs
using IronBarCode;

BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    ExpectMultipleBarcodes = false,
    ExpectBarcodeTypes = BarcodeEncoding.QRCode | BarcodeEncoding.Code128,
    CropArea = new System.Drawing.Rectangle(100, 200, 300, 400),
};

BarcodeResults result = BarcodeReader.Read("QuickStart.jpg", options);
if (result != null)
{
    Console.WriteLine(result.First().Text);
}
```

Scanning multiple barcodes in a single image is also feasible.

```cs
using IronBarCode;

BarcodeResults results = BarcodeReader.Read("MultipleBarcodes.png");

// Processing each result
foreach (BarcodeResult result in results)
{
    string value = result.Value;
    Bitmap img = result.BarcodeImage;
    BarcodeEncoding barcodeType = result.BarcodeType;
    byte[] binary = result.BinaryValue;
    Console.WriteLine(value);
}
```

Barcodes from pages of PDFs or multipage TIFF files can also be read efficiently.

```cs
using IronBarCode;

BarcodeResults pagedResults = BarcodeReader.Read("MultipleBarcodes.pdf");

// Iterate through each barcode found
foreach (BarcodeResult result in pagedResults)
{
    int pageNumber = result.PageNumber;
    string value = result.Value;
    Bitmap img = result.BarcodeImage;
    BarcodeEncoding barcodeType = result.BarcodeType;
    byte[] binary = result.BinaryValue;
    Console.WriteLine(value);
}
```

## Writing Barcodes

Creating barcodes with Iron Barcode involves using the `BarcodeWriter` class which simplifies the entire process. After specifying barcode format and value, an image of the barcode is generated.

```cs
using IronBarCode;

GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode", BarcodeEncoding.Code128);
myBarcode.SaveAsImage("myBarcode.png");
```

## Styling Barcodes

Iron Barcode permits extensive customization of barcodes. Using its generated barcode object and Fluent API, you can modify multiple visual parameters seamlessly within a single line of code.

```cs
using IronBarCode;

GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode", BarcodeEncoding.Code128);
myBarcode.AddAnnotationTextAboveBarcode("Product URL:");
myBarcode.AddBarcodeValueTextBelowBarcode();
myBarcode.SaveAsImage("myBarcode.png");
```

## Exporting Barcodes as HTML

Generated barcode objects can easily export HTML, incorporating various forms like HTML documents, tags, or a data URI.

```cs
using IronBarCode;

GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode", BarcodeEncoding.Code128);
// Specify several presentation options
myBarcode.AddAnnotationTextAboveBarcode("Product URL:");
myBarcode.AddBarcodeValueTextBelowBarcode();
myBarcode.SetMargins(100);
myBarcode.ChangeBarCodeColor(IronSoftware.Drawing.Color.Purple);

// Save in multiple formats
myBarcode.SaveAsPng("myBarcode.png");
```

## Generating QR Codes

For QR codes, `QRCodeWriter` offers additional features over the `BarcodeWriter` class, including setting QR error correction levels for balance between size and readability.

```cs
using IronBarCode;
using IronSoftware.Drawing;

QRCodeLogo logo = new QRCodeLogo("visual-studio-logo.png");
GeneratedBarcode myQRCodeWithLogo = QRCodeWriter.CreateQrCodeWithLogo("https://ironsoftware.com/csharp/barcode/", logo);
myQRCodeWithLogo.ChangeBarCodeColor(Color.DarkGreen).SaveAsPdf("MyQRWithLogo.pdf");
```

## Supported Barcode Formats

Iron Barcode robustly supports a wide range of common and advanced barcode types including:

- QR codes, branded QR codes
- Multiformat barcodes: Aztec, Data Matrix, CODE 93, CODE 128
- Specialized formats: RSS Expanded Databar, UPS MaxiCode
- Stacked linear barcodes and conventional numerical barcodes

## Why Opt for Iron Barcode?

Iron Barcode provides a developer-friendly API with a proven track record for reliability in reading and generating barcodes from real-world sources, not just ideal conditions. It includes robust adjustment capabilities for common scan distortions.

## Moving Forward

To delve deeper into utilizing Iron Barcode, explore our comprehensive tutorials, visit our GitHub, or consult the [.NET API Reference](https://ironsoftware.com/csharp/barcode/object-reference/) in MSDN format.
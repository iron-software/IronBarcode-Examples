# Barcoding and QR Code Integration in C# and VB.NET Applications

> Docs: [IronBarcode documentation](https://ironsoftware.com/csharp/barcode/docs/?utm_source=github)


The IronBarcode library reads and generates barcodes and QR codes from C# and the other .NET languages.

## Setting Up IronBarcode

Begin your integration by installing IronBarcode either from NuGet or directly via the [DLL download page](https://ironsoftware.com/csharp/barcode/?utm_source=github).

For Visual Studio users, incorporate IronBarcode using the NuGet Package Manager:

```shell
Install-Package BarCode
```

Or, you can install using the dotnet CLI command:

```shell
dotnet add package IronBarCode
```

## Decoding Barcodes and QR Codes

Decoding a barcode is straightforward and requires minimal code with IronBarcode.

```csharp
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

This one command identifies and decodes several barcode formats from a single document. It accepts JPEG, PNG, GIF, TIFF, and PDF input, and takes options for tuning decoding performance.

For quicker results, you might consider tweaking the `BarcodeReaderOptions` to suit your performance needs:

```csharp
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

You can further refine the scanning process by setting the `ScanMode` to a more basic level:

```csharp
using IronBarCode;

BarcodeResults results = BarcodeReader.Read("MultipleBarcodes.png");

foreach (BarcodeResult result in results)
{
    Console.WriteLine($"Detected barcode value: {result.Value}, type: {result.BarcodeType}");
}
```

Adjust the scanner to look for specific barcodes to reduce processing times and enhance efficiency:

```csharp
using IronBarCode;

BarcodeResults pagedResults = BarcodeReader.Read("MultipleBarcodes.pdf");

foreach (BarcodeResult result in pagedResults)
{
    Console.WriteLine($"Page {result.PageNumber}: {result.Value}");
}

BarcodeResults multiFrameResults = BarcodeReader.Read("Multiframe.tiff", new BarcodeReaderOptions
{
    Speed = ReadingSpeed.Detailed,
    ExpectMultipleBarcodes = true,
    ExpectBarcodeTypes = BarcodeEncoding.Code128,
});
```

## Generating Barcodes

Create barcodes easily using the `BarcodeWriter` class:

```csharp
using IronBarCode;

GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode", BarcodeEncoding.Code128);
myBarcode.SaveAsImage("myBarcode.png");
```

## Customizing Barcode Appearance

IronBarcode provides ample options for styling barcodes:

```csharp
using IronBarCode;

GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode", BarcodeEncoding.Code128);
myBarcode.AddAnnotationTextAboveBarcode("Product URL:");
myBarcode.AddBarcodeValueTextBelowBarcode();
myBarcode.SetMargins(100);
myBarcode.ChangeBarCodeColor(IronSoftware.Drawing.Color.Purple);

myBarcode.SaveAsPng("myBarcode.png");
```

## Barcode Export Options

IronBarcode supports exporting barcodes into various formats including HTML:

```csharp
using IronBarCode;

QRCodeWriter.CreateQrCode("https://ironsoftware.com", 500, QRCodeWriter.QrErrorCorrectionLevel.Medium).SaveAsPdf("MyQR.pdf");
```

## QR Code Creation

For QR codes, the `QRCodeWriter` allows more specific configurations like error correction levels:

```csharp
using IronBarCode;
using IronSoftware.Drawing;

QRCodeLogo qrCodeLogo = new QRCodeLogo("visual-studio-logo.png");
GeneratedBarcode myQRCodeWithLogo = QRCodeWriter.CreateQrCodeWithLogo("https://ironsoftware.com/csharp/barcode/", qrCodeLogo);
myQRCodeWithLogo.ChangeBarCodeColor(Color.DarkGreen).SaveAsPdf("MyQRWithLogo.pdf");
```

## Supported Barcode Standards

IronBarcode supports a multitude of barcode formats for reading and generating purposes including various 1D and 2D codes.

## Why Opt for IronBarcode?

IronBarcode provides a user-friendly API designed for high efficiency and precision in real-world applications. The `BarcodeWriter` handles data corrections automatically while supporting image correction technologies to ensure reliable barcode detection.

## Next Steps

Maximize your benefits from IronBarcode by exploring more tutorials in our documentation and visiting our [GitHub page](https://github.com/iron-software).
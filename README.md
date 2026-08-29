# IronBarcode.Examples

Runnable C# examples for [IronBarcode](https://ironsoftware.com/csharp/barcode/?utm_source=github), a .NET barcode and QR code library that reads and generates Code 39/93/128, UPC-A/E, EAN-8/13, PDF417, Aztec, Data Matrix, QR, Micro QR, and 20+ other symbologies from images, PDFs, and streams.

## Install

```bash
dotnet add package BarCode
```

## Quickstart

```csharp
using IronBarCode;

// Generate a barcode and save it
var barcode = BarcodeWriter.CreateBarcode("PKG-2026-88421", BarcodeEncoding.Code128);
barcode.ResizeTo(400, 100);
barcode.SaveAsPng("shipping-label.png");

// Read barcodes back from an image or PDF
var results = BarcodeReader.Read("shipping-label.png");
foreach (var result in results)
{
    Console.WriteLine($"{result.BarcodeType}: {result.Value}");
}
```

For QR codes, swap in `QRCodeWriter.CreateQrCode("https://example.com", 300)`, which supports error correction levels and `CreateQrCodeWithLogo` for branded codes. To read barcodes from PDFs, use `BarcodeReader.ReadPdf("document.pdf")`.

For production use, set a license key via `License.LicenseKey = "YOUR-KEY"`. Without one, generated barcodes include a watermark.

## What's in this repo

Each folder contains a self-contained .NET project you can open and run:

- `examples/` — focused snippets demonstrating individual features
- `get-started/` — minimal first projects covering installation and basic generation
- `how-to/` — task-oriented guides for specific barcode operations
- `quickstart/` — end-to-end project scaffolds
- `tutorials/` — longer walkthroughs combining multiple features

## Common tasks covered

- Generating linear barcodes: Code 39, Code 93, Code 128, EAN-8, EAN-13, UPC-A, UPC-E, ITF, Codabar, MSI Plessey
- Generating 2D barcodes: QR, Micro QR, Aztec, Data Matrix, PDF417, MaxiCode
- Reading barcodes from images, PDFs, bitmaps, and streams
- Multi-barcode scanning with automatic detection
- Image preprocessing: deskew, denoise, sharpen, threshold, contrast adjustment
- Fluent styling: colors, margins, annotation text, resizing
- QR code customization: error correction levels, embedded logos, color theming
- Export formats: PNG, JPEG, BMP, TIFF, GIF, PDF, HTML, SVG
- Reading with `BarcodeReaderOptions` for parallel multi-threaded scanning

## Platform support

.NET 8, 7, 6, 5, .NET Core, .NET Standard, and .NET Framework. Windows, macOS, Linux, Docker, Azure, and AWS. See the [installation docs](https://ironsoftware.com/csharp/barcode/docs/?utm_source=github) for environment-specific notes.

## Documentation and support

- Full documentation: [ironsoftware.com/csharp/barcode/docs](https://ironsoftware.com/csharp/barcode/docs/?utm_source=github)
- API reference: [ironsoftware.com/csharp/barcode/object-reference/api](https://ironsoftware.com/csharp/barcode/object-reference/api/?utm_source=github)
- Issues with these examples: file directly on this repository
- Product support: [support@ironsoftware.com](mailto:support@ironsoftware.com)

## About

This repository is maintained by [Iron Software](https://ironsoftware.com/?utm_source=github). IronBarcode is a commercial library — see [licensing](https://ironsoftware.com/csharp/barcode/licensing/?utm_source=github) for terms and trial details.
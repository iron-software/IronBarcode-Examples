# Stream Export of Barcodes Made Simple

***Based on <https://ironsoftware.com/how-to/export-barcode-as-stream/>***


Using IronBarcode’s functionality, one can effortlessly generate barcodes and transform them into stream formats. This includes utilizing the **MemoryStream** class, which facilitates the integration of the barcode within additional software applications without needing disk input/output. This method enhances system performance, reduces required storage space, ensures better data protection, and allows for flexible integration across multiple platforms.

## Fast Guide: Instant Barcode Streaming

Leverage IronBarcode to swiftly create a barcode and output it as a MemoryStream, all in a single line of code, completely bypassing the need for a file system.

```csharp
:title=Instant Barcode to Stream
var stream = BarcodeWriter.CreateBarcode("Quick123", BarcodeEncoding.Code128).ToStream();
```

## Example: Converting a Barcode into a Stream

After [creating a barcode](https://ironsoftware.com/csharp/barcode/how-to/create-barcode-images/) with the specified parameters, it's possible to use the `ToStream` method to serialize this barcode into a MemoryStream, which defaults to a PNG image format. This procedure is equally applicable to QR codes and is compatible with [custom stylings](https://ironsoftware.com/csharp/barcode/how-to/customize-qr-code-style/).

```csharp
using IronBarCode;
using System.IO;

// Create a standard barcode
GeneratedBarcode barcode = BarcodeWriter.CreateBarcode("IronBarcode1234", BarcodeEncoding.Code128);

// Stream conversion for barcode
Stream barcodeStream = barcode.ToStream();

// Instantiate QR code
GeneratedBarcode qrCode = QRCodeWriter.CreateQrCode("IronBarcode1234");

// Stream conversion for QR code
Stream qrCodeStream = qrCode.ToStream();
```

## Stream Various Image Formats from Barcodes

IronBarcode provides several methods to convert a barcode to a `MemoryStream` in different image formats, facilitating a straightforward selection process depending on the required format. Below are the formats and corresponding methods available:

- **BinaryStream** property: Produces a `System.IO.Stream` of the barcode as a Bitmap.
- `ToGifStream()`: Outputs a GIF format image.
- `ToJpegStream()`: Outputs a JPEG/JPG format image.
- `ToPdfStream()`: Outputs a PDF document format.
- `ToPngStream()`: Outputs a PNG format image.
- `ToStream()`: By default, outputs a PNG format image. With an argument from `AnyBitmap.ImageFormat`, other formats can be specified.
- `ToTiffStream()`: Outputs a TIFF format image.

Here, we demonstrate the usage of `ToJpegStream` and `ToStream` methods to create streams in JPEG format:

```csharp
using IronBarCode;
using IronSoftware.Drawing;
using System.IO;

// Create a linear barcode
GeneratedBarcode barcode = BarcodeWriter.CreateBarcode("IronBarcode1234", BarcodeEncoding.Code128);

// Convert barcode to JPEG format stream
Stream barcodeStream = barcode.ToStream(AnyBitmap.ImageFormat.Jpeg);

// Create a QR code
GeneratedBarcode qrCode = QRCodeWriter.CreateQrCode("IronBarcode1234");

// Convert QR code to JPEG format stream
Stream qrCodeStream = qrCode.ToJpegStream();
```

To summarize, IronBarcode streamlines the process of barcode creation and conversion into a **MemoryStream**, offering a highly efficient and refined method for developers.
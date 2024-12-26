# How to Convert Barcodes to Stream Data

***Based on <https://ironsoftware.com/how-to/export-barcode-as-stream/>***


IronBarcode simplifies the process of generating barcodes and then translating them into streams, particularly using **MemoryStream**, which integrates smoothly within your applications. This avoids the need for disk operations, boosts application performance, minimizes storage requirements, heightens data security, and allows easier integration across different platforms and applications.

### Initialize with IronBarcode

--------

## Example: Converting Barcode to Stream

After you have [generated a barcode](https://ironsoftware.com/csharp/barcode/how-to/create-barcode-images/) with your chosen value, the `ToStream` method can be applied to transform this barcode into a MemoryStream. By default, it uses the PNG format. This feature is also fully supportive of QR codes, including scenarios after [implementing personalized styles](https://ironsoftware.com/csharp/barcode/how-to/customize-qr-code-style/).

```cs
using IronBarCode;
using System.IO;

// Generate a one-dimensional barcode
GeneratedBarcode barcode = BarcodeWriter.CreateBarcode("IronBarcode1234", BarcodeEncoding.Code128);

// Stream conversion for barcode
Stream barcodeStream = barcode.ToStream();

// Generate a QR code
GeneratedBarcode qrCode = QRCodeWriter.CreateQrCode("IronBarcode1234");

// Stream conversion for QR code
Stream qrCodeStream = qrCode.ToStream();
```

## Stream Output for Barcodes in Multiple Image Formats

Various methods are provided by IronBarcode to convert barcode images into streams of different formats:
 
- **BinaryStream** property: Produces a `System.IO.Stream` for the barcode rendered as a bitmap.
- `ToGifStream()`: Outputs a GIF formatted image stream.
- `ToJpegStream()`: Converts to a JPEG/JPG image stream.
- `ToPdfStream()`: Transforms into a PDF document stream.
- `ToPngStream()`: Creates a PNG image stream.
- `ToStream()`: By default, outputs a PNG image stream, but permits specifying the desired format using the **AnyBitmap.ImageFormat** enum.
- `ToTiffStream()`: Generates a TIFF image stream.

The following example demonstrates using `ToJpegStream` and `ToStream` to create streams in JPEG format:

```cs
using IronBarCode;
using IronSoftware.Drawing;
using System.IO;

// Generate a one-dimensional barcode
GeneratedBarcode barcode = BarcodeWriter.CreateBarcode("IronBarcode1234", BarcodeEncoding.Code128);

// Convert the barcode to a JPEG stream
Stream barcodeStream = barcode.ToStream(AnyBitmap.ImageFormat.Jpeg);

// Generate a QR code
GeneratedBarcode qrCode = QRCodeWriter.CreateQrCode("IronBarcode1234");

// Convert the QR code to a JPEG stream
Stream qrCodeStream = qrCode.ToJpegStream();
```

To wrap up, IronBarcode effortlessly facilitates the creation and export of barcodes into **MemoryStream** objects, enabling you to easily embed barcode streaming capabilities into your various applications.
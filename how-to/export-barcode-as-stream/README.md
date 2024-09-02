# Streamlining Barcode Export to MemoryStreams

IronBarcode enhances application performance by enabling barcodes to be created and immediately converted to streams, notably using **MemoryStream**. This functionality not only avoids disk I/O tasks but also enhances performance, minimizes storage needs, bolsters data security, and allows for a versatile integration across diverse applications.

## Example: Streaming Barcode Export

After [creating a barcode](https://ironsoftware.com/csharp/barcode/how-to/create-barcode-images/) with the intended content, the `ToStream` method can be employed to transfer the barcode into a MemoryStream, defaulting to a PNG image format. This capability extends flawlessly to QR codes, especially when [incorporating custom designs](https://ironsoftware.com/csharp/barcode/how-to/customize-qr-code-style/).

```cs
using IronBarCode;
using System.IO;

// Generate a one-dimensional barcode
GeneratedBarcode barcode = BarcodeWriter.CreateBarcode("IronBarcode1234", BarcodeEncoding.Code128);

// Stream the barcode
Stream barcodeStream = barcode.ToStream();

// Generate a QR code
GeneratedBarcode qrCode = QRCodeWriter.CreateQrCode("IronBarcode1234");

// Stream the QR code
Stream qrCodeStream = qrCode.ToStream();
```

## Variable Image Formats for Streaming Barcodes

IronBarcode provides several methods to stream a barcode into a `MemoryStream`, depending on the required image format. Here are the available options:

- **BinaryStream** property: Returns a System.IO.Stream containing the barcode image as a Bitmap.
- `ToGifStream()`: Allocates a GIF format stream.
- `ToJpegStream()`: Allocates a JPEG/JPG format stream.
- `ToPdfStream()`: Allocates a PDF document stream.
- `ToPngStream()`: Allocates a PNG image stream.
- `ToStream()`: By default, allocates a PNG image stream, but any format can be specified using **AnyBitmap.ImageFormat** enumeration.
- `ToTiffStream()`: Allocates a TIFF image stream.

Let's look at how the `ToJpegStream` and `ToStream` functions are used to produce JPEG format streams with the following code:

```cs
using IronBarCode;
using IronSoftware.Drawing;
using System.IO;

// Generate a one-dimensional barcode
GeneratedBarcode barcode = BarcodeWriter.CreateBarcode("IronBarcode1234", BarcodeEncoding.Code128);

// Stream the barcode in JPEG format
Stream barcodeStream = barcode.ToStream(AnyBitmap.ImageFormat.Jpeg);

// Generate a QR code
GeneratedBarcode qrCode = QRCodeWriter.CreateQrCode("IronBarcode1234");

// Stream the QR code in JPEG format
Stream qrCodeStream = qrCode.ToJpegStream();
```

In summary, IronBarcode provides an efficient and straightforward approach to creating and exporting barcodes directly to a **MemoryStream**, making it exceptionally convenient and adaptable for developers.
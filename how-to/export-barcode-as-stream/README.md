# Exporting Barcodes Directly to Memory Streams

***Based on <https://ironsoftware.com/how-to/export-barcode-as-stream/>***


IronBarcode facilitates the generation and subsequent conversion of barcodes directly into streams, leveraging **MemoryStream** for immediate use within your programs. This feature bypasses the need for disk-based storage, thus accelerating performance, decreasing storage demands, augmenting data security, and offering a versatile workflow that easily integrates with a variety of applications.

## Example: Converting a Barcode to a Stream

After [generating a barcode](https://ironsoftware.com/csharp/barcode/how-to/create-barcode-images/) with your specified value, you can use the `ToStream` method to change the barcode into a MemoryStream, typically in a PNG format. This approach is fully compatible with QR codes, even when [applying custom styles](https://ironsoftware.com/csharp/barcode/how-to/customize-qr-code-style/).

```cs
using System.IO;
using BarCode;
namespace ironbarcode.ExportBarcodeAsStream
{
    public class Section1
    {
        public void Run()
        {
            // Generating a one-dimensional barcode
            GeneratedBarcode barcode = BarcodeWriter.CreateBarcode("IronBarcode1234", BarcodeEncoding.Code128);
            
            // Streaming the barcode as a PNG
            Stream barcodeStream = barcode.ToStream();
            
            // Generating a QR code
            GeneratedBarcode qrCode = QRCodeWriter.CreateQrCode("IronSoftware QR");
            
            // Streaming the QR code
            Stream qrCodeStream = qrCode.ToStream();
        }
    }
}
```

## Techniques for Exporting Barcodes in Diverse Image Formats

Users have several options to export their barcode images to `MemoryStream` using different image formats. Below is a compilation of methods available:

- **BinaryStream** property: Provides a System.IO.Stream of the barcode rendered as a Bitmap.
- `ToGifStream()`: Exports the barcode as a GIF image.
- `ToJpegStream()`: Converts to a JPEG/JPG image format.
- `ToPdfStream()`: Generates a PDF document.
- `ToPngStream()`: Outputs as a PNG image.
- `ToStream()`: Defaults to PNG, but accepts **AnyBitmap.ImageFormat** enum to specify another format.
- `ToTiffStream()`: Produces a TIFF image format.

Let's demonstrate using the `ToJpegStream` and `ToStream` methods to obtain streams in JPEG format with the following code:

```cs
using System.IO;
using BarCode;
namespace ironbarcode.ExportBarcodeAsStream
{
    public class Section2
    {
        public void Run()
        {
            // Generating a linear barcode
            GeneratedBarcode barcode = BarcodeWriter.CreateBarcode("SampleBarcode128", BarcodeEncoding.Code128);
            
            // Convert barcode to a JPEG stream
            Stream barcodeStream = barcode.ToStream(AnyBitmap.ImageFormat.Jpeg);
            
            // Generating a QR code
            GeneratedBarcode qrCode = QRCodeWriter.CreateQrCode("Sample QR Code");
            
            // Stream the QR code in JPEG format
            Stream qrCodeStream = qrCode.ToJpegStream();
        }
    }
}
```

In conclusion, IronBarcode simplifies the process of creating and exporting barcodes to a **MemoryStream**, offering a direct and efficient method for developers.
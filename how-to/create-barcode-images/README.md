# Generating Barcode Images using IronBarcode

## Creating One-Dimensional Barcodes and Exporting Them as Images

IronBarcode is more than just a tool for reading barcodes; it excels in generating barcode images efficiently. To create a barcode, employ the `CreateBarcode()` function from the `BarcodeWriter` class. This function allows you to define the barcode's value, type, width, and height. To save the image locally, chain the `SaveAs()` method to the output of `CreateBarcode()`. Let's explore this process before we jump into an example.

### Specifications for Barcode Value

The `BarcodeWriter.CreateBarcode()` method can handle various types of inputs such as `byte[]`, `MemoryStream`, and `System.String`. This flexibility ensures that IronBarcode can seamlessly integrate into your applications, accommodating any input format without needing conversions.

### Barcode Types

IronBarcode supports a multitude of barcode types, each with their unique characteristics and applications. It’s crucial to select the appropriate barcode type based on the value it needs to encode—whether it's numeric, alphabetic, or alphanumeric. The options are accessible through the `BarcodeEncoding` class. For detailed information on the available barcode types, refer to the [API Reference](https://ironsoftware.com/csharp/barcode/object-reference/api/IronBarCode.BarcodeEncoding.html?q=BarcodeEncoding).

### Dimension Specifications

Through the `BarcodeWriter.CreateBarcode()` method, you can set your desired barcode dimensions (width and height) in pixels, with a default setting of 250 pixels each.

### Saving Generated Barcodes

Once a barcode is generated, it's encapsulated in a `GeneratedBarcode` object. Here are some methods you can use to export this object to various image formats:

- `SaveAsGif()`: Saves the barcode as a GIF image.
- `SaveAsImage()`: Generic image saving method where the format is specified within the file path.
- `SaveAsJpeg()`: Exports the barcode as a JPEG file.
- `SaveAsPng()`: Saves as a PNG file.
- `SaveAsTiff()`: Outputs a TIFF image file.
- `SaveAsWindowsBitmap()`: Generates a BMP image file.

### Example: Creating a One-Dimensional Barcode

Here's how you can create a one-dimensional barcode and save it as a JPEG image:

```cs
using IronBarCode;

BarcodeWriter.CreateBarcode("IronBarcode123", BarcodeEncoding.Code128, 200, 100).SaveAsJpeg("OneDBarcode.jpeg");
```

![One dimensional barcode example](https://ironsoftware.com/static-assets/barcode/how-to/create-barcode-images/OneDBarcode.jpeg)

## Generating QR Codes and Storing Them as Images

QR codes, a highly versatile and customizable 2-dimensional barcode type, are fully supported by IronBarcode. Unlike one-dimensional barcodes, QR code generation in IronBarcode requires calling `CreateQrCode()` from the `QRCodeWriter` class, which supports several parameters to tailor the QR code to specific needs.

### Parameters for QR Codes

Like the `BarcodeWriter.CreateBarcode()` method, `QRCodeWriter.CreateQrCode()` can accept inputs such as `byte[]`, `MemoryStream`, and `System.String`. 

### QR Code Dimensions

Users can directly input the size of the QR in pixels. The default size is 500 pixels.

### Error Correction Capability

`QRErrorCorrectionLevel` helps in defining the robustness of the QR code against damages and occlusions, with four levels of error correction:

- **Highest**: 30% of the QR code is dedicated to error correction, allowing for logo embedding.
- **High**: 25% error correction, slightly simpler than the highest level.
- **Medium**: Offers 15% error correction, trading off complexity for quicker generation.
- **Low**: Minimal error correction at 7%, resulting in the simplest form of QR codes.

### QR Code Versions

The `QrVersion` parameter allows defining the version of the QR code from 1 to 40, affecting the complexity and data capacity. Setting it to 0 lets IronBarcode choose the best version based on the data size. For more insights, visit [QR Version](https://www.qrcode.com/en/about/version.html).

### Generating and Saving a QR Code

Below is an example of generating a medium complexity QR code and saving it as a JPEG image:

```cs
using IronBarCode;

QRCodeWriter.CreateQrCode("IronBarcode1234", 250, QRCodeWriter.QrErrorCorrectionLevel.Medium, QrVersion: 0).SaveAsJpeg("QRMedium.jpeg");
```

![Medium correction level QR Code](https://ironsoftware.com/static-assets/barcode/how-to/create-barcode-images/QRMedium.jpeg)

This code snippet illustrates saving a QR code with an alphanumeric value, a size of 250 pixels, medium error correction, and automatically selected version, emphasizing IronBarcode's adaptability and user-friendliness in handling diverse barcode generation needs.
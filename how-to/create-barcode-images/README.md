# How to Create Barcode Images

***Based on <https://ironsoftware.com/how-to/create-barcode-images/>***


## Generating One-Dimensional Barcodes and Saving Them as Images

IronBarcode offers robust capabilities not only for decoding but also for generating barcodes. With just a few lines of code, you can easily create and save barcode images. This involves using the `CreateBarcode()` method from the `BarcodeWriter` class, which allows you to specify the barcode's value, type, width, and height. After configuring these parameters, you simply chain a `SaveAs()` method to save the barcode image to the local disk. Let's delve into the details and then walk through an example implementation.

### Specifying the Barcode Value

The `BarcodeWriter.CreateBarcode()` method is versatile, accepting various data types for the barcode value, including `byte[] array`, `MemoryStream`, and `System.String`. This flexibility makes IronBarcode a great choice for seamless integration into different applications, as the data can be utilized directly without needing conversion.

### Choosing Barcode Encoding Types

IronBarcode supports an extensive array of barcode encoding types, each with unique characteristics and applications. It is crucial to select an encoding type that aligns with your data requirements as certain types are limited to numeric, alphabetical, or alphanumeric values. You can consult the `BarcodeEncoding` class to explore available encoding options. For comprehensive details, refer to the [API Reference](https://ironsoftware.com/csharp/barcode/object-reference/api/IronBarCode.BarcodeEncoding.html?q=BarcodeEncoding).

### Setting Width and Height

When using the `BarcodeWriter.CreateBarcode()` method, you can specify the dimensions of the resulting barcode in pixels, with `250 px` being the default setting for both width and height.

### Saving Barcodes as Images

The `GeneratedBarcode` object, resultant of the `CreateBarcode()` method, can be persisted as an image file. Below are methods that facilitate saving the barcode in various image formats:

- `SaveAsGif()`: Saves the barcode as a GIF image.
- `SaveAsImage()`: General method for saving the barcode image, requiring the file format specification.
- `SaveAsJpeg()`: Saves the barcode as a JPEG image.
- `SaveAsPng()`: Saves the barcode as a PNG image.
- `SaveAsTiff()`: Saves the barcode as a TIFF image.
- `SaveAsWindowsBitmap()`: Saves the barcode as a BMP image.

### Example: Creating and Saving a Barcode

Here, we demonstrate how to generate a one-dimensional barcode and save it as a JPEG image file:

```cs
using IronBarCode;
using BarCode;

namespace ironbarcode.CreateBarcodeImages
{
    public class Section1
    {
        public void Run()
        {
            var barcode = BarcodeWriter.CreateBarcode("IronBarcode123", BarcodeEncoding.Code128, 200, 100);
            barcode.SaveAsJpeg("OneDBarcode.jpeg");
        }
    }
}
```

![One dimensional barcode from snippet](https://ironsoftware.com/static-assets/barcode/how-to/create-barcode-images/OneDBarcode.jpeg)

## Generating and Saving QR Code Images

QR codes, a type of two-dimensional barcode, are widely used due to their storage capacity and versatility. IronBarcode provides a specialized `CreateQrCode()` method within the `QRCodeWriter` class for creating QR codes. This method requires four parameters: the barcode value, QR code size, error correction level, and QR version.

### QR Code Value and Size

Values for QR codes can be numeric, alphabetical, or alphanumeric, and are inputted directly into the `CreateQrCode()` method as a `byte[]`, `MemoryStream`, or `System.String`. The size of the QR code is adjustable and is specified in pixels, with `500 px` being the default.

### QR Error Correction Level

The `QRErrorCorrectionLevel` provides four options, influencing the QR code's complexity and fault tolerance:

- **Highest**: 30% error correction, suitable for QR codes with embedded images or logos.
- **High**: 25% error correction.
- **Medium**: 15% error correction, offering a balance between complexity and speed.
- **Low**: 7% error correction, the simplest form with the highest risk of errors.

### QR Version

The QR Version dictates the symbol version of the QR code, ranging from 1 to 40. Higher versions accommodate more data but are more complex. Setting the QR version to 0 allows IronBarcode to auto-select the best version based on the data to be encoded. More information on QR versions can be found [here](https://www.qrcode.com/en/about/version.html).

### Example: Creating a QR Code Image

This snippet illustrates how to create a QR code with medium error correction and automatically determine the most suitable QR version, subsequently saving it as a JPEG image:

```cs
using IronBarCode;
using BarCode;

namespace ironbarcode.CreateBarcodeImages
{
    public class Section2
    {
        public void Run()
        {
            var qrCode = QRCodeWriter.CreateQrCode("IronBarcode1234", 250, QRCodeWriter.QrErrorCorrectionLevel.Medium, qrVersion: 0);
            qrCode.SaveAsJpeg("QRMedium.jpeg");
        }
    }
}
```

![QR Code with medium correction level](https://ironsoftware.com/static-assets/barcode/how-to/create-barcode-images/QRMedium.jpeg)

This example used an alphanumeric value for the QR code and specified the error correction to be medium, allowing IronBarcode to choose the appropriate QR version for the given data.
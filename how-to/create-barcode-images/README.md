# How to Create Barcode Images

***Based on <https://ironsoftware.com/how-to/create-barcode-images/>***


---

### Introduction to IronBarcode

## Generate One-Dimensional Barcodes and Store as Images

IronBarcode offers robust capabilities beyond just scanning barcodes — it allows users to efficiently generate and export barcode images using minimal code. Begin by invoking the `CreateBarcode()` method from the `BarcodeWriter` class, specifying the barcode's value, type, width, and height. Then, chain the `SaveAs()` method to store the image locally. Below, we’ll first explore these functionalities before diving into specific code implementations.

### Barcode Value

The function `BarcodeWriter.CreateBarcode()` supports several types of input values including `byte[] array`, `MemoryStream`, and `System.String`. This flexibility facilitates easy integration of IronBarcode within various applications, as it can handle different value types directly.

### Barcode Encoding Types

IronBarcode supports an extensive array of barcode formats, each with distinct characteristics and applications. It’s imperative to select an appropriate barcode type based on your specific requirements, as different types support numerical, alphabetical, or alphanumeric values. The available barcode formats are accessed via the `BarcodeEncoding` class. For further details on the supported barcode types in IronBarcode, you can refer to the [API Reference](https://ironsoftware.com/csharp/barcode/object-reference/api/IronBarCode.BarcodeEncoding.html?q=BarcodeEncoding).

### Width and Height of Barcode

With `BarcodeWriter.CreateBarcode()`, users can define their barcode's dimensions by passing the desired width and height in pixels. Please note that the default values for these dimensions are set at `250 px`.

### Saving Barcodes as Images

Upon generation, barcodes are represented as objects of the `GeneratedBarcode` class. These objects can be saved as different image formats depending on your needs:

- `SaveAsGif()`: Saves as a GIF image.
- `SaveAsImage()`: General method for saving as an image, requires specifying the file format.
- `SaveAsJpeg()`: Saves as a JPEG image.
- `SaveAsPng()`: Saves as a PNG image.
- `SaveAsTiff()`: Saves as a TIFF image.
- `SaveAsWindowsBitmap()`: Saves as a BMP image.

### Example of Creating a One-Dimensional Barcode

This example demonstrates generating a one-dimensional barcode and saving it as a JPEG.

```cs
using IronBarCode;

BarcodeWriter.CreateBarcode("IronBarcode123", BarcodeEncoding.Code128, 200, 100).SaveAsJpeg("OneDBarcode.jpeg");
```

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/barcode/how-to/create-barcode-images/OneDBarcode.jpeg" alt="One dimensional barcode from snippet" class="img-responsive add-shadow">
    </div>
</div>

## Generating and Saving QR Codes as Images 

QR codes are a popular 2-dimensional barcode type, known for their flexibility and customization options. In IronBarcode, QR codes are created differently due to their complex necessities. The `CreateQrCode()` method from the `QRCodeWriter` class handles QR code creation, accepting parameters for the barcode value, size, error correction level, and version. Let’s delve into each of these parameters.

### QR Code Value

Similar to `BarcodeWriter.CreateBarcode()`, `QRCodeWriter.CreateQrCode()` accepts values in several formats: `byte[] array`, `MemoryStream`, and `System.String`. This allows for diverse input options.

### QR Code Size

The size of the QR code can be specifically set in pixels through the method, with `500 px` as the default size.

### QR Error Correction Level

The `QRErrorCorrectionLevel` property of the `QRCodeWriter` class offers four levels of error correction, enhancing the QR code's robustness against damage and obstructions. Below are the levels and their corresponding error correction percentages:

- **Highest**: 30% error correction, suitable for QR codes that may include logos.
- **High**: 25% error correction.
- **Medium**: 15% error correction.
- **Low**: 7% error correction, the simplest form.

### QR Version

This parameter scales from 1 to 40, determining the complexity and data capacity of the QR code. It's important to select an appropriate version based on the data amount to avoid encoding issues. Setting this to `0` lets IronBarcode determine the optimal version automatically. More details can be found [here](https://www.qrcode.com/en/about/version.html).

### Creating and Saving a QR Code Image

Here’s how you can create a QR code and save it:

```cs
using IronBarCode;

QRCodeWriter.CreateQrCode("IronBarcode1234", 250, QRCodeWriter.QrErrorCorrectionLevel.Medium, qrVersion: 0).SaveAsJpeg("QRMedium.jpeg");
```

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/barcode/how-to/create-barcode-images/QRMedium.jpeg" alt="QR Code with medium correction level" class="img-responsive add-shadow">
    </div>
</div>

In the above snippet, an alphanumeric value is encoded in the QR code, specifying a dimension of 250 pixels, a medium error correction level, and leaving the QR version determination to IronBarcode. The code saves the QR image as a JPEG.
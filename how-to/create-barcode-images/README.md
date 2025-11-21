# How to Create Barcode Images

***Based on <https://ironsoftware.com/how-to/create-barcode-images/>***


## Quickstart: Create and Save a Code128 Barcode in One Line

Ease into using IronBarcode with our one-liner for swiftly generating and saving a Code128 barcode from a simple text as a PNG image. This instant solution requires minimal setup: simply provide the string, select the format and dimensions, and save it as an image file.

```cs
// Title: Generate Barcode Image Instantly
IronBarCode.BarcodeWriter.CreateBarcode("Sample123", BarcodeEncoding.Code128, 250, 100).SaveAsPng("Barcode.png");
```

## Barcode Generation and Image Output

IronBarcode offers a straightforward approach for barcode generation. This is done by utilizing the `CreateBarcode()` method from the `BarcodeWriter` class. Here, you can specify the barcode value, encoding type, and the dimensions for the barcode. The resulting `GeneratedBarcode` object is then ready to be saved as an image using the `SaveAs()` method. Let's delve into each of these parameters before presenting a practical example.

### Barcode Value

The method `BarcodeWriter.CreateBarcode()` supports various data types for barcode values such as `byte[] array`, `MemoryStream`, and `string`. The acceptable length and character set of the string will depend on the chosen barcode format; details are provided extensively in our documentation.

### Barcode Encoding Types

A comprehensive list of supported barcode formats for creation is provided by IronBarcode, detailed in our article on [Supported Barcode Formats](https://ironsoftware.com/csharp/barcode/get-started/supported-barcode-formats/). Each barcode type offers distinct characteristics and advantages, which can be explored in our documentation to find the best option for your application.

### Width and Height

The dimensions of the barcode images are specified in pixels, with a default setting of _250 px_ each for width and height. Certain barcode types like QR and PDF417 have compliance requirements regarding dimensions. If specified dimensions are non-compliant, the compliant size is used instead, adding whitespace to fill any extra space. If dimensions are too small, an exception will be raised.

### Saving Barcodes as Different Image Formats

Upon generating a barcode using `BarcodeWriter.CreateBarcode()`, it can be saved in various image formats. Below are the methods available for different file types:

- `SaveAsGif()`: Saves as a GIF image.
- `SaveAsJpeg()`: Outputs a JPEG image.
- `SaveAsPng()`: Produces a PNG image.
- `SaveAsTiff()`: Creates a TIFF image.
- `SaveAsWindowsBitmap()`: Generates a BMP image file.
- `SaveAsImage()`: General method where the file format must be specified.

### Example: Create and Save a Barcode as JPEG

In this example, we create a Code128 barcode and save it as a JPEG image.

```csharp
using IronBarCode;

BarcodeWriter.CreateBarcode("IronBarcode123", BarcodeEncoding.Code128, 200, 100).SaveAsJpeg("OneDBarcode.jpeg");
```

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/barcode/how-to/create-barcode-images/OneDBarcode.jpeg" alt="One-dimensional barcode from snippet" class="img-responsive add-shadow">
    </div>
</div>

## Generating QR Codes and Saving Them as Image Files

With IronBarcode, generating a QR code—a prominent two-dimensional barcode—is well-supported due to its adaptability and visual appeal. Different properties and methods are used for QR codes due to their complexity, which is handled by the `QRCodeWriter.CreateQrCode()` method.

### QR Code Parameters

- **Value**: Can be numeric, alphabetic, or alphanumeric.
- **Size**: Defined in pixels, with a default of 500 px.
- **Error Correction Level**: Adjusts the QR's fault tolerance (Low, Medium, High, Highest).
- **QR Version**: Specifies the data capacity of the QR code, automatically adjusted if set to 0.

Each level of error correction enhances the QR's resilience against damages and obscurities, which is reflected in the complexity and appearance of the QR code.

### Create and Save a QR Code Example

Below is an illustration of creating and saving a QR code using medium error correction. The QR image is saved as a JPEG format file.

```csharp
using IronBarCode;

QRCodeWriter.CreateQrCode("IronBarcode1234", 250, QRCodeWriter.QrErrorCorrectionLevel.Medium, qrVersion: 0).SaveAsJpeg("QRMedium.jpeg");
```

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/barcode/how-to/create-barcode-images/QRMedium.jpeg" alt="QR Code with medium correction level" class="img-responsive add-shadow">
    </div>
</div>

The choice of error correction level and QR version allows customization based on the specific needs and environment where the QR code will be used.
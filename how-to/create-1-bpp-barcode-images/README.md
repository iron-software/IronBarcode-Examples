# Generating 1BPP Barcode Images with C#

***Based on <https://ironsoftware.com/how-to/create-1-bpp-barcode-images/>***


Creating and handling barcodes efficiently involves considering multiple factors such as the barcode's size and dimensions, especially when processing large batches. One efficient solution for achieving rapid processing and reliable machine readability is utilizing 1-bit-per-pixel (1BPP) barcode images. A 1BPP image, being strictly monochrome, depicts only two colors—typically black and white—with each pixel determined by a single bit where "0" might indicate black and "1" white, or the reverse.

The particularly small file size of 1BPP barcode images, where each pixel comprises merely one bit, considerably enhances its efficiency for storage and transfer, particularly in sending barcode images to printers.

IronBarcode provides extensive support for converting barcodes to 1bpp among other formats, ensuring versatility across various scenarios. This document explores the simplicity of creating 1bpp barcode images using IronBarcode.

## Quickstart: Generating a 1-Bit-Per-Pixel Barcode Image

This introduction illustrates the effortless process of generating a high-contrast, monochrome 1BPP barcode suitable for fast scanning and bulk processing using IronBarcode in a single line of code:

```cs
:title=Create a 1-BPP Barcode Instantly
var img = IronBarCode.BarcodeWriter.CreateBarcode("12345", IronBarCode.BarcodeWriterEncoding.EAN8).To1BppImage();
```

### Tutorial: Generating 1BPP Barcode Images

To transform a barcode into a 1bpp image, simply utilize the `To1BppImage` method. This method efficiently converts and saves the barcode into a 1bpp image format.

```cs
using IronBarCode;

// Encoding "12345" into a barcode using the EAN8 format
var myBarcode = BarcodeWriter.CreateBarcode("12345", BarcodeWriterEncoding.EAN8);

// Transforming the barcode into a 1bpp formatted image
var anyBitmap = myBarcode.To1BppImage();
```

### How to Save as a 1BPP Bitmap

If saving the barcode as a bitmap is required, IronBarcode facilitates this with the `SaveAs1BppBitmap` method. Here’s how to save it as a bitmap file simply:

```cs
using IronBarCode;

// Encode "12345" into a barcode using EAN8 format
var myBarcode = BarcodeWriter.CreateBarcode("12345", BarcodeWriterEncoding.EAN8);

// Save the barcode as a 1bpp Bitmap file
myBarcode.SaveAs1BppBitmap("1bppImage.bmp");
```

### How to Save as Binary Data

IronBarcode also allows saving the barcode as binary data, which can be particularly useful for integrating with other applications within your development environment. Here's the procedure:

```cs
using IronBarCode;

// Generating a barcode with data "12345" using EAN8
var myBarcode = BarcodeWriter.CreateBarcode("12345", BarcodeWriterEncoding.EAN8);

// Converting and saving the barcode as binary data
var byteData = myBarcode.To1BppBinaryData();
```
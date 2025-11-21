# Decoding Multiple Barcodes Simultaneously

***Based on <https://ironsoftware.com/how-to/read-multiple-barcodes/>***


In numerous sectors such as logistics, retail, healthcare, and inventory management, the ability to decode several barcodes at once is a critical efficiency enhancer. The IronBarcode library provides a straightforward method to harness this capability, significantly improving productivity and operational workflows.

## Easy Guide: Efficient Barcode Reading from an Image

This guide demonstrates how effortlessly IronBarcode can detect and read all barcodes in an image. By simply enabling `ExpectMultipleBarcodes = true` and specifying the types of barcodes you are targeting, you can bypass the unnecessary complexities.

```cs
:title=Efficient Multi-Barcode Reading
var results = IronBarCode.BarcodeReader.Read("image.png", new IronBarCode.BarcodeReaderOptions { ExpectMultipleBarcodes = true, ExpectBarcodeTypes = IronBarCode.BarcodeEncoding.AllOneDimensional });
```

## Example: Decoding Multiple Barcodes

IronBarcode is designed to perform continuous scanning on a document to decode various barcodes by default. In some cases, however, it might return only one barcode even when more are visible. To overcome this, you can adjust your settings to ensure the multiple barcode feature is utilized as depicted below. It’s noteworthy that the **ExpectMultipleBarcodes** setting can be found in both **BarcodeReaderOptions** and **PdfBarcodeReaderOptions**, making it applicable for image and PDF barcode reading tasks alike.

### Sample Image

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/barcode/how-to/read-multiple-barcodes/multiple-barcodes.png" alt="Image to be read" class="img-responsive add-shadow">
    </div>
</div>

```cs
using IronBarCode;
using System;

// Configuration for reading multiple barcodes
BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    ExpectMultipleBarcodes = true,
    ExpectBarcodeTypes = BarcodeEncoding.AllOneDimensional,
};

// Execute barcode reading
var results = BarcodeReader.Read("testbc1.png", options);

foreach (var result in results)
{
    Console.WriteLine(result.ToString());
}
```

By enabling **ExpectMultipleBarcodes**, IronBarcode scans the entire document, capturing and storing each barcode detected in the **BarcodeResults** collection. This allows for easy iteration and display of each barcode value using a foreach loop.

## Single Barcode Decoding Example

While IronBarcode excels at reading multiple barcodes, it is also efficient in singleton scenarios. By default, it scans the entire document even if only one barcode is needed. By setting **ExpectMultipleBarcodes** to false, you minimize the scan breadth, leading to quicker barcode detection. Below is how you implement this change.

### Sample Image

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/barcode/how-to/read-multiple-barcodes/multiple-barcodes.png" alt="Image to be read" class="img-responsive add-shadow">
    </div>
</div>

```cs
using IronBarCode;
using System;

// Configuring for a single barcode read
BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    ExpectMultipleBarcodes = false,
    ExpectBarcodeTypes = BarcodeEncoding.AllOneDimensional,
};

// Reading the barcode
var results = BarcodeReader.Read("testbc1.png", options);

foreach (var result in results)
{
    Console.WriteLine(result.ToString());
}
```

In this instance, using the same image with multiple barcodes, the setting **ExpectMultipleBarcodes** is false. Consequently, IronBarcode returns only the first detected barcode and ceases further scanning.

### Performance Insights

Adjusting the **ExpectMultipleBarcodes** to false can significantly enhance the speed when only a single barcode needs to be recognized.

Here is a comparative performance analysis using the same setup:

| **ExpectMultipleBarcodes = true** | **ExpectMultipleBarcodes = false** |
|-----------------------------------|------------------------------------|
| 00.91 second                      | 00.10 second                       |
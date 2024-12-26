# How to Efficiently Read Multiple Barcodes Simultaneously

***Based on <https://ironsoftware.com/how-to/read-multiple-barcodes/>***


The ability to read several barcodes at once is vital across many sectors such as logistics, retail, healthcare, and inventory management. This functionality facilitates more effective data manipulation. IronBarcode stands out as an invaluable asset in enhancing operational efficiency and productivity by allowing for the simultaneous reading of multiple barcodes.

<h3>Getting Started with IronBarcode</h3>

---

## Example: Reading Multiple Barcodes

IronBarcode is designed to scan a document continuously to recognize multiple barcodes. Sometimes, users experience getting only a single barcode reading from an image containing several. This issue can be resolved by adjusting settings to better detect multiple barcodes, demonstrated in the following example. Note that the `ExpectMultipleBarcode` property is included in both `BarcodeReaderOptions` and `PdfBarcodeReaderOptions`, making it applicable to both image and PDF documents.

#### Sample Image

<div class="content-img-align-center">
  <div class="center-image-wrapper">
       <img src="https://ironsoftware.com/static-assets/barcode/how-to/read-multiple-barcodes/multiple-barcodes.png" alt="Multiple barcodes" class="img-responsive add-shadow">
  </div>
</div>

```cs
using IronBarCode;
using System;

// Configure the options for reading multiple barcodes
BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    ExpectMultipleBarcodes = true,
    ExpectBarcodeTypes = BarcodeEncoding.AllOneDimensional,
};

// Perform barcode reading
var results = BarcodeReader.Read("testbc1.png", options);

foreach (var result in results)
{
    Console.WriteLine(result.ToString());
}
```

In the above example, `ExpectMultipleBarcodes` is set to true, prompting IronBarcode to search the entire image for several barcodes and collect them into the `BarcodeResults` container. Using a `foreach` loop facilitates the easy retrieval and display of each barcode value on the console.

## Example: Reading a Single Barcode

IronBarcode is equipped to identify both a single or multiple barcodes in images or PDFs. Typically, the engine will scan the entire document even if only one barcode is present. For better performance when only one barcode is needed, setting `ExpectMultipleBarcodes` to false enhances processing speed as the engine stops scanning upon detecting the first barcode. Below is an example that illustrates this setting.

#### Sample Image

<div class="content-img-align-center">
  <div class="center-image-wrapper">
       <img src="https://ironsoftware.com/static-assets/barcode/how-to/read-multiple-barcodes/multiple-barcodes.png" alt="Demonstration single scan" class="img-responsive add-shadow">
  </div>
</div>

```cs
using IronBarCode;
using System;

// Adjust settings for single barcode reading
BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    ExpectMultipleBarcodes = false,
    ExpectBarcodeTypes = BarcodeEncoding.AllOneDimensional,
};

// Commence barcode reading
var results = BarcodeReader.Read("testbc1.png", options);

foreach (var result in results)
{
    Console.WriteLine(result.ToString());
}
```

Using the identical image with multiple barcodes, the above modification with `ExpectMultipleBarcodes` set to false allows the retrieval of only the first detected barcode, ceasing the scan thereafter.

#### Performance Analysis

Adjusting the `ExpectMultipleBarcodes` setting produces a significant variance in processing times. Below is an approximate comparison of performance impact between the two settings on the same machine:

<table class="table table__configuration-variables" style="text-align: center;">
  <tr>
      <th style="text-align: center;">ExpectMultipleBarcodes = true</th>
      <th style="text-align: center;">ExpectMultipleBarcodes = false</th>
  </tr>
  <tr>
      <td>00.91 second</td>
      <td>00.10 second</td>
  </tr>
</table>
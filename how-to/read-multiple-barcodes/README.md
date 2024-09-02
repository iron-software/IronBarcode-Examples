# How to Simultaneously Read Multiple Barcodes

Simultaneously reading multiple barcodes is essential in sectors like logistics, retail, healthcare, and inventory management, as it facilitates swift data handling. The IronBarcode library provides an effective solution for this, streamlining workflow and improving efficiency.

## Example: Reading Multiple Barcodes

IronBarcode is equipped to scan a document continuously and detect multiple barcodes by default. However, there are situations where it might return only a single barcode value despite the presence of several in the document. To overcome this, the **ExpectMultipleBarcodes** setting can be adjusted. This feature is available in both **BarcodeReaderOptions** and **PdfBarcodeReaderOptions**, ensuring functionality with both images and PDF files.

#### Example Image

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/barcode/how-to/read-multiple-barcodes/multiple-barcodes.png" alt="Barcode Example" class="img-responsive add-shadow">
    </div>
</div>

```cs
using IronBarCode;
using System;

// Configure the barcode reader to anticipate multiple barcodes
BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    ExpectMultipleBarcodes = true,
    ExpectBarcodeTypes = BarcodeEncoding.AllOneDimensional,
};

// Execute barcode reading
var barcodeResults = BarcodeReader.Read("example-image.png", options);

// Access and display each barcode value found
foreach (var barcode in barcodeResults)
{
    Console.WriteLine(barcode.ToString());
}
```

In the above code, enabling **ExpectMultipleBarcodes** allows IronBarcode to scan the entire content for multiple barcodes, which are then stored in **barcodeResults**. By iterating over these results, the values of each barcode can be printed out.

## Example: Reading a Single Barcode

IronBarcode is capable of detecting both single and multiple barcodes within the same document. Normally, it scans the entire document even if set to detect only a single barcode, but you can optimize this by setting **ExpectMultipleBarcodes** to false, which makes the scan stop after the first barcode is detected, thus speeding up the process. 

#### Example Image

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/barcode/how-to/read-multiple-barcodes/multiple-barcodes.png" alt="Barcode Example" class="img-responsive add-shadow">
    </div>
</div>

```cs
using IronBarCode;
using System;

// Set to detect a single barcode
BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    ExpectMultipleBarcodes = false,
    ExpectBarcodeTypes = BarcodeEncoding.AllOneDimensional,
};

// Perform barcode reading
var barcodeResults = BarcodeReader.Read("example-image.png", options);

// Display the result of the first found barcode
foreach (var barcode in barcodeResults)
{
    Console.WriteLine(barcode.ToString());
}
```

Here, **ExpectMultipleBarcodes** is set to false, and as expected, the scanning ceases after the first barcode is detected and processed.

#### Comparison of Performance

By setting **ExpectMultipleBarcodes** to false, it is possible to enhance the efficiency of single-barcode reading operations significantly.

Here is a comparative performance evaluation between both settings:

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


In conclusion, whether you need to process multiple barcodes or just a single one, adjusting the **ExpectMultipleBarcodes** setting in IronBarcode facilitates versatile scanning approaches tailored to your operational needs.
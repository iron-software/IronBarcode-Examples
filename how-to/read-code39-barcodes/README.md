# Effortlessly Read Code 39 Barcodes in C# with IronBarcode

***Based on <https://ironsoftware.com/how-to/read-code39-barcodes/>***


For various industries including inventory, logistics, and industrial sectors, Code 39 barcodes are integral due to their reliability and broad compatibility. Code 39 is a versatile barcode type that accommodates variable lengths.

Originally, the Standard Code 39 could encode uppercase letters (A-Z), digits (0-9), and some special characters such as space, "-", "$", "+", "%", and ".". While suitable for basic identification purposes, the complexity of modern requirements led to the development of the Code 39 Extended specification, which encodes all 128 ASCII characters.

We will guide you through reading both standard and extended Code 39 barcodes using the features of IronBarcode.

## Getting Started with IronBarcode

!!!—LIBRARY_START_TRIAL_BLOCK—!!!

-----

## How to Read a Standard Code 39 Barcode

Utilizing IronBarcode to read a Code 39 barcode is simple. Initially, configure a new `BarcodeReaderOptions` instance, specifying `BarcodeEncoding.Code39`. This configuration informs the reader about the type of barcode it should expect, thereby optimizing the reading process.

Next, deploy the `Read` method to scan the barcodes, inputting the barcode image together with the configured options. Subsequent to reading, iterate through the resultant barcodes and output each barcode's string value to the console.

### Visual Reference of Barcode

The image here represents a standard Code 39 barcode.

<div class="content-img-align-center">
    <div class="center-image-wrapper" style="width=50%">
        <img src="https://ironsoftware.com/static-assets/barcode/how-to/read-code39-barcodes/code39.webp" alt="Standard Code 39 barcode" class="img-responsive add-shadow">
    </div>
</div>

### Implementation Example

```cs
using IronBarCode;
using System;

BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    // Aiming to detect only Code 39 barcodes
    ExpectBarcodeTypes = BarcodeEncoding.Code39
};

// Execute barcode reading from an image with the pre-set options
var results = BarcodeReader.Read("code39.png", options);

// Iterate and output each discovered barcode data
foreach (var result in results)
{
    // Display the content of the standard Code 39 barcode
    Console.WriteLine(result.ToString());
}
```

### Display of Results

Below is the depiction of the output for a typical reading of the standard Code 39 barcode.

<div class="content-img-align-center">
    <div class="center-image-wrapper" style="width=50%">
        <img src="https://ironsoftware.com/static-assets/barcode/how-to/read-code39-barcodes/standard-output.webp" alt="Standard Code39 Output" class="img-responsive add-shadow">
    </div>
</div>

-----

## How to Read an Extended Code 39 Barcode

The approach for processing an extended Code 39 barcode is analogous to the standard form, with a minor tweak. Here, activate the `UseCode39ExtendedMode` to true to allow the reader to decode special character pairs (like +T or %O) into their full ASCII character representations (like "t" and "!").

### Barcode Image Example

Displayed below is an image of an extended Code 39 barcode labeled "Test-Data!" showcasing lowercase letters and a punctuation mark, features only manageable under extended mode.

<div class="content-img-align-center">
    <div class="center-image-wrapper" style="width=50%">
        <img src="https://ironsoftware.com/static-assets/barcode/how-to/read-code39-barcodes/code39extended.webp" alt="Extended Code39" class="img-responsive add-shadow">
    </div>
</div>

### Implementation Example

```cs
using IronBarCode;
using System;

BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    // Activation of extended Code 39 mode
    UseCode39ExtendedMode = true,

    // Set the expected barcode type to Code 39
    ExpectBarcodeTypes = BarcodeEncoding.Code39
};

// Perform the barcode reading on the extended Code 39 image
var results = BarcodeReader.Read("code39extended.png", options);

// Iterate and display every retrieved barcode detail
foreach (var result in results)
{
    // Output the full decoded ASCII value (e.g., "Test-Data!")
    Console.WriteLine(result.ToString());
}
```

### Resultant Output

This image showcases the output after reading the extended Code 39 barcode.

<div class="content-img-align-center">
    <div class="center-image-wrapper" style="width=50%">
        <img src="https://ironsoftware.com/static-assets/barcode/how-to/read-code39-barcodes/extended-output.webp" alt="Extended Code39 Output" class="img-responsive add-shadow">
    </div>
</div>

It's advisable to redirect any console outputs that don't display correctly into a `.txt` file for error-free verification.
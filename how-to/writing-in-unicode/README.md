# Generating Unicode and International Language Barcodes in C#

***Based on <https://ironsoftware.com/how-to/writing-in-unicode/>***


Creating barcodes that support international languages encompasses several considerations including string length and the suitable barcode encoding for that specific string value. IronBarcode provides extensive support for both generating and writing in Unicode, which simplifies the process for developers looking to distribute their products globally with applicable barcodes. Here we provide a step-by-step guide, complete with code samples, to aid developers in this task.

## Get Started Quickly: Generate a Unicode Barcode Using DataMatrix

Below is a straightforward example of how to instantly create a Unicode barcode with IronBarcode. This example demonstrates how to compose a barcode containing text in multiple languages in a single line of code, and then save this barcode as an image file.

```csharp
// Title: Effortlessly Generate a Unicode Barcode
var barcode = IronBarCode.BarcodeWriter.CreateBarcode("123 英語 اللغة العربية", IronBarCode.BarcodeWriterEncoding.DataMatrix);
barcode.SaveAsImage("unicode.png");
```

---

## Example of Writing a Unicode Barcode

With IronBarcode's strong capabilities in Unicode support, software developers can effortlessly integrate and handle strings containing various languages, enhancing the flexibility of their applications. Below, we demonstrate how a string combining Chinese, Arabic, and Thai can be effectively managed to create a barcode.

Here's the string we'll utilize as the barcode value:

```csharp
string unicodeText = "周態告応立待太記行神正用真最… (and so on)";
```

To generate the barcode, we utilize the `BarcodeWriter.CreateBarcode` method by providing the text and desired encoding:

```csharp
﻿using IronBarCode;

// Sample text including Chinese, Arabic and Thai characters
string text = "周態告応立待太記行神正用真最… (complete text)";

// Generating a DataMatrix barcode with specified text
var createdBarcode = BarcodeWriter.CreateBarcode(text, BarcodeWriterEncoding.DataMatrix);

// Saving the generated barcode as an image
createdBarcode.SaveAsImage("Unicode.jpeg");
```

Below is the output image produced by the above code:

<div class="content-img-align-center">
  <div class="center-image-wrapper">
    <img src="https://ironsoftware.com/static-assets/barcode/how-to/writing-in-unicode/Unicode.webp" alt="Sample Output Unicode Barcode">
    <p style="color: #181818; font-style: italic;">Sample Output Unicode Barcode</p>
  </div>
</div>

---

### Encoding Support for Unicode Barcodes

While Unicode is universally supported across many barcode formats, only specific barcodes can natively embed Unicode text. Here is a quick reference for barcode types that support Unicode:

<div class="content-table">
  <table>
    <tbody>
      <tr class="tr-head">
        <th>Barcode Type</th>
        <th>Unicode Support</th>
        <th>Best For</th>
        <th>Maximum Capacity</th>
      </tr>
      <!-- Table rows -->
    </tbody>
  </table>
</div>

Different barcode types have varying capacities for characters which must be considered, especially when utilising encodings such as PDF417 with long strings.

For a detailed list of all supported barcode formats, please refer to [this link](https://ironsoftware.com/csharp/barcode/get-started/supported-barcode-formats).

### Reading the Unicode Barcode 

IronBarcode's capabilities are not just restricted to writing barcodes but also extend to reading them. To read back the data embedded in a Unicode barcode, the `Read` method from `BarcodeReader` is employed.

Consider this example where we read the previously generated barcode:

```csharp
﻿using IronBarCode;
using System.IO;

// Performance of reading the Unicode barcode
BarcodeResults results = BarcodeReader.Read("Unicode.jpeg");

// Save the decoded text to a file
File.WriteAllText("text.txt", results[0].Text);
```

This method outputs the barcode's decoded text into a text file rather than the console due to potential encoding issues in terminal environments.

#### Displayed Output

![Displayed barcode text output](https://ironsoftware.com/static-assets/barcode/how-to/writing-in-unicode/outputvalue.webp)
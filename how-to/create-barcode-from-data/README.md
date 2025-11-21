# Generating Barcodes from Various Data Types

***Based on <https://ironsoftware.com/how-to/create-barcode-from-data/>***


Barcodes can be swiftly generated from various data types, including plain text, binary data, and even memory streams, using the `BarcodeWriter.CreateBarcode()` method provided by IronBarcode.

## Quick Guide: Instant Barcode Generation from a Single String

Utilize the IronBarcode library to create barcodes effortlessly. Here’s an example where a barcode is generated from a simple string in just one command line:

```cs
// Create a barcode from the string "Order123" using Code128 encoding
var barcode = IronBarCode.BarcodeWriter.CreateBarcode("Order123", IronBarCode.BarcodeWriterEncoding.Code128);
```

## Generate Barcodes from Strings

This example illustrates how to generate barcodes from various types of string data:

```cs
using IronBarCode;

string text = "Hello, World!";
string siteUrl = "https://ironsoftware.com/csharp/barcode/";
string receiptID = "2023-08-04-12345"; // A numeric ID for receipts
string flightID = "FLT2023NYC-LAX123456"; // An alphanumeric flight ID
string number = "1234";

BarcodeWriter.CreateBarcode(text, BarcodeEncoding.Aztec).SaveAsPng("text.png");
BarcodeWriter.CreateBarcode(siteUrl, BarcodeEncoding.QRCode).SaveAsPng("url.png");
BarcodeWriter.CreateBarcode(receiptID, BarcodeEncoding.Code93, 250, 67).SaveAsPng("receiptID.png");
BarcodeWriter.CreateBarcode(flightID, BarcodeEncoding.PDF417, 250, 67).SaveAsPng("flightID.png");
BarcodeWriter.CreateBarcode(number, BarcodeEncoding.Codabar, 250, 67).SaveAsPng("number.png");
```

In this example, we encoded different types of data into various barcode formats and saved the outputs as PNG images.

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/barcode/how-to/create-barcode-from-data/text.png" alt="Text" class="img-responsive add-shadow" style="margin: auto;">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Text</p>
    </div>
    <div class="competitors__card" style="width: 50%;">
        <img src="https://ironsoftware.com/static-assets/barcode/how-to/create-barcode-from-data/url.png" alt="URL" class="img-responsive add-shadow" style="margin: auto;">
        <p class="competitors__download-link" style="color: #181818; font-style: italic; margin-bottom: 25px;">URL</p>
    </div>
</div>

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/barcode/how-to/create-barcode-from-data/receiptID.png" alt="Receipt ID" class="img-responsive add-shadow" style="margin: auto;">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Receipt ID</p>
    </div
    <div class="competitors__card" style="width: 50%;">
        <img src="https://ironsoftware.com/static-assets/barcode/how-to/create-barcode-from-data/flightID.png" alt="Flight ID" class="img-responsive add-shadow" style="margin: auto;">
        <p class="competitors__download-link" style="color: #181818; font-style: italic; margin-bottom: 25px;">Flight ID</p>
    </div>
</div>

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/barcode/how-to/create-barcode-from-data/Number.png" alt="Number"  class="img-responsive add-shadow">
         <p class="competitors__download-link" style="color: #181818; font-style: italic;">Number</p>
    </div>
</div>

## Barcode Creation from Byte Arrays

When generating barcodes from byte arrays, it is critical to match the data encoding to the appropriate `BarcodeEncoding`. Each barcode format requires a specific encoding compatibility. Below are the various character encodings supportable by IronBarcode:

- **ASCII**:
  - Uses 7 bits for each character.
  - Example: 'A' is 65, 'B' is 66.

- **UTF-8**:
  - A variable-length encoding system representing all Unicode characters.
  - Example: The Euro symbol (€) is encoded as 0xE2 0x82 0xAC.

- **UTF-16**:
  - Uses 16-bit sequences to encode a wide range of characters.
  - Example: The Greek letter alpha (α) is 0x03B1.

- **UTF-32**:
  - Uses a consistent 32-bit sequence for each symbol.
  - Example: The UTF-32 code for α is 0x000003B1.

- **ISO-8859-1**:
  - Extends ASCII by adding characters from Western European languages.
  - Example: 'é' is represented by 233.

*[Note: IronBarcode defaults to using ISO-8859-1 for encoding.]*

Here’s how you can generate barcodes from byte data:

```cs
using IronBarCode;
using System.Text;

byte[] inputText = Encoding.UTF8.GetBytes("Hello, World!");
byte[] inputUrl = Encoding.UTF8.GetBytes("https://ironsoftware.com/csharp/barcode/");
byte[] inputReceiptID = Encoding.UTF8.GetBytes("2023-08-04-12345"); // Receipt ID
byte[] inputFlightID = Encoding.UTF8.GetBytes("FLT2023NYC-LAX123456"); // Flight ID
byte[] inputNumber = Encoding.UTF8.GetBytes("1234");

BarcodeWriter.CreateBarcode(inputText, BarcodeEncoding.Aztec).SaveAsPng("text.png");
BarcodeWriter.CreateBarcode(inputUrl, BarcodeEncoding.QRCode).SaveAsPng("url.png");
BarcodeWriter.CreateBarcode(inputReceiptID, BarcodeEncoding.Code93, 250, 67).SaveAsPng("receiptID.png");
BarcodeWriter.CreateBarcode(inputFlightID, BarcodeEncoding.PDF417, 250, 67).SaveAsPng("flightID.png");
BarcodeWriter.CreateBarcode(inputNumber, BarcodeEncoding.Codabar, 250, 67).SaveAsPng("number.png");
```

## Generating Barcodes from Memory Streams

The following code demonstrates generating barcodes from memory streams, a process suitable for real-time data handling:

```cs
using IronBarCode;
using System.IO;
using System.Text;

MemoryStream streamText = new MemoryStream(Encoding.UTF8.GetBytes("Hello, World!"));
MemoryStream streamUrl = new MemoryStream(Encoding.UTF8.GetBytes("https://ironsoftware.com/csharp/barcode/"));
MemoryStream streamReceiptID = new MemoryStream(Encoding.UTF8.GetBytes("2023-08-04-12345")); // Receipt ID info
MemoryStream streamFlightID = new MemoryStream(Encoding.UTF8.GetBytes("FLT2023NYC-LAX123456")); // Flight ID info
MemoryStream streamNumber = new MemoryStream(Encoding.UTF8.GetBytes("1234"));

BarcodeWriter.CreateBarcode(streamText, BarcodeEncoder
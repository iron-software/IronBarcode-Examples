# Generating Barcodes from Various Data Types

> Full guide: [Generating Barcodes from Various Data Types](https://ironsoftware.com/csharp/barcode/how-to/create-barcode-from-data/?utm_source=github)


Barcodes can be swiftly generated from various data types, including plain text, binary data, and even memory streams, using the `BarcodeWriter.CreateBarcode()` method provided by IronBarcode.

## Quick Guide: Instant Barcode Generation from a Single String

Utilize the IronBarcode library to create barcodes. Here’s an example where a barcode is generated from a simple string in just one command line:

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


BarcodeWriter.CreateBarcode(streamText, BarcodeEncoding.Aztec).SaveAsPng("text.png");
BarcodeWriter.CreateBarcode(streamUrl, BarcodeEncoding.QRCode).SaveAsPng("url.png");
BarcodeWriter.CreateBarcode(streamReceiptID, BarcodeEncoding.Code93, 250, 67).SaveAsPng("receiptID.png");
BarcodeWriter.CreateBarcode(streamFlightID, BarcodeEncoding.PDF417, 250, 67).SaveAsPng("flightID.png");
BarcodeWriter.CreateBarcode(streamNumber, BarcodeEncoding.Codabar, 250, 67).SaveAsPng("number.png");
```

This builds a `MemoryStream` over a `System.Byte[]` and passes it to
`BarcodeWriter.CreateBarcode()`. Working from a stream rather than a file means:

- **Performance**: no disk I/O, which is quicker for data that is only needed
  once.
- **Security**: the data stays in memory rather than being written somewhere it
  has to be cleaned up.
- **Flexibility**: it drops straight into other stream-based APIs.
- **Resource use**: the runtime disposes of it for you.

## Batch Barcode Generation over Streams

For stream-based work at scale, generate each barcode and export it straight
back to a stream:

```cs
using IronBarCode;
using System.IO;
using System.Text;

// Example: Processing multiple barcodes in a batch using streams
public static List<Stream> GenerateBarcodeStreams(List<string> dataItems)
{
    var barcodeStreams = new List<Stream>();

    foreach (var item in dataItems)
    {
        // Convert string to stream
        var dataStream = new MemoryStream(Encoding.UTF8.GetBytes(item));

        // Generate barcode from stream
        var barcode = BarcodeWriter.CreateBarcode(dataStream, BarcodeEncoding.Code128);

        // Export barcode back to stream
        var outputStream = barcode.ToStream();
        outputStream.Position = 0; // Reset position for reading

        barcodeStreams.Add(outputStream);
    }

    return barcodeStreams;
}

// Usage example
var orderNumbers = new List<string> { "ORD-001", "ORD-002", "ORD-003" };
var barcodes = GenerateBarcodeStreams(orderNumbers);
```

## Styling a Generated Barcode

`BarcodeWriter.CreateBarcode` returns a `GeneratedBarcode`, which carries the
sizing, colour and annotation methods:

```cs
using IronSoftware.Drawing;
using IronBarCode;

// Create a barcode with custom styling
GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("PRODUCT-12345", BarcodeEncoding.Code128);

// Apply custom styling
myBarcode.ResizeTo(300, 100);
myBarcode.SetMargins(10);
myBarcode.ChangeBarCodeColor(Color.DarkBlue);

// Add text annotations
myBarcode.AddBarcodeValueTextBelowBarcode();
myBarcode.AddAnnotationTextAboveBarcode("Product SKU", new Font("Arial"), Color.Black, 12);

// Save the customized barcode
myBarcode.SaveAsPng("customized-barcode.png");
```

> The guide writes the annotation call as
> `AddAnnotationTextAboveBarcode("Product SKU", Font.Arial, Color.Black, 12)`.
> `IronSoftware.Drawing.Font` has no static `Arial`; it is constructed from a
> family name, so this example uses `new Font("Arial")`.

## Encoding Binary Data in a QR Code

Binary content has to be encoded as text before it will fit a barcode. Base64
does that, and a high error-correction level keeps the result readable at the
resulting data density:

```cs
using System;
using System.IO;
using IronBarCode;

// Example: Encoding binary data (like a small file) into QR Code
byte[] binaryData = File.ReadAllBytes("document.pdf");
string base64Data = Convert.ToBase64String(binaryData);

// Create QR code with high error correction for binary data
GeneratedBarcode binaryBarcode = QRCodeWriter.CreateQrCode(
    base64Data,
    errorCorrection: QRCodeWriter.QrErrorCorrectionLevel.High
);

// Save with appropriate size for data density
binaryBarcode.ResizeTo(500, 500);
binaryBarcode.SaveAsPng("binary-data-qr.png");
```

> The guide names that argument `errorCorrectionLevel`. The parameter on
> `QRCodeWriter.CreateQrCode` is `errorCorrection`, so the guide's version does
> not compile.

## Choosing a Barcode Format

Each format suits a different kind of payload:

- **QR Code**: URLs, email addresses and longer text. Holds up to 4,296
  alphanumeric characters and carries error correction.
- **Code128**: alphanumeric data such as order numbers and serial codes.
- **PDF417**: denser payloads such as flight tickets and government IDs, up to
  1,850 alphanumeric characters.
- **Code93**: compact numeric data, common in postal and inventory systems.
- **Aztec**: mobile ticketing and transport, in less space than a QR code.

## Frequently Asked Questions

**How do I create a barcode from text in C#?**
One line: `BarcodeWriter.CreateBarcode("YourText", BarcodeWriterEncoding.Code128)`.

**What can I encode into a barcode?**
Strings, URLs, IDs, byte arrays and streams. `CreateBarcode` has an overload for
each.

**Which format should I use for a URL?**
QR Code. It holds enough for a long address and includes error correction.

**Can I create barcodes from binary data?**
Yes, through the `System.Byte[]` and `System.IO.Stream` overloads of
`CreateBarcode`.

**What image formats can I save to?**
PNG, JPEG, BMP, GIF and TIFF.

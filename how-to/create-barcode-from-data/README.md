# Generate Barcodes from Text, URLs, IDs, Numbers, Binary Data & Memory Streams

IronBarcode's ability to create barcodes from diverse data sources such as Text, URLs, IDs, Numbers, Binary Data, and Memory Streams makes it an indispensable tool across various industries. It effectively handles different use cases, including generating barcodes for product labels, URL bookmarks, access control identifiers, tracking numbers, and accurately encoding binary data or streams into readable barcodes.

The ease of use offered by IronBarcode's `BarcodeWriter.CreateBarcode()` is notable as it accepts a wide array of object types without requiring explicit type conversions. This feature facilitates streamlined coding, promoting greater efficiency and productivity.

## Generate Barcodes from Strings

The `BarcodeWriter.CreateBarcode()` method in IronBarcode effortlessly handles data of type `System.String`, accommodating entities like text, URLs, IDs, and numbers directly. Below is an example of how to use this method:

```cs
using IronBarCode;

string text = "Hello, World!";
string url = "https://ironsoftware.com/csharp/barcode/";
string receiptID = "2023-08-04-12345"; // Numeric ID for a receipt
string flightID = "FLT2023NYC-LAX123456"; // Alphanumeric ID for a flight
string number = "1234";

BarcodeWriter.CreateBarcode(text, BarcodeEncoding.Aztec).SaveAsPng("text.png");
BarcodeWriter.CreateBarcode(url, BarcodeEncoding.QRCode).SaveAsPng("url.png");
BarcodeWriter.CreateBarcode(receiptID, BarcodeEncoding.Code93, 250, 67).SaveAsPng("receiptID.png");
BarcodeWriter.CreateBarcode(flightID, BarcodeEncoding.PDF417, 250, 67).SaveAsPng("flightID.png");
BarcodeWriter.CreateBarcode(number, BarcodeEncoding.Codabar, 250, 67).SaveAsPng("number.png");
```

In the code snippet above, we convert five string examples into different barcode formats and save them as PNG images. The generated barcodes can alternatively be output as [Images](https://ironsoftware.com/csharp/barcode/how-to/create-barcode-images/), [Streams](https://ironsoftware.com/csharp/barcode/how-to/export-barcode-as-stream/), [HTML strings](https://ironsoftware.com/csharp/barcode/how-to/create-barcode-as-html/), or as [PDF documents](https://ironsoftware.com/csharp/barcode/how-to/create-barcode-as-pdf/). Here are the barcode images produced:

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
    </div>
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

## Generate Barcodes from Byte Arrays

IronBarcode's capabilities extend beyond converting `System.String` into barcodes. It can also process `System.Byte []` for users with more complex needs. The proper byte encoding must be matched to the appropriate `BarcodeEncoding`. Below is an explanation of various byte encodings and their properties:

- **ASCII**:
  - ASCII utilizes 7 bits per character for standard English letters, digits, punctuation, and controls.
- **Unicode**:
  - Covering all human writing systems, each symbol gets a unique code point in Unicode.
- **UTF-8**:
  - UTF-8 can encode all Unicode characters and adjusts the byte length according to the character's complexity.
- **UTF-16**:
  - UTF-16 uses 16-bit sequences capable of representing all Unicode characters.
- **UTF-32**:
  - With a fixed 32-bit length per character, UTF-32 is simple but can consume more space for extended character sets.
- **ISO-8859-1** (Latin-1):
  - Extending ASCII to include Western European characters, ISO-8859-1 uses 8 bits per character.

The default encoding in IronBarcode is ISO-8859-1, but others can be specified. For guidance on compatible barcode encodings refer to [this page](https://ironsoftware.com/csharp/barcode/how-to/read-barcodes-from-images/).

Below is an example of how this can be implemented:

```cs
using IronBarCode;
using System.Text;

byte[] text = Encoding.UTF8.GetBytes("Hello, World!");
byte[] url = Encoding.UTF8.GetBytes("https://ironsoftware.com/csharp/barcode/");
byte[] receiptID = Encoding.UTF8.GetBytes("2023-08-04-12345"); // Numeric ID for a receipt
byte[] flightID = Encoding.UTF8.GetBytes("FLT2023NYC-LAX123456"); // Alphanumeric ID for a flight
byte[] number = Encoding.UTF8.GetBytes("1234");

BarcodeWriter.CreateBarcode(text, BarcodeEncoding.Aztec).SaveAsPng("text.png");
BarcodeWriter.CreateBarcode(url, BarcodeEncoding.QRCode).SaveAsPng("url.png");
BarcodeWriter.CreateBarcode(receiptID, BarcodeEncoding.Code93, 250, 67).SaveAsPng("receiptID.png");
BarcodeWriter.CreateBarcode(flightID, BarcodeEncoding.PDF417, 250, 67).SaveAsPng("flightID.png");
BarcodeWriter.CreateBarcode(number, BarcodeEncoding.Codabar, 250, 67).SaveAsPng("number.png");
```

In this snippet, byte arrays representing various data inputs are transformed into barcodes using the `BarcodeWriter` along with desired barcode formats and sizing options.

## Generate Barcodes from Streams

The flexibility of IronBarcode extends to supporting `System.IO.Stream` object inputs, enhancing its utility for applications that manage memory streams. Here is an example of how streams can be used to generate barcodes:

```cs
using IronBarCode;
using System.IO;
using System.Text;

MemoryStream text = new MemoryStream(Encoding.UTF8.GetBytes("Hello, World!"));
MemoryStream url = new MemoryStream(Encoding.UTF8.GetBytes("https://ironsoftware.com/csharp/barcode/"));
MemoryStream receiptID = a MemoryStream(Encoding.UTF8.GetBytes("2023-08-04-12345")); // Numeric ID for a receipt
MemoryStream flightID = a MemoryStream(Encoding.UTF8.GetBytes("FLT2023NYC-LAX123456")); // Alphanumeric ID for a flight
MemoryStream number = a MemoryStream(Encoding.UTF8.GetBytes("1234"));

BarcodeWriter.CreateBarcode(text, BarcodeEncoding.Aztec).SaveAsPng("text.png");
BarcodeWriter.CreateBarcode(url, BarcodeEncoding.QRCode).SaveAsPng("url.png");
BarcodeWriter.CreateBarcode(receiptID, BarcodeEncoding.Code93, 250, 67).SaveAsPng("receiptID.png");
BarcodeWriter.CreateBarcode(flightID, BarcodeEncoding.PDF417, 250, 67).SaveAsPng("flightID.png");
BarcodeWriter.CreateBarcode(number, BarcodeEncoding.Codabar, 250, 67).SaveAsPng("number.png");
```

In the above code, `MemoryStream` objects are utilized to pass byte array data into the `BarcodeWriter.CreateBarcode()` method for barcode generation, showcasing the adaptability of IronBarcode to different input types.
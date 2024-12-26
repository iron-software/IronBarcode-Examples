# Generate Barcodes from Text, Web URLs, IDs, Numbers, Binary Data, and Memory Streams

***Based on <https://ironsoftware.com/how-to/create-barcode-from-data/>***


IronBarcode is a versatile tool capable of generating barcodes from various data inputs like Text, URLs, IDs, Numbers, Binary Data, and Memory Streams. This feature suits numerous applications, including barcodes for product labeling, URL links, ID badges for security, numeric tracking codes, and even for encoding binary data or memory streams into readable barcodes, enhancing data operations across different sectors.

With IronBarcode, the process of creating barcodes is streamlined. The `BarcodeWriter.CreateBarcode()` method accommodates various object types as inputs without the necessity for type casting. This simplifies the development workflow and enhances productivity.


<h2>Starting with IronBarcode</h2>

## Generating a Barcode From a String

Using IronBarcode, a `System.String` can be easily utilized as an input parameter in the `BarcodeWriter.CreateBarcode()` method for different data types such as texts, URLs, IDs, and numbers. Here is an example of how to utilize this functionality:

```cs
using IronBarCode;

string text = "Hello, World!";
string url = "https://ironsoftware.com/csharp/barcode/";
string receiptID = "2023-08-04-12345"; // Numeric Receipt ID
string flightID = "FLT2023NYC-LAX123456"; // Alphanumeric Flight ID
string number = "1234";

BarcodeWriter.CreateBarcode(text, BarcodeEncoding.Aztec).SaveAsPng("text.png");
BarcodeWriter.CreateBarcode(url, BarcodeEncoding.QRCode).SaveAsPng("url.png");
BarcodeWriter.CreateBarcode(receiptID, BarcodeEncoding.Code93, 250, 67).SaveAsPng("receiptID.png");
BarcodeWriter.CreateBarcode(flightID, BarcodeEncoding.PDF417, 250, 67).SaveAsPng("flightID.png");
BarcodeWriter.CreateBarcode(number, BarcodeEncoding.Codabar, 250, 67).SaveAsPng("number.png");
```

This code sample transforms five different string values into barcodes: basic text, a URL, a numeric ID, an alphanumeric ID, and a simple number. These data inputs are directly provided to `BarcodeWriter.CreateBarcode()` along with encoding details and optional size configurations. The resulting barcodes can thereafter be saved as images, streams, HTML strings, or even PDF documents. You can check the resulting barcode images from the executed IronBarcode library at the following locations:

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

## Generate Barcode From Byte Array

IronBarcode extends its functionality to drafting barcodes from `System.Byte []` objects, vital for complex applications. Below are definitions and examples of byte encodings frequently used:

- **ASCII**:
  - Character encoding using 7 bits to represent characters, including English alphabet, numerals, and control characters. For example, the ASCII code for 'A' is 65, and 'B' is 66.
- **Unicode**:
  - A coding standard designed to cover all characters and symbols in human writing systems, assigning a unique code for every character, like U+0041 for 'A' and U+03B1 for α (alpha).
- **UTF-8**:
  - A variable-length character encoding that encompasses all Unicode characters, using different byte lengths per character.
- **UTF-16**:
  - A 16-bit variable-length character encoding representing all Unicode characters.
- **UTF-32**:
  - A 32-bit fixed sequence representing each character, utilized mainly for non-ASCII characters.
- **ISO-8859-1** (Latin-1):
  - An 8-bit extension of ASCII covering Western European language characters.

By default, IronBarcode employs ISO-8859-1 for byte encoding unless specified otherwise. Not all barcode encodings support every byte encoding, so this selection should be carefully paired with the intended barcode encoding. More on barcode encoding types can be found on the [barcode readings from images page](https://ironsoftware.com/csharp/barcode/how-to/read-barcodes-from-images/).

Here’s a practical example:

```cs
using IronBarCode;
using System.Text;

byte[] text = Encoding.UTF8.GetBytes("Hello, World!");
byte[] url = Encoding.UTF8.GetBytes("https://ironsoftware.com/csharp/barcode/");
byte[] receiptID = Encoding.UTF8.GetBytes("2023-08-04-12345");
byte[] flightID = Encoding.UTF8.GetBytes("FLT2023NYC-LAX123456");
byte[] number = Encoding.UTF8.GetBytes("1234");

BarcodeWriter.CreateBarcode(text, BarcodeEncoding.Aztec).SaveAsPng("text.png");
BarcodeWriter.CreateBarcode(url, BarcodeEncoding.QRCode).SaveAsPng("url.png");
BarcodeWriter.CreateBarcode(receiptID, BarcodeEncoding.Code93, 250, 67).SaveAsPng("receiptID.png");
BarcodeWriter.CreateBarcode(flightID, BarcodeEncoding.PDF417, 250, 67).SaveAsPng("flightID.png");
BarcodeWriter.CreateBarcode(number, BarcodeEncoding.Codabar, 250, 67).SaveAsPng("number.png");
```

In this example, 5 string data forms are converted into `System.Byte []`, and these byte arrays serve as inputs into the `BarcodeWriter`, accompanied by the desired `BarcodeEncoding`. Optional settings like `MaxWidth` and `MaxHeight` can be configured for the barcode dimensions.

## Generate Barcode From Stream

Moreover, IronBarcode supports the `System.IO.Stream` object, catering to those who handle MemoryStreams and seek to generate barcodes without shifting input formats. Here’s how this is done:

```cs
using IronBarCode;
using System.IO;
using System.Text;

MemoryStream text = new MemoryStream(Encoding.UTF8.GetBytes("Hello, World!"));
MemoryStream url = new MemoryStream(Encoding.UTF8.GetBytes("https://ironsoftware.com/csharp/barcode/"));
MemoryStream receiptID = new MemoryStream(Encoding.UTF8.GetBytes("2023-08-04-12345"));
MemoryStream flight ID = new MemoryStream(Encoding.UTF8.GetBytes("FLT2023NYC-LAX123456"));
MemoryStream number = a MemoryStream(Encoding.UTF8.GetBytes("1234"));

BarcodeWriter.CreateBarcode(text, BarcodeEncoding.Aztec).SaveAsPng("text.png");
BarcodeWriter.CreateBarcode(url, BarcodeEncoding.QRCode).SaveAsPng("url.png");
BarcodeWriter.CreateBarcode(receiptID, BarcodeEncoding.Code93, 250, 67).SaveAsPng("receiptID.png");
BarcodeWriter.CreateBarcode(flightID, BarcodeEncoding.PDF417, 250, 67).SaveAsPng("flightID.png");
BarcodeWriter.CreateBarcode(number, BarcodeEncoding.Codabar, 250, 67).SaveAsPng("number.png");
```

This final example builds upon the previous section by converting `System.Byte []` objects into `MemoryStream` instances, which are then fed into `BarcodeWriter.CreateBarcode()` to forge barcodes from `MemoryStream` objects.
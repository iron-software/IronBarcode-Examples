# Generate Barcodes from Various Data Types with IronBarcode

***Based on <https://ironsoftware.com/how-to/create-barcode-from-data/>***


IronBarcode is a comprehensive tool that supports the generation of barcodes from diverse data sources such as Text, URLs, IDs, Numbers, Binary Data, and Memory Streams. This feature makes it especially useful in scenarios such as marking products, encoding URLs, generating ID tags for secure access, numbering for tracking systems, and transforming binary or stream data into readable barcodes. Its capacity to accept multiple data types directly into the `BarcodeWriter.CreateBarcode()` method enhances efficiency by eliminating the necessity for explicit type conversions, thereby simplifying the development process and improving productivity.

## Generating Barcodes from String Data

With IronBarcode's `BarcodeWriter.CreateBarcode()`, developers can easily input strings – whether they're textual data, URLs, IDs, numeric codes, or other text formats. Below is an example demonstrating how to encode different types of string data into barcodes:

```cs
using BarCode;
namespace ironbarcode.CreateBarcodeFromData
{
    public class Section1
    {
        public void Run()
        {
            ﻿using IronBarCode;

            string text = "Hello, World!";
            string url = "https://ironsoftware.com/csharp/barcode/";
            string receiptID = "2023-08-04-12345"; // Numeric ID
            string flightID = "FLT2023NYC-LAX123456"; // Alphanumeric ID
            string number = "1234";

            BarcodeWriter.CreateBarcode(text, BarcodeEncoding.Aztec).SaveAsPng("text.png");
            BarcodeWriter.CreateBarcode(url, BarcodeEncoding.QRCode).SaveAsPng("url.png");
            BarcodeWriter.CreateBarcode(receiptID, BarcodeEncoding.Code93, 250, 67).SaveAsPng("receiptID.png");
            BarcodeWriter.CreateBarcode(flightID, BarcodeEncoding.PDF417, 250, 67).SaveAsPng("flightID.png");
            BarcodeWriter.CreateBarcode(number, BarcodeEncoding.Codabar, 250, 67).SaveAsPng("number.png");
        }
    }
}
```
The code above transforms strings into barcodes, demonstrating the capability of handling various data types, and the resultant barcodes can be exported as [Images](https://ironsoftware.com/csharp/barcode/how-to/create-barcode-images/), [Streams](https://ironsoftware.com/csharp/barcode/how-to/export-barcode-as-stream/), [HTML strings](https://ironsoftware.com/csharp/barcode/how-to/create-barcode-as-html/), and [PDF documents](https://ironsoftware.com/csharp/barcode/how-to/create-barcode-as-pdf/). Here are the barcode images produced by the code:

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

<div>Create Barcode From Byte Array
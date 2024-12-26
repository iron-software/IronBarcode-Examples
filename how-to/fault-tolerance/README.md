# Establishing Fault Tolerance in Barcodes

***Based on <https://ironsoftware.com/how-to/fault-tolerance/>***


## Understanding Fault Tolerance

**Fault tolerance** in barcoding refers to the barcode's ability to remain decipherable in spite of having defects such as smudges, scratches, or errors due to various scanning conditions. The level of fault tolerance required is crucial when deciding on the type of barcode encoding needed. Generally, 2D barcodes exhibit greater fault tolerance than their 1D counterparts due to several factors:

- **Data Capacity**: 2D barcodes hold more data because they encode information both horizontally and vertically. This includes alphanumeric characters, binary data, images, and more.
- **Error Correction**: These barcodes implement advanced error correction methods that allow scanners to identify and rectify mistakes, even when parts of the barcode are imperceptible.
- **Redundancy**: 2D barcodes encode data in multiple layers, enhancing the chances of data extraction from parts that remain unharmed.
- **Compactness**: Thanks to their compressed size, 2D barcodes fit into smaller spaces.
- **Flexibility**: They can be scanned from various angles and orientations, thanks to their flexible design.

### Initiating Fault Tolerance using IronBarcode

## Example of Enhancing Fault Tolerance in QR Codes

2D barcodes like **QR Codes**, **DataMatrix**, **PDF417**, and **Aztec** maintain readability through robust Error Correction capabilities. IronBarcode provides the functionality to specifically adjust QR code error correction levels.

Here's how to manage QR code fault tolerance via the `QrErrorCorrection` parameter when using the `QRCodeWriter.CreateQrCode` method. There are four available error correction levels:
- **Highest**: Ensures 30% error correction.
- **High**: Provides 25% error correction.
- **Medium**: Offers 15% error correction.
- **Low**: Affords 7% error correction.

Note that higher levels of error correction result in denser QR codes, thus requiring a balance between visual complexity and fault tolerance for optimal usage.

```cs
using IronBarCode;

// Generate a QR Code with medium error correction
GeneratedBarcode qrWithMediumCorrection = QRCodeWriter.CreateQrCode("https://ironsoftware.com/csharp/barcode/", 500, QRCodeWriter.QrErrorCorrectionLevel.Medium);
qrWithMediumCorrection.SaveAsPng("mediumCorrection.png");
```

Creating a highly fault-tolerant QR code with IronBarcode is straightforward—all it takes is the invocation of the `QRCodeWriter.CreateQrCode` method with the appropriate parameters like value, size, and error correction level. Selecting the right level from the `QRCodeWriter.QrErrorCorrectionLevel` enumeration is essential. After setting these parameters, the method yields a `GeneratedBarcode` object, which can be used for further actions or saved as an image.

## Comparing Error Correction Levels

The following images illustrate QR codes encoded with varying error correction intensities. As can be seen, increased error correction leads to more complex patterns in the QR codes, enhancing their fault tolerance.

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 45%;">
        <img src="https://ironsoftware.com/static-assets/barcode/how-to/fault-tolerance/highest-correction.png" alt="Highest Error Correction" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Highest Error Correction</p>
    </div>
    <div class="competitors__card" style="width: 45%;">
        <img src="https://ironsoftware.com/static-assets/barcode/how-to/fault-tolerance/high-correction.png" alt="High Error Correction" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic; margin-bottom: 20px;">High Error Correction</p>
    </div>
</div>

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 45%;">
        <img src="https://ironsoftware.com/static-assets/barcode/how-to/fault-tolerance/medium-correction.png" alt="Medium Error Correction" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Medium Error Correction</p>
    </div>
    <div class="competitors__card" style="width: 45%;">
        <img src="https://ironsoftware.com/static-assets/barcode/how-to/fault-tolerance/low-correction.png" alt="Low Error Correction" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Low Error Correction</p>
    </div>
</div>
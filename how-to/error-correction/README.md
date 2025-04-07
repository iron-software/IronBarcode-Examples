# How to Adjust Error Correction Levels in Barcodes

***Based on <https://ironsoftware.com/how-to/error-correction/>***


## Understanding Error Correction in Barcodes

**Error Correction** is a crucial feature in barcodes that enhances their reliability by maintaining readability despite visual impairments or encoding inaccuracies. Such issues might result from printing errors, smudges, scratches, or inconsistent scanning environments. Choosing the right type of barcode encoding often depends on its error correction capabilities.

Typically, 2D barcodes exhibit greater resilience against defects compared to 1D barcodes due to several reasons:

- **Data Capacity**: 2D barcodes can encapsulate a larger amount of data as they encode information in both horizontal and vertical dimensions. This includes text, binary content, images, and more.
- **Redundancy**: The multilayer data encoding in 2D barcodes assists in retrieving information even if parts of the barcode are damaged.
- **Compactness**: Their small size makes 2D barcodes ideal for limited spaces.
- **Flexibility**: These barcodes can be effectively scanned from various orientations and angles.

## How to Configure Error Correction in QR Codes

Presently, with IronBarcode, setting error correction is only feasible for **QR Codes**, **Micro QR Codes**, and **rMQRs**. IronBarcode accommodates all four predefined error correction levels according to the QR standards. The error correction level can be modified using the `QrErrorCorrection` option in the `QRCodeWriter.CreateQrCode` method. These levels include:
- **Highest**: Level **H**, capable of restoring up to 30% of the data.
- **High**: Level **Q**, capable of restoring up to 25% of the data.
- **Medium**: Level **M**, capable of restoring up to 15% of the data.
- **Low**: Level **L**, capable of restoring up to 7% of the data.

It's important to note that higher levels of error correction generate more complex QR code images, balancing between error resilience and visual simplicity is necessary. The code snippet below illustrates how to apply medium error correction:

```cs
using IronBarCode;

GeneratedBarcode mediumCorrectionCode = QRCodeWriter.CreateQrCode("https://ironsoftware.com/csharp/barcode/", 500, QRCodeWriter.QrErrorCorrectionLevel.Medium);
mediumCorrectionCode.SaveAsPng("mediumCorrection.png");
```

## Comparing Error Correction Levels

The following visual comparison illustrates the QR Code at different levels of error correction. Notably, higher error correction levels yield more complex images but enhance error resilience.

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 45%;">
        <img src="https://ironsoftware.com/static-assets/barcode/how-to/error-correction/highest-correction.png" alt="Highest Error Correction" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Highest Error Correction</p>
    </div>
    <div class="competitors__card" style="width: 45%;">
        <img src="https://ironsoftware.com/static-assets/barcode/how-to/error-correction/high-correction.png" alt="High Error Correction" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic; margin-bottom: 20px;">High Error Correction</p>
    </div>
</div>

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 45%;">
        <img src="https://ironsoftware.com/static-assets/barcode/how-to/error-correction/medium-correction.png" alt="Medium Error Correction" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Medium Error Correction</p>
    </div>
    <div class="competitors__card" style="width: 45%;">
        <img src="https://ironsoftware.com/static-assets/barcode/how-to/error-correction/low-correction.png" alt="Low Error Correction" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Low Error Correction</p>
    </div>
</div>
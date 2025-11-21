# Implementing Error Correction Techniques in Barcodes

***Based on <https://ironsoftware.com/how-to/error-correction/>***


**Error Correction** capabilities in barcode technology ensure that barcodes remain readable even when they encounter visual defects. Defects could result from numerous issues, including printing errors, smudges, or scratches, as well as from differing scanning environments. The choice of barcode encoding often revolves around error correction capabilities.

Generally, 2D barcodes are better equipped against defects than their 1D counterparts for several reasons:

- **Data Capacity**: Unlike 1D barcodes, 2D barcodes hold vast amounts of data vertically and horizontally, supporting various data forms such as texts, binary, and images.
- **Redundancy**: In 2D barcodes, data is encoded in multiple layers, which means even if parts are damaged, data can still be retrieved from the intact areas.
- **Compactness**: Their small size makes 2D barcodes ideal for space-restricted items.
- **Scanning Versatility**: These barcodes can be recognized from multiple angles and orientations.

## Quickstart: Incorporating Error Correction Levels in QR Code Generation

Creating QR codes with predefined error correction levels is simple using IronBarcode. Set the desired error correction using the `CreateQrCode` method, which includes parameters for content, size, and error correction level. Here’s an example of creating a medium level error-corrected QR code:

```cs
:title=Instant QR Code Generation with Medium Error Correction
// Generating a new QR code with medium error correction level
var qrCode = IronBarCode.QRCodeWriter.CreateQrCode(
    "https://ironsoftware.com",  // QR Code content
    500,                         // QR Code size as 500x500 pixels
    IronBarCode.QRCodeWriter.QrErrorCorrectionLevel.Medium  // Set error correction level to Medium
).SaveAsPng("qrMedium.png");  // Save the QR code as PNG
```

## Modifying Error Correction Levels in QR Codes

IronBarcode allows customization of error correction across QR Codes, Micro QRs, and rMQRs, adhering to all four standard error correction levels defined in QR code specifications. These levels are adjustable via the `QrErrorCorrection` option in `QRCodeWriter.CreateQrCode`. They include:

- **Highest**: Level **H** (up to 30% data recovery)
- **High**: Level **Q** (up to 25% data recovery)
- **Medium**: Level **M** (up to 15% data recovery)
- **Low**: Level **L** (up to 7% data recovery)

High levels of error correction generate denser QR codes and necessitate a balance between visibility and reliability. Here is how you can configure this:

```csharp
// Including the necessary IronBarCode namespace
using IronBarCode;

// Creating a QR code with specific URL, dimension, and error correction
GeneratedBarcode qr = QRCodeWriter.CreateQrCode(
    "https://ironsoftware.com/csharp/barcode/", // URL included in QR
    500,                                        // QR size in pixels
    QRCodeWriter.QrErrorCorrectionLevel.Medium // Medium error correction level
);

// Saving the QR code image in PNG format
qr.SaveAsPng("errorMediumCorrection.png");
```

## Visual Comparison of Error Correction Levels

Below are QR Code samples that depict varying levels of error correction from the same content, demonstrating how more robust error correction contributes to increased QR code complexity and enhanced tolerance to faults.

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
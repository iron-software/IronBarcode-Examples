# Understanding Fault Tolerance in Barcodes

***Based on <https://ironsoftware.com/how-to/fault-tolerance/>***


## Explaining Fault Tolerance

**Fault tolerance** refers to a barcode’s capability to remain scannable despite being partially obscured or physically damaged. This can happen due to several reasons such as scratches, smears, or print-quality issues, which may compromise the integrity of the barcode. It's critical for determining the appropriate barcode type for different applications.

Typically, 2D barcodes offer better fault tolerance compared to 1D barcodes, due to the following reasons:

- **Data Capacity**: Unlike 1D barcodes, 2D barcodes can encode information both horizontally and vertically, accommodating more complex data including text, binary, and images.
- **Error Correction**: They integrate advanced error correction mechanisms that allow scanners to identify and rectify mistakes, ensuring reliability even when the barcode is partially damaged.
- **Redundancy**: By encoding information in multiple data layers, 2D barcodes ensure data can be retrieved even from damaged sections.
- **Compactness**: Their design allows for utilization in smaller spaces without losing data integrity.
- **Flexibility**: These barcodes can be decoded from various angles and alignments, enhancing usability.

## Implementing Fault Tolerance in QR Codes

2D barcode formats like **QR Codes**, **DataMatrix**, **PDF417**, and **Aztec** include built-in Error Correction features to enhance readability under damage. IronBarcode offers tools to specifically adjust this feature in QR codes.

Adjusting the **QrErrorCorrection** parameter in the `QRCodeWriter.CreateQrCode` method controls the fault tolerance, available in four levels:
- **Highest**: 30% error correction
- **High**: 25% error correction
- **Medium**: 15% error correction
- **Low**: 7% error correction

The higher the error correction level, the more complex the QR code image becomes. This requires balancing between image clarity and error resilience when creating QR codes.

```cs
using IronBarCode;
using BarCode;
namespace ironbarcode.FaultTolerance
{
    public class BarcodeGenerator
    {
        public void Execute()
        {
            GeneratedBarcode mediumCorrectionBarcode = QRCodeWriter.CreateQrCode("https://ironsoftware.com/csharp/barcode/", 500, QRCodeWriter.QrErrorCorrectionLevel.Medium);
            mediumCorrectionBarcode.SaveAsPng("mediumCorrectionBarcode.png");
        }
    }
}
```

This snippet exemplifies how IronBarcode simplifies the creation of robust QR codes with just a couple of lines: you instantiate a QR code with desired parameters and save the output.

## Contrasting Levels of Error Correction

Here's an illustrative comparison of QR codes with different error correction settings, showcasing varying complexity and robustness.

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
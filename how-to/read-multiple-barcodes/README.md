# Reading Multiple Barcodes Simultaneously

***Based on <https://ironsoftware.com/how-to/read-multiple-barcodes/>***


Scanning multiple barcodes in one go is essential across various sectors, such as logistics, healthcare, retail, and inventory management. This ability facilitates efficient data processing. Using IronBarcode, this process is simplified, enhancing operational efficiency and productivity.

## Multiple Barcodes Reading Example

IronBarcode’s default mode includes scanning for multiple barcodes when parsing documents. However, occasional issues have been reported where the return is limited to a single barcode value, despite the presence of multiple barcodes in an image. To rectify this, the settings can be adjusted to specifically enable the reading of multiple barcodes. This adjustment is applicable through the **ExpectMultipleBarcode** setting, found in both **BarcodeReaderOptions** and **PdfBarcodeReaderOptions**, catering to images and PDFs respectively.

#### Example Image

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/barcode/how-to/read-multiple-barcodes/multiple-barcodes.png" alt="Image to be read" class="img-responsive add-shadow">
    </div>
</div>

```cs
using System;
using BarCode;

namespace ironbarcode.ReadMultipleBarcodes
{
    public class MultipleBarcodesReader
    {
        public void Execute()
        {
            // Configure to read multiple barcodes
            BarcodeReaderOptions options = new BarcodeReaderOptions()
            {
                ExpectMultipleBarcodes = true,
                ExpectBarcodeTypes = BarcodeEncoding.AllOneDimensional,
            };

            // Initiate barcode read
            var barcodeResults = BarcodeReader.Read("testbc1.png", options);

            // Output each barcode result to the console
            foreach (var barcode in barcodeResults)
            {
                Console.WriteLine(barcode.ToString());
            }
        }
    }
}
```

With the **ExpectMultipleBarcodes** set to true, IronBarcode performs an exhaustive scan for barcodes across the entire document and stores the results in **BarcodeResults**. Using a `foreach` loop, these barcode values are then accessed and printed.

## Single Barcode Reading Example

IronBarcode is adept at reading both single and multiple barcodes from images or PDFs. By default, the entire document is scanned, even for a single barcode. For enhanced performance during single barcode reads, setting **ExpectMultipleBarcodes** to false ceases the scanning process post the first detected barcode, thus speeding up data retrieval. The example below illustrates this setting adjustment.

#### Example Image

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/barcode/how-to/read-multiple-barcodes/multiple-barcodes.png" alt="Image to be read" class="img-responsive add-shadow">
    </div>
</div>

```cs
using System;
using BarCode;

namespace ironbarcode.ReadMultipleBarcodes
{
    public class SingleBarcodeReader
    {
        public void Execute()
        {
            // Configure to read a single barcode
            BarcodeReaderOptions options = new BarcodeReaderOptions()
            {
                ExpectMultipleBarcodes = false,
                ExpectBarcodeTypes = BarcodeEncoding.AllOneDimensional,
            };

            // Initiate barcode read
            var barcodeResults = BarcodeReader.Read("testbc1.png", options);

            // Output the first (or only) barcode result to the console
            foreach (var barcode in barcodeResults)
            {
                Console.WriteLine(barcode.ToString());
            }
        }
    }
}
```

### Performance Comparison

Adjusting **ExpectMultipleBarcodes** influences the efficiency of barcode readings. Below is an indicative performance comparison using the same settings on the same device:

| Setting: ExpectMultipleBarcodes = true | Setting: ExpectMultipleBarcodes = false |
|-----------------------------------------|----------------------------------------|
| 00.91 second                            | 00.10 second                           | 

By setting **ExpectMultipleBarcodes** to false, the process becomes notably quicker for single barcode scans.
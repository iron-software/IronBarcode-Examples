***Based on <https://ironsoftware.com/tutorials/reading-barcodes/>***

c class Section3
    {
        public void Run()
        {
            BarcodeReaderOptions options = new BarcodeReaderOptions()
            {
                // Apply specific image filters
                ImageFilters = new ImageFilterCollection() {
                    new AdaptiveThresholdFilter(),
                },
                
                // Automatically correct image orientation using machine learning
                AutoRotate = true,
            };
            
            // Commence barcode reading with advanced options
            BarcodeResults results = BarcodeReader.Read("TryHarderQR.png", options);
        }
    }
}

<hr>

## Reading Multiple Barcodes

### PDF Documents

This example demonstrates scanning a [scanned PDF document](https://ironsoftware.com/img/tutorials/reading-barcodes/MultipleBarcodes.pdf) to detect all embedded one-dimensional barcode formats swiftly:

```cs
using System;
using BarCode;
namespace ironbarcode.ReadingBarcodes
{
    public class Section4
    {
        public void Run()
        {
            // Scanning multiple barcodes from a PDF document
            BarcodeResults results = BarcodeReader.ReadPdf("MultipleBarcodes.pdf");
            
            // Processing and displaying each result
            foreach (var pageResult in results)
            {
                Console.WriteLine($"{pageResult.Value} found on page {pageResult.PageNumber}");
                // Additional data could also be logged here
            }
        }
    }
}
```

The scan results include barcodes from different pages as shown below.

<center>
<img src="https://ironsoftware.com/img/tutorials/reading-barcodes/MultipleBarcodes.png" alt="C# - Reading Barcodes from a PDF results" class="img-responsive add-shadow img-margin" style="max-width:250px">
</center>

### Scans TIFFs

Similarly, barcode extraction from a multi-frame TIFF yields comparable outcomes:

<center>
<img src="https://ironsoftware.com/img/tutorials/reading-barcodes/Multiframe.tiff.overview.png" alt="C# - Reading Barcodes from a multi-frame TIFF image"  class="img-responsive add-shadow img-margin" style="max-width:100%">
</center>

```cs
using IronBarCode;
using BarCode;
namespace ironbarcode.ReadingBarcodes
{
    public class Section5
    {
        public void Run()
        {
            // Leveraging IronBarcode to scan multi-frame TIFF images
            BarcodeResults multiFrameResults = BarcodeReader.Read("Multiframe.tiff");
            
            // Process results
            foreach (var pageResult in multiFrameResults)
            {
                // Implement required actions based on each barcode found
            }
        }
    }
}
```

### MultiThreading

Utilizing multithreading in IronBarcode enhances barcode scanning performance across diverse document types.

```cs
using IronBarCode;
using BarCode;
namespace ironbarcode.ReadingBarcodes
{
    public class Section6
    {
        public void Run()
        {
            // Preparing documents for batch scanning
            var ListOfDocuments = new[] { "image1.png", "image2.JPG", "image3.pdf" };
            
            BarcodeReaderOptions options = new BarcodeReaderOptions()
            {
                Multithreaded = true,
            };
            
            // Performing a multithreaded scan
            BarcodeResults batchResults = BarcodeReader.Read(ListOfDocuments, options);
        }
    }
}
```

## Summary  

IronBarcode stands as a robust .NET library and C# tool capable of reading a variety of barcode formats, either from pristine digital images or imperfect real-world sources.

### Further Reading 

For additional insights on working with IronBarcode, explore other tutorials or examples provided on our homepage [API Reference](https://ironsoftware.com/csharp/barcode/object-reference/).

### Source Code Downloads

Download and run the tutorials by visiting our [Tutorial Github Repository](https://github.com/iron-software/Iron-Barcode-Reading-Barcodes-In-CSharp) or downloading directly from [C# Source Code in a Zip File](https://ironsoftware.com/downloads/assets/tutorials/reading-barcodes/Iron-Barcode-Reading-Barcodes-In-CSharp.zip).
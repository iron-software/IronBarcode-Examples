# Barcodes & QR Codes with C# & VB.NET Using Iron Barcode

***Based on <https://ironsoftware.com/docs/docs/>***


Creating and interpreting barcodes in C# and VB.NET is straightforward with the Iron Barcode library from Iron Software.

## Installing IronBarcode

Begin by acquiring Iron Barcode either through the NuGet package manager or by [downloading the DLL](https://ironsoftware.com/csharp/barcode/packages/IronBarCode.zip) directly from our site. You can access all Iron Barcode features from the `IronBarcode` namespace.

For a hassle-free installation, use the NuGet Package Manager within Visual Studio:
The package to install is “Barcode”.

```shell
Install-Package BarCode
```

Learn more about this package on [NuGet](https://www.nuget.org/packages/Barcode/).

## How to Read a Barcode or QR Code

To read barcodes, Iron Barcode requires only a few lines of code:

```cs
using IronBarCode;
using BarCode;
namespace ironbarcode.Quickstart
{
    public class Section1
    {
        public void ReadSingleBarcode()
        {
            BarcodeResults results = BarcodeReader.Read("QuickStart.jpg");
            if (results != null)
            {
                foreach (BarcodeResult result in results)
                {
                    Console.WriteLine(result.Text);
                }
            }
        }
    }
}
```

To optimize barcode reading, specify the barcode types to detect, enable or disable multiple barcode reading, or define a region of interest:

```cs
using IronBarCode;
using BarCode;
namespace ironbarcode.Quickstart
{
    public class Section2
    {
        public void RunWithOptions()
        {
            BarcodeReaderOptions options = new BarcodeReaderOptions()
            {
                ExpectMultipleBarcodes = false,
                ExpectBarcodeTypes = BarcodeEncoding.QRCode | BarcodeEncoding.Code128,
                CropArea = new System.Drawing.Rectangle(100, 200, 300, 400),
            };

            BarcodeResults result = BarcodeReader.Read("QuickStart.jpg", options);
            if (result != null)
            {
                Console.WriteLine(result.First().Text);
            }
        }
    }
}
```

You can also scan multiple barcodes from an image:

```cs
using IronBarCode;
using BarCode;
namespace ironbarcode.Quickstart
{
    public class Section3
    {
        public void ScanMultipleBarcodes()
        {
            BarcodeResults results = BarcodeReader.Read("MultipleBarcodes.png");

            foreach (BarcodeResult result in results)
            {
                string value = result.Value;
                Bitmap img = result.BarcodeImage;
                BarcodeEncoding barcodeType = result.BarcodeType;
                byte[] binary = result.BinaryValue;
                Console.WriteLine(value);
            }
        }
    }
}
```

Additionally, Iron Barcode can analyze barcodes from PDF files or multipage TIFFs with advanced image corrections:

```cs
using IronBarCode;
using BarCode;
namespace ironbarcode.Quickstart
{
    public class Section4
    {
        public void ReadFromDocuments()
        {
            BarcodeResults pagedResults = BarcodeReader.Read("MultipleBarcodes.pdf");

            foreach (BarcodeResult result in pagedResults)
            {
                int pageNumber = result.PageNumber;
                string value = result.Value;
                Bitmap img = result.BarcodeImage;
                BarcodeEncoding barcodeType = result.BarcodeType;
                byte[] binary = result.BinaryValue;
                Console.WriteLine(value);
            }
            
            BarcodeResults multiFrameResults = BarcodeReader.Read(inputImage: "Multiframe.tiff", new BarcodeReaderOptions
            {
                Speed = ReadingSpeed.Detailed,
                ExpectMultipleBarcodes = true,
                ExpectBarcodeTypes = BarcodeEncoding.Code128,
                Multithreaded = false,
                RemoveFalsePositive = false,
                ImageFilters = null
            });
        }
    }
}
```

## Generating Barcodes

To generate barcodes, use the `BarcodeWriter` class. It is a simplified process where you define the barcode type and the content. Here's how to create and save it as an image:

```cs
using IronBarCode;
using BarCode;
namespace ironbarcode.Quickstart
{
    public class Section5
    {
        public void GenerateBarcode()
        {
            GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode", BarcodeEncoding.Code128);
            myBarcode.SaveAsImage("myBarcode.png");
        }
    }
}
```

Further customize your barcodes using the Fluent API for visual modifications and text annotations:

```cs
using IronBarCode;
using BarCode;
namespace ironbarcode.Quickstart
{
    public class Section6
    {
        public void CustomizeAndAnnotateBarcode()
        {
            GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode",
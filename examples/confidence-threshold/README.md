***Based on <https://ironsoftware.com/examples/confidence-threshold/>***

Since December 2023, IronBarcode has leveraged machine learning technologies to boost its barcode recognition abilities. Developers can adjust the **`ConfidenceThreshold`** parameter within the `BarcodeReaderOptions` to specify the lowest confidence level acceptable for detections by the ML model. This threshold can be set anywhere from `0.0` to `1.0`, and the default value is `0.7`.

For those looking to perform barcode detection without the machine learning enhancement, the [Barcode.Slim](https://www.nuget.org/packages/BarCode.Slim) package is a viable alternative.

Explore advanced image correction techniques with IronBarcode through this detailed guide: [Learning Image Correction Techniques with IronBarcode](https://ironsoftware.com/csharp/barcode/how-to/image-correction/).
***Based on <https://ironsoftware.com/examples/confidence-threshold/>***

As of December 2023, IronBarcode has integrated machine learning to improve its barcode recognition capability. Adjust the `ConfidenceThreshold` property within `BarcodeReaderOptions` to specify the minimum confidence level required for detections by the ML model to be deemed accurate. This threshold can be set anywhere from 0.0 to 1.0, with a default value of 0.7.

For those looking to perform barcode detection without the assistance of machine learning, the [Barcode.Slim](https://www.nuget.org/packages/BarCode.Slim) package is an excellent alternative.
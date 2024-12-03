***Based on <https://ironsoftware.com/examples/confidence-threshold/>***

As of December 2023, IronBarcode has integrated machine learning technologies to advance its ability to detect barcodes accurately. Adjust the `ConfidenceThreshold` setting in the `BarcodeReaderOptions` to specify the lowest acceptable confidence level for barcode identifications made by the machine learning model. This threshold can be set anywhere from 0.0 to 1.0, with the standard configuration being 0.7.

For those opting to detect barcodes without the machine learning enhancement, the [Barcode.Slim](https://www.nuget.org/packages/BarCode.Slim) package is recommended.
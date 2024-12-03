***Based on <https://ironsoftware.com/examples/barcode-quickstart/>***

The class `BarcodeWriter.CreateBarcode` enables the generation of barcodes and QR codes from textual, numerical, or binary inputs and supports encoding them into suitable formats. To save these barcodes, you can use the `SaveAsImage()` function for producing images, or other convenient methods for storing in formats like PDF, HTML, `System.Drawing.Image`, streams, or `Bitmap` objects.

On the flip side, for reading barcodes, the `BarcodeReader` class is your go-to resource. A straightforward approach for its operation is utilizing the `BarcodeReader.Read` method, as illustrated previously.

Important to note are the various settings available under `BarcodeReaderOptions`. These settings provide customization capabilities that enhance the reading process, including speeding up the reading, increasing scan thoroughness, halting the scan after detecting the first barcode to conserve time, filtering for particular barcode types, and implementing multithreading, among other adjustable features.
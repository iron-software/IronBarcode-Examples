***Based on <https://ironsoftware.com/examples/qrcoder-csharp-example/>***

The `BarcodeWriter.CreateBarcode` class is instrumental for generating barcodes and QR codes from various data types such as strings, numbers, or binary data. Once created, these can be encoded into a desired format. To export these barcodes, one might utilize the `SaveAsImage()` function, though there are several other methods available for saving to formats like PDF, HTML, System.Drawing.Image, stream, or even directly into a Bitmap object.

Similarly, barcodes can be scanned and read using the `BarcodeReader` class. A straightforward approach to accomplish this is by employing the `BarcodeReader.Read` function.

It's essential to be aware of the multiple configurations available within `BarcodeReaderOptions`. These configurations can enhance the reading process by making it quicker, more thorough, even allowing the process to halt after decoding a single barcode to conserve time. Additionally, you can specify the exact types of barcode you wish to detect and take advantage of multithreading capabilities for improved efficiency and performance.
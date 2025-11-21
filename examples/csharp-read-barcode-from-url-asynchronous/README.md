***Based on <https://ironsoftware.com/examples/csharp-read-barcode-from-url-asynchronous/>***

Utilizing the `BarcodeReader` class, you can efficiently scan barcodes. The most direct approach is to employ the `BarcodeReader.Read` method. Additionally, IronBarcode is equipped with a `ReadAsync` method, perfect for asynchronous programming that leverages multiple threads.

### Key Points

- **Synchronous vs Asynchronous Methods**
  - The `Read` method is ideal for scenarios where immediate barcode data retrieval is necessary and it operates on the main thread.
  - The `ReadAsync` method facilitates asynchronous operations, permitting the continuation of other processes whilst the barcode read operation completes.

- **`BarcodeReaderOptions`**
  - `ExpectMultipleBarcodes`: When enabled (set to `true`), this option commands the reader to search for multiple barcodes within a single image.
  - `EnhanceAccuracy`: This setting bolsters the precision of the barcode reads, albeit at a slower pace.
  - `SpeedUp`: Designed to expedite the reading process, useful for handling large volumes of images swiftly, though it may compromise accuracy when activated.

[Discover more about Asynchronous and Multithreaded Barcode Reading](https://ironsoftware.com/csharp/barcode/how-to/async-multithread/)
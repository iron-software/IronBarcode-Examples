# Exploring Asynchronous and Multithreading Operations in IronBarcode

***Based on <https://ironsoftware.com/how-to/async-multithread/>***


The concepts of **Asynchronous** and **Multithreading** operations are often misunderstood. Both are designed to improve software performance and efficiency through better resource management and reduced execution time. Yet, their implementation and applications differ. Using IronBarcode, this guide will elucidate these differences and demonstrate how to leverage each technique effectively.

## Example: Asynchronous Barcode Reading

Asynchronous operations allow potentially blocking or long-running tasks to be performed without stopping the execution of the main thread. In the C# programming environment, this is achieved using the `async` and `await` keywords with supported methods, allowing the main thread to be freed up for other tasks. This is ideal for I/O-bound tasks where the main thread can continue with other work until called upon by the asynchronous task.

For barcode reading, consider this process:
1. The file is read.
2. Reading configurations are applied.
3. The barcode is decoded.

During the file reading phase, the main task can yield control.

To read barcodes asynchronously from images and PDF documents, use `ReadAsync` and `ReadPdfAsync` respectively.

```cs
using IronBarCode;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ironbarcode.AsyncMultithread
{
    public class AsyncExample
    {
        public async Task ReadBarcodesAsync()
        {
            var imagePaths = new List<string> { "image1.png", "image2.png" };

            // Define barcode reading settings
            var options = new BarcodeReaderOptions
            {
                ExpectMultipleBarcodes = true
            };

            // Asynchronous barcode reading
            var asyncResults = await BarcodeReader.ReadAsync(imagePaths, options);

            // Output results to the console
            foreach (var result in asyncResults)
            {
                Console.WriteLine(result.ToString());
            }
        }
    }
}
```
This example demonstrates reading a list of images for barcodes asynchronously. You set the image paths and configure the read options before awaiting the read operation, which frees up the main thread in the meantime.

#### Multithreading Example for Barcode Reading

Multithreading facilitates executing a single process across multiple threads concurrently, as opposed to sequentially in a single thread. This involves partitioning tasks among various threads, enabling simultaneous execution. To utilize multiple CPU cores effectively, multithreading can dramatically improve application responsiveness and performance.

Configure multithreading in IronBarcode by setting the `Multithreaded` property and specifying `MaxParallelThreads`:

```cs
using IronBarCode;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ironbarcode.AsyncMultithread
{
    public class MultithreadExample
    {
        public void ReadBarcodesMultithread()
        {
            var imagePaths = new List<string> { "test1.jpg", "test2.png" };

            // Multithreaded barcode reading settings
            var options = new BarcodeReaderOptions
            {
                Multithreaded = true,
                MaxParallelThreads = 4,
                ExpectMultipleBarcodes = true
            };

            // Execute barcode reading on multiple threads
            var results = BarcodeReader.Read(imagePaths, options);

            // Display results
            foreach (var result in results)
            {
                Console.WriteLine(result.ToString());
            }
        }
    }
}
```

### Comparing Performance: Normal vs. Asynchronous vs. Multithreading

#### Review of Sample Images

<div class="competitors-section__wrapper-even-1" style="margin-bottom: 40px;">
    <div class="competitors__card" style="width: 45%;">
        <img src="https://ironsoftware.com/static-assets/barcode/how-to/async-multithread/sample1.webp" alt="Image 1" class="img-responsive add-shadow">
    </div>
    <div class="competitors__card" style="width: 53%;">
        <img src="https://ironsoftware.com/static-assets/barcode/how-to/async-multithread/sample2.webp" alt="Image 2" class="img-responsive add-shadow">
    </div>
</div>

<table class="table" style="text-align: center;">
    <tr style="background-color: rgb(241 249 251);">
        <th style="text-align: center;">Normal Read</th>
        <th style="text-align: center;">Asynchronous Read</th>
        <th style="text-align: center;">Multithreaded Read (4 cores)</th>
    </tr>
    <tr>
        <td>01.75 second</td>
        <td>01.67 second</td>
        <td>01.17 second</td>
    </tr>
</table>

The table above illustrates the performance improvements offered by asynchronous and multithreaded techniques compared to conventional methods. Selection between asynchrony and multithreading will depend on specific application needs.

For additional details and examples on handling multiple barcodes within a single document, please visit [IronBarcode’s Guide on Reading Multiple Barcodes](https://ironsoftware.com/csharp/barcode/how-to/read-multiple-barcodes/).
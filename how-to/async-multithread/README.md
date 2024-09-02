# Understanding Async and Multithreading in IronBarcode

The concepts of **Async** and **Multithreading** can often be mixed up, but they serve distinct purposes in enhancing software performance by optimizing the use of system resources and minimizing runtime. This guide walks through the distinction and practical implementation of each within the context of IronBarcode.

## Implementing Asynchronous Barcode Reading

Asynchronous operations allow intensive processes to run without halting the execution of the main thread. This approach is particularly useful in C# where you can utilize the `async` and `await` keywords with methods that support asynchronous capabilities. Such methods don't create new threads but instead release the main thread while processing, allowing the application to remain responsive.

Here’s how you can utilize IronBarcode for asynchronous barcode reading:

1. Read file
2. Apply decoding options
3. Decode barcode

During the file reading step, the other tasks aren't blocked.

To read barcodes asynchronously from images and PDFs, use the `ReadAsync` and `ReadPdfAsync` methods, respectively.

```cs
using IronBarCode;
using System.Threading.Tasks;
using System.Collections.Generic;

public class AsyncBarcodeExample
{
    public static async Task ReadBarcodesAsync()
    {
        var imagePaths = new List<string> { "image1.png", "image2.png" };

        // Configure barcode reading options
        var options = new BarcodeReaderOptions
        {
            ExpectMultipleBarcodes = true
        };

        // Asynchronous reading from a list of image paths
        var results = await BarcodeReader.ReadAsync(imagePaths, options);

        // Output the results to the console
        foreach (var result in results)
        {
            System.Console.WriteLine(result.ToString());
        }
    }
}
```

Here, barcodes from a series of image paths are read asynchronously with configured options. The application does not wait idly during reads but continues with other operations, leading to better performance and responsiveness.

## Multithreaded Barcode Reading

Multithreading spreads a process across several threads running concurrently, increasing the efficiency of applications on multi-core processors. Unlike asynchronous operations, which are more suited for tasks waiting on external operations, multithreading divides task execution among several threads.

Here's how to enable and utilize multithreading in IronBarcode:

- Set the `Multithreaded` property.
- Specify the number of cores to use concurrently through `MaxParallelThreads`.

By default, `MaxParallelThreads` is set to 4 but can be tailored according to the processor capabilities.

```cs
using IronBarCode;
using System.Collections.Generic;

public class MultithreadBarcodeExample
{
    public static void ReadBarcodesMultithreaded()
    {
        var imagePaths = new List<string> {"test1.jpg", "test2.png"};

        var options = new BarcodeReaderOptions
        {
            Multithreaded = true,
            MaxParallelThreads = 4,
            ExpectMultipleBarcodes = true
        };

        var results = BarcodeReader.Read(imagePaths, options);

        foreach (var result in results)
        {
            System.Console.WriteLine(result.ToString());
        }
    }
}
```

### Performance Implications

The performance benefits of both asynchronous and multithreaded approaches are significant. To illustrate, examine the barcode reading times from two sample images below:

#### Sample Images

<div class="competitors-section__wrapper-even-1" style="margin-bottom: 40px;">
    <div class="competitors__card" style="width: 45%;">
        <img src="https://ironsoftware.com/static-assets/barcode/how-to/async-multithread/sample1.webp" alt="Sample Image 1" class="img-responsive add-shadow">
    </div>
    <div class="competitors__card" style="width: 53%;">
        <img src="https://ironsoftware.com/static-assets/barcode/how-to/async-multithread/sample2.webp" alt="Sample Image 2" class="img-responsive add-shadow">
    </div>
</div>

<table class="table" style="text-align: center;">
    <tr style="background-color: rgb(241 249 251);">
        <th>Normal Read</th>
        <th>Asynchronous Read</th>
        <th>Multithreaded Read (4 cores)</th>
    </tr>
    <tr>
        <td>1.75 seconds</td>
        <td>1.67 seconds</td>
        <td>1.17 seconds</td>
    </tr>
</table>

The performance enhancement with asynchronous and multithreaded operations is noticeable. Both techniques hold their unique use cases and can work wonders for applications that need to manage heavy workloads efficiently. Deciding which technique to use will depend on the specific requirements and the nature of the tasks in your application.

For further guidance on handling multiple barcodes in a single document, refer to our guide [Read Multiple Barcodes](https://ironsoftware.com/csharp/barcode/how-to/read-multiple-barcodes/).
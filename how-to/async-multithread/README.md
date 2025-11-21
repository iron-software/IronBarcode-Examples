# Understanding Async and Multithreading Techniques

***Based on <https://ironsoftware.com/how-to/async-multithread/>***


The concepts of `Async` and `Multithreading` are commonly confused, yet they are distinct approaches that aim to boost program performance by optimizing how system resources are utilized and decreasing the time it takes for programs to run. IronBarcode facilitates using both techniques. This article will delve into their differences and demonstrate how they can be implemented using IronBarcode.

## Quickstart: Async & Multithreaded Barcode Reading Example

Get started quickly with IronBarcode by employing this simple example. Discover how effortlessly you can perform asynchronous and multithreaded barcode scanning on multiple images simultaneously using minimal preparation.

```cs
:title=Kickstart Async & Multithreaded Barcode Scans
var scanResults = await IronBarCode.BarcodeReader.ReadAsync(imagePaths, new IronBarCode.BarcodeReaderOptions { Multithreaded = true, MaxParallelThreads = 4, ExpectMultipleBarcodes = true });
```

## Example of Reading Barcodes Asynchronously

Understanding asynchronous reading starts with recognizing how it allows extended or blocking operations to continue without halting the main thread's execution. In C#, by using the `async` and `await` keywords along with methods that support asynchronous operations, one can avoid generating new threads and simply release the existing thread. The main thread plays a vital role in starting and managing tasks but isn't bound to just one task, freeing it up for other operations like I/O-bound tasks. 

In barcode reading scenarios, this could look like:

- Loading the barcode file,
- Configuring reading parameters, 
- Executing the decode process.

In the "Loading the barcode file" step, the primary task can be freed.

You can employ `ReadAsync` for images and `ReadPdfAsync` for PDFs to perform asynchronous barcode reading.

```csharp
using IronBarCode;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

List<string> imagePaths = new List<string>() { "image1.png", "image2.png" };

// Setting barcode reading options
BarcodeReaderOptions readOptions = new BarcodeReaderOptions()
{
    ExpectMultipleBarcodes = true
};

// Asynchronous reading
BarcodeResults asyncResults = await BarcodeReader.ReadAsync(imagePaths, readOptions);

// Output the results to the console
foreach (var result in asyncResults)
{
    Console.WriteLine(result.ToString());
}
```

Here, we shown how to configure a list of image paths for asynchronous barcode reading using IronBarcode. This setup also extends to reading PDF documents asynchronously, available through the `ReadPdfAsync` method in the same class.

## Example of Reading Barcodes with Multithreading

Multithreading diverges from asynchronous operations by allowing a process to operate across multiple threads at once, promoting concurrent execution. This technique is highly effective on machines with multiple CPU cores since each core can execute a thread independently. Like asynchronous operations, multithreading enhances application performance and responsiveness.

To employ multithreading in IronBarcode, activate the `Multithreaded` property and define the maximum number of executable cores using `MaxParallelThreads` within `BarcodeReaderOptions`. The default setting for `MaxParallelThreads` is 4, but it is adjustable based on the number of CPU cores available.

```cs
using IronBarCode;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

List<string> imagePaths = new List<string>(){"test1.jpg", "test2.png"};

// Barcode reading configurations
BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    Multithreaded = true,
    MaxParallelThreads = 4,
    ExpectMultipleBarcodes = true
};

// Multithreaded barcode reading
BarcodeResults mtResults = BarcodeReader.Read(imagePaths, options);

// Display the results
foreach (var result in mtResults)
{
    Console.WriteLine(result.ToString());
}
```

### Performance Comparison

Let's compare the reading times for normal, asynchronous, and multithreaded operations using the two images below:

#### Sample Image

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
        <td>01.75 seconds</td>
        <td>01.67 seconds</td>
        <td>01.17 seconds</td>
    </tr>
</table>

The table above clearly shows the performance gains achieved through asynchronous and multithreaded reading. Both techniques serve different purposes and have distinct approaches, requiring careful consideration of which is best suited for your specific application.

For further details on handling multiple barcodes in a single document, visit the [Read Multiple Barcodes Guide](https://ironsoftware.com/csharp/barcode/how-to/read-multiple-barcodes/).
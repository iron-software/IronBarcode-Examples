# Understanding Async and Multithread Techniques

***Based on <https://ironsoftware.com/how-to/async-multithread/>***


Understanding the distinctions between <strong>Async</strong> and <strong>Multithreading</strong> is essential as both strategies aim to boost application performance by optimizing resource use and minimising execution time. They adopt different methods and mechanisms for enhancing program efficiency. IronBarcode effectively implements both techniques. We will delve into these concepts and demonstrate their use with IronBarcode.

## Getting Started with IronBarcode

### Asynchronous Barcode Reading Example

To begin, let's discuss asynchronous barcode reading and its advantages. Asynchronous operations allow time-consuming tasks to run without halting the execution of the main program thread. Using C#, this can be achieved with the **async** and **await** keywords which do not spawn new threads but rather free up the existing thread. The main thread, essential for initiating and overseeing tasks, can switch to other operations during idle times—ideal for I/O tasks like file operations or network calls.

For instance, when reading barcodes, the steps involved are:
- File reading
- Setting reading parameters
- Decoding the barcode

The "File reading" step can relinquish the main thread.

Implement `ReadAsync` and `ReadPdfAsync` for asynchronous barcode reading from images and PDFs respectively.

```cs
using IronBarCode;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

var imagePaths = new List<string> { "image1.png", "image2.png" };

// Define barcode reading options
var options = new BarcodeReaderOptions
{
    ExpectMultipleBarcodes = true
};

// Asynchronously read barcodes
var asyncResult = await BarcodeReader.ReadAsync(imagePaths, options);

// Output the results
foreach (var result in asyncResult)
{
    Console.WriteLine(result.ToString());
}
```

From the above example, `ReadAsync` is utilized from the **BarcodeReader** class to process the listed image paths asynchronously. For PDF barcode reading, employ the `ReadPdfAsync` function, also located within the same class.

### Multithread Barcode Reading Example

Contrastingly, multithreading involves executing a process across multiple threads simultaneously rather than sequentially. This allows tasks to run in parallel, significantly speeding up execution, especially on systems with multiple CPU cores. Like asynchronous methods, multithreading improves application responsiveness.

To use multithreading in IronBarcode, activate the **Multithreaded** flag and define **MaxParallelThreads** in `BarcodeReaderOptions`. The default setting is 4 but can be modified according to the CPU cores available.

To verify CPU cores, navigate: Task Manager -> Performance tab -> See 'Cores' count.

```cs
using IronBarCode;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

var imagePaths = new List<string>{ "test1.jpg", "test2.png" };

// Set up barcode reader options for multithreading
var options = new BarcodeReaderOptions
{
    Multithreaded = true,
    MaxParallelThreads = 4,
    ExpectMultipleBarcodes = true
};

// Execute barcode reading with multithreading
var results = BarcodeReader.Read(imagePaths, options);

// Display the results
foreach (var result in results)
{
    Console.WriteLine(result.ToString());
}
```

### Comparing Performance

Now, let us compare the efficiency of normal, asynchronous, and multithreaded reads using the following sample images.

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
        <td>01.75 second</td>
        <td>01.67 second</td>
        <td>01.17 second</td>
    </tr>
</table>

The table depicts a marked improvement in reading times when using asynchronous and multithreaded techniques. Despite their different applications and methodologies, both strategies enhance performance for various user scenarios.

For additional information on handling documents with multiple barcodes, please refer to the [Read Multiple Barcodes](https://ironsoftware.com/csharp/barcode/how-to/read-multiple-barcodes/) guide.
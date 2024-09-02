using IronBarCode;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

List<string> imagePaths = new List<string>(){"test1.jpg", "test2.png"};

// Barcode reading options
BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    Multithreaded = true,
    MaxParallelThreads = 4,
    ExpectMultipleBarcodes = true
};

// Read barcode with multithreaded enabled
BarcodeResults results = BarcodeReader.Read(imagePaths, options);

// Print the results to console
foreach (var result in results)
{
    Console.WriteLine(result.ToString());
}
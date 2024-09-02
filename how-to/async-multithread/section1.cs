using IronBarCode;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
#endregion
public class async_multithread_async
{
    public async Task codeAsync()
    {
        List<string> imagePaths = new List<string>() { "image1.png", "image2.png" };

        // Barcode reading options
        BarcodeReaderOptions options = new BarcodeReaderOptions()
        {
            ExpectMultipleBarcodes = true
        };

        // Read barcode using Async
        BarcodeResults asyncResult = await BarcodeReader.ReadAsync(imagePaths, options);

        // Print the results to console
        foreach (var result in asyncResult)
        {
            Console.WriteLine(result.ToString());
        }
    
using IronBarCode;
using System;

var options = new BarcodeReaderOptions
{
    // Choose a reading speed from: Faster, Balanced, Detailed, ExtremeDetail
    // There is a tradeoff in performance as more detail is set
    Speed = ReadingSpeed.Balanced,
};

// Read with the options applied
var results = BarcodeReader.Read("barcode.png", options);

// Output the first found value
Console.WriteLine($"Found {results.Values()[0]}");
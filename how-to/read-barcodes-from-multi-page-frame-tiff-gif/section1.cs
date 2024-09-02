using IronBarCode;
using System;

// Read barcode from TIF image
BarcodeResults results = BarcodeReader.Read("sample.tif");

// Output the barcodes value to console
foreach (var result in results)
{
    Console.WriteLine(result.Value);
}
using IronBarCode;
using System;

// Set the option to read single code 39 barcode
BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    ExpectBarcodeTypes = BarcodeEncoding.Code39
};

// Read barcode
var results = BarcodeReader.Read("code39.png", options);

foreach (var result in results)
{
    Console.WriteLine(result.ToString());
}
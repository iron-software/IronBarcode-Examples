using IronBarCode;
using System;

// Read barcode from PNG
BarcodeResults result = BarcodeReader.Read("bc3.png");

// Output barcode type to console
foreach (BarcodeResult barcode in result)
{
    Console.WriteLine("The barcode value is " + barcode.ToString() + " and the barcode type is " + barcode.BarcodeType);
}
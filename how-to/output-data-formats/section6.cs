using IronBarCode;
using System;

// Read barcode from PDF
BarcodeResults result = BarcodeReader.ReadPdf("test.pdf");

// Output page orientation and rotation to console
foreach (BarcodeResult barcode in result)
{
    Console.WriteLine(barcode.Value);
    Console.WriteLine(barcode.PageOrientation);
    Console.WriteLine(barcode.Rotation);
}
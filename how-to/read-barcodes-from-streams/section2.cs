using IronBarCode;
using IronPdf;
using System;
using System.IO;

MemoryStream document = PdfDocument.FromFile(@"file_path.pdf").Stream;

var myBarcode = BarcodeReader.ReadPdf(document);

foreach (var value in myBarcode)
{
    Console.WriteLine(value.ToString());
}
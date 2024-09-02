using IronBarCode;
using System;

GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.QRCode);
var htmlTag = myBarcode.ToHtmlTag();
Console.WriteLine(htmlTag);
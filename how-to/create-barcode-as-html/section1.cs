using IronBarCode;
using System;

GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.QRCode);
var dataUrl = myBarcode.ToDataUrl();
Console.WriteLine(dataUrl);
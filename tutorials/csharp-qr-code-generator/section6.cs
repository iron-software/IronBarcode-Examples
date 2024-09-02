using IronBarCode;
using System;
using System.Linq;

BarcodeResults result = BarcodeReader.Read("QR.png", new BarcodeReaderOptions() { ExpectBarcodeTypes = BarcodeEncoding.QRCode });
if (result != null)
{
    Console.WriteLine(result.First().Value);
}
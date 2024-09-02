using IronBarCode;
using System.IO;

GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.DataMatrix);
Stream myBarcodeStream = myBarcode.ToPdfStream();
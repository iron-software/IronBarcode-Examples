using IronBarCode;
using System.IO;
using System.Text;

MemoryStream text = new MemoryStream(Encoding.UTF8.GetBytes("Hello, World!"));
MemoryStream url = new MemoryStream(Encoding.UTF8.GetBytes("https://ironsoftware.com/csharp/barcode/"));
MemoryStream receiptID = new MemoryStream(Encoding.UTF8.GetBytes("2023-08-04-12345")); // Receipt ID (numeric id)
MemoryStream flightID = new MemoryStream(Encoding.UTF8.GetBytes("FLT2023NYC-LAX123456")); // Flight id (alphanumeric id)
MemoryStream number = new MemoryStream(Encoding.UTF8.GetBytes("1234"));

BarcodeWriter.CreateBarcode(text, BarcodeEncoding.Aztec).SaveAsPng("text.png");
BarcodeWriter.CreateBarcode(url, BarcodeEncoding.QRCode).SaveAsPng("url.png");
BarcodeWriter.CreateBarcode(receiptID, BarcodeEncoding.Code93, 250, 67).SaveAsPng("receiptID.png");
BarcodeWriter.CreateBarcode(flightID, BarcodeEncoding.PDF417, 250, 67).SaveAsPng("flightID.png");
BarcodeWriter.CreateBarcode(number, BarcodeEncoding.Codabar, 250, 67).SaveAsPng("number.png");
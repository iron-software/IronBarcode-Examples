using IronBarCode;
using System.IO;

// Creating a barcode is as simple as:
var myBarcode = BarcodeWriter.CreateBarcode("12345", BarcodeWriterEncoding.EAN8);

// And save our barcode as an image:
myBarcode.SaveAsImage("EAN8.jpeg");

// OR, we can do both steps on one line:
BarcodeWriter.CreateBarcode("12345", BarcodeWriterEncoding.EAN8).ResizeTo(400, 100).SaveAsImage("EAN8.jpeg");

// Barcode can also be made from from Binary data (byte or stream)
string payloadAsString = "This is some random string";

byte[] payloadAsByteArray = System.Text.Encoding.Default.GetBytes(payloadAsString); // Byte Array
var AztecBarcode = BarcodeWriter.CreateBarcode(payloadAsByteArray, BarcodeWriterEncoding.Aztec, 400, 400); // Create from Byte Array

MemoryStream payloadAsStream = new MemoryStream(payloadAsByteArray); // MemoryStream
var AztecBarcode2 = BarcodeWriter.CreateBarcode(payloadAsStream, BarcodeWriterEncoding.Aztec, 400, 400); // Create from Memory Stream

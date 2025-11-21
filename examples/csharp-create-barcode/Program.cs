using IronBarCode;
using System.IO;

// Create a barcode with one line of code
var myBarcode = BarcodeWriter.CreateBarcode("12345", BarcodeWriterEncoding.EAN8);

// Save the barcode as an image
myBarcode.SaveAsImage("EAN8.jpeg");

// A barcode can also be made from binary data (byte or stream)
string payloadAsString = "This is some random string";

byte[] payloadAsByteArray = System.Text.Encoding.Default.GetBytes(payloadAsString); // Byte array
var AztecBarcode = BarcodeWriter.CreateBarcode(payloadAsByteArray, BarcodeWriterEncoding.Aztec, 400, 400); // Create from Byte array

MemoryStream payloadAsStream = new MemoryStream(payloadAsByteArray); // MemoryStream
var AztecBarcode2 = BarcodeWriter.CreateBarcode(payloadAsStream, BarcodeWriterEncoding.Aztec, 400, 400); // Create from memory stream

using IronBarCode;

// Generate a Simple BarCode image and save as PNG
GeneratedBarcode myBarcode = IronBarCode.BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode", BarcodeWriterEncoding.Code128);
myBarcode.SaveAsPng("myBarcode.png");

// This line opens the image in your default image viewer
System.Diagnostics.Process.Start("myBarcode.png");
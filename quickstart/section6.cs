using IronBarCode;

GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode", BarcodeEncoding.Code128);
myBarcode.AddAnnotationTextAboveBarcode("Product URL:");
myBarcode.AddBarcodeValueTextBelowBarcode();
myBarcode.SaveAsImage("myBarcode.png");
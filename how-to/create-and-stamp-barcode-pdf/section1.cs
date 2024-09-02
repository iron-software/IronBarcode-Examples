using IronBarCode;

GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.Code128, 200, 100);
myBarcode.StampToExistingPdfPage("pdf_file_path.pdf", X: 200, Y: 100, 3, "password");
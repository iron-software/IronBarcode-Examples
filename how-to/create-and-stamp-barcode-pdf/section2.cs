using IronBarCode;
using System.Collections.Generic;

GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.Code128, 200, 100);
List<int> pages = new List<int>();
pages.Add(1);
pages.Add(2);
pages.Add(3);
myBarcode.StampToExistingPdfPages("pdf_file_path.pdf", X: 200, Y: 100, pages, "password");
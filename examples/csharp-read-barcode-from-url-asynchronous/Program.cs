using IronBarCode;

// Reading many images asynchronously using ReadAsync
string[] imagePaths = new string[] { "image1.png", "image2.png" };
var resultsAsync = BarcodeReader.ReadAsync(imagePaths, new BarcodeReaderOptions() { ExpectMultipleBarcodes = true });

// Reading many PDFs asynchronously using ReadPdfAsync
string[] pdfPaths = new string[] { "doc1.pdf", "doc2.pdf" };
var resultsPdfAsync = BarcodeReader.ReadPdfsAsync(pdfPaths, new PdfBarcodeReaderOptions() { ExpectMultipleBarcodes = true, Scale = 3, DPI = 300 });

***Based on <https://ironsoftware.com/examples/barcode-quickstart/>***

IronBarCode is adept at handling numerous standard formats, ranging from image files such as JPEG, PNG, and JPG to more dynamic types like Bitmap. Additionally, it supports external file formats like PDF, ensuring a seamless integration into any coding environment. This versatility grants developers extensive flexibility with file formats and variables.

Not only does IronBarcode serve as a comprehensive barcode reader across all file formats, but it also functions as a robust barcode generator supporting all common encodings and formats, including `EAN8`, `Code128`, and `Code39`. Initializing the barcode generator is straightforward, requiring just two lines of code. Thanks to its ease of use and numerous customization options, IronBarCode stands out as the premier choice for managing barcode-related tasks.

## Barcode Processing with C&num;

1. var myBarcode = BarcodeWriter.CreateBarcode("12345", BarcodeWriterEncoding.EAN8);
2. Image myBarcodeImage = myBarcode.Image;
3. myBarcode.ResizeTo(400, 100);
4. var resultFromFile = BarcodeReader.Read(@"file/barcode.png");
5. var myOptionsExample = new BarcodeReaderOptions{...}

### Introduction to BarcodeWriter

We commence by incorporating `IronBarCode` and `System.Drawing`, then initiate `BarcodeWriter` to generate a barcode using the string "12345" formatted as `EAN8`. The barcode is subsequently saved as an image, available in various formats including `Image` and `Bitmap`.

#### Advanced Features of BarcodeWriter

As demonstrated, creating a barcode with IronBarCode is remarkably efficient, involving only a couple of lines of code and allowing the generated barcode to be saved as a file for future use. IronBarCode also offers a range of options to customize the barcode according to specific requirements, utilizing the `ResizeTo` method for adjusting the image dimensions.

### Overview of Barcode Reader

Similarly, we initialize `BarcodeReader`, direct the file path to the `Read` method, and capture the result in a variable for follow-up manipulation of the barcode object. While `ReadPDF` caters to reading from PDF formats, the `Read` function handles general image formats and bitmaps.

#### Configuring BarcodeReaderOptions 

IronBarCode equips developers with the capability to customize barcode scanning from standard file formats. `BarcodeReaderOptions` enhances the versatility by allowing adjustments to the scanning process, such as reading speed with `Speed`, anticipation of multiple barcodes with `ExpectedMultipleBarcodes`, and barcode types with `ExpectBarcodeTypes`. These settings facilitate efficient parallel processing, optimizing multiple threads for concurrent barcode reading from several images. For a comprehensive overview of these properties, refer to the full documentation [here](https://ironsoftware.com/csharp/barcode/object-reference/api/IronBarCode.BarcodeReaderOptions.html).

[Explore our How-to-Guide, complete with examples, sample code, and files here >](https://ironsoftware.com/csharp/barcode/how-to/read-barcodes-from-images/)
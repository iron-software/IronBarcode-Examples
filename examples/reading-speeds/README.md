***Based on <https://ironsoftware.com/examples/reading-speeds/>***

IronBarCode enhances the ability to read barcodes by providing a flexible balance between processing speed and accuracy, making it ideal for handling large volumes. Developers have the ability to adjust the reading strategy based on the quality of the input image and the resources available. This means you can choose quicker processing for clearer images or use more comprehensive techniques for better accuracy on difficult images. This adaptability allows developers to fine-tune the scanning process to efficiently meet the particular needs of different operational environments.

## 4-Step Guide to Selecting the Reading Speed Option

- `var options = new BarcodeReaderOptions();`
- `options.Speed = ReadingSpeed.Balanced;`
- `var results = BarcodeReader.Read("barcode.png", options);`
- `Console.WriteLine($"Found {results.Values()[0]}");`

The initial step in selecting the reading speed option is to create a new instance of `BarcodeReaderOptions` and adjust its settings for barcode reading. We specifically adjust the `Speed` property to `ReadingSpeed.Balanced`, which is a setting that offers a compromise between performance and precision, suitable for most standard applications.

Next, we use the `Read` method to process the input image, applying the customized `BarcodeReaderOptions`. Then, we retrieve and display the barcode result by accessing the `Values` array to get the first barcode detected.

Selecting an appropriate reading speed for your barcode might seem daunting, but IronBarcode provides several choices and customization features to aid in this decision.

[For more examples, check the How-to Guide on using IronBarcode with C#](https://ironsoftware.com/csharp/barcode/how-to/reading-speed-options).
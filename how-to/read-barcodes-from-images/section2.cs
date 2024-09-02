using IronBarCode;
using System;

BarcodeReaderOptions myOptions = new BarcodeReaderOptions()
{
    ExpectBarcodeTypes = BarcodeEncoding.AllOneDimensional, //or AllTwoDimensional
    ExpectMultipleBarcodes = true, // Default is true
    MaxParallelThreads = 2, // Default is 4
    Speed = ReadingSpeed.Detailed, // 4 levels of speed. Default is Balanced
    CropArea = new IronSoftware.Drawing.Rectangle(x: 242, y: 1124, width: 359, height: 378), // Units are in px
    ImageFilters = new ImageFilterCollection { new BinaryThresholdFilter() }, // Assign to image filter object name
    Multithreaded = true, // Default is true
    UseCode39ExtendedMode = true, // Default is true

};

var myBarcode = BarcodeReader.Read(@"image_file_path.jpg", myOptions); // Image file path

foreach (var item in myBarcode)
{
    Console.WriteLine(item.ToString());
}
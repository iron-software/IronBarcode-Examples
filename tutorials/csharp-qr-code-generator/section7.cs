using IronBarCode;
using System;
using System.Linq;

BarcodeReaderOptions options = new BarcodeReaderOptions
{
    Speed = ReadingSpeed.Faster,
    ExpectMultipleBarcodes = false,
    ExpectBarcodeTypes = BarcodeEncoding.All,
    Multithreaded = false,
    MaxParallelThreads = 0,
    CropArea = null,
    UseCode39ExtendedMode = false,
    RemoveFalsePositive = false,
    ImageFilters = null
};

BarcodeResults result = BarcodeReader.Read("QR.png", options);
if (result != null)
{
    Console.WriteLine(result.First().Value);
}
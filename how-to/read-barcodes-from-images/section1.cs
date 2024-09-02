using IronBarCode;
using System;

var myBarcode = BarcodeReader.Read(@"image_file_path.jpg"); //image file path

foreach (var item in myBarcode)
{
    Console.WriteLine(item.ToString());
}
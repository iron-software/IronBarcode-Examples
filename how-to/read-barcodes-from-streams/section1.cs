using IronBarCode;
using IronSoftware.Drawing;
using System;
using System.Collections.Generic;
using System.IO;

List<MemoryStream> list = new List<MemoryStream>();
list.Add(AnyBitmap.FromFile("image1.jpg").ToStream());
list.Add(AnyBitmap.FromFile("image2.jpg").ToStream());
list.Add(AnyBitmap.FromFile("image3.png").ToStream());

var myBarcode = BarcodeReader.Read(list);

foreach (var barcode in myBarcode)
{
    Console.WriteLine(barcode.ToString());
}
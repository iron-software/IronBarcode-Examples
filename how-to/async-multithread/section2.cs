using BarCode;
namespace IronBarcode.Examples.HowTo.AsyncMultithread
{
    public static class Section2
    {
        public static void Run()
        {
            ﻿using IronBarCode;
            using System;
            using System.Collections.Generic;
            using System.Threading.Tasks;
            
            List<string> imagePaths = new List<string>() { "image1.png", "image2.png" };
            
            // Barcode reading options
            BarcodeReaderOptions options = new BarcodeReaderOptions()
            {
                ExpectMultipleBarcodes = true
            };
            
            // Read barcode using Async
            BarcodeResults asyncResult = await BarcodeReader.ReadAsync(imagePaths, options);
            
            // Print the results to console
            foreach (var result in asyncResult)
            {
                Console.WriteLine(result.ToString());
            }
        }
    }
}
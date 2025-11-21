using BarCode;
namespace IronBarcode.Examples.HowTo.ReadingSpeedOptions
{
    public static class Section3
    {
        public static void Run()
        {
            ﻿using IronBarCode;
            using System;
            using System.Diagnostics;
            using System.IO;
            using System.Linq;
            
            var optionsFaster = new BarcodeReaderOptions
            {
                Speed = ReadingSpeed.Balanced
            };
            
            // Directory containing PDF files
            string folderPath = @"YOUR_FILE_PATH";
            
            // Get all PDF files in the directory
            var pdfFiles = Directory.GetFiles(folderPath, "*.jpg");
            
            int countFaster = 0;
            var stopwatch = Stopwatch.StartNew();
            foreach (var file in pdfFiles)
            {
                // Read the barcode
                var results = BarcodeReader.Read(file, optionsFaster);
            
                if (results.Any())
                {
                    Console.WriteLine($"Barcode(s) found in: {Path.GetFileName(file)}");
                    foreach (var result in results)
                    {
                        Console.WriteLine($"  Value: {result.Value}, Type: {result.BarcodeType}");
                        countFaster++;
                    }
                }
                else
                {
                    Console.WriteLine($"No barcode found in: {Path.GetFileName(file)}");
                }
            }
            
            stopwatch.Stop();
            
            // Print number of images the barcode reader could decode
            Console.WriteLine($"Balanced could read = {countFaster} out of {pdfFiles.Length} in {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}
using BarCode;
namespace IronBarcode.Examples.HowTo.WritingInUnicode
{
    public static class Section4
    {
        public static void Run()
        {
            ﻿using IronBarCode;
            using System.IO;
            
            // Reading the Unicode barcode
            BarcodeResults result = BarcodeReader.Read("Unicode.jpeg");
            
            // Output the text value from the barcode to a txt file
            File.WriteAllText("text.txt", result[0].Text);
        }
    }
}
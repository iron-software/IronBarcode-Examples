using BarCode;
namespace IronBarcode.Examples.HowTo.CustomizeBarcodeStyle
{
    public static class Section4
    {
        public static void Run()
        {
            ﻿using IronBarCode;
            using IronSoftware.Drawing;
            
            GeneratedBarcode barcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.Aztec, 500, 500);
            
            // Change barcode and background color
            barcode.ChangeBarCodeColor(Color.DarkCyan);
            barcode.ChangeBackgroundColor(Color.PeachPuff);
            
            // Create font for annotation
            Font annotationFont = new Font("Candara", FontStyle.Bold, 70);
            
            // Add annotation
            barcode.AddAnnotationTextAboveBarcode("IronBarcodeRocks!", annotationFont, Color.DarkOrange);
            
            // Create font for barcode value
            Font barcodeValueFont = new Font("Cambria", FontStyle.Regular, 70);
            
            // Add displayed barcode value
            barcode.AddBarcodeValueTextBelowBarcode(barcodeValueFont, Color.SandyBrown);
            
            barcode.SaveAsPng("annotationAndBarcodeValue.png");
        }
    }
}
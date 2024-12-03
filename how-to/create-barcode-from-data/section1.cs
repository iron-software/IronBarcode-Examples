using BarCode;
namespace ironbarcode.CreateBarcodeFromData
{
    public class Section1
    {
        public void Run()
        {
            ﻿using IronBarCode;
            
            string text = "Hello, World!";
            string url = "https://ironsoftware.com/csharp/barcode/";
            string receiptID = "2023-08-04-12345"; // Receipt ID (numeric id)
            string flightID = "FLT2023NYC-LAX123456"; // Flight ID (alphanumeric id)
            string number = "1234";
            
            BarcodeWriter.CreateBarcode(text, BarcodeEncoding.Aztec).SaveAsPng("text.png");
            BarcodeWriter.CreateBarcode(url, BarcodeEncoding.QRCode).SaveAsPng("url.png");
            BarcodeWriter.CreateBarcode(receiptID, BarcodeEncoding.Code93, 250, 67).SaveAsPng("receiptID.png");
            BarcodeWriter.CreateBarcode(flightID, BarcodeEncoding.PDF417, 250, 67).SaveAsPng("flightID.png");
            BarcodeWriter.CreateBarcode(number, BarcodeEncoding.Codabar, 250, 67).SaveAsPng("number.png");
        }
    }
}
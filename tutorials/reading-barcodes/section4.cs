using System;
using BarCode;
namespace IronBarcode.Examples.Tutorial.ReadingBarcodes
{
    public static class Section4
    {
        public static void Run()
        {
            // Multiple barcodes may be scanned up from a single document or image. A PDF document may also used as the input image
            BarcodeResults results = BarcodeReader.ReadPdf("MultipleBarcodes.pdf");
            
            // Work with the results
            foreach (var pageResult in results)
            {
                string Value = pageResult.Value;
                int PageNum = pageResult.PageNumber;
                System.Drawing.Bitmap Img = pageResult.BarcodeImage;
                BarcodeEncoding BarcodeType = pageResult.BarcodeType;
                byte[] Binary = pageResult.BinaryValue;
                Console.WriteLine(pageResult.Value + " on page " + PageNum);
            }
        }
    }
}
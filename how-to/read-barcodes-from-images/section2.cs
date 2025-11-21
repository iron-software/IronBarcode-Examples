using System;
using BarCode;
namespace IronBarcode.Examples.HowTo.ReadBarcodesFromImages
{
    public static class Section2
    {
        public static void Run()
        {
            var myBarcode = BarcodeReader.Read(@"image_file_path.jpg"); //image file path
            
            foreach (var item in myBarcode)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
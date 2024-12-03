using System;
using BarCode;
namespace ironbarcode.ReadBarcodesFromImages
{
    public class Section1
    {
        public void Run()
        {
            var myBarcode = BarcodeReader.Read(@"image_file_path.jpg"); //image file path
            
            foreach (var item in myBarcode)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
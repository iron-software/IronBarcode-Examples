using System.IO;
using BarCode;
namespace IronBarcode.Examples.HowTo.ReadBarcodesFromStreams
{
    public static class Section2
    {
        public static void Run()
        {
            List<MemoryStream> list = new List<MemoryStream>();
            list.Add(AnyBitmap.FromFile("image1.jpg").ToStream());
            list.Add(AnyBitmap.FromFile("image2.jpg").ToStream());
            list.Add(AnyBitmap.FromFile("image3.png").ToStream());
            
            var myBarcode = BarcodeReader.Read(list);
            
            foreach (var barcode in myBarcode)
            {
                Console.WriteLine(barcode.ToString());
            }
        }
    }
}
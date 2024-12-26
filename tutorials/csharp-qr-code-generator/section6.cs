using System.Linq;
using BarCode;
namespace IronBarcode.Examples.Tutorial.CsharpQrCodeGenerator
{
    public static class Section6
    {
        public static void Run()
        {
            // Create Some Binary Data - This example equally well for Byte[] and System.IO.Stream
            byte[] BinaryData = System.Text.Encoding.UTF8.GetBytes("https://ironsoftware.com/csharp/barcode/");
            
            // WRITE QR with Binary Content
            QRCodeWriter.CreateQrCode(BinaryData, 500).SaveAsImage("MyBinaryQR.png");
            
            // READ QR with Binary Content
            var MyReturnedData = BarcodeReader.Read("MyBinaryQR.png").First();
            if (BinaryData.SequenceEqual(MyReturnedData.BinaryValue))
            {
                Console.WriteLine("\t Binary Data Read and Written Perfectly");
            }
            else
            {
                throw new Exception("Corrupted Data");
            }
        }
    }
}
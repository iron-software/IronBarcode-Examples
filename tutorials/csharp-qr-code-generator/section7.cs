using System.Linq;
using BarCode;
namespace IronBarcode.Examples.Tutorial.CsharpQrCodeGenerator
{
    public static class Section7
    {
        public static void Run()
        {
            // Convert string to binary data
            byte[] binaryData = System.Text.Encoding.UTF8.GetBytes("https://ironsoftware.com/csharp/barcode/");
            
            // Create QR code from binary content
            QRCodeWriter.CreateQrCode(binaryData, 500).SaveAsPng("MyBinaryQR.png");
            
            // Read and verify binary data integrity
            var myReturnedData = BarcodeReader.Read("MyBinaryQR.png").First();
            
            // Confirm data matches original
            if (binaryData.SequenceEqual(myReturnedData.BinaryValue))
            {
                Console.WriteLine("Binary Data Read and Written Perfectly");
            }
            else
            {
                throw new Exception("Data integrity check failed");
            }
        }
    }
}
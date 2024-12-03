using IronBarCode;
using BarCode;
namespace ironbarcode.OutputDataFormats
{
    public class Section3
    {
        public void Run()
        {
            // Read barcode from PNG
            BarcodeResults result = BarcodeReader.Read("multiple-barcodes.png");
            
            int i = 1;
            foreach (BarcodeResult barcode in result)
            {
                var binaryValue = barcode.BinaryValue;
                var barcodeType = IronBarCode.BarcodeEncoding.QRCode;
            
                // Create QR code
                GeneratedBarcode generatedBarcode = BarcodeWriter.CreateBarcode(binaryValue, barcodeType);
            
                // Export QR code
                generatedBarcode.SaveAsPng($"qrFromBinary{i}.png");
                i++;
            }
        }
    }
}
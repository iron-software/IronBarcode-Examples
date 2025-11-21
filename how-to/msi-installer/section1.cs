using BarCode;
namespace IronBarcode.Examples.HowTo.MsiInstaller
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Scan MSI Barcodes Instantly with IronBarcode
            var msiImg = IronBarCode.BarcodeWriter.CreateBarcode("12345", BarcodeWriterEncoding.MSI).SaveAsImage("msi.png");
            var results = IronBarCode.BarcodeReader.Read("msi.png", new BarcodeReaderOptions { ExpectBarcodeTypes = BarcodeEncoding.MSI });
        }
    }
}
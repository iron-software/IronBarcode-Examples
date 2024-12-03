using IronBarCode;
using BarCode;
namespace ironbarcode.Quickstart
{
    public class Section4
    {
        public void Run()
        {
            BarcodeResults pagedResults = BarcodeReader.Read("MultipleBarcodes.pdf");
            
            // Loop through the results
            foreach (BarcodeResult result in pagedResults)
            {
                int pageNumber = result.PageNumber;
                string value = result.Value;
                Bitmap img = result.BarcodeImage;
                BarcodeEncoding barcodeType = result.BarcodeType;
                byte[] binary = result.BinaryValue;
                Console.WriteLine(result.Value);
            }
            
            // or from a multi-page  TIFF scan with image correction:
            BarcodeResults multiFrameResults = BarcodeReader.Read(inputImage: "Multiframe.tiff", new BarcodeReaderOptions
            {
                Speed = ReadingSpeed.Detailed,
                ExpectMultipleBarcodes = true,
                ExpectBarcodeTypes = BarcodeEncoding.Code128,
                Multithreaded = false,
                RemoveFalsePositive = false,
                ImageFilters = null
            });
        }
    }
}
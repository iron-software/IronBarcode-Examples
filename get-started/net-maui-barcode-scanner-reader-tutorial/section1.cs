using BarCode;
namespace IronBarcode.Examples.GettingStarted.NetMauiBarcodeScannerReaderTutorial
{
    public static class Section1
    {
        public static void Run()
        {
            private async void SelectBarcode(object sender, EventArgs e)
            {
                // Use FilePicker to allow the user to select an image file.
                var images = await FilePicker.Default.PickAsync(new PickOptions
                {
                    PickerTitle = "Pick image",
                    FileTypes = FilePickerFileType.Images
                });
            
                // Get the full path of the selected image file.
                var imageSource = images.FullPath.ToString();
            
                // Set the source of the Image view to the selected image's path.
                barcodeImage.Source = imageSource;
            
                // Use IronBarcode to read the barcode from the image file and get the first result.
                var result = BarcodeReader.Read(imageSource).First().Text;
            
                // Display the read result in the Editor.
                outputText.Text = result;
            }
        }
    }
}
using BarCode;
namespace IronBarcode.Examples.HowTo.NetMauiBarcodeScannerReaderTutorial
{
    public static class Section1
    {
        public static void Run()
        {
            private async void SelectBarcode(object sender, EventArgs e)
            {
                var images = await FilePicker.Default.PickAsync(new PickOptions
                {
                PickerTitle = "Pick image",
                FileTypes = FilePickerFileType.Images
                });
                var imageSource = images.FullPath.ToString();
                barcodeImage.Source = imageSource;
                var result = BarcodeReader.Read(imageSource).First().Text;
                outputText.Text = result;
            }
        }
    }
}
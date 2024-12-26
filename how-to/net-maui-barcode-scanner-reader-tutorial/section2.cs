using BarCode;
namespace IronBarcode.Examples.HowTo.NetMauiBarcodeScannerReaderTutorial
{
    public static class Section2
    {
        public static void Run()
        {
            private async void CopyEditorText (object sender, EventArgs e)
            {
                await Clipboard.SetTextAsync(outputText.Text);
                await DisplayAlert("Success", "Text is copied!", "OK");
            }
        }
    }
}
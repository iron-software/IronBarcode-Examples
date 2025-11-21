using BarCode;
namespace IronBarcode.Examples.GettingStarted.NetMauiBarcodeScannerReaderTutorial
{
    public static class Section2
    {
        public static void Run()
        {
            private async void CopyEditorText(object sender, EventArgs e)
            {
                // Copy the text from the Editor to the clipboard.
                await Clipboard.SetTextAsync(outputText.Text);
            
                // Show a success message to the user.
                await DisplayAlert("Success", "Text is copied!", "OK");
            }
        }
    }
}
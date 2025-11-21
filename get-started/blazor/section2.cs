using BarCode;
namespace IronBarcode.Examples.GettingStarted.Blazor
{
    public static class Section2
    {
        public static void Run()
        {
            [JSInvokable]
            public async Task ProcessImage(string imageString)
            {
                // Create an image object containing the base64 data
                var imageObject = new CamImage();
                imageObject.imageDataBase64 = imageString;
                
                // Serialize image object to JSON
                var jsonObj = System.Text.Json.JsonSerializer.Serialize(imageObject);
                
                // Send image data to server-side API for processing
                var barcodeeResult = await Http.PostAsJsonAsync("Ironsoftware/ReadBarCode", imageObject);
                if (barcodeeResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    QRCodeResult = await barcodeeResult.Content.ReadAsStringAsync();
                    StateHasChanged();
                }
            }
        }
    }
}
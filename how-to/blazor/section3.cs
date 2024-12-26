using BarCode;
namespace IronBarcode.Examples.HowTo.Blazor
{
    public static class Section3
    {
        public static void Run()
        {
            [JSInvokable]
            public async void ProcessImage(string imageString)
            {
            
                var imageObject = new CamImage();
                imageObject.imageDataBase64 = imageString;
                var jsonObj = System.Text.Json.JsonSerializer.Serialize(imageObject);
                //Do image processing here
                var barcodeeResult = await Http.PostAsJsonAsync($"Ironsoftware/ReadBarCode", imageObject);
                if (barcodeeResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    QRCodeResult = barcodeeResult.Content.ReadAsStringAsync().Result;
                    StateHasChanged();
                }
            }
        }
    }
}
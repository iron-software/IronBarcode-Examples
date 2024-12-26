using BarCode;
namespace IronBarcode.Examples.HowTo.AzureSupport
{
    public static class Section1
    {
        public static void Run()
        {
            [FunctionName("barcode")]
            public static HttpResponseMessage Run(
                    [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
                    ILogger log)
            {
                log.LogInformation("C# HTTP trigger function processed a request.");
                IronBarCode.License.LicenseKey = "Key";
                var MyBarCode = BarcodeWriter.CreateBarcode("IronBarcode Test", BarcodeEncoding.QRCode);
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new ByteArrayContent(MyBarCode.ToJpegBinaryData());
                result.Content.Headers.ContentDisposition =
                        new ContentDispositionHeaderValue("attachment") { FileName = $"{DateTime.Now.ToString("yyyyMMddmm")}.jpg" };
                result.Content.Headers.ContentType =
                        new MediaTypeHeaderValue("image/jpeg");
                return result;
            }
        }
    }
}
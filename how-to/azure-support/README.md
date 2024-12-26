# Can I Run IronBarCode with .NET on Azure?

***Based on <https://ironsoftware.com/how-to/azure-support/>***


Absolutely! You can utilize IronBarCode on Azure for generating and reading QR codes and barcodes within C# and VB .NET applications. IronBarCode's compatibility and performance have been extensively verified on various Azure environments, including MVC websites, Azure Functions, among others.

---

### Step 1

## Getting Started with IronBarCode Installation

To begin, install the IronBarCode using NuGet:

[NuGet Package for IronBarCode](https://www.nuget.org/packages/BarCode)

```shell
Install-Package BarCode
```

---

### How to Tutorial

## 2. Choosing the Right Azure Tier

For typical library usage, the Azure **B1** hosting tier is recommended. For systems requiring higher throughput, an upgrade might be necessary.

## 3. Selecting the Appropriate Framework

IronBarCode supports both .NET Core and .NET Framework on Azure. When it comes to .NET Standard applications, they offer a slightly better performance in terms of speed and stability, albeit at a higher memory usage.

### Considerations for Azure Hosting

The Azure free and shared plans, including the consumption plan, are not ideal for QR code processing due to their limited resources. We suggest opting for the Azure B1 hosting or a Premium plan, which is our preferred choice.

## 4. Leveraging Docker for Improved Performance on Azure

Deploying IronBarCode within Docker containers on Azure can significantly enhance control over application performance.

Explore our detailed guide on setting IronBarCode with Docker on Azure for both Linux and Windows: [IronBarCode Azure Docker Tutorial](https://ironsoftware.com/csharp/barcode/how-to/docker-linux/).

## 5. Azure Function Integration

IronBarCode is compatible with Azure Functions V3. While it has not yet been tested with V4, it is on our development roadmap.

### Azure Function Example with IronBarCode

The following code snippet has been tested with Azure Functions v3.3.1.0 or higher. Below is an example:

```cs
[FunctionName("barcode")]
public static HttpResponseMessage BarcodeFunction(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
        ILogger log)
{
    log.LogInformation("C# HTTP trigger function processed a request.");
    IronBarCode.License.LicenseKey = "Your-License-Key-Here"; // Make sure to replace with your actual license key
    var barcodeGenerator = BarcodeWriter.CreateBarcode("IronBarcode Test", BarcodeEncoding.QRCode);
    var response = new HttpResponseMessage(HttpStatusCode.OK);
    response.Content = new ByteArrayContent(barcodeGenerator.ToJpegBinaryData());
    response.Content.Headers.ContentDisposition = 
            new ContentDispositionHeaderValue("attachment") { FileName = $"{DateTime.Now.ToString("yyyyMMddHHmm")}.jpg" };
    response.Content.Headers.ContentType = 
            new MediaTypeHeaderValue("image/jpeg");
    return response;
}
```
# Deploying IronBarCode on Azure with .NET

***Based on <https://ironsoftware.com/how-to/azure-support/>***


Yes, IronBarCode is fully compatible with Azure, enabling you to generate and read QR codes and barcodes within C# & VB.NET applications on various Azure platforms, such as MVC websites and Azure Functions.

---

## Getting Started with IronBarCode

First, install IronBarCode via NuGet:
[https://www.nuget.org/packages/BarCode](https://www.nuget.org/packages/BarCode)

```shell
Install-Package BarCode
```

---

## Optimization Tips for Azure Environments

### Choosing the Right Azure Tier

For general usage, Azure's **B1** hosting tier usually meets the library's needs perfectly. However, for systems requiring high throughput, consider upgrading for optimal performance.

### Selecting the Framework

IronBarCode performs well on Azure whether you use .NET Core, .NET Framework, or .NET Standard, with .NET Standard often showing slightly better speed and stability but at the expense of higher memory usage.

#### Note on Azure Hosting Tiers

The free and shared tiers, including the consumption plan on Azure, do not perform well for QR code processing. We recommend opting for the Azure B1 or Premium plans, which we use for our internal projects.

### Using Docker for Enhanced Control

Deploying IronBarCode within Docker containers on Azure allows more control over performance.

For a detailed guide, refer to our [IronBarCode Docker tutorial for Azure](https://ironsoftware.com/csharp/barcode/how-to/docker-linux/) designed for both Linux and Windows.

### Azure Function Compatibility

IronBarCode is certified for Azure Functions V3. Tests for Azure Functions V4 are pending but planned.

#### Example Code for Azure Function

Here's proven code for Azure Functions v3.3.1.0 and above:

```cs
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
```

By following these steps and recommendations, you can effectively run IronBarCode on Azure to enhance your applications with barcode and QR code functionalities.
# Can I Run IronBarCode with .NET on Azure?

Absolutely! IronBarCode is fully capable of being deployed on Azure for creating and scanning QR codes and barcodes in C# and VB .NET applications. It has undergone extensive testing on various Azure services, including MVC websites and Azure Functions, amongst others.

<hr class="separator">

<p class="main-content__segment-title">Step 1</p>

## 1. Setting Up IronBarCode

Begin by installing IronBarCode using NuGet: [https://www.nuget.org/packages/BarCode](https://www.nuget.org/packages/BarCode)

```shell
Install-Package BarCode
```

<hr class="separator">

<p class="main-content__segment-title">How to Tutorial</p>

## 2. Choosing the Right Azure Tier

For most library needs, Azure **B1** hosting tiers are recommended. For systems with higher demand, an upgrade might be necessary.

## 3. Optimal Framework for Deployment

IronBarCode supports both .NET Core and .NET Framework on Azure. Applications targeting .NET Standard may show slightly better performance in terms of speed and stability, though they consume more memory.

### Limitations of Azure Free Tier

For QR code processing tasks, Azure's free and shared tiers, including the consumption plan, prove inadequate. We advise opting for the Azure B1 hosting or Premium plans, which we use ourselves.

## 4. Utilizing Docker on Azure

To better manage performance capabilities on Azure, deploying IronBarCode within Docker containers can be very effective.

Access our detailed [IronBarCode Azure Docker tutorial](https://ironsoftware.com/csharp/barcode/how-to/docker-linux/) designed for both Linux and Windows setups.

## 5. Compatibility with Azure Functions

IronBarCode is compatible with Azure Functions V3. Testing for V4 is on our roadmap.

### Example Azure Function Code

Here's an example function tested with Azure Functions v3.3.1.0 and later:

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

This code snippet showcases how to generate a QR code and return it as a JPEG image in an HTTP response within an Azure Function.
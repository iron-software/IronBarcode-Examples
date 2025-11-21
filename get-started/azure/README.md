# Can IronBarcode Operate with .NET on Azure?

***Based on <https://ironsoftware.com/get-started/azure/>***


Absolutely! IronBarcode is fully compatible for incorporating into .NET applications running on Azure. It has been rigorously evaluated on various Azure services including MVC websites and Azure Functions, proving its versatility across multiple Azure environments.

---

### Essential Preliminaries

## Getting Started with IronBarcode Installation

Begin by adding the IronBarcode package available on [NuGet](https://www.nuget.org/packages/BarCode):

```shell
Install-Package BarCode
```

Alternatively, the [IronBarcode.dll](https://ironsoftware.com/csharp/barcode/packages/IronBarCode.zip) can be directly downloaded and integrated into your project.

---

### Instructional Guide

## Azure Performance Considerations

For optimal performance, selecting the Azure **B1** service plan is recommended for most application scenarios. More robust requirements might necessitate a more powerful plan.

## Supported .NET Environments

IronBarcode is compatible with .NET Standard, Core, and Framework projects, facilitating broad usage across different .NET environments.

## Using Docker with Azure

To enhance control over performance and reliability, deploying IronBarcode within Docker containers on Azure can be beneficial. For instructions on setting this up, see this [tutorial](https://ironsoftware.com/csharp/barcode/get-started/docker-linux/).

## Azure Functions Compatibility

IronBarcode is fully supported within Azure Functions V3 and V4.

### Azure Function Code Sample

Here is a validated sample for Azure Functions v3.3.1.0 and above:

```csharp
using System;
using System.Net;
using System.Net.Http;
using IronBarCode;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;

public static class BarcodeFunction
{
    // This function responds to HTTP requests.
    [FunctionName("barcode")]
    public static HttpResponseMessage Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
        ILogger log)
    {
        log.LogInformation("Received an HTTP request in the C# function.");

        // Ensure to set IronBarcode license key.
        IronBarCode.License.LicenseKey = "Your-Key-Here";

        // Generate a QR barcode using IronBarcode.
        var myBarCode = BarcodeWriter.CreateBarcode("Sample IronBarcode Text", BarcodeEncoding.QRCode);

        // Setup the HTTP response returning the barcode.
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new ByteArrayContent(myBarCode.ToJpegBinaryData())
        };
        
        // Set content headers with filename based on the date and time.
        response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
        { 
            FileName = $"{DateTime.Now:yyyyMMddmm}.jpg" 
        };
        
        // Define the JPEG format in headers.
        response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");

        return response;
    }
}
```

In this sample:

- An Azure Function named "barcode" is specified which triggers on HTTP requests.
- It logs an informational message upon triggering.
- It configures the IronBarcode license key (alter `"Your-Key-Here"` with your actual license key).
- It generates a QR barcode, converts it to JPEG, and packages it in the HTTP response.
- The content is prepared as an attachment and the output format is declared as JPEG.
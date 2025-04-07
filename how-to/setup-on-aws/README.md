# Managing Barcode Operations on AWS Lambda with IronBarcode

***Based on <https://ironsoftware.com/how-to/setup-on-aws/>***


<div class="container-fluid">
    <div class="row">
        <div class="col-md-2">
            <img src="https://ironsoftware.com/img/platforms/Amazon_Lambda_architecture_logo.svg">
        </div>
    </div>
</div>

Discover the steps necessary to implement an AWS Lambda function that handles barcode reading and writing via IronBarcode. We'll show you how to set it up to interact with an S3 bucket.

## Installation

Before starting, ensure to integrate the **[AWSSDK.S3](https://www.nuget.org/packages/AWSSDK.S3/4.0.0-preview.3)** as it will be used with an S3 bucket.

### Using IronBarcode Zip

When utilizing the IronBarcode Zip, properly configuring the temporary directory is crucial.

```cs
var awsTmpPath = @"/tmp/";
IronBarCode.Installation.DeploymentPath = awsTmpPath;
```

Incorporating **[Microsoft.ML.OnnxRuntime](https://www.nuget.org/packages/Microsoft.ML.OnnxRuntime)** is vital for barcode detection functionalities. Note that for barcode generation, this dependency is not required unless you engage in ML-based detection methods.

## Setting up an AWS Lambda Project

Facilitate the creation of AWS Lambda in Visual Studio by:

- Installing the [AWS Toolkit for Visual Studio](https://aws.amazon.com/visualstudio/)
- Selecting 'AWS Lambda Project (.NET Core - C#)'
- Choosing the '.NET 8 (Container Image)' blueprint and finalizing the setup.

![Choose container image](https://ironsoftware.com/static-assets/ocr/how-to/iron-ocr-aws-tutorial/Blueprint.png)

## Package Dependencies Integration

IronBarcode library seamlessly operates on .NET 8 within AWS Lambda without additional dependencies. Here’s how you update the Dockerfile of your project:

```
FROM public.ecr.aws/lambda/dotnet:8
 
# Apply system updates

***Based on <https://ironsoftware.com/how-to/setup-on-aws/>***

RUN dnf update -y
 
WORKDIR /var/task
 
# This part involves copying the compiled .NET Lambda project output into the Docker image from your local environment. Ensure the destination path aligns with where you publish your project outputs.

***Based on <https://ironsoftware.com/how-to/setup-on-aws/>***

COPY "bin/Release/lambda-publish"  .
```

## Customize the FunctionHandler Code

The following example highlights creating an EAN8 barcode, storing it in an S3 bucket, and reading it back. Setting up the temporary directory is essential when using the IronBarcode library.

```cs
using Amazon.Lambda.Core;
using Amazon.S3;
using Amazon.S3.Model;
using IronBarCode;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace IronBarcodeZipAwsLambda;

public class Function
{
    private static readonly IAmazonS3 _s3Client = new AmazonS3Client(Amazon.RegionEndpoint.APSoutheast1);

    public async Task FunctionHandler(ILambdaContext context)
    {
        var awsTmpPath = @"/tmp/";
        IronBarCode.Installation.DeploymentPath = awsTmpPath;

        IronBarCode.License.LicenseKey = "IRONBARCODE-MYLICENSE-KEY-1EF01";

        string filename = Guid.NewGuid().ToString();
        string bucketName = "deploymenttestbucket";
        string objectKey = $"IronBarcodeZip/{filename}.png";

        try
        {
            var myBarcode = BarcodeWriter.CreateBarcode("1212345", BarcodeWriterEncoding.EAN8);
            
            context.Logger.LogLine($"Barcode created.");
            
            await UploadPngToS3Async(bucketName, objectKey, myBarcode.ToPngBinaryData());
            
            context.Logger.LogLine($"Barcode uploaded successfully to {bucketName}/{objectKey}");

            var resultFromByte = BarcodeReader.Read(myBarcode.ToPngBinaryData());

            foreach (var item in resultFromByte)
            {
                context.Logger.LogLine($"Barcode value is = {item.Value}");
            }
        }
        catch (Exception e)
        {
            context.Logger.LogLine($"[ERROR] FunctionHandler: {e.Message}");
        }
    }

    private async Task UploadPngToS3Async(string bucketName, string objectKey, byte[] pngData)
    {
        using (var memoryStream = new MemoryStream(pngData))
        {
            var request = new PutObjectRequest
            {
                BucketName = bucketName,
                Key = objectKey,
                InputStream = memoryStream,
                ContentType = "image/png",
            };

            await _s3Client.PutObjectAsync(request);
        }
    }
}
```

Before you start the try block in the `FunctionHandler`, prepare the destination details for storing the barcode in the S3 bucket. This is exemplified in the `UploadPngToS3Async` function.

You can also enhance the `Read` method by incorporating various `BarcodeReaderOptions` to unlock additional functionalities such as [reading multiple barcodes](https://ironsoftware.com/csharp/barcode/how-to/read-multiple-barcodes/), [specifying crop regions](https://ironsoftware.com/csharp/barcode/how-to/set-crop-region/), and employing [advanced image processing techniques](https://ironsoftware.com/csharp/barcode/how-to/image-correction/).

## Optimize Memory & Timeout Settings

Adjust the memory allocation starting at 512 MB and the timeout period to 300 seconds found in the `aws-lambda-tools-defaults.json`. If you encounter runtime errors, consider increasing the available memory.

For more nuances, refer to the troubleshooting guide: [AWS Lambda - Runtime Exited Signal: Killed](https://ironsoftware.com/csharp/barcode/troubleshooting/aws-lambda-runtime-exited-signal-killed/).

## Publishing the Function

In Visual Studio, simply right-click on the Lambda project and choose 'Publish to AWS Lambda...'. Configure as needed. You can find comprehensive guidance on this on the [AWS documentation](https://docs.aws.amazon.com/toolkit-for-visual-studio/latest/user-guide/lambda-creating-project-in-visual-studio.html#publish-to-lam).

## Activate Your Lambda

You may trigger your AWS Lambda either through the [Lambda console](https://console.aws.amazon.com/lambda) or directly from Visual Studio. 
Explore these functional capacities and integrate IronBarcode into your cloud-based projects for barcode management.
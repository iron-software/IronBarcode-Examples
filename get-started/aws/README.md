# Reading and Writing Barcodes with AWS Lambda and IronBarcode

***Based on <https://ironsoftware.com/get-started/aws/>***


<div class="container-fluid">
    <div class="row">
        <div class="col-md-2">
            <img src="https://ironsoftware.com/img/platforms/Amazon_Lambda_architecture_logo.svg" alt="AWS Lambda">
        </div>
    </div>
</div>

In this tutorial, you will learn how to integrate IronBarcode with AWS Lambda to read and write barcodes directly from Amazon S3 storage.

## Setup Requirements

To integrate IronBarcode with AWS Lambda, you'll need to install the **[AWSSDK.S3](https://www.nuget.org/packages/AWSSDK.S3/4.0.0-preview.3)** package.

### Configuring IronBarcode

If you're using the IronBarcode library through a ZIP deployment, it's important to specify the temporary directory:

```csharp
var awsTemporaryDirectory = @"/tmp/";
IronBarCode.Installation.DeploymentPath = awsTemporaryDirectory;
```

To read barcodes effectively, it's essential to install the **[Microsoft.ML.OnnxRuntime](https://www.nuget.org/packages/Microsoft.ML.OnnxRuntime)** package. Without this, you can still write barcodes, but barcode reading functions might be limited unless you configure IronBarcode to read without leveraging machine learning.

## Creating Your AWS Lambda Project

Setting up a new AWS Lambda project is straightforward with Visual Studio:
- First, install the [AWS Toolkit for Visual Studio](https://aws.amazon.com/visualstudio/).
- Opt for an 'AWS Lambda Project (.NET Core - C#)'.
- Choose a '.NET 8 (Container Image)' blueprint and finalize with ‘Finish’.

![Selecting the container image](https://ironsoftware.com/static-assets/ocr/how-to/iron-ocr-aws-tutorial/Blueprint.png)

## Adding Dependencies

IronBarcode operates seamlessly on AWS Lambda under .NET 8, without additional dependencies. Update your Dockerfile accordingly to set up the environment:

```dockerfile
FROM public.ecr.aws/lambda/dotnet:8

# Update the package list

***Based on <https://ironsoftware.com/get-started/aws/>***

RUN dnf update -y

WORKDIR /var/task

# Copy the Lambda project’s build artifacts into the image. Adjust the source path based on where your artifacts are located.

***Based on <https://ironsoftware.com/get-started/aws/>***

COPY "bin/Release/lambda-publish" .
```

## Adjusting the FunctionHandler

The following function creates an EAN8 barcode, uploads it to an S3 bucket, then reads from it. Ensure that the temp directory configuration is done before running this:

```csharp
using Amazon.Lambda.Core;
using Amazon.S3;
using Amazon.S3.Model;
using IronBarCode;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]
namespace IronBarcodeZipAwsLambda;

public class Function
{
    private static readonly IAmazonS3 s3Client = new AmazonS3Client(Amazon.RegionEndpoint.APSoutheast1);

    public async Task FunctionHandler(ILambdaContext context)
    {
        var tempDirectory = @"/tmp/";
        IronBarCode.Installation.DeploymentPath = tempDirectory;
  
        // Set your IronBarcode license key here
        IronBarCode.License.LicenseKey = "IRONBARCODE-MYLICENSE-KEY-1EF01";

        var filename = Guid.NewGuid().ToString();
        var bucketName = "deploymenttestbucket";
        var objectKey = $"IronBarcodeZip/{filename}.png";

        try
        {
            var barcode = BarcodeWriter.CreateBarcode("1212345", BarcodeWriterEncoding.EAN8);
            context.Logger.LogLine("Barcode created.");

            await UploadPngToS3Async(bucketName, objectKey, barcode.ToPngBinaryData());
            context.Logger.LogLine($"Barcode uploaded successfully to {bucketName}/{objectKey}");

            var readResult = BarcodeReader.Read(barcode.ToPngBinaryData());
            foreach (var item in readResult)
            {
                context.Logger.LogLine($"Barcode value: {item.Value}");
            }
        }
        catch(Exception e)
        {
            context.Logger.LogLine($"[ERROR] FunctionHandler: {e.Message}");
        }
    }

    private async Task UploadPngToS3Async(string bucketName, string objectKey, byte[] data)
    {
        using(var memoryStream = new MemoryStream(data))
        {
            var request = new PutObjectRequest
            {
                BucketName = bucketName,
                Key = objectKey,
                InputStream = memoryStream,
                ContentType = "image/png",
            };

            await s3Client.PutObjectAsync(request);
        }
    }
}
```

## Optimizing Memory and Timeout Settings

When configuring your Lambda function, start with 512 MB of memory and a 300-second timeout. If you encounter a 'signal: killed' error, consider increasing the memory limit.

## Deployment

Deploy your Lambda from Visual Studio by right-clicking the project, selecting 'Publish to AWS Lambda', and configuring the necessary settings.

## Testing

Activate your Lambda via the [AWS Lambda console](https://console.aws.amazon.com/lambda) or through Visual Studio, and start interacting with barcode data on AWS!
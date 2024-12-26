# Blazor Barcode Scanner Guide with IronBarcode

***Based on <https://ironsoftware.com/how-to/blazor/>***


IronBarcode seamlessly integrates with Blazor projects, and this guide will demonstrate how to incorporate IronBarcode into such projects.

The integration allows for capturing QR or Barcode images using a webcam. Leveraging Blazor and JavaScript, this tutorial guides you through sending images from the frontend to your C# backend where the IronBarcode library is used to decode the image's value. We'll explore how to set up a Blazor app that employs IronBarcode to decipher barcode or QR code data from webcam-captured images.

## Setting Up Your Blazor Project

Start by launching Visual Studio and creating a new Blazor Server App.

![](https://ironsoftware.com/static-assets/barcode/faq/blazor/CreateBlazorProject.png)

Name your project.

![](https://ironsoftware.com/static-assets/barcode/faq/blazor/ProjectName.png)

Choose the .NET 6 framework.

![](https://ironsoftware.com/static-assets/barcode/faq/blazor/SelectFramework.png)

Once set up, here's what your main screen should look like.

![](https://ironsoftware.com/static-assets/barcode/faq/blazor/MainScreen.png)

Now, add a new Razor component for the webcam functionality.

![](https://ironsoftware.com/static-assets/barcode/faq/blazor/NewRazorComponent.png)

Assign a name to it.

![](https://ironsoftware.com/static-assets/barcode/faq/blazor/NewRazorComponentName.png)

## Incorporating JavaScript for Webcam Functionality

To preserve privacy, it's advisable to manage webcam functionality directly on the client side. Begin by adding a JavaScript file named `webcam.js` to handle the webcam interactions.

![](https://ironsoftware.com/static-assets/barcode/faq/blazor/javascriptFileLocation.png)

Ensure this JavaScript file is loaded by including it in the `index.html` file.

```html
<script src="webcam.js"></script>
```

In `webcam.js`, add a function to activate the camera:

```javascript
// Declaration of the video stream variable
let videoStream;

// Initialize the camera and handle constraints
async function initializeCamera() {
    const canvas = document.querySelector("#canvas");
    const video = document.querySelector("#video");

    if (!("mediaDevices" in navigator) || !("getUserMedia" in navigator.mediaDevices)) {
        alert("Camera API is not available in your browser");
        return;
    }

    // Define video constraints
    const constraints = {
        video: {
            width: { min: 180 },
            height: { min: 120 },
            facingMode: useFrontCamera ? "user" : "environment"
        }
    };

    try {
        videoStream = await navigator.mediaDevices.getUserMedia(constraints);
        video.srcObject = videoStream;
    } catch (err) {
        alert("Could not access the camera: " + err);
    }
}
```

When the page loads, invoke the camera initialization within the `OnInitializedAsync()` method of `Index.razor`.

```cs
protected override async Task OnInitializedAsync()
{
    await JSRuntime.InvokeVoidAsync("initializeCamera");
}
```

Add HTML elements to display the video stream:

```html
<section class="section">
    <video autoplay id="video" width="320"></video>
</section>
```

## Image Capture

Create a JavaScript function in `webcam.js` to capture the video frame and send it for processing:

```javascript
function getFrame(dotNetHelper) {
    canvas.width = video.videoWidth;
    canvas.height = video.videoHeight;
    canvas.getContext('2d').drawImage(video, 0, 0);
    let dataUrl = canvas.toDataURL("image/png");
    dotNetHelper.invokeMethodAsync('ProcessImage', dataUrl);
}
```

Define a C# method to process the captured image:

```cs
[JSInvokable]
public async void ProcessImage(string imageString)
{
    var imageObject = new CamImage { imageDataBase64 = imageString };
    var jsonObj = System.Text.Json.JsonSerializer.Serialize(imageObject);
    var barcodeResult = await Http.PostAsJsonAsync("Ironsoftware/ReadBarCode", imageObject);

    if (barcodeResult.StatusCode == System.Net.HttpStatusCode.OK)
    {
        QRCodeResult = await barcodeResult.Content.ReadAsStringAsync();
        StateHasChanged();
    }
}
```

Invoke the image capture function on button click:

```cs
private async Task CaptureFrame()
{
    await JSRuntime.InvokeAsync<string>("getFrame", DotNetObjectReference.Create(this));
}
```

## Decoding with IronBarcode

First, integrate IronBarcode into the server project:

```shell
Install-Package BarCode
```

Next, define an API endpoint in your server project to process the encoded image data and retrieve the barcode information using IronBarcode:

```cs
[HttpPost]
[Route("ReadBarCode")]
public string ReadBarCode(CamImage imageData)
{
    try
    {
        var splitData = imageData.imageDataBase64.Split(',');
        var imageDataBytes = Convert.FromBase64String(splitData.Length > 1 ? splitData[1] : splitData[0]);
        IronBarCode.License.LicenseKey = "Key";

        using (var ms = new MemoryStream(imageDataBytes))
        {
            Image barcodeImage = Image.FromStream(ms);
            var result = IronBarCode.BarcodeReader.Read(barcodeImage);
            if (result == null || result.Value == null)
            {
                return $"{DateTime.Now} : Barcode not detected";
            }

            return $"{DateTime.Now} : Barcode is ({result.Value})";
        }
    }
    catch (Exception ex)
    {
        return $"Exception: {ex.Message}";
    }
}

public class CamImage
{
    public string imageDataBase64 { get; set; }
}
```

You can download the complete project [here](https://ironsoftware.com/static-assets/barcode/faq/blazor/BlazorIronBarcodeWithCAM.zip).
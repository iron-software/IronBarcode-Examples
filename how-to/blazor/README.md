# Blazor Barcode Scanner Guide with IronBarcode

***Based on <https://ironsoftware.com/how-to/blazor/>***


This guide demonstrates how to integrate IronBarcode into a Blazor project to effectively capture and read QR codes or barcodes from a user's webcam.

Utilizing Blazor alongside JavaScript, this approach allows you to retrieve QR or barcode data directly into your C# application via the IronBarcode library, which extracts the code value from the image. This tutorial will cover the steps to configure a Blazor application with IronBarcode to read QR and barcode data from a webcam feed.

## Setting Up the Blazor Project

Begin by launching Visual Studio, creating a new project, and selecting the Blazor Server App template.

![Blazor project creation process](https://ironsoftware.com/static-assets/barcode/faq/blazor/CreateBlazorProject.png)

Name your project:

![Naming the project](https://ironsoftware.com/static-assets/barcode/faq/blazor/ProjectName.png)

Choose .NET 6 as the framework:

![Selecting the framework](https://ironsoftware.com/static-assets/barcode/faq/blazor/SelectFramework.png)

Once set up, your main screen should look like this:

![Main screen after setup](https://ironsoftware.com/static-assets/barcode/faq/blazor/MainScreen.png)

Next, add a new Razor component for handling the webcam functionality:

![Adding a new Razor component](https://ironsoftware.com/static-assets/barcode/faq/blazor/NewRazorComponent.png)

Assign a name to your component:

![Naming the Razor component](https://ironsoftware.com/static-assets/barcode/faq/blazor/NewRazorComponentName.png)

## Integrating JavaScript for Webcam Access

For privacy reasons, it's beneficial to manage webcam interactions on the client side. Create a JavaScript file named `webcam.js` for managing webcam functions.

![Location for JavaScript file](https://ironsoftware.com/static-assets/barcode/faq/blazor/javascriptFileLocation.png)

Include your JavaScript file in the `index.html`:

```html
<script src="webcam.js"></script>
```

Add the camera initialization function to `webcam.js`:

```javascript
// Tracks the current video stream
let videoStream;
async function initializeCamera() {
    const canvas = document.querySelector("#canvas");
    const video = document.querySelector("#video");
    if (!("mediaDevices" in navigator && "getUserMedia" in navigator.mediaDevices)) {
        alert("Camera API is not available in your browser");
        return;
    }

    // Define video capture constraints
    const constraints = {
        video: {
            width: { min: 180 },
            height: { min: 120 },
            facingMode: useFrontCamera ? "user" : "environment"
        },
    };

    try {
        videoStream = await navigator.mediaDevices.getUserMedia(constraints);    
        video.srcObject = videoStream;
    } catch (err) {
        alert("Could not access the camera: " + err);
    }
}
```

Activate the webcam on page load by editing the `OnInitializedAsync()` method in `Index.razor`:

```csharp
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

## Image Capture Process

Construct a JavaScript function to capture a video frame as an image:

```javascript
function getFrame(dotNetHelper) {
    canvas.width = video.videoWidth;
    canvas.height = video.videoHeight;
    canvas.getContext('2d').drawImage(video, 0, 0);
    let dataUrl = canvas.toDataURL("image/png");
    dotNetHelper.invokeMethodAsync('ProcessImage', dataUrl);
}
```

This function captures a frame, encodes it in base64, and passes it to the `ProcessImage` function for server-side processing.

Define the `ProcessImage` function in your C# codebase:

```csharp
[JSInvokable]
public async void ProcessImage(string imageString)
{
    var imageObject = new CamImage { imageDataBase64 = imageString };
    var jsonObj = System.Text.Json.JsonSerializer.Serialize(imageObject);
    var barcodeResult = await Http.PostAsJsonAsync("Ironsoftware/ReadBarCode", imageObject);
    if (barcodeResult.StatusCode == System.Net.HttpStatusCode.OK)
    {
        QRCodeResult = barcodeResult.Content.ReadAsStringAsync().Result;
        StateHasChanged();
    }
}
```

Trigger image capture when the user presses the Capture Frame button:

```csharp
private async Task CaptureFrame()
{
    await JSRuntime.InvokeAsync<String>("getFrame", DotNetObjectReference.Create(this));
}
```

## Extracting Barcode Data with IronBarcode

First, add IronBarcode to your server project:

```shell
Install-Package BarCode
```

Create an API endpoint that processes the encoded image and extracts the QR or barcode data:

```csharp
[HttpPost]
[Route("ReadBarCode")]
public string ReadBarCode(CamImage imageData)
{
    try {
        var splitData = imageData.imageDataBase64.Split(',');
        byte[] imageBytes = Convert.FromBase64String((splitData.Length > 1) ? splitData[1] : splitData[0]);
        IronBarCode.License.LicenseKey = "Your-License-Key";

        using (var ms = new MemoryStream(imageBytes))
        {
            Image barcodeImage = Image.FromStream(ms);
            var result = IronBarCode.BarcodeReader.Read(barcodeImage);
            if (result == null || result.Value == null)
            {
                return $"{DateTime.Now}: Barcode not detected";
            }

            return $"{DateTime.Now}: Barcode is ({result.Value})";
        }
    } catch (Exception ex) {
        return $"Exception: {ex.Message}";
    }
}

public class CamImage
{
    public string imageDataBase64 { get; set; }
}
```

Find the sample project [here](https://ironsoftware.com/static-assets/barcode/faq/blazor/BlazorIronBarcodeWithCAM.zip).
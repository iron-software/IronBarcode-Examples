# Integrating IronBarcode with a Blazor Application

***Based on <https://ironsoftware.com/get-started/blazor/>***


This manual provides step-by-step guidance on using IronBarcode with a Blazor application, specifically illustrating how to scan barcodes and QR codes using a webcam.

## Setting Up the Blazor Project

Begin by launching Visual Studio and creating a new `Blazor Server App`:

![Create New Blazor Project](https://ironsoftware.com/static-assets/barcode/faq/blazor/CreateBlazorProject.png)

Specify your project's name and location:

![Set Project Name and Location](https://ironsoftware.com/static-assets/barcode/faq/blazor/ProjectName.png)

Choose **.NET 6** or another modern .NET Standard version:

![Select the Framework](https://ironsoftware.com/static-assets/barcode/faq/blazor/SelectFramework.png)

Proceed to the main development screen:

![Blazor Development Main Screen](https://ironsoftware.com/static-assets/barcode/faq/blazor/MainScreen.png)

To add webcam functionality, introduce a new Razor component:

![Add New Razor Component](https://ironsoftware.com/static-assets/barcode/faq/blazor/NewRazorComponent.png)

Name your new component and confirm by clicking _Add_:

![Name the New Razor Component](https://ironsoftware.com/static-assets/barcode/faq/blazor/NewRazorComponentName.png)

## Enabling Webcam Capability Using JavaScript

To manage webcam functionality, add a new JavaScript file named `webcam.js`:

![JavaScript File Location](https://ironsoftware.com/static-assets/barcode/faq/blazor/javascriptFileLocation.png)

Include the `webcam.js` file in your project's `index.html`:

```html
<script src="webcam.js"></script>
```

The content of `webcam.js` with camera initialization looks like:

```javascript
let videoStream;

async function initializeCamera() {
    const canvas = document.querySelector("#canvas");
    const video = document.querySelector("#video");
    
    if (!("mediaDevices" in navigator) || !("getUserMedia" in navigator.mediaDevices)) {
        alert("Camera API is unavailable in this browser");
        return;
    }

    const constraints = {
        video: { width: { min: 180 }, height: { min: 120 } },
        facingMode: useFrontCamera ? "user" : "environment"
    };

    try {
        videoStream = await navigator.mediaDevices.getUserMedia(constraints);
        video.srcObject = videoStream;
    } catch (err) {
        alert("Failed to access the camera: " + err);
    }
}
```

Invoke `initializeCamera()` when the Blazor app loads by modifying `OnInitializedAsync()` in `Index.razor`:

```csharp
protected override async Task OnInitializedAsync()
{
    await JSRuntime.InvokeVoidAsync("initializeCamera");
}
```

Define HTML elements to display the webcam stream:

```html
<section class="section">
    <video autoplay id="video" width="320"></video>
</section>
```

## Capturing Images from the Webcam

Define a function in `webcam.js` to capture video frames and send them to the server:

```javascript
function getFrame(dotNetHelper) {
    canvas.width = video.videoWidth;
    canvas.height = video.videoHeight;

    canvas.getContext('2d').drawImage(video, 0, 0);

    const dataUrl = canvas.toDataURL("image/png");
    
    dotNetHelper.invokeMethodAsync('ProcessImage', dataUrl);
}
```

`ProcessImage()` in C# handles the received image data and processes it server-side:

```csharp
[JSInvokable]
public async Task ProcessImage(string imageString)
{
    var imageObject = new CamImage { imageDataBase64 = imageString };
    var json = System.Text.Json.JsonSerializer.Serialize(imageObject);
    
    var response = await Http.PostAsJsonAsync("Ironsoftware/ReadBarCode", imageObject);
    if (response.StatusCode == System.Net.HttpStatusCode.OK)
    {
        QRCodeResult = await response.Content.ReadAsStringAsync();
        StateHasChanged();
    }
}
```

Trigger `getFrame()` when the **Capture Frame** button is clicked:

```csharp
private async Task CaptureFrame()
{
    await JSRuntime.InvokeAsync<String>("getFrame", DotNetObjectReference.Create(this));
}
```

## Extracting Barcodes from Captured Images

Add the IronBarcode library to your solution:

```shell
dotnet add package IronBarCode
```

Implement a server-side API method to decode the image and extract barcode/QR values:

```csharp
[HttpPost]
[Route("ReadBarCode")]
public string ReadBarCode(CamImage imageData)
{
    try {
        var data = Convert.FromBase64String(imageData.imageDataBase64.Split(',')[1]);
        IronBarCode.License.LicenseKey = "Key"; 
        using var ms = new MemoryStream(data);
        var barcodeImage = Image.FromStream(ms);
        var result = BarcodeReader.Read(barcodeImage);
        return result == null ? $"{DateTime.Now}: Barcode Not Detected" : $"{DateTime.Now}: Barcode is ({result.Value})";
    }
    catch (Exception ex) {
        return $"Exception: {ex.Message}";
    }
}

public class CamImage
{
    public string imageDataBase64 { get; set; }
}
```

The sample project is available [here](https://ironsoftware.com/static-assets/barcode/faq/blazor/BlazorIronBarcodeWithCAM.zip).
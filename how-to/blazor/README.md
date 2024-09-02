# Blazor Barcode Scanner Guide Using IronBarcode

This guide covers the integration of IronBarcode within a Blazor application. By leveraging IronBarcode, it's feasible to decode QR codes or Barcodes captured from a user's webcam. The combination of Blazor and JavaScript is impactful as it allows capturing images and processing them in C# using IronBarcode. In this guide, we'll step through setting up a Blazor project and using IronBarcode to analyze QR and Barcode data captured from a webcam.

## Setting Up Your Blazor Project

Start by launching Visual Studio, and go through these steps: Create New Project => Select Blazor Server App.

![Create Blazor Project](https://ironsoftware.com/static-assets/barcode/faq/blazor/CreateBlazorProject.png) 

Specify your project Name.

![Project Name](https://ironsoftware.com/static-assets/barcode/faq/blazor/ProjectName.png) 

Choose the framework, ideally .NET 6.

![Select Framework](https://ironsoftware.com/static-assets/barcode/faq/blazor/SelectFramework.png) 

Confirmation that setup is complete.

![Main Screen](https://ironsoftware.com/static-assets/barcode/faq/blazor/MainScreen.png) 

Add a new Razor component for camera functionality.

![New Razor Component](https://ironsoftware.com/static-assets/barcode/faq/blazor/NewRazorComponent.png) 

Name the new component appropriately.

![New Razor Component Name](https://ironsoftware.com/static-assets/barcode/faq/blazor/NewRazorComponentName.png) 


## Implementing JavaScript for Webcam Access

To maintain client-side privacy while using the webcam, add a JavaScript file named `webcam.js` containing the camera functionalities.

![Location of JavaScript File](https://ironsoftware.com/static-assets/barcode/faq/blazor/javascriptFileLocation.png) 

Ensure the JavaScript file is linked within the `index.html` file:

```html
<script src="webcam.js"></script>
```

Add the following initial camera setup in `webcam.js`:

```javascript
// Track the current video stream
let videoStream;
async function initializeCamera() {
    const canvas = document.querySelector("#canvas");
    const video = document.querySelector("#video");
    if (!("mediaDevices" in navigator) || !("getUserMedia" in navigator.mediaDevices)) {
        alert("Camera API is not available in your browser.");
        return;
    }

    // Constraints for the video
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
        alert("Could not access the camera. Error: " + err);
    }
}
```

Initialize your webcam when the web page loads by adding this to `OnInitializedAsync` method in `Index.razor`:

```cs
protected override async Task OnInitializedAsync()
{
    await JSRuntime.InvokeVoidAsync("initializeCamera");
}
```

Include HTML tags to display the video stream:

```html
<section class="section">
    <video autoplay id="video" width="320"></video>
</section>
```
## Image Capture

Write a JavaScript function in `webcam.js` to capture a frame from the webcam feed. This function transfers the video frame to the canvas and converts it to a Base64-encoded string:

```javascript
function getFrame(dotNetHelper) {
    canvas.width = video.videoWidth;
    canvas.height = video.videoHeight;
    canvas.getContext('2d').drawImage(video, 0, 0);
    let dataUrl = canvas.toDataURL("image/png");
    // Invoke ProcessImage Function and send DataUrl as a parameter
    dotNetHelper.invokeMethodAsync('ProcessImage', dataUrl);
}
```

Process the captured image frame server-side with C#:

```cs
[JSInvokable]
public async void ProcessImage(string imageString)
{
    var imageObject = new CamImage { imageDataBase64 = imageString };
    var serializedObject = System.Text.Json.JsonSerializer.Serialize(imageObject);

    // Process image here
    var barcodeResult = await Http.PostAsJsonAsync("Ironsoftware/ReadBarCode", imageObject);
    if (barcodeResult.IsSuccessStatusCode) {
        QRCodeResult = await barcodeResult.Content.ReadAsStringAsync();
        StateHasChanged();
    }
}
```

This method should be triggered when the "Capture Frame" button is clicked:

```cs
private async Task CaptureFrame()
{
    await JSRuntime.InvokeAsync<string>("getFrame", DotNetObjectReference.Create(this));
}
```

## Extracting Data with IronBarcode

Integrate IronBarcode in your server-side Blazor project.

```shell
Install-Package BarCode
```

Implement the API endpoint to decode the barcode from the captured image:

```cs
[HttpPost]
[Route("ReadBarCode")]
public string ReadBarCode(CamImage imageData)
{
    try {
        var splitData = imageData.imageDataBase64.Split(',');
        byte[] imageBytes = Convert.FromBase64String((splitData.Length > 1) ? splitData[1] : splitData[0]);
        IronBarCode.License.LicenseKey = "YOUR_LICENSE_KEY";

        using (var ms = new MemoryStream(imageBytes)) {
            Image barcodeImage = Image.FromStream(ms);
            var result = IronBarCode.BarcodeReader.Read(barcodeImage);
            if (result == null || result.Value == null) {
                return $"{DateTime.Now} : No barcode detected.";
            }

            return $"{DateTime.Now} : Barcode detected ({result.Value}).";
        }
    } catch (Exception ex) {
        return $"Exception occurred: {ex.Message}";
    }
}

public class CamImage
{
    public string imageDataBase64 { get; set; }
}
```

Explore the completed project [here](https://ironsoftware.com/static-assets/barcode/faq/blazor/BlazorIronBarcodeWithCAM.zip).
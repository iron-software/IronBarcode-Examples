# How to Implement Barcode Reading and Writing in iOS with .NET MAUI

> Full guide: [How to Implement Barcode Reading and Writing in iOS with .NET MAUI](https://ironsoftware.com/csharp/barcode/get-started/ios/)


<div class="container-fluid">
    <div class="row">
        <div class="col-md-2">
            <img src="https://ironsoftware.com/img/platforms/h74/ios.svg">
        </div>
    </div>
</div>

.NET MAUI (Multi-platform App UI) extends Xamarin.Forms, offering a cohesive framework for building cross-platform apps using .NET. This framework allows developers to craft native interfaces that operate smoothly across Android, iOS, macOS, and Windows, simplifying the application development lifecycle.

The **BarCode.iOS package** introduces barcode functionality specifically for iOS development.

## IronBarcode iOS Package Introduction

The **BarCode.iOS package** is designed exclusively for implementing barcode functionalities on iOS devices within .NET cross-platform projects, eliminating the need for the standard BarCode package.

```shell
Install-Package BarCode.iOS
```

<link rel="stylesheet" type="text/css" href="https://ironsoftware.com/front/css/content__install-components__extended.css" media="print" onload="this.media='all'; this.onload=null;">
<div class="products-download-section">
    <div class="js-modal-open product-item nuget" style="width: fit-content; margin-left: auto; margin-right: auto;" data-modal-id="trial-license-after-download">
        <div class="product-image">
            <img class="img-responsive add-shadow" alt="C# NuGet Library for PDF" src="https://ironsoftware.com/img/nuget-logo.svg">
        </div>
        <div class="product-info">
            <h3>Install with <span>NuGet</span></h3>
        </div>
        <div class="js-open-modal-ignore copy-nuget-section" data-toggle="tooltip" data-placement="bottom" title="" data-original-title="Click to copy">
            <div class="copy-nuget-row">
            <pre class="install-script">Install-Package BarCode.iOS</pre>
            <div class="copy-button">
                <button class="btn btn-default copy-nuget-script" type="button" data-toggle="popover" data-placement="bottom" data-content="Copied." aria-label="Copy the Package Manager command" data-original-title="" title="">
                <span class="far fa-copy"></span>
                </button>
            </div>
        </div>
    </div>
    <div class="nuget-link">nuget.org/packages/BarCode.iOS/</div>
    </div>
</div>

## Establishing a .NET MAUI Project

Choose .NET MAUI App under the Multiplatform category and proceed.

![Create .NET MAUI App project](https://ironsoftware.com/static-assets/barcode/how-to/setup-on-ios/create-maui-app.webp)

## Adding the BarCode.iOS Library

Incorporating the library is straightforward, especially through NuGet.

1. In Visual Studio, navigate to "Dependencies > Nuget" by right-clicking and choose "Manage NuGet Packages ...".
2. Under the "Browse" tab, search for "BarCode.iOS".
3. Locate and select the "BarCode.iOS" package then hit "Add Package".

To ensure compatibility only with iOS, adjust the csproj file:

1. Right-click the *.csproj file and pick "Edit Project File".
2. Insert a new ItemGroup condition as shown:

```xml
<ItemGroup Condition="$(TargetFramework.Contains('ios')) == true">
    <PackageReference Include="BarCode.iOS" Version="2025.3.4" />
</ItemGroup>
```

3. Relocate the "BarCode.iOS" PackageReference into the new ItemGroup.

This adjustment restricts the "BarCode.iOS" package from being utilized on platforms such as Android. For Android devices, install [BarCode.Android](https://nuget.org/packages/BarCode.Android/).

## Designing the App Interface

Adjust the XAML file to incorporate inputs for barcode and QR code generation, including a button to select a document for barcode reading, as demonstrated below:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="IronBarcodeMauiIOS.MainPage">
 
    <VerticalStackLayout Padding="20">
        <HorizontalStackLayout>
            <CheckBox x:Name="generatePdfCheckBox" IsChecked="{Binding IsGeneratePdfChecked}" />
            <Label Text="PDF (unchecked for PNG)" VerticalOptions="Center"/>
        </HorizontalStackLayout>
    
        <Entry x:Name="barcodeInput" Placeholder="Enter barcode value..." />
        <Button Text="Generate and save barcode" Clicked="WriteBarcode" />

        <Entry x:Name="qrInput" Placeholder="Enter QR code value..." />
        <Button Text="Generate and save QR code" Clicked="WriteQRcode" />

        <Button
        Text="Read Barcode"
        Clicked="ReadBarcode"
        Grid.Row="0"
        HorizontalOptions="Center"
        Margin="20, 20, 20, 10"/>
        <ScrollView
        Grid.Row="1"
        BackgroundColor="LightGray"
        Padding="10"
        Margin="10, 10, 10, 30">
            <Label x:Name="OutputText"/>
        </ScrollView>
    </VerticalStackLayout>
 
</ContentPage>
```

## Barcode Operations

Utilize the MainPage.xaml setup provided to configure barcode and QR code generation, ensuring a license key is set. Here's an explanation of the process:

```csharp
using IronBarCode;
namespace IronBarcodeMauiIOS;
public partial class MainPage : ContentPage
{
    public bool IsGeneratePdfChecked
    {
        get => generatePdfCheckBox.IsChecked;
        set
        {
            generatePdfCheckBox.IsChecked = value;
        }
    }

    public MainPage()
    {
        InitializeComponent();
        IronBarCode.License.LicenseKey = "IRONBARCODE-MYLICENSE-KEY-1EF01";
    }
    
    // Method to generate and save a barcode
    private async void WriteBarcode(object sender, EventArgs e)
    {
        // If the barcode input isn't empty, proceed to generate barcode
        try
        {
            if (!string.IsNullOrEmpty(barcodeInput.Text))
            {
                var barcode = BarcodeWriter.CreateBarcode(barcodeInput.Text, BarcodeEncoding.EAN13);

                // Set file extension based on checkbox state
                string fileExtension = IsGeneratePdfChecked ? "pdf" : "png";
                string fileName = $"Barcode_{DateTime.Now:yyyyMMddHHmmss}.{fileExtension}";
                byte[] fileData = IsGeneratePdfChecked ? barcode.ToPdfBinaryData() : barcode.ToPngBinaryData();

                // Save the created barcode to the appropriate location
                await SaveToDownloadsAsync(fileData, fileName);
            }
        }
        catch (Exception ex)
        {
            // Exceptions should be logged for troubleshooting
            System.Diagnostics.Debug.WriteLine(ex);
        }
    }

    // Method to generate and save a QR code
    private async void WriteQRcode(object sender, EventArgs e)
    {
        // If the QR code input isn't empty, proceed to generate QR code
        try
        {
            if (!string.IsNullOrEmpty(qrInput.Text))
            {
                var barcode = QRCodeWriter.CreateQrCode(qrInput.Text);

                // Set file extension based on checkbox state
                string fileExtension = IsGeneratePdfChecked ? "pdf" : "png";
                string fileName = $"QRcode_{DateTime.Now:yyyyMMddHHmmss}.{fileExtension}";
                byte[] fileData = IsGeneratePdfChecked ? barcode.ToPdfBinaryData() : barcode.ToPngBinaryData();

                // Save the created QR code to the appropriate location
                await SaveToDownloadsAsync(fileData, fileName);
            }
        }
        catch (Exception ex)
        {
            // Exceptions should be logged for troubleshooting
            System.Diagnostics.Debug.WriteLine(ex);
        }
    }

    // Method to read a barcode from a file
    private async void ReadBarcode(object sender, EventArgs e)
    {
        try
        {
            var options = new PickOptions
            {
                PickerTitle = "Please select a file"
            };
            var file = await FilePicker.PickAsync(options);

            OutputText.Text = "";

            if (file != null)
            {
                using var stream = await file.OpenReadAsync();
                BarcodeResults result;

                // Determine if the document is a PDF or an image
                if (file.ContentType.Contains("pdf"))
                {
                    result = BarcodeReader.ReadPdf(stream);
                }
                else
                {
                    result = BarcodeReader.Read(stream);
                }

                // Display the results
                string barcodeResult = "";
                int count = 1;
                result.ForEach(x => { barcodeResult += $"barcode {count}: {x.Value}
"; count++; });
                OutputText.Text = barcodeResult;
            }
        }
        catch (Exception ex)
        {
            // Log exceptions to debug output
            System.Diagnostics.Debug.WriteLine(ex);
        }
    }

    // Method to save file data to the Downloads folder (or Documents on iOS)
    public async Task SaveToDownloadsAsync(byte[] fileData, string fileName)
    {
        // #if IOS
        // Define the custom path you want to save to
        var customPath = "/Users/Iron/Library/Developer/CoreSimulator/Devices/7D1F57F2-1103-46DA-AEE7-C8FC871502F5/data/Containers/Shared/AppGroup/37CD82C0-FCFC-45C7-94BB-FFEEF7BAFF13/File Provider Storage/Document";

        // Combine the custom path with the file name
        var filePath = Path.Combine(customPath, fileName);

        try
        {
            // Create the directory if it doesn't exist
            if (!Directory.Exists(customPath))
            {
                Directory.CreateDirectory(customPath);
            }

            // Save the file to the specified path
            await File.WriteAllBytesAsync(filePath, fileData);

            // Display a success message
            await Application.Current.MainPage.DisplayAlert("Saved", $"File saved to {filePath}", "OK");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Error saving file: " + ex.Message);
        }
        // #endif
    }
}
```

`ReadBarcode` opens the picked file as a stream and branches on its content
type: `BarcodeReader.ReadPdf` for a PDF, `BarcodeReader.Read` for an image.
Both return a `BarcodeResults` collection, which is enumerated into the output
label.

`SaveToDownloadsAsync` is where the platforms diverge. The custom path in the
snippet is a simulator container on one particular machine; substitute the
directory your own build writes to.

Lastly, switch the build target to iOS Simulator and run the project.

## Frequently Asked Questions

**Which package do I install?**
`BarCode.iOS`, not the standard `BarCode` package. It carries the iOS-specific
build of the library.

**What do I need before starting?**
A .NET MAUI project, the MAUI workload installed, and a Mac to build and run the
iOS target.

**Which method generates a barcode?**
`BarcodeWriter.CreateBarcode` for a linear barcode, `QRCodeWriter.CreateQrCode`
for a QR code. Both return a `GeneratedBarcode`.

**How do I save the result as a PDF or a PNG?**
`GeneratedBarcode.ToPdfBinaryData()` and `ToPngBinaryData()` return the bytes;
write them wherever the platform allows.

**The barcode is not recognised. What should I check?**
Confirm the image is in focus and the whole symbol is inside the frame, and that
the encoding you are reading matches what was written.

**Why set a license key?**
Without one the library runs in trial mode and stamps its output.

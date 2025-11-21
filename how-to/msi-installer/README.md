# Building an MSI Installer with IronBarCode

***Based on <https://ironsoftware.com/how-to/msi-installer/>***


A Microsoft Installer (MSI) package is crucial for the management of software installation, updates, and uninstalls on Windows platforms. It offers a systematized approach for deploying applications, critical for enterprise environments.

IronBarCode integrates with your applications to transform them into MSI packages, ensuring consistent installations across different systems and allowing you to choose which components to include.

In this tutorial, we will learn how to craft an MSI file using a simple barcode application.

## Quickstart: Generate and Read an MSI Barcode with Ease

With IronBarcode’s straightforward API, you can generate and decode MSI barcodes effortlessly. Here is how you can create and scan an MSI barcode image quickly using just a few lines of code:

```cs
:title=Quickly Create and Read MSI Barcodes Using IronBarcode
var msiImage = IronBarCode.BarcodeWriter.CreateBarcode("12345", BarcodeWriterEncoding.MSI).SaveAsImage("barcode-msi.png");
var scanResults = IronBarCode.BarcodeReader.Read("barcode-msi.png", new BarcodeReaderOptions { ExpectBarcodeTypes = BarcodeEncoding.MSI });
```

---

## Prerequisites

Ensure you have [Microsoft Visual Studio Installer Projects extension](https://marketplace.visualstudio.com/items?itemName=VisualStudioClient.MicrosoftVisualStudio2022InstallerProjects) downloaded to proceed with creating MSI installers.

## Setting Up an MSI Installer

We will demonstrate this using a .NET Framework Windows Forms App project.

## Adding a Button

- Go to the ToolBox.
- Find and select Button.
- Drag and drop it onto the Windows form.

![Button Addition](https://ironsoftware.com/static-assets/barcode/how-to/msi-installer/add-button.webp)

## Button Code Modification

To access the C# code of the form, double-click on the button control. This code will handle the barcode scanning from an image file (for PDFs, use the `ReadPdf` method).

```cs
using IronBarCode;
using IronSoftware.Drawing;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MsiInstallerSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IronSoftware.Logger.LoggingMode = IronSoftware.Logger.LoggingModes.All;
            IronSoftware.Logger.LogFilePath = "Default.log";
            IronBarCode.License.LicenseKey = "IRONBARCODE-YOUR-LICENSE-KEY";

            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "Image files (*.*)|*.*";

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (Bitmap bitmap = new Bitmap(fileDialog.FileName))
                        {
                            AnyBitmap imageBitmap = AnyBitmap.FromBitmap(bitmap);
                            var readerOptions = new BarcodeReaderOptions
                            {
                                Speed = ReadingSpeed.Detailed,
                                ExpectMultipleBarcodes = true,
                                ScanMode = BarcodeScanMode.Auto
                            };

                            BarcodeResults readResults = IronBarCode.BarcodeReader.Read(imageBitmap, readerOptions);

                            if (readResults.Count > 0)
                            {
                                string accumulatedBarcodes = "";
                                foreach (var barcode in readResults)
                                {
                                    Console.WriteLine($"Barcode Found: {barcode.Text}");
                                    accumulatedBarcodes += barcode.Text + "\n";
                                }

                                MessageBox.Show($"Detected Barcodes: \n{accumulatedBarcodes}");
                            }
                            else
                            {
                                MessageBox.Show("No barcode detected.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }
        }
    }
}
```

## Integrating a Setup Project

To package your form and its logic into an MSI installer, add a Setup Project to your solution.

Right-click on the solution, select **Add** > **New Project...**

![Setup Project Addition](https://ironsoftware.com/static-assets/barcode/how-to/msi-installer/add-setup-project.webp) 

Within the Setup Project, include the following files crucial for ensuring functionality:

- `onnxruntime.dll`
- `IronBarcodeInterop.dll`
- `ReaderInterop.dll`

![DLL Inclusion](https://ironsoftware.com/static-assets/barcode/how-to/msi-installer/add-additional-dll.webp)

Should any file be missing, see the troubleshooting guide: [Missing DLLs in Creating MSI Installer](https://ironsoftware.com/csharp/barcode/troubleshooting/missing-dll-msi-installer/)

Build your Setup Project. The MSI installer will be located under: MsiInstallerSample\SetupProject\Release

## Testing the Installer

Run the installer using the newly created MSI file to verify everything works as intended.

![Installation Demo](https://ironsoftware.com/static-assets/barcode/how-to/msi-installer/demonstration.gif)

## Get the MSI Installer Sample Project

Access the full code of this guide in a downloadable zipped file, ready to open in Visual Studio as a WinFormApp project.

[Download the WinForm MSI App Project](https://ironsoftware.com/static-assets/barcode/how-to/msi-installer/MsiInstallerSample.zip)
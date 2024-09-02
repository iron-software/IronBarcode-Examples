# Utilizing Iron Barcode License Keys

## Acquiring a License Key

Integrating an IronBarcode license key into your project enables you to launch your application live, free from restrictions and watermarks.

Secure your license by [purchasing one here](https://ironsoftware.com/csharp/barcode/licensing/) or register to receive a [free 30-day trial key](#).

---

## Step 1: Obtain the Most Recent Version of IronBarcode

### Installation via NuGet

Start by installing the latest IronBarcode NuGet Package.

```shell
Install-Package BarCode
```

Find further details on the NuGet package [here](https://www.nuget.org/packages/BarCode/).

### Installation via DLL

Alternatively, the [IronBarCode DLL can be directly downloaded](https://ironsoftware.com/csharp/barcode/packages/IronBarCode.zip) and referenced in your project from the [.NET Barcode DLL].

---

## Step 2: Incorporate Your License Key

### Utilizing Code to Set Your License

Incorporate this snippet in your application's startup sequence, prior to utilizing IronBarcode.

```cs
IronBarCode.License.LicenseKey = "IRONBARCODE-MYLICENSE-KEY-1EF01";
```

---

### Applying a License with Web.Config or App.Config

To configure the license key throughout your application via Web.Config or App.Config, insert the following entry within your config file under appSettings.

```xml
<configuration>
...
  <appSettings>
    <add key="IronBarCode.LicenseKey" value="IRONBARCODE-MYLICENSE-KEY-1EF01"/>
  </appSettings>
...
</configuration>
```

Be aware of a licensing interference occurring between IronBarCode versions [2023.4.1 to 2024.3.2](https://www.nuget.org/packages/BarCode/2024.3.2) affecting:
- **ASP.NET** deployments
- **.NET Framework versions ≥ 4.6.2**

The licensing key from a `Web.config` file may not be recognized. For troubleshooting, visit the [Setting License Key in Web.config guide](https://ironsoftware.com/csharp/barcode/troubleshooting/license-key-web.config/).

Confirm licensing with `IronBarCode.License.IsLicensed`.

---

### Configuring a License Key in .NET Core via appsettings.json

For global application key settings in .NET Core:

- Create a `appsettings.json` in the project root
- Add an `IronBarCode.LicenseKey` entry. Set the value as your license key.
- Ensure the file's properties are set to *Copy to Output Directory: Copy always*

Example file: `appsettings.json`
```json
{
	"IronBarCode.LicenseKey":"IRONBARCODE-MYLICENSE-KEY-1EF01"
}  
```

---

## Step 3: Validate Your License

Execute the following to confirm proper license installation.

```cs
bool result = IronBarCode.License.IsValidLicense("IRONBARCODE-MYLICENSE-KEY-1EF01");

// Verify the licensing status
bool is_licensed = IronBarCode.License.IsLicensed;
```

---

## Step 4: Initiate Your Project

For guidelines on starting with IronBarcode, review our [Getting Started with IronBarcode tutorial](https://ironsoftware.com/csharp/barcode/docs/).

---

## Need Assistance? 

For any inquiries, please contact [support@ironsoftware.com](mailto:support@ironsoftware.com).
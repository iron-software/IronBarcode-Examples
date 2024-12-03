# Using Iron Barcode License Keys

***Based on <https://ironsoftware.com/how-to/license-keys/>***


## Obtaining a License Key

Deploy your projects without any limitations or watermarks by adding an IronBarcode license key.

Purchase a license [here](https://ironsoftware.com/csharp/barcode/licensing/) or obtain a [free 30-day trial key here](https://ironsoftware.com/csharp/barcode/licensing/#trial-license).

---

## Step 1: Acquire the Latest IronBarcode Version

### Installation via NuGet

First, let's install the most recent Barcode NuGet Package.

```shell
Install-Package BarCode
```

Visit [NuGet](https://www.nuget.org/packages/BarCode/) for more details.

### Manual Installation

Alternatively, download the [IronBarCode.Dll](https://ironsoftware.com/csharp/barcode/packages/IronBarCode.zip) and reference it in your project from [.NET Barcode DLL](https://ironsoftware.com/csharp/barcode/packages/IronBarCode.zip).

---

## Step 2: Implement Your License Key

### Applying Your License Programmatically

Ensure to incorporate this snippet at the beginning of your application, before utilizing IronBarcode.

```cs
IronBarCode.License.LicenseKey = "IRONBARCODE-MYLICENSE-KEY-1EF01";
```

### Configuring License through Web.Config or App.Config

For global application settings via Web.Config or App.Config, insert this key:

```xml
<configuration>
...
  <appSettings>
    <add key="IronBarCode.LicenseKey" value="IRONBARCODE-MYLICENSE-KEY-1EF01"/>
  </appSettings>
...
</configuration>
```

If you are using IronBarCode versions from [2023.4.1](https://www.nuget.org/packages/BarCode/2023.4.1) to [2024.3.2](https://www.nuget.org/packages/BarCode/2024.3.2) in ASP.NET projects or in .NET Framework version 4.6.2 or higher, you may encounter a license key recognition problem in `Web.config`. Check out our guide to [Setting License Key in Web.config](https://ironsoftware.com/csharp/barcode/troubleshooting/license-key-web.config/) for help.

Confirm licensing via `IronBarCode.License.IsLicensed`.

---

### Configuring License through .NET Core appsettings.json

For .NET Core global application settings:

1. Add an `appsettings.json` to your project's root.
2. Insert this key into your JSON config file. Set the value to your license key.
3. Ensure the file's properties are set to *Copy to Output Directory: Copy Always*.

File Example: *appsettings.json*
```json
{
  "IronBarCode.LicenseKey":"IRONBARCODE-MYLICENSE-KEY-1EF01"
}  
```

---

## Step 3: Verify Your License Key

Test if your license key was applied correctly.

```cs
bool result = IronBarCode.License.IsValidLicense("IRONBARCODE-MYLICENSE-KEY-1EF01"); // Checks license validity

bool is_licensed = IronBarCode.License.IsLicensed; // Verifies successful licensing
```

---

## Step 4: Initialize Your Project

Begin your development by following our [Getting Started with IronBarcode guide](https://ironsoftware.com/csharp/barcode/docs/).

---

## Need Assistance?

For any inquiries, please contact our support team at [support@ironsoftware.com](mailto:support@ironsoftware.com).
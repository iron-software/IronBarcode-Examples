# Using Iron Barcode License Keys

***Based on <https://ironsoftware.com/get-started/license-keys/>***


## Obtaining a License Key

Unlock the full capabilities of IronBarcode by obtaining a license key, which allows you to deploy your projects without any limitations or watermarks.

Secure a license by [purchasing a license key](https://ironsoftware.com/csharp/barcode/licensing/) or by obtaining a [no-cost 30-day trial key here](https://ironsoftware.com/trial-license).

<hr class="separator">

## Step 1: Install the Latest Version of IronBarcode

!!!--LIBRARY_START_TRIAL_BLOCK--!!!

### Installation via NuGet

Initially, let's install the most recent version of IronBarcode using the NuGet Package Manager.

```shell
Install-Package BarCode
```

For more details regarding the NuGet package, visit [NuGet's website](https://www.nuget.org/packages/BarCode/).

### Installation via DLL

Alternatively, you can download the [IronBarcode.dll](https://ironsoftware.com/csharp/barcode/packages/IronBarCode.zip) and include it in your project.

<hr class="separator">

## Step 2: Activating Your License Key

### Implementing the License via Code

To activate your license, insert this line of code at the beginning of your application, before utilizing IronBarcode.

```csharp
// Setting the IronBarcode license key
IronBarCode.License.LicenseKey = "IRONBARCODE-MYLICENSE-KEY-1EF01";
```

<hr class="separator">

### Implementing the License via Web.Config or App.Config

For a global application key setup using Web.Config or App.Config, insert the following entry in the `appSettings` of your configuration file.

```xml
<configuration>
  ...
  <appSettings>
    <add key="IronBarCode.LicenseKey" value="IRONBARCODE-MYLICENSE-KEY-1EF01"/>
  </appSettings>
  ...
</configuration>
```

Please note, there are license recognition issues in IronBarCode ranging from version [2023.4.1](https://www.nuget.org/packages/BarCode/2023.4.1) to [2024.3.2](https://www.nuget.org/packages/BarCode/2024.3.2) specifically affecting:
- **ASP.NET** projects
- **.NET Framework version 4.6.2 and up**

The licensing configuration in a `Web.config` may not be acknowledged. For assistance, visit our guide on [Addressing License Key Issues in Web.config](https://ironsoftware.com/csharp/barcode/troubleshooting/license-key-web.config/).

<hr class="separator">

### Implementing the License via .NET Core's appsettings.json

For application-wide key activation in a .NET Core project:

* Create and append the `appsettings.json` file in your project root.
* Add the `IronBarCode.LicenseKey` entry with your license key.
* Make sure to set the file property to *Copy to Output Directory: Copy always*.

Example file: *appsettings.json*

```json
{
  "IronBarCode.LicenseKey": "IRONBARCODE-MYLICENSE-KEY-1EF01"
}
```

<hr class="separator">

## Step 3: Verify Your License

Ensure your license is correctly activated.

```csharp
// Validate the installed license key
bool result = IronBarCode.License.IsValidLicense("IRONBARCODE-MYLICENSE-KEY-1EF01");

// Determine if IronBarCode is fully licensed
bool is_licensed = IronBarCode.License.IsLicensed;
```

<hr class="separator">

## Step 4: Begin Your Project

Kickstart your development by following our [IronBarcode Getting Started Guide](https://ironsoftware.com/csharp/barcode/docs/).

<hr class="separator">

## Need Help?

For additional guidance or support, feel free to contact [support@ironsoftware.com](mailto:support@ironsoftware.com).
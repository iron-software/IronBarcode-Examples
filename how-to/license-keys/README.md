# Working with Iron Barcode License Keys

***Based on <https://ironsoftware.com/how-to/license-keys/>***


## Acquiring a License Key

To utilize IronBarcode in a live project environment without any watermarks or limitations, you'll need a license key.

You can [purchase a license here](https://ironsoftware.com/csharp/barcode/licensing/) or register for a [free 30-day trial key](https://ironsoftware.com/csharp/barcode/trial-license).

<hr class="separator">

## Step 1: Install the Latest IronBarcode Version

### Installation via NuGet

Initially, you need to install the Iron Barcode NuGet Package to proceed.

```shell
Install-Package BarCode
```

Check out the package on [NuGet](https://www.nuget.org/packages/BarCode/).

### Installation via DLL

Alternatively, you can [download the IronBarCode DLL](https://ironsoftware.com/csharp/barcode/packages/IronBarCode.zip) and include it in your project by referencing it from the [.NET Barcode DLL].

<hr class="separator">

## Step 2: Implement Your License Key

### Applying your license with code

Insert this code early in your application's initialization sequence, prior to using IronBarcode.

```cs
IronBarCode.License.LicenseKey = "IRONBARCODE-MYLICENSE-KEY-1EF01";
```
<hr class="separator">

### Applying your license through Web.Config or App.Config

For a global application key setup using Web.Config or App.Config, incorporate this setting in your config file under appSettings.

```xml
<configuration>
...
  <appSettings>
    <add key="IronBarCode.LicenseKey" value="IRONBARCODE-MYLICENSE-KEY-1EF01"/>
  </appSettings>
...
</configuration>
```

Be aware of a current license issue affecting IronBarCode versions [2023.4.1](https://www.nuget.org/packages/BarCode/2023.4.1) to [2024.3.2](https://www.nuget.org/packages/BarCode/2024.3.2) in:
- **ASP.NET** projects
- **.NET Framework versions >= 4.6.2**

The `Web.config` file does not consistently relay the license key to the application. For more info, see '[Setting License Key in Web.config](https://ironsoftware.com/csharp/barcode/troubleshooting/license-key-web.config/)'.

Confirm the licensing status with `IronBarCode.License.IsLicensed` to ensure it returns `true`.

<hr class="separator">

### Applying your license key in a .NET Core appsettings.json file

For a global key setup in a .NET Core application:

- Add a JSON file called `appsettings.json` in your project’s root directory.
- Include an 'IronBarCode.LicenseKey' in your JSON configuration. The value should be your license key.
- Set the file properties to include *Copy to Output Directory: Copy always*

File: *appsettings.json*
```json
{
	"IronBarCode.LicenseKey":"IRONBARCODE-MYLICENSE-KEY-1EF01"
}  
```

<hr class="separator">

## Step 3: Verify Your Key

Test the correctness of your key installation.

```cs
bool result = IronBarCode.License.IsValidLicense("IRONBARCODE-MYLICENSE-KEY-1EF01");

// Confirm successful licensing of IronBarCode 
bool is_licensed = IronBarCode.License.IsLicensed;
```

<hr class="separator">

## Step 4: Initiate Your Project

Embark on your project by following our guide on [How to Get Started with IronBarcode](https://ironsoftware.com/csharp/barcode/docs/).

<hr class="separator">

## Need Assistance?

For inquiries, contact [support@ironsoftware.com](mailto:support@ironsoftware.com)
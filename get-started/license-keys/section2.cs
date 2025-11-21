using BarCode;
namespace IronBarcode.Examples.GettingStarted.LicenseKeys
{
    public static class Section2
    {
        public static void Run()
        {
            // Verify if the provided license key is valid
            bool result = IronBarCode.License.IsValidLicense("IRONBARCODE-MYLICENSE-KEY-1EF01");
            
            // Check if IronBarCode is licensed successfully
            bool is_licensed = IronBarCode.License.IsLicensed;
        }
    }
}
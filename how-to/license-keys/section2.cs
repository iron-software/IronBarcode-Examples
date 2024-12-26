using BarCode;
namespace IronBarcode.Examples.HowTo.LicenseKeys
{
    public static class Section2
    {
        public static void Run()
        {
            bool result = IronBarCode.License.IsValidLicense("IRONBARCODE-MYLICENSE-KEY-1EF01");
            
            // Check if IronBarCode is licensed successfully 
            bool is_licensed = IronBarCode.License.IsLicensed;
        }
    }
}
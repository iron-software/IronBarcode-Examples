using BarCode;
namespace IronBarcode.Examples.GettingStarted.Aws
{
    public static class Section1
    {
        public static void Run()
        {
            var awsTmpPath = @"/tmp/";
            IronBarCode.Installation.DeploymentPath = awsTmpPath;
        }
    }
}
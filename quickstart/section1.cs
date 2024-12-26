using IronBarCode;
using BarCode;
namespace IronBarcode.Examples.Overview.Quickstart
{
    public static class Section1
    {
        public static void Run()
        {
            BarcodeResults results = BarcodeReader.Read("QuickStart.jpg");
            if (results != null)
            {
                foreach (BarcodeResult result in results)
                {
                    Console.WriteLine(result.Text);
                }
            }
        }
    }
}
using IronBarCode;
using BarCode;
namespace ironbarcode.Quickstart
{
    public class Section1
    {
        public void Run()
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
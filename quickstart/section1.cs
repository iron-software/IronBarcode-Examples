using IronBarCode;

BarcodeResults results = BarcodeReader.Read("QuickStart.jpg");
if (results != null)
{
    foreach (BarcodeResult result in results)
    {
        Console.WriteLine(result.Text);
    }
}
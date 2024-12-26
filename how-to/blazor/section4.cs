using BarCode;
namespace IronBarcode.Examples.HowTo.Blazor
{
    public static class Section4
    {
        public static void Run()
        {
            private async Task CaptureFrame()
            {
                await JSRuntime.InvokeAsync<String>("getFrame", DotNetObjectReference.Create(this));
            }
        }
    }
}
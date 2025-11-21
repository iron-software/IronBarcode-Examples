using BarCode;
namespace IronBarcode.Examples.GettingStarted.Blazor
{
    public static class Section3
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
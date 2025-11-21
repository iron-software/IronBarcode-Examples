using BarCode;
namespace IronBarcode.Examples.GettingStarted.Blazor
{
    public static class Section1
    {
        public static void Run()
        {
            protected override async Task OnInitializedAsync()
            {
                await JSRuntime.InvokeVoidAsync("initializeCamera");
            }
        }
    }
}
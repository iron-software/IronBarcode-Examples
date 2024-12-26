using BarCode;
namespace IronBarcode.Examples.HowTo.Blazor
{
    public static class Section2
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
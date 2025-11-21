using BarCode;
namespace IronBarcode.Examples.HowTo.CustomizeQrCodeStyle
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Generate Custom QR in Seconds
            IronBarCode.QRCodeWriter.CreateQrCodeWithLogo("https://example.com", new IronBarCode.QRCodeLogo("logo.png"), 300).ChangeBarCodeColor(IronSoftware.Drawing.Color.DeepSkyBlue).AddAnnotationTextAboveBarcode("Scan Me", new IronSoftware.Drawing.Font("Verdana",12), IronSoftware.Drawing.Color.White, 5).SaveAsPng("customQR.png");
        }
    }
}
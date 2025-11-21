using System.Drawing;
using BarCode;
namespace IronBarcode.Examples.Tutorial.CsharpQrCodeGenerator
{
    public static class Section6
    {
        public static void Run()
        {
            // Generate QR code with logo
            QRCodeLogo qrCodeLogo = new QRCodeLogo("visual-studio-logo.png");
            GeneratedBarcode myVerifiedQR = QRCodeWriter.CreateQrCodeWithLogo("https://ironsoftware.com/", qrCodeLogo);
            
            // Apply light color (may affect readability)
            myVerifiedQR.ChangeBarCodeColor(Color.LightBlue);
            
            // Verify the QR code can still be scanned
            if (!myVerifiedQR.Verify())
            {
                Console.WriteLine("LightBlue is not dark enough to be read accurately. Let's try DarkBlue");
                myVerifiedQR.ChangeBarCodeColor(Color.DarkBlue);
            }
            
            // Save verified QR code
            myVerifiedQR.SaveAsHtmlFile("MyVerifiedQR.html");
            
            // Open in default browser
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "MyVerifiedQR.html",
                UseShellExecute = true
            });
        }
    }
}
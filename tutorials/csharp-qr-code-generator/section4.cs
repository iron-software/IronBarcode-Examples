using System;
using BarCode;
namespace ironbarcode.CsharpQrCodeGenerator
{
    public class Section4
    {
        public void Run()
        {
            // Verifying QR Codes
            QRCodeLogo qrCodeLogo = new QRCodeLogo("visual-studio-logo.png");
            GeneratedBarcode MyVerifiedQR = QRCodeWriter.CreateQrCodeWithLogo("https://ironsoftware.com/", qrCodeLogo);
            
            MyVerifiedQR.ChangeBarCodeColor(System.Drawing.Color.LightBlue);
            
            if (!MyVerifiedQR.Verify())
            {
                Console.WriteLine("\t LightBlue is not dark enough to be read accurately.  Lets try DarkBlue");
                MyVerifiedQR.ChangeBarCodeColor(Color.DarkBlue);
            }
            MyVerifiedQR.SaveAsHtmlFile("MyVerifiedQR.html");
            
            // open the barcode html file in your default web browser
            System.Diagnostics.Process.Start("MyVerifiedQR.html");
        }
    }
}
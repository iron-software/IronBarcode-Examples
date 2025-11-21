using BarCode;
namespace IronBarcode.Examples.HowTo.WritingInUnicode
{
    public static class Section3
    {
        public static void Run()
        {
            ﻿using IronBarCode;
            
            // Unicode text with Chinese, Arabic and Thai characters
            string text = "周態告応立待太記行神正用真最。音日独素円政進任見引際初携食。更火識将回興継時億断保媛全職。文造画念響竹都務済約記求生街東。天体無適立年保輪動元念足総地作靖権瀬内。失文意芸野画美暮実刊切心。感変動技実視高療試意写表重車棟性作家薄井。陸瓶右覧撃稿法真勤振局夘決。任堀記文市物第前兜純響限。囲石整成先尾未展退幹販山令手北結。أم يذكر النفط قبضتهم على, الصين وفنلندا ما حدى. تم لكل أملاً المنتصر, ٣٠ حدى مارد القوى. شرسة للسيطرة قامفي. حتى أم يطول المحيط, زهاء وحلفاؤها من فعل. لم قامت الجو الساحلية وتم, ويعزى واقتصار قبل كل。ภคันทลาพาธสตาร์เซฟตี้ แชมป์ มาร์เก็ตติ้งล้มเหลวโยเกิร์ต แลนด์บาบูนอึมครึม รุสโซ แบรนด์ไคลแม็กซ์ พิซซ่าโมเดลเสือโคร่ง ม็อบโซนรายชื่อ แอดมิชชั่น ด็อกเตอร์ พะเรอ มาร์คเจไดโมจิราสเบอร์รี เอนทรานซ์ออดิชั่นศิลปวัฒนธรรมเปราะบาง โมจิซีเรียสวอลนัตทริป";
            
            // Create a DataMatrix barcode with the specified text
            var myBarcode = BarcodeWriter.CreateBarcode(text, BarcodeWriterEncoding.DataMatrix);
            
            // Save the barcode as an image
            myBarcode.SaveAsImage("Unicode.jpeg");
        }
    }
}
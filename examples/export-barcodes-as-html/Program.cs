using IronBarCode;

GeneratedBarcode MyBarCode = BarcodeWriter.CreateBarcode("1234567890", BarcodeWriterEncoding.Code128);

// Save as a stand-alone HTML file without any image assets
MyBarCode.SaveAsHtmlFile("MyBarCode.html");

// Save as a stand-alone HTML image tag which can be served in HTML files, ASPX or MVC Views. No image assets required, the tag embeds the entire image in its source content
string ImgTag = MyBarCode.ToHtmlTag();

// Turn the image into a HTML/CSS Data URI.
string DataURI = MyBarCode.ToDataUrl();

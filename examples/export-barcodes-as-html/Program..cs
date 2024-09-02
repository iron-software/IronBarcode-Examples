using IronBarCode;

/*** EXPORTING BARCODES AS HTML FILES OR TAGS ***/

GeneratedBarcode MyBarCode = BarcodeWriter.CreateBarcode("1234567890", BarcodeWriterEncoding.Code128);

// Save as a stand-alone HTML file with no image assets required
MyBarCode.SaveAsHtmlFile("MyBarCode.html");

// Save as a stand-alone HTML image tag which can be served in HTML files, ASPX or MVC Views.  No image assets required, the tag embeds the entire image in its Src contents
string ImgTag = MyBarCode.ToHtmlTag();

// Turn the image into an Html/CSS Data URI.  https://en.wikipedia.org/wiki/Data_URI_scheme
string DataURI = MyBarCode.ToDataUrl();

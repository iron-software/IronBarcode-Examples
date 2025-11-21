***Based on <https://ironsoftware.com/examples/csharp-create-barcode/>***

IronBarcode provides a robust and versatile set of functionalities for generating barcodes. If your project  involves creating a dedicated barcode creator supporting popular formats such as `EAN8`, `Code128`, and `Code39`, or if you require a dynamic library for adding barcode generation to your software with `ByteArray` or `MemoryStream`, IronBarcode offers a straightforward and feature-rich solution. It allows exporting to common image file types like `png`, `jpg`, and `jpeg`.

<div class="examples__featured-snippet">
  <h2>Barcode Generator in C#</h2>
  
</div>

## BarcodeWriter.CreateBarcode

To generate a barcode, initiate an instance of the `BarcodeWriter` class and then employ the method `BarcodeWriter.CreateBarcode`. This function requires two parameters: a `string` representing the barcode content, and a choice of encoding from the `BarcodeWriterEncoding` enumeration. After generation, the barcode image can be saved for further applications.

IronBarcode also enhances code elegance by enabling method chaining, demonstrated in line 3 of the example. This approach not only generates a barcode but also adjusts its size using `ResizeTo`, based on specified dimensions, and finally stores the image using `SaveAsImage`.

Moreover, IronBarcode adapts to various development needs with several variants of the `BarcodeWriter.CreateBarcode` method. For instance, to generate a barcode from a `ByteArray`, one can utilize a specific variation of the `CreateBarcode` method. This involves passing the `ByteArray` as input and setting dimensions of the barcode in advance.

For scenarios requiring a `MemoryStream`, IronBarcode is equally accommodating. Simply pass the `MemoryStream` as the initial parameter to `BarcodeWriter.CreateBarcode`, following the earlier example's pattern, and proceed similarly.

IronBarcode is fully equipped to handle multiple development scenarios, helping developers efficiently create and integrate barcode solutions into their applications and beyond!

[Learn How to Create Custom Barcode Images](https://ironsoftware.com/csharp/barcode/how-to/create-barcode-images/)
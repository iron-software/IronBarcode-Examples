# How to Export Barcodes as PDF

***Based on <https://ironsoftware.com/how-to/create-barcode-as-pdf/>***


---

---

Exporting barcodes as PDFs is a highly utilized feature of IronBarcode. This capability allows not only for exporting barcodes as complete PDF files but also as binary data or even streams. This flexibility is crucial as it enables the PDFs generated from `GeneratedBarcode` to be used as intermediate data within applications rather than solely as static files saved to a disk. Let's delve into these versatile export options.

## Export Barcodes as PDF File

Naturally, the first capability we'll discuss is saving a `GeneratedBarcode` as a **PDF file**. This functionality is seen as delivering a final output from IronBarcode, where the file is stored permanantly on a drive. Implementing this involves invoking the `SaveAsPdf()` method on the `GeneratedBarcode` object. The example below illustrates this procedure:

```cs
using IronBarCode;
using BarCode;
namespace ironbarcode.CreateBarcodeAsPdf
{
    public class Section1
    {
        public void Run()
        {
            GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.DataMatrix);
            myBarcode.SaveAsPdf("myBarcode.pdf");
        }
    }
}
```

In the snippet above, we begin by generating a barcode using `CreateBarcode()`, specifying both the barcode content and its encoding. The `GeneratedBarcode` that results from this is then converted into a PDF file via `SaveAsPdf()`, where the filename or path is the method's parameter.

## Export Barcodes as PDF Binary Data

IronBarcode facilitates the conversion of a `GeneratedBarcode` into **binary data** format. This is easily accomplished by executing `ToPdfBinaryData()` on the `GeneratedBarcode` object and storing the result in a byte array, which may be used subsequently within the application. Below is an example demonstrating this process:

```cs
using IronBarCode;
using BarCode;
namespace ironbarcode.CreateBarcodeAsPdf
{
    public class Section2
    {
        public void Run()
        {
            GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.DataMatrix);
            byte[] myBarcodeByte = myBarcode.ToPdfBinaryData();
        }
    }
}
```

Here, we directly convert the `GeneratedBarcode` to binary data and assign it to a byte array. Optionally, developers can further verify the output's data type using `Console.WriteLine(myBarcodeByte.GetType())`.

## Export Barcodes as PDF Stream

IronBarcode can also export `GeneratedBarcode` as a **Stream**. This option serves a similar purpose to the binary data format, intended for further use within applications. You execute `ToPdfStream()` and save the resulting `System.IO.Stream`. The following code snippet provides a practical guide:

```cs
using System.IO;
using BarCode;
namespace ironbarcode.CreateBarcodeAsPdf
{
    public class Section3
    {
        public void Run()
        {
            GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.DataMatrix);
            Stream myBarcodeStream = myBarcode.ToPdfStream();
        }
    }
}
```

As shown, to transform a `GeneratedBarcode` into a PDF stream, you simply bind `ToPdfStream()` to the barcode object and secure it to a `System.IO.Stream` type variable for subsequent application use.

In summary, IronBarcode is an excellent API for generating and exporting barcodes in PDF format, efficiently accommodating either final product needs or intermediate output forms.
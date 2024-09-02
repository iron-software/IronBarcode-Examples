# How to Convert Barcodes to PDF Using IronBarcode

---

One of the standout features of IronBarcode is its ability to convert `GeneratedBarcode` into a PDF format. IronBarcode not only lets you save the barcode as PDF files, but also facilitates the conversion of barcode into PDF binary data or PDF streams. This functionality is crucial as it provides users with the choice to either use the PDF output as a temporary component within their applications or as a final output destined for storage on a disk. Let's delve into the ways to utilize these features.

## Converting Barcodes to PDF Files

A key feature here is the conversion of a `GeneratedBarcode` to a **PDF file**, typically saved directly to a disk. This is done using the `SaveAsPdf()` method on the `GeneratedBarcode` object. Below is an example demonstrating this implementation:

```cs
using IronBarCode;

GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.DataMatrix);
myBarcode.SaveAsPdf("myBarcode.pdf");
```

In the snippet above, we initiate the process by creating a barcode using the `CreateBarcode()` method, specifying the URL and the barcode type as parameters. The resulting `GeneratedBarcode` object is then saved as a PDF using the `SaveAsPdf()` method, with the desired file name as its parameter.

## Converting Barcodes to PDF Binary Data

IronBarcode also allows for the conversion of `GeneratedBarcode` to **binary data**. This is easily achieved by applying the `ToPdfBinaryData()` to the `GeneratedBarcode` object, resulting in a byte array that can be utilized further within your application. Here's how it is done:

```cs
using IronBarCode;

GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.DataMatrix);
byte[] myBarcodeByte = myBarcode.ToPdfBinaryData();
```

In this example, we invoke the `ToPdfBinaryData()` method on the `GeneratedBarcode` object and store the output in a byte array. This binary data can further be manipulated or used within the software. Optionally, invoking `Console.WriteLine(myBarcodeByte.GetType())` confirms that the output is indeed a byte array.

## Converting Barcodes to PDF Stream

Further to converting to binary data, IronBarcode can also export `GeneratedBarcode` as a **Stream**. This option serves a similar purpose but provides the data in the form of a stream. Here’s how you can generate a PDF stream:

```cs
using IronBarCode;
using System.IO;

GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/", BarcodeEncoding.DataMatrix);
Stream myBarcodeStream = myBarcode.ToPdfStream();
```

In the snippet above, we retrieve the PDF stream from the `GeneratedBarcode` by applying the `ToPdfStream()` method and storing the result in a `Stream` variable. This stream can then be used within your application as needed.

In conclusion, IronBarcode offers robust and flexible options for converting barcodes into PDF format, catering to needs ranging from final storage to further manipulation within applications.
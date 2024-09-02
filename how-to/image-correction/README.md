# Enhancing Image Quality with Correction Filters

It's a well-known fact that not all images are created equal, and often, imperfect images are a key reason why barcode reading can fail in IronBarcode. But don't worry, it's usually not your fault. Rather than the tedious task of retaking the photo or fumbling with different image processing tools, IronBarcode introduces a seamless solution that allows you to apply correction filters directly within your application. This feature not only enhances the readability of images by IronBarcode but also boosts the overall accuracy of the process.

Keep reading to discover the range of image correction filters available in IronBarcode, understand their impact on your images, and learn how to effectively apply these filters.

## Enhancing Barcode Readability with Image Filters

To leverage the filtering capabilities, start by creating an instance of the `ImageFilterCollection` class and initialize each filter separately. Following this, assign this instance to the `ImageFilters` attribute of the `BarcodeReaderOptions` class. Finally, include this configured options object in the `Read` method, using it to process your targeted image.

Consider the image displayed below as our example for demonstration.

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/barcode/how-to/image-correction/sample.webp" alt="Sample image" class="img-responsive  add-shadow">
         <p class="competitors__download-link" style="color: #181818; font-style: italic; margin-bottom: 20px;">Sample image</p>
    </div>
</div>

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="/static-assets/barcode/how-to/image-correction/sample.webp" alt="Sample image" class="img-responsive  add-shadow">
         <p class="competitors__download-link" style="color: #181818; font-style: italic; margin-bottom: 20px;">Sample image</p>
    </div>
</div>

Upon first inspection, the image seems somewhat blurry, yet the brightness levels are adequate, and the colors black and white are noticeable. Consequently, it's necessary to use at least the **SharpenFilter** and **ContrastFilter** to enhance the readability of the barcode. The following code snippet illustrates how to implement these filters on the image, process the reading, and output the results to the console.

Here is the paraphrased section of the article:

```cs
using IronBarCode;
using System;

// Set up barcode reader options with specific image filters
BarcodeReaderOptions readOptions = new BarcodeReaderOptions()
{
    // Define the sequence of filters to be applied
    ImageFilters = new ImageFilterCollection()
    {
        new SharpenFilter(3.5f), // Sharpening to enhance edges
        new ContrastFilter(2)    // Increasing contrast to refine the barcode image
    },
};

// Read the barcode from an image using the defined options
BarcodeResults scanResults = BarcodeReader.Read("sample.png", readOptions);

// Save the filtered image version to the disk
scanResults.ExportFilterImagesToDisk("filteredSample.png");

// Output the barcode values to the console
foreach (BarcodeResult result in scanResults)
{
    Console.WriteLine(result.Text);
}
```

In addition to applying filters to improve barcode readability and scanning the image, the code sample described earlier also demonstrates how to save the processed image to a storage device. For a visual comparison of the original and modified images, refer to the images presented below.

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="/static-assets/barcode/how-to/image-correction/sample.webp" alt="Sample image" class="img-responsive add-shadow" >
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Sample image</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="/static-assets/barcode/how-to/image-correction/filteredSample.webp" alt="Filtered sample" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Filtered sample</p>
    </div>
</div>

<hr>

## Exploring Image Correction Filters with IronBarcode

IronBarcode includes a suite of tailor-made filters for image correction that are integral to enhancing the recognition accuracy of imperfect barcodes. Users must familiarize themselves with the operational nuances of these filters to appropriately choose the best filter for their needs and to circumvent possible performance bottlenecks originating from excessive or incorrect filter usage. Listed below is the array of available filters:

- **AdaptiveThresholdFilter**
- **BinaryThresholdFilter**
- **BrightnessFilter**
- **ContrastFilter**
- **InvertFilter**
- **SharpenFilter**

Filters are executed in the sequence they are arranged within the `ImageFilterCollection` object. This order is crucial as it directly influences the outcome and effectiveness of the barcode reading process.

## Adaptive Threshold Filter

The **AdaptiveThresholdFilter** is an option within IronBarcode that employs the [Bradley Adaptive Threshold technique](https://saturncloud.io/blog/bradley-adaptive-thresholding-algorithm-a-powerful-tool-for-image-segmentation/#:~:text=The%20Bradley%20adaptive%20thresholding%20algorithm%2C%20proposed%20by%20Derek%20Bradley%20and,illumination%20or%20varying%20contrast%20levels.) to automatically set the threshold for converting an image to binary form. This filter excels in environments where the lighting is inconsistent and the background intensity varies, making it a robust choice for such conditions.

Here's the paraphrased section of your article:

```cs
using IronBarCode;

// Set up barcode reading options with specific image filters
BarcodeReaderOptions optionsForReading = new BarcodeReaderOptions()
{
    // Specifying the sequence of filters to apply
    ImageFilters = new ImageFilterCollection() {
        new AdaptiveThresholdFilter(0.9f), // Using a high sensitivity for Adaptive Threshold
    },
};

// Execute reading the barcode with specified options
BarcodeResults readResults = BarcodeReader.Read("sample.png", optionsForReading);

// Save the results of the filtered image to a file
readResults.ExportFilterImagesToDisk("adaptiveThreshold_0.9.png");
```

Here's the paraphrased section of the article:

-----
Here are the results after applying the filter with various settings.

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="/static-assets/barcode/how-to/image-correction/adaptiveThreshold.webp" alt="Default Adaptive Threshold" class="img-responsive add-shadow" >
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Default value</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="/static-assets/barcode/how-to/image-correction/adaptiveThreshold_0.9.webp" alt="0.9 Adaptive Threshold" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">0.9 value</p>
    </div>
</div>

Additionally, the constructor allows for setting several other parameters that assist in customizing the process:

- **Upper**: Specifies the upper (white) threshold color.
- **Lower**: Specifies the lower (black) threshold color.
- **Threshold**: Defines the binarization limit, ranging from 0.0 to 1.0.
- **Rectangle**: Determines the specific area of the image to apply the processing.

In the displayed output, the image has been transformed to contain only black and white colors. However, this may not be optimal for barcode scanning as using a combination of different filters is often necessary for better results. It is advised for users to fine-tune these parameters through testing to find the most effective settings.

## Binary Threshold Filter

The **BinaryThresholdFilter** in IronBarcode works by dividing an image's pixels at a specified threshold, essentially comparing the brightness of individual color components. This method is akin to the AdaptiveThresholdFilter and may generate unwanted or additional noise if not configured properly. To aid users, IronBarcode presets the filter's properties to optimal default values.

This filter shares configurational parameters with the AdaptiveThresholdFilter, allowing for detailed adjustment based on specific imaging needs:

- **Upper**: Represents the upper (white) threshold color.
- **Lower**: Represents the lower (black) threshold color.
- **Threshold**: Defines the threshold limit (ranging from 0.0 to 1.0) for pixel binarization.
- **Rectangle**: Specifies the rectangular area within the image to which the filter should be applied.

Here is the paraphrased content for the section of the article you specified:

```cs
using IronBarCode;

// Initialize BarcodeReaderOptions
BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    // Define the sequence of filters to apply
    ImageFilters = new ImageFilterCollection() {
        new BinaryThresholdFilter(0.9f) // Applying Binary Threshold Filter with a value of 0.9
    },
};

// Read the barcode from the sample image using the configured options
BarcodeResults barcodeResults = BarcodeReader.Read("sample.png", options);

// Save the image after filter application to disk
barcodeResults.ExportFilterImagesToDisk("binaryThreshold_0.9.png");
```

Here's the paraphrased section with image paths resolved to `ironsoftware.com`:

-----
Below is the depicted outcome after applying the filters to the sample image.

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="/static-assets/barcode/how-to/image-correction/binaryThreshold.webp" alt="Default Binary Threshold" class="img-responsive add-shadow" >
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Default value</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="/static-assets/barcode/how-to/image-correction/binaryThreshold_0.9.webp" alt="0.9 Binary Threshold" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">0.9 value</p>
    </div>
</div>

From the output image, it's apparent that the image has been reduced to black and white. Unfortunately, this filter reveals its ineffectiveness for this image, as it results in the loss of barcode bars and introduces additional visual noise.

## Brightness Filter

The **BrightnessFilter** is a crucial component of the IronBarcode's suite of image correction tools. This filter is specifically designed to modify the brightness levels of a barcode image. Depending on the input specified, this filter can alter the brightness intensity of the output. By default, the filter is set to a value of 1, which maintains the original brightness of the image. Setting the value to 0 results in a completely black image, whereas increasing the value above 1 brightens the image significantly.

```cs
using IronBarCode;

// Set up barcode reader options with image filters
BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    // Specifying the sequence of filters to be applied
    ImageFilters = new ImageFilterCollection() {
        new BrightnessFilter(1.5f), // Adjusting brightness
    },
};

// Reading the barcode with the specified options
BarcodeResults results = BarcodeReader.Read("sample.png", options);

// Saving the processed image to disk
results.ExportFilterImagesToDisk("brightness_1.5.png");
```

Here is the paraphrased section:

-----
The image displayed below is the result after the application of this filter to the initial sample.

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="/static-assets/barcode/how-to/image-correction/sample.webp" alt="Default Brightness" class="img-responsive add-shadow" >
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Default value</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="/static-assets/barcode/how-to/image-correction/brightness_1.5.webp" alt="1.5 Brightness" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">1.5 value</p>
    </div>
</div>

## Contrast Filter

The **ContrastFilter** enhances the contrast within an image, which is the variance in color and brightness between different components. When the contrast is heightened, it makes the details in the image more distinguishable and the colors more vibrant. Conversely, lowering the contrast results in a gentler and less detailed image appearance.

By default, the filter is set to a value of 1, maintaining the original contrast of the image. Setting it to 0 transforms the image into a flat gray, whereas setting it higher than 1 amplifies the contrast, making the image visually more dramatic.

```cs
using IronBarCode;

// Set up barcode reading options with specific image filters
BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    // Sequentially apply the specified image filters
    ImageFilters = new ImageFilterCollection() {
        new ContrastFilter(1.5f) // Setting contrast filter with an intensity of 1.5
    },
};

// Reading the barcode from an image with the configured options
BarcodeResults barcodeResults = BarcodeReader.Read("sample.png", options);

// Saving the image with applied filters to disk
barcodeResults.ExportFilterImagesToDisk("contrast_1.5.png");
```

Reapplying this filter on the sample will result in the image displayed below.

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="/static-assets/barcode/how-to/image-correction/sample.webp" alt="Default Contrast" class="img-responsive add-shadow" >
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Default value</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="/static-assets/barcode/how-to/image-correction/contrast_1.5.webp" alt="1.5 Contrast" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">1.5 value</p>
    </div>
</div>

## Invert Filter

The Invert Filter is designed to reverse the colors within an image, effectively turning white to black and black to white. This functionality is especially advantageous when processing barcode images against varied background colors. Contrary to the **BinaryThresholdFilter**, the Invert Filter executes a straightforward color inversion without requiring adjustments for sensitivity. It also supports the use of a **CropRectangle** to target specific areas within the image for inversion, rather than applying the effect across the entire image surface.

```cs
using IronBarCode;

// Configure barcode reading options with specific filters
BarcodeReaderOptions barcodeOptions = new BarcodeReaderOptions()
{
    // Declare the sequence of filters to apply
    ImageFilters = new ImageFilterCollection() {
        new InvertFilter(), // Using invert filter to switch colors
    },
};

// Execute the read operation with the configured options
BarcodeResults barcodeResults = BarcodeReader.Read("sample1.png", barcodeOptions);

// Save the processed image with inverted colors to disk
barcodeResults.ExportFilterImagesToDisk("invert.png");
```

Below is the resulting image after the filter was applied to the sample input.

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/barcode/how-to/image-correction/sample.webp" alt="Original image" class="img-responsive add-shadow" >
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Original image</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/barcode/how-to/image-correction/invert.webp" alt="Inverted" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Inverted</p>
    </div>
</div>

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="/static-assets/barcode/how-to/image-correction/sample.webp" alt="Original image" class="img-responsive add-shadow" >
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Original image</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="/static-assets/barcode/how-to/image-correction/invert.webp" alt="Inverted" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Inverted</p>
    </div>
</div>

## Sharpen Filter

The **SharpenFilter** stands out as the final image correction option available in IronBarcode. It is specifically designed to refine the clarity of an image, making it particularly advantageous for use with images that lack sharpness. By tweaking the **Sigma** parameter upon creation of the filter, users are able to fine-tune how sharp the image becomes. The standard setting for sigma is set at 3, but increasing this value will further enhance the sharpness level of the image.

Here's a paraphrased version of the provided code section:

```cs
using IronBarCode;
using System;

// Setup barcode reading options with specified image filters
BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    // Filters to be added in the specified sequence
    ImageFilters = new ImageFilterCollection()
    {
        new SharpenFilter(3.5f), // Increase sharpness
        new ContrastFilter(2)    // Increase contrast
    }
};

// Read the barcode from an image with the applied filters
BarcodeResults results = BarcodeReader.Read("sample.png", options);

// Save the processed image with filters applied
results.ExportFilterImagesToDisk("filteredSample.png");

// Display barcode result text in console output
foreach (BarcodeResult result in results)
{
    Console.WriteLine(result.Text);
}
```

In this revised snippet:
- Comments have been updated for clarity and comprehensiveness.
- `float` casting is removed to simplify the code since `3.5f` already defines a `float`.
- Comments are added to clarify each step, enhancing readability and maintainability.

Below you can view the <em>enhanced sharpness</em> version of our example image.

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="/static-assets/barcode/how-to/image-correction/sharpen.webp" alt="Default Sharpen" class="img-responsive add-shadow" >
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Default value</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="/static-assets/barcode/how-to/image-correction/sharpen_0.5.webp" alt="0.5 Sharpen" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">0.5 value</p>
    </div>
</div>

When contrasting the above image with the initial one, it exhibits enhanced sharpness, significantly improving barcode detection with IronBarcode. It's common practice to use the **SharpenFilter** synergistically with additional filters from the `ImageFilterCollection`.

Beyond just configuring the `ImageFilters`, there are more properties within `BarcodeReaderOptions` that refine barcode scanning accuracy. For detailed guidance on setting these options, visit [this article](https://ironsoftware.com/csharp/barcode/how-to/read-barcodes-from-images/#setting-barcode-reader-options).


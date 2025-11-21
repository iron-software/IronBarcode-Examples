# How to Utilize Image Correction Filters

***Based on <https://ironsoftware.com/how-to/image-correction/>***


Truth be told, not all images are flawless, and often these imperfections contribute significantly to the challenges IronBarcode faces when trying to decode barcode images. These difficulties are not necessarily the fault of the user. Rather than the arduous tasks of retaking the image or utilizing third-party enhancement software, IronBarcode provides a solution that allows users to programmatically apply filters to the images. This functionality enhances image clarity, enabling IronBarcode to interpret the image more effectively.

Keep reading to discover the variety of image correction filters available in IronBarcode, how they modify the appearance of images, and the steps for applying them.

## Quickstart: Enhance Barcode Scanning with Sharpen and Contrast Filters

Efficiently enhance your barcode scanning capabilities by applying the `SharpenFilter` and `ContrastFilter` from IronBarcode's `ImageFilterCollection` within `BarcodeReaderOptions`. This simple integration significantly boosts the quality of barcode scans without the need for additional software.

```cs
:title=Enhance Barcode Scanning — Implement Image Adjustments
// Read a barcode from an image with specified image filters for better clarity
BarcodeResults results = IronBarCode.BarcodeReader.Read("input.png", new IronBarCode.BarcodeReaderOptions { 
    ImageFilters = new IronBarCode.ImageFilterCollection() { 
        new IronBarCode.SharpenFilter(3.5f), // Sharpens the image
        new IronBarCode.ContrastFilter(2.0f) // Enhances the contrast
    } 
});
```

## Example on Enhancing Barcode Readability Using Image Filters

To begin enhancing your images, first establish a new instance of the `ImageFilterCollection` class. Following this, instantiate each filter needed separately and add these to the `ImageFilterCollection`. Next, direct this collection to the `ImageFilters` attribute of your `BarcodeReaderOptions`. Lastly, these options should be included when invoking the `Read` function alongside your chosen image.

Here's an example using a particular image for illustration:

![Sample image](https://ironsoftware.com/static-assets/barcode/how-to/image-correction/sample.webp "Sample Image for Processing")

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="/static-assets/barcode/how-to/image-correction/sample.webp" alt="Sample image" class="img-responsive add-shadow">
         <p class="competitors__download-link" style="color: #181818; font-style: italic; margin-bottom: 20px;">Sample image</p>
    </div>
</div>

At first glance, the image seems somewhat out of focus, but the brightness levels are adequate, and the distinction between white and black colors is clear. Hence, it is essential to employ at least the **SharpenFilter** and **ContrastFilter** to enhance the readability of the barcode. The following code snippet provides a method to implement these filters on the image, decipher it, and present the output in the console.

Here's the paraphrased section of your article:

```csharp
using IronBarCode;
using System;

// Configure the barcode reading by initializing BarcodeReaderOptions
BarcodeReaderOptions barcodeOptions = new BarcodeReaderOptions()
{
    // Specify ordered filters to enhance image quality
    ImageFilters = new ImageFilterCollection()
    {
        new SharpenFilter(3.5f), // Sharpens the image
        new ContrastFilter(2)    // Increases the contrast
    }
};

// Read the barcode from the image with applied filters
BarcodeResults barcodeResults = BarcodeReader.Read("sample.png", barcodeOptions);

// Output the decoded barcode content to the console
foreach (BarcodeResult result in barcodeResults)
{
    Console.WriteLine(result.Text); // Displays the barcode text
}
```

In addition to employing filters and scanning the barcode as demonstrated in the prior code example, we also saved the processed image files. Here, you can observe a side-by-side comparison of both the original and the enhanced images.

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

## Exploring Image Correction Filters in IronBarcode

IronBarcode is equipped with a suite of image filters that are specifically crafted for correcting image issues. These tools are crucial for enhancing the readability of barcodes captured under less-than-ideal conditions. To maximize the effectiveness of these filters and avoid potential performance pitfalls, it's essential for users to grasp how each filter functions and make judicious choices about their application. Here is a comprehensive list of the available filters:

- `AdaptiveThresholdFilter`
- `BinaryThresholdFilter`
- `BrightnessFilter`
- `ContrastFilter`
- `InvertFilter`
- `SharpenFilter`
- `ErodeFilter`
- `DilateFilter`
- `HistogramEqualizationFilter`
- **Blur Filters**:
  - `GaussianBlurFilter`
  - `BilateralFilter`
  - `MedianBlurFilter`

The sequence in which these filters are applied is determined by their arrangement within the `ImageFilterCollection`.

## Adaptive Threshold Filter

The **AdaptiveThresholdFilter** in IronBarcode employs the [Bradley Adaptive Threshold](https://saturncloud.io/blog/bradley-adaptive-thresholding-algorithm-a-powerful-tool-for-image-segmentation/#:~:text=The%20Bradley%20adaptive%20thresholding%20algorithm%2C%20proposed%20by%20Derek%20Bradley%20and,illumination%20or%20varying%20contrast%20levels.) technique. This advanced method autonomously sets the thresholding parameters for converting an image into a binary form, making it highly effective for pictures with inconsistent lighting and diverse intensity backgrounds.

```csharp
using IronBarCode;


// Define options for barcode reading
var barcodeOptions = new BarcodeReaderOptions()
{
    // Specify filters to be used, in sequence
    ImageFilters = new ImageFilterCollection(true) {
        new AdaptiveThresholdFilter(0.9f),
    },
};

// Execute reading process with specified options
var readResults = BarcodeReader.Read("sample.png", barcodeOptions);

// Save the processed image to a local file
readResults.ExportFilterImagesToDisk("adaptiveThreshold_0.9.png");
```

```
Here are the results of the filter application with various settings.
```

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

The constructor permits customization through several additional configuration parameters:

- **Upper**: Assigns the upper (white) limit for thresholding.
- **Lower**: Sets the lower (black) boundary for thresholding.
- **Threshold**: Establishes the binarization limit between 0.0 and 1.0.
- **Rectangle**: Defines the region where the processor will be applied.

As observed in the processed image, it transforms into a binary representation consisting solely of **black** and **white** colors. Although this state is not particularly optimal for barcode decoding, as effective usage relies on combination filtering. To optimize outcomes, users are encouraged to fine-tune these configurations through testing.

## Binary Threshold Filter

The **BinaryThresholdFilter** operates by segmenting an image's pixels at a specified threshold, using it to gauge the luminance within a particular color component. Like the AdaptiveThresholdFilter, this filter can also generate extraneous noise if misapplied. Nonetheless, IronBarcode presets the filter's properties to optimal defaults for general use.

The configuration parameters for the BinaryThresholdFilter are the same as those for the AdaptiveThresholdFilter, facilitating a consistent setup across different filter types. The parameters include:

- **Upper**: Defines the threshold color for brighter areas, typically set to white.
- **Lower**: Sets the threshold for darker areas, usually black.
- **Threshold**: Establishes the binarization limit, ranging from 0.0 to 1.0.
- **Rectangle**: Specifies the rectangle area within the image where the filter should be applied.

```csharp
using IronBarCode;

// Setup the BarcodeReaderOptions with specific image filters
BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    // Specifying the order of the image filters to be applied
    ImageFilters = new ImageFilterCollection(true) {
        new BinaryThresholdFilter(0.9f)  // setting the binary threshold filter
    },
};

// Reading the barcode from a sample image using the configured options
BarcodeResults results = BarcodeReader.Read("sample.png", options);

// Saving the processed image to disk with the applied filter
results.ExportFilterImagesToDisk("binaryThreshold_0.9.png");
```

Here is the paraphrased section with the resolved URL paths:

-----
Below is the demonstrated output after applying the filters to the sample image.

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

Examining the resultant image, it's evident that the sample has transformed into a binary black and white format. Despite this, it's apparent that the filter applied isn't optimal for this particular image, as it leads to the elimination of barcode lines and the introduction of additional noise.

## Brightness Filter

The **BrightnessFilter** in IronBarcode is a crucial component of the image filter collection. This filter is designed to modify the brightness level of a barcode image. Depending on the input, the filter can alter the **Amount** of brightness in the final image. By default, the value is set to 1, meaning the image's brightness remains as is. Setting the value to 0 results in a completely black image, whereas increasing the value above 1 brightens the image accordingly.

Here's the paraphrased section of the article:

```csharp
using IronBarCode;

// Setting up options for barcode reading with specific image filters
BarcodeReaderOptions readOptions = new BarcodeReaderOptions()
{
    // Enabling image filters and specifying the sequence of application
    ImageFilters = new ImageFilterCollection(true) 
    {
        new BrightnessFilter(1.5f), // Applying a brightness filter
    },
};

// Reading the barcode with predefined options
BarcodeResults scanResults = BarcodeReader.Read("sample.png", readOptions);

// Saving the processed image to the disk
scanResults.ExportFilterImagesToDisk("brightness_1.5.png");
```

Here is the paraphrased content for the specific section you've selected:

---
Here is a view of the image following the application of the filter.

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

## Adjusting Image Contrast with IronBarcode's Contrast Filter

IronBarcode's **ContrastFilter** is designed to modify the contrast levels in your images. Contrast in an image refers to the variation in intensity between different elements. By increasing the contrast, more details can be accentuated, making the image look more dynamic and clear. Conversely, decreasing the contrast can soften the image and blend the elements more gently.

The **ContrastFilter** comes pre-set with a default value of `1`, which maintains the original state of the image without any alteration. Setting the value to `0` converts the image into a uniform gray scale, effectively neutralizing any contrast. On the other hand, setting the value higher than `1` boosts the image's contrast, sharpening the distinction between light and dark areas.

Here's the paraphrased section, with code comments enhanced for clarity and links resolved to `ironsoftware.com`:

```csharp
// Importing necessary IronBarCode namespace
using IronBarCode;

// Setting up the barcode reading options with specific image filters
BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    // Initialize ImageFilterCollection, perform save iterations
    ImageFilters = new ImageFilterCollection(true) {
        // Apply a ContrastFilter with a factor of 1.5 to improve contrast
        new ContrastFilter(1.5f),
    },
};

// Reading the barcode from "sample.png" using the provided options
BarcodeResults results = BarcodeReader.Read("sample.png", options);

// Save the processed image to the disk with a modified file name indicating the contrast setting
results.ExportFilterImagesToDisk("contrast_1.5.png");
```

This code sets up and applies a contrast filter with a parameter of 1.5 to enhance image contrast before reading the barcode, then saves this enhanced image to disk.

The application of this filter to our example input generates the image displayed below.

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

The Invert Filter reverses the hues within an image, transforming white areas to black and vice versa. This capability is especially beneficial when decoding barcodes set against colored backgrounds. Unlike the **BinaryThresholdFilter**, which requires parameters for operation, the Invert Filter flips colors straightforwardly. Additionally, it incorporates the use of a **CropRectangle** to target specific areas for inversion, rather than altering the entire image's color scheme. This targeted approach allows precise adjustments only where needed.

The paraphrased section with the full markdown context and updated code snippet is as follows:

```csharp
using IronBarCode;

// Configure barcode reading options with specific filters
BarcodeReaderOptions readOptions = new BarcodeReaderOptions()
{
    // Specify filters to be used
    ImageFilters = new ImageFilterCollection(true) {
        new InvertFilter(),  // Adding an Invert Filter
    },
};

// Read the barcode using the configured options
BarcodeResults scannedResults = BarcodeReader.Read("sample.png", readOptions);

// Save the image with the applied filter to disk
scannedResults.ExportFilterImagesToDisk("invert.png");
```

Resulting Image After Applying the Filter

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

IronBarcode includes a useful feature known as the Sharpen Filter, designed to improve the clarity and definition of images. This is especially beneficial for images that are initially blurry. By adjusting the **Sigma** parameter when setting up the filter, users can control the level of sharpness their images will have. The default setting for Sigma is set at 3, but increasing this value enhances the sharpness further, making the details more distinct and crisp.

```csharp
using IronBarCode;
using System;

// Define options for barcode reading, specifying filters
BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    // Assign filters; enable saving intermediate filter states
    ImageFilters = new ImageFilterCollection(saveIntermediateImages: true) {
        new SharpenFilter(0.5f), // Set sharpness enhancement
    },
};

// Reading barcode with the specified options
BarcodeResults results = BarcodeReader.Read("sample.png", options);

// Save the filtered image output to local storage
results.ExportFilterImagesToDisk("sharpen_0.5.png");
```

Below is the image displaying the <em>enhanced sharpness</em> of the sample input image.
<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/barcode/how-to/image-correction/sharpen.webp" alt="Default Sharpen" class="img-responsive add-shadow" >
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Default value</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/barcode/how-to/image-correction/sharpen_0.5.webp" alt="0.5 Sharpen" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">0.5 value</p>
    </div>
</div>

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

The comparison between the adjusted image and its original version shows a notable increase in sharpness. This enhancement can greatly aid in decoding barcodes with IronBarcode. Typically, the **SharpenFilter** is used in conjunction with additional filters within the `ImageFilterCollection` class to optimize results.

## Erode Filter

The **ErodeFilter** is designed to eliminate fine white noise while enhancing the thickness of barcode lines by eroding the pixels around the edges of shapes. It's particularly effective in conditions where the barcode's background is crowded with white dots, or the barcode itself appears too blurry or has low resolution, causing some of the bars to fuse together. The **ErodeFilter** notably thickens the lines while also clearing away the white dots that may be present in the background.

Additionally, users have the option to amplify the erosion effect by setting a `kernelSize` value in the filter. A larger `kernelSize` translates into a more pronounced impact on the image. It's important to note that `kernelSize` refers to a square kernel; for example, in this context, it would utilize a 5x5 kernel.

To demonstrate, consider applying the **ErodeFilter** with an increased kernel size to vividly illustrate its effects on an image.

```cs
using IronBarCode;

// Initialize the options for the Barcode reader
BarcodeReaderOptions readerOptions = new BarcodeReaderOptions()
{
    // Set the image filters, enabling saving iterations
    ImageFilters = new ImageFilterCollection(true) {
        new ErodeFilter(5), // Applying an Erode filter with a kernel size of 5
    },
};

// Perform the barcode reading with the configured options
BarcodeResults readResults = BarcodeReader.Read("sample.png", readerOptions);

// Save the filtered image output to a local file
readResults.ExportFilterImagesToDisk("erodeFilter.jpg");
```

<div class="competitors-section__wrapper-even-1">
  <div class="competitors__card" style="width: 46%;">
    <img src="/static-assets/barcode/how-to/image-correction/sample.webp" alt="Original image" class="img-responsive add-shadow" >
    <p class="competitors__download-link" style="color: #181818; font-style: italic;">Original image</p>
  </div>
  <div class="competitors__card" style="width: 46%;">
    <img src="/static-assets/barcode/how-to/image-correction/erodeFilter.webp" alt="Inverted" class="img-responsive add-shadow">
    <p class="competitors__download-link" style="color: #181818; font-style: italic;">Erode Filter Applied</p>
  </div>
</div>

Upon examining the before and after images, it's clear that certain bars have become markedly thicker, a result of applying a more intense kernel size using the erosion filter. Simultaneously, there's a noticeable reduction in the white speckles that previously marred the image. Given the properties of the erosion filter, employing a larger kernel size could inadvertently lead to the elimination of thinner bars if overused. As demonstrated in the visuals, developers are advised to meticulously calibrate and modify the kernel size within the **ErodeFilter** to tailor the filter's impact according to their specific needs.

## Dilate Filter

The **DilateFilter** acts in contrast to the **ErodeFilter** by extending light areas, primarily the background, through the addition of pixels at object edges. This filter is particularly adept at mending damaged or weak barcodes, closing minor breaks, or boosting sections of low contrast. However, it's crucial to recognize that its impact on the dark regions of barcodes, like the black bars (given a white background), differs from what might be expected. As the dilatation process enlarges lighter areas, it concurrently reduces the dark sections. This attribute is beneficial when barcode bars are excessively thick or blended. Nevertheless, overuse could lead to diminished scan precision due to the undue narrowing of these bars.

In a manner akin to that described previously, the dilatation effect can be intensified by specifying an integer value for the `kernelSize`, which adjusts the filter's strength.

In the subsequent example, we employ a larger `kernelSize` to demonstrate the impactful results of the **DilateFilter**.

```cs
using IronBarCode;

// Define options for barcode reading, specifying image filters to use
BarcodeReaderOptions readOptions = new BarcodeReaderOptions()
{
    // Setting the sequence of filters; enabling saving each filter application
    ImageFilters = new ImageFilterCollection(true) {
        new DilateFilter(5), // Using DilateFilter with a kernel size of 5
    },
};

// Read the barcode from an image file using the configured options
BarcodeResults scanResults = BarcodeReader.Read("sample.png", readOptions);

// Save the imagery after applying the dilation filter to a file
scanResults.ExportFilterImagesToDisk("dilatedOutput.jpg");
```

<div class="competitors-section__wrapper-even-1">
  <div class="competitors__card" style="width: 46%;">
    <img src="/static-assets/barcode/how-to/image-correction/sample.webp" alt="Original image" class="img-responsive add-shadow" >
    <p class="competitors__download-link" style="color: #181818; font-style: italic;">Original image</p>
  </div>
  <div class="competitors__card" style="width: 46%;">
    <img src="/static-assets/barcode/how-to/image-correction/dilateFilter.webp" alt="Inverted" class="img-responsive add-shadow">
    <p class="competitors__download-link" style="color: #181818; font-style: italic;">Dilation Filter Applied</p>
  </div>
</div>

As demonstrated in the displayed image, utilizing the **DilateFilter** excessively can have detrimental effects on the barcode's configuration. It tends to merge bars that are close to each other and create void areas within the barcodes. To achieve the desired results, users are encouraged to experiment with and adjust the kernel size, either increasing or decreasing it based on the specific requirements of the image.

## Histogram Equalization Filter

The **Histogram Equalization Filter** significantly improves image clarity by adjusting the contrast and redistributing pixel intensities. This filter is particularly valuable for barcodes in low-contrast conditions, like faded or unevenly lit images, where it can correct visual impairments caused by dark shadows or bright glare. It operates by analyzing the histogram of the image, a graphical representation of pixel brightness, and then manipulating this distribution to enhance contrast. This process shifts the dynamic range of the histogram, making dark pixels darker and bright pixels lighter, resulting in a clearer, more distinct image.

```csharp
using IronBarCode;

// Setup the options for barcode reading with filters
BarcodeReaderOptions optionSettings = new BarcodeReaderOptions()
{
    // Indicating the order of the filters
    ImageFilters = new ImageFilterCollection(true) {
        new HistogramEqualizationFilter(),  // Adding histogram equalization filter
    },
};

// Reading the barcode from the provided image file
BarcodeResults barcodeResults = BarcodeReader.Read("sample.png", optionSettings);

// Saving the processed image to a file
barcodeResults.ExportFilterImagesToDisk("histogramEqualizationFilter.jpg");
```

<div class="competitors-section__wrapper-even-1">
  <div class="competitors__card" style="width: 46%;">
    <img src="/static-assets/barcode/how-to/image-correction/sample.webp" alt="Original image" class="img-responsive add-shadow" >
    <p class="competitors__download-link" style="color: #181818; font-style: italic;">Original image</p>
  </div>
  <div class="competitors__card" style="width: 46%;">
    <img src="/static-assets/barcode/how-to/image-correction/histogramEqualizationFilter.webp" alt="Inverted" class="img-responsive add-shadow">
    <p class="competitors__download-link" style="color: #181818; font-style: italic;">Histogram Equalization Filter Applied</p>
  </div>
</div>

As evident from the image above, the black bars have become distinctly darker and the surrounding spaces much brighter compared to the original image.

## Blur Filter Types

### Gaussian Blur Filter

The **GaussianBlurFilter** effectively reduces image noise and detail using a Gaussian function, which smooths the image by averaging the pixels in a defined area. The filter utilizes two main parameters for customization:

- **Kernel**: This matrix influences how the pixels are averaged, typically set to a 3x3 matrix with a default Sigma value.
- **Sigma**: Adjusts the intensity of the blur; a higher Sigma results in a stronger blur effect.

Example usage with IronBarcode:

```csharp
using IronBarCode;

BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    ImageFilters = new ImageFilterCollection(true) {
        new GaussianBlurFilter(3, 3, 3.0f),
    },
};

BarcodeResults results = BarcodeReader.Read("sharpen.webp", options);

results.ExportFilterImagesToDisk("gaussianBlur.png");
```

The application of this filter results in a moderately blurred image, as shown below:

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/barcode/how-to/image-correction/sharpen.webp" alt="Sharpened Image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Before Blur</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/barcode/how-to/image-correction/gaussianBlur.webp" alt="Gaussian Blurred Image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">After Gaussian Blur</p>
    </div>
</div>

### Bilateral Blur Filter

The **BilateralFilter** is distinctive in that it smoothens the image while retaining edge sharpness. This is accomplished by considering both the color difference and the distance between pixels. The filter uses three parameters:

- **NeighborhoodDiameter**: Dictates the diameter for filtering. Increasing the diameter involves more pixels in the process.
- **SigmaColor**: Regulates how much the color differences affect the blur.
- **SigmaSpace**: Determines the influence of pixel distance on the blur effect.

Example application in IronBarcode:

```csharp
using IronBarCode;

BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    ImageFilters = new ImageFilterCollection(true) {
        new BilateralFilter(5, 75, 75),
    },
};

BarcodeResults results = BarcodeReader.Read("sharpen.webp", options);

results.ExportFilterImagesToDisk("bilateral.png");
```

The effect of the filter on an image is visible in the results below:

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/barcode/how-to/image-correction/sharpen.webp" alt="Sharpened Image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Before Bilateral Blur</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/barcode/how-to/image-correction/bilateral.webp" alt="Bilaterally Blurred Image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">After Bilateral Blur</p>
    </div>
</div>

### Median Blur Filter

The **MedianBlurFilter** is particularly effective for noise reduction without significantly affecting the edges of the image. It replaces each pixel's value with the median value of adjacent pixels. Its main adjustable setting is:

- **KernelSize**: Influences the size of the pixel region considered. It must be an odd number larger than one.

Implementing this filter with IronBarcode:

```csharp
using IronBarCode;

BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    ImageFilters = new ImageFilterCollection(true) {
        new MedianBlurFilter(5),
    },
};

BarcodeResults results = BarcodeReader.Read("sharpen.webp", options);

results.ExportFilterImagesToDisk("medianBlur.png");
```

The resulting image displays the smoothing effect:

<div class="competitors-section__wrapper-even-1">
    <div className="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/barcode/how-to/image-correction/sharpen.webp" alt="Sharpened Image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Before Median Blur</p>
    </div>
    <div className="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/barcode/how-to/image-correction/medianBlur.webp" alt="Median Blurred Image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">After Median Blur</p>
    </div>
</div>

### GaussianBlur Filters

The **GaussianBlurFilter** is utilized to impart a Gaussian blur effect on images, effectively mitigating noise. This is a widely adopted technique for image smoothing.

This filter operates by averaging the pixel values around each target pixel based on a Gaussian distribution. The effectiveness and specificity of the blur are governed by:

- **Kernel**: This is a grid (matrix) that determines how pixel averaging is conducted.
  
- **Sigma**: A parameter that defines the spread or intensity of the blur.

By default, the GaussianBlurFilter employs a 3x3 kernel matrix and a Sigma setting of 3.0, achieving a standard level of blur which softens the image without obscuring significant details. Enhancing the Sigma value intensifies the blur. Adjusting the kernel size allows for broader or more focused averaging regions, offering flexibility in the application of blur to suit various image conditions.

```csharp
using IronBarCode;

// Setting up options for barcode reading and specifying image filters
BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    // Defining the sequence of image filters to use
    ImageFilters = new ImageFilterCollection(true) {
        new GaussianBlurFilter(3, 3, 3.0f), // Using a Gaussian Blur filter
    },
};

// Reading the barcode with specified options
BarcodeResults barcodeData = BarcodeReader.Read("sharpen.webp", options);

// Saving the results of the filter to a file
barcodeData.ExportFilterImagesToDisk("gaussianBlur.png");
```

Here is the paraphrased section with resolved relative URL paths:

-----
When the **MedianBlurFilter** is applied to the sample input, you can see the resultant image depicted below.

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="/static-assets/barcode/how-to/image-correction/sharpen.webp" alt="Default Sharpen" class="img-responsive add-shadow" >
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Sharpen image</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="/static-assets/barcode/how-to/image-correction/gaussianBlur.webp" alt="GaussianBlur image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">GaussianBlur image</p>
    </div>
</div>

### Bilateral Filters

The **BilateralFilter** is adept at refining images while simultaneously preserving their edges, setting it apart from more basic blurring techniques that indiscriminately affect every pixel. This sophisticated filter uniquely considers both the color discrepancy and spatial separation between pixels, which safeguards the integrity of edges during the smoothing process.

The efficacy of the Bilateral Filter is adjusted by three pivotal factors:

- **NeighborhoodDiameter**: This parameter defines the scope of the pixel neighborhood that the filter will process. A higher diameter value enlarges the filter's scope, encompassing a broader array of adjacent pixels. The filter is preset with a default diameter of 5.

- **SigmaColor**: This variable quantifies the impact of color disparities among pixels on the filtering outcome. A greater SigmaColor value amplifies the interaction between differently colored pixels, enhancing the filter's sensitivity to color variations. It is initially set to 75.0.

- **SigmaSpace**: This factor measures the influence of pixel proximity on the filter's effectiveness. With an increased SigmaSpace, the filter extends its influence to pixels located further apart, magnifying its spatial coverage. This setting also defaults to 75.0.

Here's a paraphrased version of the code snippet provided, with explanations added and methods restructured to improve readability:

```csharp
using IronBarCode;

// Set up the options for barcode reading including specified filters
BarcodeReaderOptions optionsSetup = new BarcodeReaderOptions()
{
    // Enable saving images after each filter's application and specify the Bilateral Filter
    ImageFilters = new ImageFilterCollection(true) {
        new BilateralFilter(5, 75, 75), // Diameter, SigmaColor, SigmaSpace
    },
};

// Read the barcode from the image using the defined options
BarcodeResults barcodeData = BarcodeReader.Read("sharpen.webp", optionsSetup);

// Save the filtered images to the disk with a specific filename
barcodeData.ExportFilterImagesToDisk("bilateral.png");
```

This rewritten code clarifies the intent of each operation, enhances code documentation, and maintains the structure and logic of your original sample.

The application of this filter on the provided sample can be observed in the image depicted below.

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="/static-assets/barcode/how-to/image-correction/sharpen.webp" alt="Default Sharpen" class="img-responsive add-shadow" >
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Sharpen image</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="/static-assets/barcode/how-to/image-correction/bilateral.webp" alt="Bilateral image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Bilateral image</p>
    </div>
</div>

### MedianBlur Filters

The **MedianBlurFilter** serves to minimize image noise by substituting the value of each pixel with the median value from the adjacent pixels in its vicinity. This filter excels at maintaining edge definition while effectively eliminating noise.

- **KernelSize**: This parameter establishes the dimensions of the surrounding area around each pixel that is considered for median calculation. It is imperative that this value be an odd number greater than 0. The typical default setting is 5.

Here's the paraphrased section with resolved URL paths as specified:

```csharp
using IronBarCode;  // Include IronBarCode namespace for access to barcode reading functionalities

// Create configuration for barcode reader with specific image filters
BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    // Initialize with a new filter collection and specify ordering importance
    ImageFilters = new ImageFilterCollection(true) {
        new MedianBlurFilter(5),  // Add Median Blur filter with a kernel size of 5
    },
};

// Read barcode from an image using the configured options
BarcodeResults barcodeReadingResults = BarcodeReader.Read("sharpen.webp", options);

// Save the resulting image after applying the median blur filter to the disk
barcodeReadingResults.ExportFilterImagesToDisk("medianBlur.png");
```

The application of this filter is demonstrated on the sample image as shown below.

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="/static-assets/barcode/how-to/image-correction/sharpen.webp" alt="Default Sharpen" class="img-responsive add-shadow" >
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Sharpen image</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="/static-assets/barcode/how-to/image-correction/medianBlur.webp" alt="MedianBlur image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">MedianBlur image</p>
    </div>
</div>

## Saving Filtered Image Progressions

Applying numerous filters sequentially on a barcode can make it challenging to assess the changes introduced by each filter. To address this, IronBarcode provides functionality to save each filtered image as it is processed. This is accomplished by initiating the `ImageFilterCollection` with `true`, signifying that output should be saved sequentially. Subsequently, the manipulated images can be saved to a desired location using the `ExportFilterImagesToDisk` method, where both the directory and filename are specified.

```csharp
using IronBarCode;

// Configuring options for Image Filter application
BarcodeReaderOptions optionsConfig = new BarcodeReaderOptions()
{
    // Selection of filters to be applied sequentially
    ImageFilters = new ImageFilterCollection(true) {
        new SharpenFilter(3.5f), // Increases sharpness
        new AdaptiveThresholdFilter(0.5f), // Adjusts image to optimal threshold
        new ContrastFilter(2) // Enhances contrast
    },
};

// Applying the filters and reading the barcode from the image
BarcodeResults scanResults = BarcodeReader.Read("sample.webp", optionsConfig);

// Saving the post-filter application image to a disk
scanResults.ExportFilterImagesToDisk("filteredImage.png");
```

The order of the implemented filters is reflected in the sequence of code operations; the final images distinctly show the effect of each filtering stage applied:

- Initial application of Sharpen Filter results in an image titled "After Sharpen".

- Combining Sharpen Filter with an Adaptive Threshold Filter produces an image named "After Adaptive Threshold".

- Further enhancing with a Contrast Filter results in a final image labeled "After Contrast".

<div class="competitors-section__wrapper-even-1" style="margin-bottom: 25px;">
    <div class="competitors__card" style="width: 48%;">
        <img src="/static-assets/barcode/how-to/image-correction/sample.webp" alt="Sample image" class="img-responsive add-shadow" >
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Sample image</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="/static-assets/barcode/how-to/image-correction/filteredImage-1.webp" alt="1.5 Contrast" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">After Sharpen</p>
    </div>
</div>
<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="/static-assets/barcode/how-to/image-correction/filteredImage-2.webp" alt="Sample image" class="img-responsive add-shadow" >
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">After Adaptive Threshold</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="/static-assets/barcode/how-to/image-correction/filteredImage-3.webp" alt="1.5 Contrast" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">After Contrast</p>
    </div>
</div>

In addition to utilizing the `ImageFilters` properties, users have the option to enhance the precision of their barcode reading by incorporating additional settings within the `BarcodeReaderOptions`. For further details on these settings, refer to the following [article](https://ironsoftware.com/csharp/barcode/how-to/read-barcodes-from-images/#setting-barcode-reader-options).


# How to Apply Image Correction Filters

***Based on <https://ironsoftware.com/how-to/image-correction/>***


It's a given that not all images are flawless, and these imperfections often hinder the readability of barcode images by IronBarcode. This shortcoming isn't necessarily due to user error. Rather than the inconvenience of retaking photos or using separate image enhancing software, IronBarcode provides a functionality that allows users to programmatically apply correction filters to their images. This feature significantly enhances the readability of barcodes and improves the overall accuracy.

Keep reading to discover the various image correction filters available in IronBarcode, understand how they affect image quality, and learn the steps to apply them effectively.

<h3>Get started with IronBarcode</h3>

# Utilizing Image Filters for Enhancing Barcode Reading Accuracy

***Based on <https://ironsoftware.com/how-to/image-correction/>***


Applying image filters is straightforward with IronBarcode. Begin by creating an instance of the `ImageFilterCollection` class, add the desired filters individually, and then set these filters to the `ImageFilters` property in the `BarcodeReaderOptions`. Subsequently, input these options alongside your image file into the `Read` method to process the image.

Consider the image displayed below as a reference:

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/barcode/how-to/image-correction/sample.webp" alt="Sample image" class="img-responsive  add-shadow">
         <p class="competitors__download-link" style="color: #181818; font-style: italic; margin-bottom: 20px;">Sample image as displayed</p>
    </div>
</div>

Observing the example image, it's noticeable that it is somewhat blurry although the brightness levels are adequate with clear distinction between black and white. It is advisable to apply both the **SharpenFilter** and **ContrastFilter** to enhance barcode readability. The following code demonstrates how to set up the filters and read the barcode:

```cs
using IronBarCode;
using System;

// Setting up barcode reading options with specific image filters
BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    // Specify the filters to be used in sequence
    ImageFilters = new ImageFilterCollection()
    {
        new SharpenFilter(3.5f),
        new ContrastFilter(2)
    },
};

// Reading the barcode using the configured options
BarcodeResults results = BarcodeReader.Read("sample.png", options);

// Displaying the barcode results on the console
foreach (BarcodeResult result in results)
{
    Console.WriteLine(result.Text);
}
```

The example above not only shows how to apply image correction filters but also how to output the results to the console. The side-by-side comparison images below illustrate the difference before and after the filter application:

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/barcode/how-to/image-correction/sample.webp" alt="Sample image" class="img-responsive add-shadow" >
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Original Sample</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/barcode/how-to/image-correction/filteredSample.webp" alt="Filtered Sample" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Filtered Example</p>
    </div>
</div>

<hr>

Below, please find the paraphrased section of the article:

---
## Implementing Image Filters to Enhance Barcode Readability

To utilize the filters, first create an instance of the `ImageFilterCollection` class and initiate individual filter instances. Next, set the `ImageFilters` property of the `BarcodeReaderOptions` object with these instances. Then, proceed to pass this options object into the `Read` method, along with your target image.

Here's the sample image we'll use for this demonstration:

![Sample image](https://ironsoftware.com/static-assets/barcode/how-to/image-correction/sample.webp)

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="/static-assets/barcode/how-to/image-correction/sample.webp" alt="Sample image" class="img-responsive  add-shadow">
         <p class="competitors__download-link" style="color: #181818; font-style: italic; margin-bottom: 20px;">Sample image</p>
    </div>
</div>

Upon first inspection, the image seems rather blurry, although the overall brightness appears suitable, and the distinction between white and black is clear. To enhance barcode detection, it's essential to apply both the `SharpenFilter` and `ContrastFilter`. See the following code segment on how to implement these filters, interpret the image, and output the results to the console.

```cs
using IronBarCode;
using System;

// Initialize barcode reader options with specified image filters
BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    // Define the sequence of filters to enhance the image
    ImageFilters = new ImageFilterCollection()
    {
        new SharpenFilter(3.5f), // Sharpen image to enhance edges
        new ContrastFilter(2)    // Increase contrast to make details more distinct
    },
};

// Read the barcode from the image using the configured options
BarcodeResults barcodeResults = BarcodeReader.Read("sample.png", options);

// Display each decoded barcode value in the console
foreach (BarcodeResult result in barcodeResults)
{
    Console.WriteLine(result.Text); // Output the text of the barcode
}
```

Following the execution of the code provided, in addition to applying filters and scanning the barcode, the processed image was saved to the disk. Below, you can observe a comparative display between the original and the processed images.

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

## Discovering Image Correction Filters with IronBarcode

IronBarcode includes a variety of specialized image filters that are tailored for correcting and enhancing the quality of barcode images. These tools are pivotal in increasing the success rate of barcode detection and recognition by adjusting image properties. However, it is essential for users to familiarize themselves with the functionalities of these filters to choose the most effective ones and to prevent any performance degradation from inappropriate or excessive use. Here is a list of the available filters:

- `AdaptiveThresholdFilter`
- `BinaryThresholdFilter`
- `BrightnessFilter`
- `ContrastFilter`
- `InvertFilter`
- `SharpenFilter`

These filters should be arranged in a specific sequence within the `ImageFilterCollection` to apply them correctly. This sequence directly influences the processing order and the resulting output, thereby impacting the effectiveness of barcode detection.

## Adaptive Threshold Filter

The **AdaptiveThresholdFilter** in IronBarcode leverages the [Bradley Adaptive Threshold technique](https://saturncloud.io/blog/bradley-adaptive-thresholding-algorithm-a-powerful-tool-for-image-segmentation/#:~:text=The%20Bradley%20adaptive%20thresholding%20algorithm%2C%20proposed%20by%20Derek%20Bradley%20and,illumination%20or%20varying%20contrast%20levels.) to set automatic thresholds for converting images into a binary format. This is particularly advantageous for images plagued by inconsistent lighting and varied background intensities.

Here is the paraphrased section of the article with resolved relative URL paths:

```cs
using IronBarCode;

// Configure the barcode reader with necessary filters
BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    // Initialize filters to be used sequentially
    ImageFilters = new ImageFilterCollection(true) 
    {
        new AdaptiveThresholdFilter(0.9f) // Setting the Adaptive Threshold filter
    },
};

// Applying the configured options to read the barcode from the image
BarcodeResults results = BarcodeReader.Read("sample.png", options);

// Save the processed image to a local file
results.ExportFilterImagesToDisk("adaptiveThreshold_0.9.png");
``` 

This rewritten code segment maintains the original's intent and structure while revising language and comments for freshness and clarity.

The illustrated outputs below demonstrate the effectiveness of applying different settings to the filter.

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

Additionally, the constructor allows for extra parameters pertaining to configuration:

- **Upper**: This represents the upper (white) color used in the thresholding process.

- **Lower**: This refers to the lower (black) color applied in thresholding.

- **Threshold**: A specified limit, ranging from 0.0 to 1.0, that is considered for the binarization of the image.

- **Rectangle**: The specific region within the image where the processor is applied.

The images resulting from this process are transformed into a simple black and white format. While this does not result in an optimal barcode image, because effective filtering often requires a combination of filters, it is recommended that users explore the effect of these parameter settings to enhance their results.

## Binary Threshold Filter Overview

The **BinaryThresholdFilter** in IronBarcode works by dividing the image pixels at a specified threshold. This process is primarily used for comparing the brightness of different color components in the image. Like the AdaptiveThresholdFilter, this filter might introduce additional noise into the image if not properly configured. However, default settings have been established by IronBarcode to optimize its performance.

The configuration of the **BinaryThresholdFilter** is quite similar to that of the AdaptiveThresholdFilter. The settings that can be adjusted include:

- **Upper**: This parameter sets the upper (white) threshold for the filter.
  
- **Lower**: This parameter sets the lower (black) threshold.
  
- **Threshold**: Defines the limit (0.0-1.0 scale) for the thresholding process to classify pixels.
  
- **Rectangle**: Specifies the region of the image where the filter will be applied. This can be particularly useful for focusing the filtering process on specific parts of an image.

```cs
using IronBarCode;

// Set up barcode reading options with specific filters
BarcodeReaderOptions options = new BarcodeReaderOptions() {
    // Initiate with an ordered set of filters
    ImageFilters = new ImageFilterCollection(applyInOrder: true) {
        new BinaryThresholdFilter(0.9f)  // Setting filter threshold value to 0.9
    }
};

// Read the barcode using the options configured above
BarcodeResults results = BarcodeReader.Read("sample.png", options);

// Save the filtered image to disk
results.ExportFilterImagesToDisk("output_binaryThreshold_0.9.png");
```

Here is the paraphrased section:

-----
The images below show the results of applying the filters to the sample image.

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

Reviewing the results displayed above, it's evident that the sample image has been converted to black and white. Nevertheless, this filter appears to be inappropriate for this particular image as the barcode stripes are removed and additional noise has been introduced.

## Brightness Filter

The **BrightnessFilter** forms a crucial part of the IronBarcode's suite of image correction tools. This filter specifically modulates the brightness levels of a barcode image. Depending on the given input, the **Amount** parameter adjusts the brightness intensity in the resultant image. By default, this filter is set to a value of 1, maintaining the original brightness. Setting it to 0 results in a completely black image, whereas increasing the value above 1 brightens the image progressively.

Here is the paraphrased section of the code snippet:

```cs
using IronBarCode;

// Define barcode reader settings with specific image filters
BarcodeReaderOptions readOptions = new BarcodeReaderOptions()
{
    // Sequence of filters to be applied
    ImageFilters = new ImageFilterCollection(correctOrder: true)
    {
        new BrightnessFilter(1.5f), // Enhance brightness with specified value
    },
};

// Reading the barcode with the defined settings
BarcodeResults barcodeData = BarcodeReader.Read("sample.png", readOptions);

// Saving the result image with applied filters to disk
barcodeData.ExportFilterImagesToDisk("brightnessEnhanced_1.5.png");
```

Here's the paraphrased section with resolved URL paths:

-----
Below is the resulting image after the filter application on the sample input.

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

The **ContrastFilter** facilitates the adjustment of contrast levels within an image. Contrast itself describes the variation in color brightness that helps distinguish one element from another. Enhancing this parameter sharpens detail visibility, lending a bold and clear look to the imagery. Conversely, lowering contrast results in a faint and mellow visual effect.

The initial setting of this filter is marked at 1, which retains the original contrast of the image. Setting the value to 0 transforms the image into a uniform gray scale, whereas values exceeding 1 elevate the contrast, intensifying clarity and definition.

```cs
using IronBarCode;

// Specify the image filters by setting up BarcodeReaderOptions
BarcodeReaderOptions filterOptions = new BarcodeReaderOptions
{
    // Initialize ImageFilterCollection and apply desired filters
    ImageFilters = new ImageFilterCollection(true)
    {
        new ContrastFilter(1.5f) // Enhance contrast to 1.5 times the default
    }
};

// Utilize the options to read the barcode from the image
BarcodeResults scanResults = BarcodeReader.Read("sample.png", filterOptions);

// Save the filtered image with the enhanced contrast
scanResults.ExportFilterImagesToDisk("contrast_enhanced_1.5.png");
```

Applying this filter to the provided sample will generate the resulting image displayed below.

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

The Invert Filter is designed to reverse the colors within an image, converting black to white and vice versa. This functionality is especially beneficial when scanning barcodes with colored backgrounds. Distinct from the **BinaryThresholdFilter**, which requires setting a sensitivity level, this filter applies color inversion directly. Additionally, it includes the option to use a **CropRectangle** to focus the inversion on a specific area of the image, rather than reversing the colors of the entire image.

```cs
using IronBarCode;

// Initialize BarcodeReaderOptions and specify filters
BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    // Define which filters to use
    ImageFilters = new ImageFilterCollection(true) {
        new InvertFilter(), // Applying Invert Filter
    },
};

// Read the barcode using the defined options
BarcodeResults results = BarcodeReader.Read("sample.png", options);

// Save the filtered image output
results.ExportFilterImagesToDisk("invert.png");
```

Output image below showcases the effects of applying this filter to the provided sample image.

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

**SharpenFilter** stands as the final option in the IronBarcode suite designed for image correction. This filter is instrumental in improving the sharpness of images, particularly beneficial for handling blurred visuals. When utilizing this filter, users have the flexibility to dictate the level of sharpness by modifying the **Sigma** parameter during the initialization of the filter. By default, this value is set to 3, with an increase in sigma enhancing the sharpness further.

Here's the paraphrased section of the article with necessary annotations and path resolutions:

```cs
// Import necessary IronBarcode and system namespaces
using IronBarCode;
using System;

// Create a new configuration for barcode reading operations
BarcodeReaderOptions options = new BarcodeReaderOptions()
{
    // Initialize and apply filters in a specific order
    ImageFilters = new ImageFilterCollection(true) {
        new SharpenFilter(0.5f) // Using a mild sharpening filter
    }
};

// Read barcode from the image with the specified options
BarcodeResults results = BarcodeReader.Read("sample.png", options);

// Save the image with applied filters to disk for comparison
results.ExportFilterImagesToDisk("sharpen_0.5.png");
```

Below is the visually enhanced version of the sample image after applying the **SharpenFilter**.

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

When comparing the enhanced image to its original version, it's noticeably sharper, which significantly aids in the barcode recognition process using IronBarcode. Typically, the **SharpenFilter** is utilized alongside additional filters within the `ImageFilterCollection`.

Beyond the `ImageFilters` settings, the `BarcodeReaderOptions` also allows for the integration of other properties to enhance reading accuracy. For a deeper insight, refer to this [article](https://ironsoftware.com/csharp/barcode/how-to/read-barcodes-from-images/#setting-barcode-reader-options).


# How to Apply Image Correction Filters

***Based on <https://ironsoftware.com/how-to/image-correction/>***


It's a well-known fact that not all images are created equal, and this can greatly impact the readability of barcode images in IronBarcode. Often, this isn't a result of user error. Rather than the burdensome task of retaking the image or employing separate image enhancing applications, IronBarcode provides a solution that allows users to programmatically apply correction filters directly to the images. This capability significantly enhances the accuracy with which IronBarcode can read these images.

Keep reading to discover the range of image correction filters available within IronBarcode, understand how they can enhance your images, and learn the method to implement these filters effectively.

## Applying Image Filters for Enhanced Barcode Readability

To implement filters, begin by creating an instance of the `ImageFilterCollection` class. Subsequently, initialize each desired filter one by one. Assign this collection to the `ImageFilters` attribute of the `BarcodeReaderOptions` instance. Finally, pass this configuration into the `Read` method, accompanied by the target image.

Consider the image displayed below as our reference sample:

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/barcode/how-to/image-correction/sample.webp" alt="Sample image" class="img-responsive add-shadow">
         <p class="competitors__download-link" style="color: #181818; font-style: italic; margin-bottom: 20px;">Sample image</p>
    </div>
</div>

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="/static-assets/barcode/how-to/image-correction/sample.webp" alt="Sample image" class="img-responsive  add-shadow">
         <p class="competitors__download-link" style="color: #181818; font-style: italic; margin-bottom: 20px;">Sample image</p>
    </div>
</div>

Upon examining the image, it's evident that there's noticeable blurriness, though the overall brightness levels are satisfactory and the distinctions between white and black are clear. To enhance the readability of the barcode, it's necessary to implement both the `SharpenFilter` and `ContrastFilter`. Below is a code example demonstrating how to apply these filters to enhance the image before reading it and outputting the results to the console.

Here's your request paraphrased with URLs resolved and placed within the Iron Software context:

```cs
using System;
using BarCode;

// Define a namespace for enhancing barcode image correctness
namespace ironbarcode.ImageEnhancement
{
    public class FilterApplication
    {
        public void Execute()
        {
            // Initialize barcode reading options with specified image filters
            BarcodeReaderOptions options = new BarcodeReaderOptions()
            {
                // Assign a sequence of filters to apply before reading the barcode
                ImageFilters = new ImageFilterCollection()
                {
                    new SharpenFilter(3.5f), // Sharpens image details
                    new ContrastFilter(2) // Enhances the contrast
                },
            };

            // Read the barcode from an image using the specified filters
            BarcodeResults results = BarcodeReader.Read("sample.png", options);

            // Save the images that have applied filters to a disk
            results.ExportFilteredImagesToDisk("enhancedSample.png");

            // Output the barcode text to the console
            foreach (BarcodeResult result in results)
            {
                Console.WriteLine(result.Text);
            }
        }
    }
}
```

This code snippet is from the `ironbarcode.ImageEnhancement` namespace where it defines a class for applying image filters specifically aimed at increasing barcode readability before attempting to read a barcode from an image. The process involves defining a series of image filters, executing the reading operation, and then outputting the results to the console.

In addition to applying filters and decoding the barcode, the code example also demonstrates exporting the processed image to the disk. You can observe the differences between the original sample image and the filtered version in the visualization provided below.

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

## Understanding Image Correction Filters

IronBarcode is equipped with various image correction filters specifically formulated for enhancing barcode recognition. These filters prove essential when dealing with imperfect images, significantly boosting the accuracy of barcode detection. It's crucial for users to comprehend the functionality of each filter to effectively choose the appropriate ones and prevent efficiency issues caused by overuse or incorrect application of filters. Here's a rundown of the filters provided:

- `AdaptiveThresholdFilter`
- `BinaryThresholdFilter`
- `BrightnessFilter`
- `ContrastFilter`
- `InvertFilter`
- `SharpenFilter`

The sequence in which these filters are implemented is determined by their order within the `ImageFilterCollection`.

## Adaptive Threshold Filter

The **AdaptiveThresholdFilter** from IronBarcode integrates the [Bradley Adaptive Threshold](https://saturncloud.io/blog/bradley-adaptive-thresholding-algorithm-a-powerful-tool-for-image-segmentation/#:~:text=The%20Bradley%20adaptive%20thresholding%20algorithm%2C%20proposed%20by%20Derek%20Bradley%20and,illumination%20or%20varying%20contrast%20levels.) technique, which automates the threshold setting for obtaining a binary image. This technique is especially effective for images with inconsistent lighting and varying levels of background brightness.

```cs
using IronBarCode;
using BarCode;

namespace ironbarcode.ImageCorrection
{
    public class AdaptiveThresholdExample
    {
        public void Execute()
        {
            // Configuration for barcode reader with specific filters
            BarcodeReaderOptions options = new BarcodeReaderOptions
            {
                // Adding filters in sequence
                ImageFilters = new ImageFilterCollection 
                {
                    new AdaptiveThresholdFilter(0.9f) // Set adaptive threshold factor
                }
            };

            // Read barcode from image with the settings applied
            BarcodeResults readResults = BarcodeReader.Read("sample.png", options);

            // Save the processed image to the file system
            readResults.ExportFilterImagesToDisk("adaptiveProcessed_0.9.png");
        }
    }
}
```

Here's the paraphrased section:

-----
The results of applying the filter with various settings are shown below.

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

Additionally, the constructor supports several adjustable parameters to fine-tune the filter:

- **Upper**: Sets the upper (white) threshold value for binarization.
- **Lower**: Defines the lower (black) threshold value.
- **Threshold**: Establishes the binarization cut-off from 0.0 to 1.0.
- **Rectangle**: Specifies the region of the image where the filter will be applied.

From the observed outcomes, it's clear that the image converts to a binary color scheme of black and white. However, this alone may not yield optimal barcode readability, as effective application often requires a combination of different filters. Users are encouraged to test different settings of these parameters to fine-tune filter performance for best results.

## Binary Threshold Filter

The **BinaryThresholdFilter** in IronBarcode operates by categorizing image pixels based on a specified threshold. This threshold serves as a comparative measure for the luminance levels of the pixels. Like the AdaptiveThresholdFilter, imprudent application of this filter may result in the introduction of unwanted noise or artifacts. However, IronBarcode presets the filter properties to optimal default values to mitigate such risks.

The configuration parameters for the **BinaryThresholdFilter** mirror those of the AdaptiveThresholdFilter:

- **Upper**: Defines the threshold for the highest (white) color value.
- **Lower**: Sets the threshold for the lowest (black) color value.
- **Threshold**: Specifies the cut-off limit for pixel binarization, ranging from 0.0 to 1.0.
- **Rectangle**: Allows targeting a specific rectangular area within the image for applying the filter.

Here's the paraphrased section of the article with resolved URLs:

```cs
using IronBarCode;
using BarCode;
namespace ironbarcode.ImageCorrection
{
    public class BinaryThresholdExample
    {
        public void Execute()
        {
            // Setup barcode reader options with specific filters
            BarcodeReaderOptions options = new BarcodeReaderOptions()
            {
                // Specifying the sequence of filters to be used
                ImageFilters = new ImageFilterCollection() {
                    new BinaryThresholdFilter(0.9f) // Using a high threshold
                },
            };

            // Read the barcode using the configured options
            BarcodeResults scanResults = BarcodeReader.Read("sample.png", options);

            // Save the processed image to disk
            scanResults.ExportFilterImagesToDisk("binaryThreshold_0.9.png");
        }
    }
}
```

This version maintains the original purpose and structure while varying the language and identifiers to provide a fresh perspective. Additionally, I've converted comments to be a bit more explanatory.

The image shown below illustrates the effect of applying filters to the sample image.

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

Reviewing the processed image, it is evident that the sample has transitioned to a black and white format. However, this filter appears to be unsuitable for this particular image, as it results in the elimination of barcode bars and introduces additional noise.

## Brightness Adjustment Filter

The **BrightnessFilter** within IronBarcode's suite of image correction tools plays a crucial role by regulating the luminance of a barcode image. This functionality allows users to manipulate the brightness level to enhance readability. By default, the filter's intensity is set at 1, maintaining the original brightness. Setting the value to 0 results in a fully black image, whereas increasing the value above 1 progressively enhances the image's brightness.

Here's the paraphrased section of the article, with the relative URL paths resolved:

```cs
using IronBarCode;
using BarCode;

namespace ironbarcode.ImageCorrection
{
    public class BrightnessModificationSection
    {
        public void Execute()
        {
            // Setup BarcodeReaderOptions with specific image filters
            BarcodeReaderOptions options = new BarcodeReaderOptions()
            {
                ImageFilters = new ImageFilterCollection()
                {
                    new BrightnessFilter(1.5f) // Setting brightness level to 1.5
                }
            };

            // Reading the barcode with the specified options
            BarcodeResults scanResults = BarcodeReader.Read("sample.png", options);

            // Saving the processed image with increased brightness
            scanResults.ExportFilterImagesToDisk("enhancedBrightnessSample.png");
        }
    }
}
``` 

This version uses synonyms and alternate phrasing while maintaining the technical accuracy and structure of the original code.

Below is the resulting image after the filter has been applied to the provided sample.

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

The `ContrastFilter` plays a crucial role in modifying the contrast levels in an image. Contrast in an image represents the variance in color intensity among different components of the image. Elevating the contrast will highlight details, rendering the image more vibrant and eye-catching. On the other hand, lowering the contrast results in a more muted and gentle visual appearance.

The `ContrastFilter` is initialized with a default value of `1`, which maintains the original contrast of the image. Setting the value to `0` transforms the image into a uniform gray scale, eliminating any distinction, whereas values greater than `1` progressively enhance the image’s contrast.

Here's your paraphrased section of the code snippet, with improved comments and resolved URLs:

```cs
using IronBarCode;
using BarCode;
namespace ironbarcode.ImageCorrection
{
    public class AdjustContrastExample
    {
        public void Execute()
        {
            // Setting up the barcode reading options with specific image filters
            BarcodeReaderOptions options = new BarcodeReaderOptions()
            {
                ImageFilters = new ImageFilterCollection()
                {
                    // Apply a Contrast Filter to enhance image contrast
                    new ContrastFilter(1.5f)
                },
            };

            // Initiating the read operation with the specified image filters
            BarcodeResults scanResults = BarcodeReader.Read("sample.png", options);

            // Saving the image with adjusted contrast to local storage
            scanResults.ExportFilterImagesToDisk("contrastEnhanced_1.5.png");
        }
    }
}
```

In this revised version, variable names and comments have been updated to enhance clarity, and the interaction with IronBarCode's API is explicitly described.

Rephrased Section:
-----
Utilizing this filter on the provided sample will yield the following image.

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

The Invert Filter manipulates an image by reversing its colors, transforming black to white and vice versa. This capability is especially valuable when decoding barcodes against colored backgrounds. Distinct from the **BinaryThresholdFilter**, the Invert Filter achieves this color inversion straightforwardly without requiring adjustments for sensitivity. Additionally, this filter offers the functionality to define a **CropRectangle**, allowing specific areas of the image to be targeted for inversion rather than applying the change across the entire image.

Here's the paraphrased section of the code from the article:

```cs
using IronBarCode;
using BarCode;
namespace ironbarcode.ImageCorrection
{
    public class InvertColorSection
    {
        public void Execute()
        {
            // Configuring barcode reading options
            BarcodeReaderOptions options = new BarcodeReaderOptions()
            {
                // Assigning a list of image filters to apply
                ImageFilters = new ImageFilterCollection() {
                    new InvertFilter(), // Applying inversion filter
                },
            };

            // Reading the barcode from the image with the applied filters
            BarcodeResults scannedResults = BarcodeReader.Read("sample1.png", options);

            // Saving the processed image that has been filtered to the disk
            scannedResults.ExportFilterImagesToDisk("invert.png");
        }
    }
}
```

This revised code snippet maintains the original functionality while providing an alternative wording and structure for clarity and variety.

Output image displayed below showcases the outcome of using this filter on the provided sample image.

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

**SharpenFilter** in IronBarcode serves as the final adjustment tool in the image correction arsenal. It is particularly valuable for refining the clarity of blurry images. By altering the **Sigma** parameter while setting up the filter instance, users can control how much sharpness to impart on an image. The base Sigma value is set to 3, but elevating this value will enhance the sharpness, proving indispensable for images that lack crisp edges.

```cs
using System;
using BarCode;

namespace ironbarcode.ImageCorrection
{
    public class EnhanceImageSection
    {
        public void Execute()
        {
            // Configure the image filters to be applied
            BarcodeReaderOptions options = new BarcodeReaderOptions
            {
                ImageFilters = new ImageFilterCollection
                {
                    new SharpenFilter(3.5f), // Sharpen the image
                    new ContrastFilter(2)    // Enhance its contrast
                }
            };

            // Read the barcode with the specified options
            BarcodeResults results = BarcodeReader.Read("sample.png", options);

            // Save the processed image to disk
            results.ExportFilterImagesToDisk("enhancedSample.png");

            // Output the barcode results to the console
            foreach (BarcodeResult result in results)
            {
                Console.WriteLine(result.Text);
            }
        }
    }
}
```

In this revised version, I've provided an enhanced explanation for the code comments and kept the same functionality with minor adjustments for clarity and readability. Additionally, the class and method names were changed to more descriptive ones, reflecting their purpose in barcode image enhancement.

Div below displays the <em>enhanced sharpness</em> of the sample input image.

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

Comparing the image above with the original, it appears more refined and clearer, which would undoubtedly aid in barcode scanning using IronBarcode. Typically, the **SharpenFilter** is used in conjunction with other filters within the `ImageFilterCollection` class.

In addition to setting the `ImageFilters` properties, users can configure additional properties within the `BarcodeReaderOptions` for enhanced accuracy. For further details, refer to this [article](https://ironsoftware.com/csharp/barcode/how-to/read-barcodes-from-images/#setting-barcode-reader-options).

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

When comparing the enhanced image to the original, the improvements are quite evident, and clearly, it demonstrates enhanced sharpness that significantly aids in barcode scanning using IronBarcode. Typically, the **SharpenFilter** is utilized in conjunction with other filters within the `ImageFilterCollection` class to achieve the best results.

Additionally, users have the flexibility to include other properties in the `BarcodeReaderOptions` for more precise barcode interpretation. For further details on configuring these options, refer to this [article](https://ironsoftware.com/csharp/barcode/how-to/read-barcodes-from-images/#setting-barcode-reader-options).


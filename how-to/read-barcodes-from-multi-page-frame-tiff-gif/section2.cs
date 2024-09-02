using IronBarCode;
using IronSoftware.Drawing;
using System.Collections.Generic;

// Import images
List<AnyBitmap> images = new List<AnyBitmap>()
{
    AnyBitmap.FromFile("image1.png"),
    AnyBitmap.FromFile("image2.png"),
    AnyBitmap.FromFile("image3.png"),
    AnyBitmap.FromFile("image4.jpg"),
    AnyBitmap.FromFile("image5.jpg")
};

// Convert TIFF from images
AnyBitmap tiffImage = AnyBitmap.CreateMultiFrameTiff(images);

// Export TIFF
tiffImage.SaveAs("multiframetiff.tiff");

// Convert GIF from images
AnyBitmap gifImage = AnyBitmap.CreateMultiFrameGif(images);

// Export GIF
gifImage.SaveAs("multiframegif1.gif");
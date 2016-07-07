using System;
using CoreGraphics;
using ImageLoader.Core.Services;
using ImageLoader.iOS.Services;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(ImageResizer))]
namespace ImageLoader.iOS.Services
{
    public class ImageResizer : IImageResizer
    {
        public byte[] ResizeImage(byte[] imageData, float width, float height)
        {
            var originalImage = ImageFromByteArray(imageData);
            var orientation = originalImage.Orientation;

            //create a 24bit RGB image
            using (var context = new CGBitmapContext(IntPtr.Zero,
                                                 (int)width, (int)height, 8,
                                                 (int)(4 * width), CGColorSpace.CreateDeviceRGB(),
                                                 CGImageAlphaInfo.PremultipliedFirst))
            {

                var imageRect = new CGRect(0, 0, width, height);

                // draw the image
                context.DrawImage(imageRect, originalImage.CGImage);

                var resizedImage = UIImage.FromImage(context.ToImage(), 0, orientation);

                // save the image as a jpeg
                return resizedImage.AsJPEG().ToArray();
            }
        }

        public static UIImage ImageFromByteArray(byte[] data)
        {
            if (data == null)
            {
                return null;
            }

            UIImage image;
            try
            {
                image = new UIImage(Foundation.NSData.FromArray(data));
            }
            catch (Exception e)
            {
                Console.WriteLine("Image load failed: " + e.Message);
                return null;
            }
            return image;
        }
    }
}
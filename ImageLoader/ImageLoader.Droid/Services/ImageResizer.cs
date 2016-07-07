using System.IO;
using Android.Graphics;
using ImageLoader.Core.Services;
using ImageLoader.Droid.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(ImageResizer))]
namespace ImageLoader.Droid.Services
{
    public class ImageResizer : IImageResizer
    {
        public byte[] ResizeImage(byte[] imageData, float width, float height)
        {
            // Load the bitmap
            var originalImage = BitmapFactory.DecodeByteArray(imageData, 0, imageData.Length);
            var resizedImage = Bitmap.CreateScaledBitmap(originalImage, (int)width, (int)height, false);

            using (var ms = new MemoryStream())
            {
                resizedImage.Compress(Bitmap.CompressFormat.Jpeg, 100, ms);
                return ms.ToArray();
            }
        }
    }
}
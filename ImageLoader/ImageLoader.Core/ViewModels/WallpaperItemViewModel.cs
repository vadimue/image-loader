using System;
using System.Diagnostics;
using System.IO;
using System.Reactive.Linq;
using Akavache;
using ImageLoader.Core.Models;
using ImageLoader.Core.Services;
using PropertyChanged;
using Xamarin.Forms;

namespace ImageLoader.Core.Views
{
    [ImplementPropertyChanged]
    public class WallpaperItemViewModel
    {
        public WallpaperItemViewModel(Wallpaper wallpaper)
        {
            Name = wallpaper.Name;

            var imagePath = wallpaper.ImageUrl;
            if (string.IsNullOrWhiteSpace(imagePath))
                return;
            BlobCache.LocalMachine.GetObject<byte[]>(imagePath)
                .Catch<byte[], Exception>(ex => FetchImage(ex, imagePath))
                .Subscribe(im => SetImageSource(im, imagePath), OnError);
        }

        private void OnError(Exception exception)
        {
            Debug.WriteLine(exception);
        }

        private IObservable<byte[]> FetchImage(Exception exception, string imagePath)
        {
            return BlobCache.LocalMachine.DownloadUrl(imagePath)
                .SelectMany(im => ResizeAndSaveImage(im, imagePath));
        }

        private void SetImageSource(byte[] bytes, string imagePath)
        {
            Image = ImageSource.FromStream(() => new MemoryStream(bytes));
            Name = "Downloaded";
        }

        private IObservable<byte[]> ResizeAndSaveImage(byte[] bytes, string imagePath)
        {
            var resizer = DependencyService.Get<IImageResizer>();
            var resized = resizer.ResizeImage(bytes, 1000, 1000);
            return BlobCache.LocalMachine.InsertObject(imagePath, resized)
                .Select(_ => resized);
        }

        public string Name { get; set; }
        public ImageSource Image { get; set; }
    }
}


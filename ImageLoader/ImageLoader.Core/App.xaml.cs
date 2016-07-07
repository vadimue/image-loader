using Akavache;
using FreshMvvm;
using ImageLoader.Core.Views;
using Xamarin.Forms;

namespace ImageLoader.Core
{
    public partial class App : Application
    {
        public App()
        {
            BlobCache.ApplicationName = "ImageLoader";

            var page = FreshPageModelResolver.ResolvePageModel<WallpaperListPageModel>();
            var basicNavContainer = new FreshNavigationContainer(page);
            MainPage = basicNavContainer;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

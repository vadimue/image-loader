using System.Collections.Generic;
using FreshMvvm;
using ImageLoader.Core.Models;

namespace ImageLoader.Core.Views
{
    public class WallpaperListPageModel : FreshBasePageModel
    {
        public List<WallpaperItemViewModel> WallpaperList { get; set; }

        public override void Init(object initData)
        {
            base.Init(initData);

            GenerateDummyData();
        }

        private void GenerateDummyData()
        {
            WallpaperList = new List<WallpaperItemViewModel>
            {
                new WallpaperItemViewModel(new Wallpaper
                {
                    Name = "Wallpaper1",
                    ImageUrl = @"http://widewallpaper.info/wp-content/uploads/2016/01/Nature-autumn-4k-uhd-wallpaper.jpeg"
                }),
                new WallpaperItemViewModel ( new Wallpaper
                {
                    Name = "Wallpaper2",
                    ImageUrl = @"https://images5.alphacoders.com/568/568653.jpg"
                }),
                new WallpaperItemViewModel ( new Wallpaper
                {
                    Name = "Wallpaper3",
                    ImageUrl = @"https://4.bp.blogspot.com/-loXAVs8YZhE/U5c1HdFoRqI/AAAAAAAA9fc/DbIgFwJdQvU/s0/Spinning+the+light+at+sunset_Ultra+HD.jpg"
                }),
                new WallpaperItemViewModel ( new Wallpaper
                {
                    Name = "Wallpaper4",
                    ImageUrl = @"http://widewallpaper.info/wp-content/uploads/2016/01/DOCK-SKY-LAKE-4K-WALLPAPER.jpg"
                })
            };
        }
    }
}

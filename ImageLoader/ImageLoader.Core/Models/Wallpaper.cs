using PropertyChanged;

namespace ImageLoader.Core.Models
{
    [ImplementPropertyChanged]
    public class Wallpaper
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}

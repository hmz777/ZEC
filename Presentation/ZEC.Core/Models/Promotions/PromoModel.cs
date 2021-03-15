using ZEC.Core.Models.Helpers;

namespace ZEC.Core.Models.Promotions
{
    public class PromoModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string ButtonText { get; set; }
        public Color BackgroundColor { get; set; }
        public Size Size { get; set; }
        public string PictureUrl { get; set; }
        public bool IsExternalLink { get; set; }
        public string Link { get; set; }
    }
}

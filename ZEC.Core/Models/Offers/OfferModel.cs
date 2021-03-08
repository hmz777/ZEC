using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZEC.Core.Models.Offers
{
    public class OfferModel
    {
        public string TitleText { get; set; }
        public string BodyText { get; set; }
        public string PictureUrl { get; set; }
        public string AltText { get; set; }
        public string Link { get; set; }
        public bool HasLink { get { return !string.IsNullOrEmpty(Link); } }
        public bool IsExternalLink { get; set; }
    }
}

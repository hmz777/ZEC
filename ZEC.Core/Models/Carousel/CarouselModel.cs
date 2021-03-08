using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZEC.Core.Models.Helpers;

namespace ZEC.Core.Models.Carousel
{
    public class CarouselModel
    {
        public CarouselModel()
        {
            Position = Position.Center;
        }

        public string HeaderText { get; set; }
        public string BodyText { get; set; }
        public string PictureUrl { get; set; }
        public string Link { get; set; }
        public string ButtonText { get; set; }
        public Position Position { get; set; }
        public bool IsExternalUrl { get; set; }
        [NotMapped]
        public bool HasLink { get { return !string.IsNullOrEmpty(Link) || !string.IsNullOrEmpty(ButtonText); } }
    }
}

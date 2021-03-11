using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZEC.Core.Models.Helpers;

namespace ZEC.Core.Models.Product
{
    public class ProductColor
    {
        public ICollection<string> Pictures { get; set; }
        public Color Color { get; set; }
    }
}

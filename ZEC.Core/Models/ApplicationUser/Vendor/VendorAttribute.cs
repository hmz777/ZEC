using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZEC.Core.Models.ShopAttributes;
using Attribute = ZEC.Core.Models.ShopAttributes.Attribute;

namespace ZEC.Core.Models.ApplicationUser.Vendor
{
    public class VendorAttribute : Attribute
    {
        public string Name { get; set; }

        public bool IsRequired { get; set; }

        public int DisplayOrder { get; set; }

        public AttributeControlType AttributeControlType { get; set; }

        public VendorAttributeValue VendorAttributeValue { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZEC.Core.Models.ApplicationUser.Vendor
{
    public class VendorAttributeValue
    {
        public string Name { get; set; }

        public bool IsPreSelected { get; set; }

        public int DisplayOrder { get; set; }

        public VendorAttribute VendorAttribute { get; set; }
    }
}

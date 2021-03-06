using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZEC.Core.Models.ApplicationUser.UserInfo;

namespace ZEC.Core.Models.ApplicationUser.Vendor
{
    public class Vendor : ApplicationUser
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int PictureId { get; set; }
        public VendorAddress VendorAddress { get; set; }
        public ICollection<VendorAttribute> VendorAttributes { get; set; }

        //Administration Info
        public string AdminComment { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }

        //Shop
        public int DisplayOrder { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public int PageSize { get; set; }
        public bool AllowCustomersToSelectPageSize { get; set; }
        public string PageSizeOptions { get; set; }
    }
}

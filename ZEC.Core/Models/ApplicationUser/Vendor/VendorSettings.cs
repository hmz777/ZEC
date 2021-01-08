using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZEC.Core.Models.ShopSettings;

namespace ZEC.Core.Models.ApplicationUser.Vendor
{
    public class VendorSettings : Settings
    {
        public string DefaultVendorPageSizeOptions { get; set; }

        public int VendorsBlockItemsToDisplay { get; set; }

        public bool ShowVendorOnProductDetailsPage { get; set; }

        public bool ShowVendorOnOrderDetailsPage { get; set; }

        public bool AllowCustomersToContactVendors { get; set; }

        public bool AllowCustomersToApplyForVendorAccount { get; set; }

        public bool TermsOfServiceEnabled { get; set; }

        public bool AllowSearchByVendor { get; set; }

        public bool AllowVendorsToEditInfo { get; set; }

        public bool NotifyStoreOwnerAboutVendorInformationChange { get; set; }

        public int MaximumProductNumber { get; set; }

        public bool AllowVendorsToImportProducts { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using ZEC.Core.Models.ApplicationUser.UserInfo;

namespace ZEC.Core.Models.ApplicationUser.Customer
{
    public class Customer : ApplicationUser
    {
        //Shop Info
        public int AffiliateId { get; set; }
        public bool IsTaxExempt { get; set; }
        public bool HasShoppingCartItems { get; set; }
        public int RegisteredInStoreId { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
        public BillingAddress BillingAddress { get; set; }
    }
}

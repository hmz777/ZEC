using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ZEC.Core.Models.ApplicationUser.Customer
{
    public class Customer : ApplicationUser
    {
        //Administration Info
        public string AdminComment { get; set; }

        //Shop Info
        public int AffiliateId { get; set; }
        public bool IsTaxExempt { get; set; }
        public bool HasShoppingCartItems { get; set; }
        public int RegisteredInStoreId { get; set; }
    }
}

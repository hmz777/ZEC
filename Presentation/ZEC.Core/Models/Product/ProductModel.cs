using System.Collections.Generic;
using ZEC.Core.Models.Helpers;

namespace ZEC.Core.Models.Product
{
    public class ProductModel
    {
        public ProductModel()
        {
            Currency = Currency.USDollar;
        }

        public string Name { get; set; }
        public string SKU { get; set; }
        public List<string> Pictures { get; set; }
        public string Manufacturer { get; set; }
        public bool HasDiscount { get; set; }
        public Currency Currency { get; set; }
        public decimal SaleValue { get { return OldPrice - Price; } }
        public decimal OldPrice { get; set; }
        public decimal Price { get; set; }
        public int No_Reviews { get; set; }
        public double OverallRating { get; set; }
        public bool IsInStock { get; set; }
        public int InventoryUnits { get; set; }
        public bool IsStoreSelection { get; set; }
        public bool HasColors { get; set; }
        public List<ProductColor> ProductColors { get; set; }
        public int RequestedQuantity { get; set; }
        public bool HasTierPrices { get; set; }
    }
}

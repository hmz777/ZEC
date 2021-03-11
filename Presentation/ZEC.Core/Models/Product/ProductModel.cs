using System.Collections.Generic;

namespace ZEC.Core.Models.Product
{
    public class ProductModel
    {
        public string Name { get; set; }
        public string SKU { get; set; }
        public ICollection<string> Pictures { get; set; }
        public string Manufacturer { get; set; }
        public bool IsOnSale { get; set; }
        public string SaleValue { get; set; }
        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }
        public int No_Reviews { get; set; }
        public int OverallRating { get; set; }
        public bool IsInStock { get; set; }
        public int InventoryUnits { get; set; }
        public bool IsStoreSelection { get; set; }
        public bool HasColors { get; set; }
        public ICollection<ProductColor> ProductColors { get; set; }
        public int RequestedQuantity { get; set; }
    }
}

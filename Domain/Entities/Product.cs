using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public bool? MakeFlag { get; set; }
        public bool? FinishGoodFlag { get; set; }
        public string Color { get; set; }
        public short SafetyStockLevel { get; set; }
        public short ReorderPoint { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public int DaysToManufacture { get; set; }
        public int IdVendor { get; set; }
        public string VendorName { get; set; }
        public int IdSubCategory { get; set; }
        public string SubCategoryName { get; set; }
        public int IdCategory { get; set; }
        public string CategoryName { get; set; }
    }
}

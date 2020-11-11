using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daxone_API.ViewModels.Admin.Product
{
    public class AddProductViewModel
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public long? CategoryId { get; set; }
        public long? SupplierId { get; set; }
        public decimal? PromotionPrice { get; set; }
        public int? Warranty { get; set; }
        public string Frame { get; set; }
        public string Rims { get; set; }
        public string Tires { get; set; }
        public string Weight { get; set; }
        public string WeightLimit { get; set; }
        public bool? Status { get; set; }
        public bool? ShowOnHome { get; set; }
    }
}
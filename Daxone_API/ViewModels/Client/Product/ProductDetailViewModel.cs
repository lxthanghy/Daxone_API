using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daxone_API.ViewModels.Client.Product
{
    public class ProductDetailViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string MetaTitle { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string MoreImage { get; set; }
        public decimal? Price { get; set; }
        public string CategoryName { get; set; }
        public string SupplierName { get; set; }
        public int? TotalReview { get; set; }
        public int? TotalRating { get; set; }
        public decimal? PromotionPrice { get; set; }
        public int? Warranty { get; set; }
        public string Frame { get; set; }
        public string Rims { get; set; }
        public string Tires { get; set; }
        public string Weight { get; set; }
        public string WeightLimit { get; set; }
        public int? ViewCount { get; set; }
    }
}
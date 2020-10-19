using System;
using System.Collections.Generic;

namespace Daxone_API.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
            Reviews = new HashSet<Review>();
            WishLists = new HashSet<WishList>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string MetaTitle { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string MoreImage { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public long? CategoryId { get; set; }
        public long? SupplierId { get; set; }
        public int? TotalReview { get; set; }
        public int? TotalRating { get; set; }
        public decimal? PromotionPrice { get; set; }
        public int? Warranty { get; set; }
        public string Frame { get; set; }
        public string Rims { get; set; }
        public string Tires { get; set; }
        public string Weight { get; set; }
        public string WeightLimit { get; set; }
        public bool? Status { get; set; }
        public bool? ShowOnHome { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public int? ViewCount { get; set; }

        public virtual ProductCategory Category { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<WishList> WishLists { get; set; }
    }
}

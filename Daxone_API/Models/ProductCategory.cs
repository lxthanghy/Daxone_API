using System;
using System.Collections.Generic;

namespace Daxone_API.Models
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            Products = new HashSet<Product>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string MetaTitle { get; set; }
        public long? ParentId { get; set; }
        public string Description { get; set; }
        public bool? Status { get; set; }
        public bool? ShowOnHome { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

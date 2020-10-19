using System;
using System.Collections.Generic;

namespace Daxone_API.Models
{
    public partial class OrderDetail
    {
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}

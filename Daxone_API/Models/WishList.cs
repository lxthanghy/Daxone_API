using System;
using System.Collections.Generic;

namespace Daxone_API.Models
{
    public partial class WishList
    {
        public long Id { get; set; }
        public long? ProductId { get; set; }
        public long? UserId { get; set; }
        public int? Quantity { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Daxone_API.Models
{
    public partial class Review
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public long? ProductId { get; set; }
        public int? Like { get; set; }
        public int? Dislike { get; set; }
        public int? Rating { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? Status { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}

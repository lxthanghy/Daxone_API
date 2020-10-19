using System;
using System.Collections.Generic;

namespace Daxone_API.Models
{
    public partial class Post
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string MetaTitle { get; set; }
        public long? PostCategoryId { get; set; }
        public string Content { get; set; }
        public bool? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public int? ViewCount { get; set; }

        public virtual PostCategory PostCategory { get; set; }
    }
}

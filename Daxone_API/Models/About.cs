using System;
using System.Collections.Generic;

namespace Daxone_API.Models
{
    public partial class About
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Status { get; set; }
    }
}

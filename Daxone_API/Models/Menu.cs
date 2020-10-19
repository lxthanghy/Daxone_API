using System;
using System.Collections.Generic;

namespace Daxone_API.Models
{
    public partial class Menu
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public int? DisplayOrder { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Status { get; set; }
    }
}

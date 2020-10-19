using System;
using System.Collections.Generic;

namespace Daxone_API.Models
{
    public partial class Feedback
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Content { get; set; }
        public bool? Status { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual User User { get; set; }
    }
}

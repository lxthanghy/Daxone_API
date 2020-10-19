using System;
using System.Collections.Generic;

namespace Daxone_API.Models
{
    public partial class User
    {
        public User()
        {
            Feedbacks = new HashSet<Feedback>();
            Reviews = new HashSet<Review>();
            WishLists = new HashSet<WishList>();
        }

        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Avatar { get; set; }
        public bool? Status { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<WishList> WishLists { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace RepoLayer.Models
{
    public partial class Users
    {
        public Users()
        {
            Address = new HashSet<Address>();
            OrderDetails = new HashSet<OrderDetails>();
            OrdersSummary = new HashSet<OrdersSummary>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ICollection<OrdersSummary> OrdersSummary { get; set; }
    }
}

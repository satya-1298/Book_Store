using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepoLayer.Model
{
    public partial class Users
    {
        public Users()
        {
            Address = new HashSet<Address>();
            OrdersSummary = new HashSet<OrdersSummary>();
        }

        [Key]
        [Column("UserID")]
        public int UserId { get; set; }
        [StringLength(255)]
        public string Username { get; set; }
        [StringLength(255)]
        public string Password { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Role { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Address> Address { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<OrdersSummary> OrdersSummary { get; set; }
    }
}

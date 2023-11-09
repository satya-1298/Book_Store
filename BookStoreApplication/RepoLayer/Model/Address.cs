using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepoLayer.Model
{
    public partial class Address
    {
        public Address()
        {
            OrdersSummary = new HashSet<OrdersSummary>();
        }

        [Key]
        [Column("AddressID")]
        public int AddressId { get; set; }
        [Column("UserID")]
        public int? UserId { get; set; }
        [StringLength(255)]
        public string StreetAddress { get; set; }
        [StringLength(255)]
        public string City { get; set; }
        [StringLength(50)]
        public string State { get; set; }
        [StringLength(10)]
        public string ZipCode { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Users.Address))]
        public virtual Users User { get; set; }
        [InverseProperty("Address")]
        public virtual ICollection<OrdersSummary> OrdersSummary { get; set; }
    }
}

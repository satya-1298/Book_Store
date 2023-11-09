using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepoLayer.Model
{
    public partial class OrdersSummary
    {
        [Key]
        public int OrderId { get; set; }
        public int? AddressId { get; set; }
        public int? UserId { get; set; }
        public int? PriceDetailId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? OrderDate { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        [ForeignKey(nameof(AddressId))]
        [InverseProperty("OrdersSummary")]
        public virtual Address Address { get; set; }
        [ForeignKey(nameof(PriceDetailId))]
        [InverseProperty("OrdersSummary")]
        public virtual PriceDetail PriceDetail { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Users.OrdersSummary))]
        public virtual Users User { get; set; }
    }
}

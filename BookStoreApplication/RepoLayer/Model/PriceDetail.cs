using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepoLayer.Model
{
    public partial class PriceDetail
    {
        public PriceDetail()
        {
            OrdersSummary = new HashSet<OrdersSummary>();
        }

        [Key]
        public int PriceDetailId { get; set; }
        public int? OrderDetailId { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }
        public int? Discount { get; set; }
        public int? DeliveryFee { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? TotalAmount { get; set; }

        [ForeignKey(nameof(OrderDetailId))]
        [InverseProperty(nameof(OrderDetails.PriceDetail))]
        public virtual OrderDetails OrderDetail { get; set; }
        [InverseProperty("PriceDetail")]
        public virtual ICollection<OrdersSummary> OrdersSummary { get; set; }
    }
}

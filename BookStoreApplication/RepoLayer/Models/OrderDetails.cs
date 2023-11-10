using System;
using System.Collections.Generic;

namespace RepoLayer.Models
{
    public partial class OrderDetails
    {
        public OrderDetails()
        {
            OrdersSummary = new HashSet<OrdersSummary>();
        }

        public int OrderDetailId { get; set; }
        public int? UserId { get; set; }
        public int? BookId { get; set; }
        public int? Discount { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int? DeliveryFee { get; set; }
        public decimal? TotalAmount { get; set; }
        public DateTime? OrderDate { get; set; }

        public virtual Books Book { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<OrdersSummary> OrdersSummary { get; set; }
    }
}

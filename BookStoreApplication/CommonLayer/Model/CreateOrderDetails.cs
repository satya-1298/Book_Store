using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class CreateOrderDetails
    {
        public int? Discount { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int? DeliveryFee { get; set; }
        public decimal? TotalAmount { get; set; }
        public DateTime? OrderDate { get; set; } 
    }
}

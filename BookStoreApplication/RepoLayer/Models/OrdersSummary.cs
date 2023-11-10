using System;
using System.Collections.Generic;

namespace RepoLayer.Models
{
    public partial class OrdersSummary
    {
        public int OrderId { get; set; }
        public int? AddressId { get; set; }
        public int? UserId { get; set; }
        public int? OrderDetailId { get; set; }

        public virtual Address Address { get; set; }
        public virtual OrderDetails OrderDetail { get; set; }
        public virtual Users User { get; set; }
    }
}

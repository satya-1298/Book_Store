using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepoLayer.Model
{
    public partial class OrderDetails
    {
        public OrderDetails()
        {
            PriceDetail = new HashSet<PriceDetail>();
        }

        [Key]
        [Column("OrderDetailID")]
        public int OrderDetailId { get; set; }
        [Column("BookID")]
        public int? BookId { get; set; }
        public int? Discount { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        [ForeignKey(nameof(BookId))]
        [InverseProperty(nameof(Books.OrderDetails))]
        public virtual Books Book { get; set; }
        [InverseProperty("OrderDetail")]
        public virtual ICollection<PriceDetail> PriceDetail { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RepoLayer.Models
{
    public partial class OrderDetails
    {
        public OrderDetails()
        {
            OrdersSummary = new HashSet<OrdersSummary>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderDetailId { get; set; }
        [ForeignKey("Users")]
        public int? UserId { get; set; }
        [ForeignKey("Books")]
        public int? BookId { get; set; }
        public int? Discount { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int? DeliveryFee { get; set; }
        public decimal? TotalAmount { get; set; }
        public DateTime? OrderDate { get; set; }

        [JsonIgnore]
        public virtual Books Book { get; set; }
        [JsonIgnore]
        public virtual Users User { get; set; }
        public virtual ICollection<OrdersSummary> OrdersSummary { get; set; }
    }
}

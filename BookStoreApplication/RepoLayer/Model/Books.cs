using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepoLayer.Model
{
    public partial class Books
    {
        public Books()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        [Key]
        [Column("BookID")]
        public int BookId { get; set; }
        [StringLength(255)]
        public string Title { get; set; }
        [StringLength(255)]
        public string Author { get; set; }
        [Column("ISBN")]
        [StringLength(13)]
        public string Isbn { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal? Price { get; set; }
        public int? QuantityInStock { get; set; }
        public int? PageNo { get; set; }
        [StringLength(500)]
        public string Images { get; set; }

        [InverseProperty("Book")]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}

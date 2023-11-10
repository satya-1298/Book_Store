using System;
using System.Collections.Generic;

namespace RepoLayer.Models
{
    public partial class Books
    {
        public Books()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public decimal? Price { get; set; }
        public int? QuantityInStock { get; set; }
        public int? PageNo { get; set; }
        public string Images { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}

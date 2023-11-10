using System;
using System.Collections.Generic;

namespace RepoLayer.Models
{
    public partial class Address
    {
        public Address()
        {
            OrdersSummary = new HashSet<OrdersSummary>();
        }

        public int AddressId { get; set; }
        public int? UserId { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<OrdersSummary> OrdersSummary { get; set; }
    }
}

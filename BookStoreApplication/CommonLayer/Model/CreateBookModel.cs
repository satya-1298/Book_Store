using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model
{
    public class CreateBookModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public decimal? Price { get; set; }
        public int? QuantityInStock { get; set; }
        public int? PageNo { get; set; }
        public string Images { get; set; }

    }  
}

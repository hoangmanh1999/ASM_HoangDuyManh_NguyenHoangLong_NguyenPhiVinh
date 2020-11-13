using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace bai29_10.Models
{
    public class Product
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName="decimal(8,2)")]
        public decimal Price { get; set; }
        public string Category { get; set; }

    }
}

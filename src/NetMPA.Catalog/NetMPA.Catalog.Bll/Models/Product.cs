using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMPA.Catalog.Bll.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Uri? Image { get; set; }
        public Category? Category { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
    }
}

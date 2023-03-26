using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMPA.Catalog.Bll.Models
{
    public class Product
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public Uri Image { get; init; }
        public Category Category { get; init; }
        public decimal Price { get; init; }
        public int Amount { get; init; }
    }
}

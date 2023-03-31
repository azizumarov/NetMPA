using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMPA.Carting.Dal.Models
{
    public class ItemDao
    {
        public int Id { get; init; }
        //– required, plain text.
        public string Name { get; init; }
        public Uri Image { get; init; }
        public decimal Price { get; init; }
        public int Quantity { get; init; }
    }
}

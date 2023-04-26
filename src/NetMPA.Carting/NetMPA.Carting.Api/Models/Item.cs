using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMPA.Carting.Api.Models
{
    public class Item
    {
        public int Id { get; init; }
        //– required, plain text.
        public string Name { get; init; }
        public Uri Image { get; init; }
        public decimal Price { get; init; }
        public int Quantity { get; init; }

        public bool isValid()
        {
            if (String.IsNullOrEmpty(Name)) throw new Exception("Name is required");

            return true;
        }
    }
}

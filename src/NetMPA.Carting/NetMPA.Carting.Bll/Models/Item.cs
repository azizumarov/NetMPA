using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMPA.Carting.Bll.Models
{
    public class Item
    {
        private int id;

        private string name;

        private Uri image;

        private decimal price;

        private int quantity;

        public int Id { get { return id; } }
        //– required, plain text.
        public string Name { get { return name; } }
        public Uri Image { get { return image; } }
        public decimal Price { get { return price; } }
        public int Quantity { get { return quantity; } }
    }
}

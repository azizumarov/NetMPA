using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMPA.Catalog.Bll.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public Uri? Image { get; set; }
        public Category? Parent { get; set; }
    }
}

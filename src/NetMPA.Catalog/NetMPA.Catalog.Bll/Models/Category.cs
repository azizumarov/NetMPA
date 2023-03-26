using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMPA.Catalog.Bll.Models
{
    public class Category
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public Uri Image { get; init; }
        public Category Parent { get; init; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace NetMPA.Carting.Bll.Models
{
    public class Cart
    {
        private Guid id;
        private IEnumerable<Item> items;

        public Guid Id { get { return id; } }
        public IEnumerable<Item> Items { get { return items; } }

    }
}

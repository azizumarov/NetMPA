using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace NetMPA.Carting.Api.Models
{
    public class Cart
    {
        public Guid Key { get; set; } 

        public IEnumerable<Item> Items { get; set; }
    }
}

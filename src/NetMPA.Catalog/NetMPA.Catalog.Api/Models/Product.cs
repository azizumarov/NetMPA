using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMPA.Catalog.Api.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Description = "Name – Required, Plain Text, Max Length = 50.")]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public Uri? Image { get; set; }
        public Category? Category { get; set; }

        [Required]
        public decimal Price { get; set; }
        
        [Required]
        public int Amount { get; set; }
    }
}

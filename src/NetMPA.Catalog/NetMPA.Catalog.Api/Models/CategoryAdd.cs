using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace NetMPA.Catalog.Api.Models
{
    /// <summary>
    /// Category model for add
    /// </summary>
    public class CategoryAdd
    {
        /// <summary>
        /// Name – Required, Plain Text, Max Length = 50.
        /// </summary>
        [Required]
        [MaxLength(50)]
        [Display(Description = "Name – Required, Plain Text, Max Length = 50.")]
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// Image – optional, URL.
        /// </summary>
        [Url]
        [Display(Description = "Image – optional, URL.")]
        public Uri? Image { get; set; }

        /// <summary>
        /// Parent Category – Optional
        /// </summary>
        [Display(Description = "Parent Category Id – Optional")]
        public int ParentId { get; set; }
    }
}

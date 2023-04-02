using System.ComponentModel.DataAnnotations;

namespace NetMPA.Catalog.Api.Models
{
    /// <summary>
    /// Category 
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Id – Required, Identificator.
        /// </summary>
        [Required]
        public int Id { get; set; }

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
        [Display(Description = "Parent Category – Optional")]
        public Category? Parent { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace E_commerce_RazorProj.Pages.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [Required]
        [Range(1, 130, ErrorMessage = "Display Order must be between 1-130")]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}

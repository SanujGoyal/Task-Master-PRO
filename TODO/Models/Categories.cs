using System.ComponentModel.DataAnnotations;

namespace TODO.Models
{
    public class Categories
    {
        [Key]
        public Guid CategoriesId { get; set; }

        [Display(Name = "Category Name")]
        public string? CategoriesName { get; set; }
    }
}

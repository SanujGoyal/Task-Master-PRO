using System.ComponentModel.DataAnnotations;

namespace TODO.Models
{
    public class Tasks
    {
        [Key]
        public Guid TaskId { get; set; }

        [Display(Name = "Task Name")]
        public string? TaskName { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public Guid? CategoriesId { get; set; }
        public Categories? Categories { get; set; }
    }
}

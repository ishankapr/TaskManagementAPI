using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagement.Entities
{
    [Table("Tasks")]
    public class TodoTask
    {
        [Key]
        [Column("TaskID")]
        public int TaskID { get; set; }

        [Column("Title")]
        [Required(ErrorMessage = "Please set title")]
        public string Title { get; set; }

        [Column("Description")]
        [Required(ErrorMessage = "Please set description")]
        public string Description { get; set; }
        
        [Column("DueDate")]
        [Required(ErrorMessage = "Please set due date")]
        public DateTime DueDate { get; set; }

        [Column("CreatedDate")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Column("IsCompleted")]
        public bool IsCompleted { get; set; } = false;

        [Column("CreatedBy")]
        public int? CreatedBy { get; set; }

    }
}

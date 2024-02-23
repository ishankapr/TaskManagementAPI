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
        public DateTime DueDate { get; set; }

        [Column("CreatedDate")]
        public DateTime CreatedDate { get; set; }
        
        [Column("CreatedBy")]
        public int CreatedBy { get; set; }

    }
}

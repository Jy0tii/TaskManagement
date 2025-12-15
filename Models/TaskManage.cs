using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Models
{
    public class TaskManage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string TaskTitle { get; set; }

        [StringLength(1000)]
        public string TaskDescription { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime TaskDueDate { get; set; }

        [Required]
        public bool TaskStatus { get; set; }

        [StringLength(500)]
        public string TaskRemarks { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime? UpdatedOn { get; set; }

        public string? CreatedById { get; set; }
        public string? CreatedByName { get; set; }   


        public string? UpdatedById { get; set; }
        public string? UpdatedByName { get; set; }

    }
}

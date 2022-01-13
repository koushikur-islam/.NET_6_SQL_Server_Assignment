using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data_Access_Layer.Models
{
    public partial class Tasks
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Title { get; set; } = null!;
        [Required, StringLength(1000)]
        public string Description { get; set; } = null!;
        public DateTime? TaskDeadline { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public TaskAssignmentsLogs TaskAssignment { get; set; } = null!;
    }
}

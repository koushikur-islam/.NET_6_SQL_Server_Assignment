using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_Access_Layer.Models
{
    public partial class Persons
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [InverseProperty("AssignedByNavigation")]
        public virtual ICollection<TaskAssignmentsLogs> TaskAssignedByNavigations { get; set; } = null!;
        [InverseProperty("AssignedToNavigation")]
        public virtual ICollection<TaskAssignmentsLogs> TaskAssignedToNavigations { get; set; }=null!;
    }
}
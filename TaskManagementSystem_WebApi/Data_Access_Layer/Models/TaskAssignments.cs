using System;
using System.Collections.Generic;

namespace Data_Access_Layer.Models
{
    public partial class TaskAssignments
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int AssignedBy { get; set; }
        public int AssignedTo { get; set; }

        public virtual Persons AssignedByNavigation { get; set; } = null!;
        public virtual Persons AssignedToNavigation { get; set; } = null!;
    }
}

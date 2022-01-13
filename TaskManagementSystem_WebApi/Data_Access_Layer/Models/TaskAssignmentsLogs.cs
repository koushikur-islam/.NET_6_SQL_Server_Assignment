using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Models
{
    public class TaskAssignmentsLogs
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Status { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime CompletedAt { get; set; }
        [ForeignKey("Tasks")]
        public int TaskId { get; set; }
        [ForeignKey("AssignedByNavigation")]
        public int AssignedById { get; set; }
        [ForeignKey("AssignedToNavigation")]
        public int AssignedToId { get; set; }

        public Tasks Tasks { get; set; } = null!;
        public Persons AssignedByNavigation { get; set; }= null!;
        public Persons AssignedToNavigation { get; set; }= null!;
    }
}
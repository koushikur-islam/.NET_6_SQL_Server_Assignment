using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Entity_Layer.CustomModels
{
    public class TaskAssignmentModel
    {
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public string Description { get; set; }=null!;
        [Required]
        public DateTime TaskDeadline { get; set; }
        [Required]
        public int AssignedById { get; set; }
        [Required]
        public int AssignedToId { get; set; }
    }
}
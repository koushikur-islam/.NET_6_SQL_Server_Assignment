using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Entity_Layer.DTO
{
    //Task Assignment Log DTO for transerferring between db entities and presentation layer
    public class TaskAssignmentLogDto
    {
        public int Id { get; set; }
        public string Status { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime CompletedAt { get; set; }
        public int TaskId { get; set; }
        public int AssignedById { get; set; }
        public int AssignedToId { get; set; }
    }
}
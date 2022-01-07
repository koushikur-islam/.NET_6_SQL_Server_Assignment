using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Models
{
    public class Tasks
    {
        public Tasks()
        {
            RequestLogs = new HashSet<RequestLogs>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int AssignedBy { get; set; }
        public int AssignedTo { get; set; }

        public virtual Persons AssignedByNavigation { get; set; } = null!;
        public virtual ICollection<RequestLogs> RequestLogs { get; set; }
    }
}
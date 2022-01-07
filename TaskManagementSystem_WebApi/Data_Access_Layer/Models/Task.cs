using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Models
{
    public class Task
    {
        public Task()
        {
            RequestLogs = new HashSet<RequestLog>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int AssignedBy { get; set; }
        public int AssignedTo { get; set; }

        public virtual Person AssignedByNavigation { get; set; } = null!;
        public virtual ICollection<RequestLog> RequestLogs { get; set; }
    }
}
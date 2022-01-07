using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Models
{
    public class RequestLog
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public DateTime DueAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public int TaskId { get; set; }

        public virtual Task Task { get; set; } = null!;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Entity_Layer.DTO
{
    public class RequestLogDto
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public DateTime DueAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public int TaskId { get; set; }
    }
}

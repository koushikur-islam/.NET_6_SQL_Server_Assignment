using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Entity_Layer.DTO
{
    public class RequestLogDto
    {
        //Request Log DTO for transerferring between db entities and presentation layer
        public int Id { get; set; }
        public string Route { get; set; } = null!;
        public DateTime RequestedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}

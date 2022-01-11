using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Entity_Layer.DTO
{
    public class ExceptionLogDto
    {
        public int Id { get; set; }
        public string ExceptionMessage { get; set; } = null!;
        public DateTime LoggedAt { get; set; }
    }
}
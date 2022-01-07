using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Models
{
    public class Persons
    {
        public Persons()
        {
            Tasks = new HashSet<Tasks>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Designation { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}
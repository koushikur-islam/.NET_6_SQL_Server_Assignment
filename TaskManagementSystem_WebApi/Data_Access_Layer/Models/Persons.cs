using System;
using System.Collections.Generic;

namespace Data_Access_Layer.Models
{
    public partial class Persons
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

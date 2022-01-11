using System;
using System.Collections.Generic;

namespace Data_Access_Layer.Models
{
    public partial class Tasks
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

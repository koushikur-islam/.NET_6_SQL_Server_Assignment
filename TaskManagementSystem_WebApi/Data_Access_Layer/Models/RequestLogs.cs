using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data_Access_Layer.Models
{
    public partial class RequestLogs
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(1000)]
        public string Route { get; set; } = null!;
        public DateTime RequestedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}

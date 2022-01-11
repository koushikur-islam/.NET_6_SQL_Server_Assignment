using System;
using System.Collections.Generic;

namespace Data_Access_Layer.Models
{
    public partial class RequestLogs
    {
        public int Id { get; set; }
        public string Route { get; set; } = null!;
        public DateTime RequestedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Data_Access_Layer.Models
{
    public partial class ExceptionLogs
    {
        public int Id { get; set; }
        public string ExceptionMessage { get; set; } = null!;
        public DateTime LoggedAt { get; set; }
    }
}

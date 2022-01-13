using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data_Access_Layer.Models
{
    public partial class ExceptionLogs
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(1000)]
        public string Route { get; set; } = null!;
        [Required, StringLength(10000)]
        public string ExceptionMessage { get; set; } = null!;
        public DateTime LoggedAt { get; set; }
    }
}
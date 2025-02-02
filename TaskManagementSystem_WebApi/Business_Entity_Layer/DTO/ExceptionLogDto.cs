﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Entity_Layer.DTO
{
    //Excption log DTO for transerferring between db entities and presentation layer
    public class ExceptionLogDto
    {
        public int Id { get; set; }
        public string Route { get; set; } = null!;
        public string ExceptionMessage { get; set; } = null!;
        public DateTime LoggedAt { get; set; }

    }
}
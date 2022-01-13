using AutoMapper;
using Business_Entity_Layer.DTO;
using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Helpers
{
    public class AutoMapperSettings:Profile
    {
        public AutoMapperSettings()
        {
            CreateMap<Persons, PersonDto>().ReverseMap();
            CreateMap<Tasks, TaskDto>().ReverseMap();
            CreateMap<RequestLogs, RequestLogDto>().ReverseMap();
            CreateMap<ExceptionLogs, ExceptionLogDto>().ReverseMap();
            CreateMap<TaskAssignmentsLogs, TaskAssignmentLogDto>().ReverseMap();
        }
    }
}
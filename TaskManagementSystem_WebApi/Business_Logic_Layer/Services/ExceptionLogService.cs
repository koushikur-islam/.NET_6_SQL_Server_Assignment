using AutoMapper;
using Business_Entity_Layer.DTO;
using Data_Access_Layer.Models;
using Data_Access_Layer.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class ExceptionLogService : IExceptionLogService
    {
        private readonly IMapper _mapper;
        private readonly ExceptionLogRepository _exceptionLogRepository;

        //Registering necessary services with dependency injection
        public ExceptionLogService(IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _exceptionLogRepository = new ExceptionLogRepository(configuration);

        }

        //Inserts any exception caught from the route along with the message to DB.
        public async Task InsertAsync(string route,string message)
        {
            var newException = new ExceptionLogDto();
            newException.Route = route;
            newException.ExceptionMessage = message;
            newException.LoggedAt = DateTime.Now;
            await _exceptionLogRepository.InsertAsync(_mapper.Map<ExceptionLogs>(newException));
        }
    }
}
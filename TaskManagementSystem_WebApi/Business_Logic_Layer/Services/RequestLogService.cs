﻿using AutoMapper;
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
    public class RequestLogService : IRequestLogService
    {
        private readonly IMapper _mapper;
        private readonly RequestLogRepository _requestLogRepository;

        //Registering all the necessary services 
        public RequestLogService(IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _requestLogRepository = new RequestLogRepository(configuration);
        }

        //Takes a query parameter for db opertaion and returns a single request from DB.
        public async Task<RequestLogDto> GetAsync(string query)
        {
            return _mapper.Map<RequestLogDto>(await _requestLogRepository.GetAsync(query));

        }

        //Inserts a request log object to DB and returns an acknowledgement.
        public async Task<bool> InsertAsync(RequestLogDto requestLog)
        {
            return await _requestLogRepository.InsertAsync(_mapper.Map<RequestLogs>(requestLog));
        }

        //Updates a request log object to DB and returns acknowlegemnt.
        public async Task<bool> UpdateAsync(RequestLogDto requestLog)
        {
            return await _requestLogRepository.UpdateAsync(_mapper.Map<RequestLogs>(requestLog));
        }
    }
}
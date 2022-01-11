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
    public class TaskService : ITaskService
    {
        private readonly IMapper _mapper;
        private readonly TaskRepository _taskRepository;
        public TaskService(IConfiguration configuration,IMapper mapper)
        {
            _mapper = mapper;
            _taskRepository = new TaskRepository(configuration);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _taskRepository.DeleteAsync(id);
        }

        public async Task<List<TaskDto>> GetAsync()
        {
            return _mapper.Map<List<TaskDto>>(await _taskRepository.GetAsync());
        }

        public async Task<TaskDto> GetAsync(int id)
        {
            return _mapper.Map<TaskDto>(await _taskRepository.GetAsync(id));
        }

        public async Task<bool> InsertAsync(TaskDto taskDto)
        {
            taskDto.CreatedAt = DateTime.Now;
            taskDto.UpdatedAt = DateTime.Now;
            return await _taskRepository.InsertAsync(_mapper.Map<Tasks>(taskDto));
        }

        public async Task<bool> UpdateAsync(int id, TaskDto taskDto)
        {
            var task = await _taskRepository.GetAsync(id);
            if (task != null)
            {
                task.Title = taskDto.Title;
                task.Description = taskDto.Description;
                task.UpdatedAt = DateTime.Now;
                return await _taskRepository.UpdateAsync(task);
            }
            return false;
        }
    }
}
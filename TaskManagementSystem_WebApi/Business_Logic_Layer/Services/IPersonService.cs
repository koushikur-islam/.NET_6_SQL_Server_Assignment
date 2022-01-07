﻿using Business_Entity_Layer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public interface IPersonService
    {
        public Task<List<PersonDto>> GetAsync();
        public Task<PersonDto> GetAsync(int id);
        public Task<bool> InsertAsync(PersonDto person);
        public Task<bool> UpdateAsync(int id,PersonDto person);
        public Task<bool> DeleteAsync(int id);

    }
}
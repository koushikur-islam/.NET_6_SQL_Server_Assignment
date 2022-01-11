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
    public class PersonService : IPersonService
    {
        private readonly PersonRepository _personRepository;
        private readonly IMapper _mapper;
        public PersonService(IConfiguration configuration,IMapper mapper)
        {
            _personRepository = new PersonRepository(configuration);
            _mapper = mapper;
        }
        public async Task<bool> DeleteAsync(PersonDto personDto)
        {
            return await _personRepository.DeleteAsync(_mapper.Map<Persons>(personDto));
        }

        public async Task<List<PersonDto>> GetAsync()
        {
            string query = "SELECT * FROM Persons;";
            return _mapper.Map<List<PersonDto>>(await _personRepository.GetAllAsync(query));
        }

        public async Task<PersonDto> GetAsync(int id)
        {
            string query = $"SELECT * FROM Persons WHERE id = {id};";
            return _mapper.Map<PersonDto>(await _personRepository.GetAsync(query));
        }

        public async Task<bool> InsertAsync(PersonDto personDto)
        {
            personDto.CreatedAt = DateTime.Now;
            personDto.UpdatedAt = DateTime.Now;
            return await _personRepository.InsertAsync(_mapper.Map<Persons>(personDto));
        }

        public async Task<bool> UpdateAsync(int id, PersonDto personDto)
        {
            string query = $"SELECT * FROM Persons WHERE id = {id};";
            var person = await _personRepository.GetAsync(query);
            if (person != null)
            {
                person.Name = personDto.Name;
                person.UpdatedAt = DateTime.Now;
                return await _personRepository.UpdateAsync(person);
            }
            return false;
        }
    }
}
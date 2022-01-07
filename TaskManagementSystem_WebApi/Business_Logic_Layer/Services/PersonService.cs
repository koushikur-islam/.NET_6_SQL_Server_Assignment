using AutoMapper;
using Business_Entity_Layer.DTO;
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
        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PersonDto>> GetAsync()
        {
            return _mapper.Map<List<PersonDto>>(await _personRepository.GetAsync());
        }

        public async Task<PersonDto> GetAsync(int id)
        {
            return _mapper.Map<PersonDto>(await _personRepository.GetAsync(id));
        }

        public Task<bool> InsertAsync(PersonDto person)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, PersonDto person)
        {
            throw new NotImplementedException();
        }
    }
}

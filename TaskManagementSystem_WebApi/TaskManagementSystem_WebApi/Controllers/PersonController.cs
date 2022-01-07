using Data_Access_Layer.Models;
using Data_Access_Layer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace TaskManagementSystem_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonRepository _personRepository;
        public PersonController(IOptions<ConnectionStrings> connectionString)
        {
            _personRepository = new PersonRepository(connectionString);
        }
        [HttpGet]
        public async Task<List<Person>> Get()
        {
            return await _personRepository.GetAsync();
        }
    }
}

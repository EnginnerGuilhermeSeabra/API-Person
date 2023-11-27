using Newtonsoft.Json;
using Person.Application.Services.Interfaces;
using Person.Domain.Aggregates.PersonAggregate.Interface;

namespace Person.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _PersonRepository;
        public PersonService(IPersonRepository PersonRepository)
        {

            _PersonRepository = PersonRepository;
        }

        public async Task<string> GetAll()
        {
            var person = await _PersonRepository.GetAll();
            return JsonConvert.SerializeObject(person, Formatting.Indented);
        }
    }
}

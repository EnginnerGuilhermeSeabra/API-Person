using Flunt.Notifications;
using Newtonsoft.Json;
using Person.Application.Commands;
using Person.Application.Services.Interfaces;
using Person.Application.Validators;
using Person.Domain.Aggregates.PersonAggregate.Interface;

namespace Person.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly ICreatePersonCommandValidator _createCommandValidator;
        private readonly IUpdatePersonCommandValidator _updateCommandValidator;
        public PersonService(IPersonRepository PersonRepository, ICreatePersonCommandValidator commandValidator, IUpdatePersonCommandValidator updateCommandValidator)
        {

            _personRepository = PersonRepository;
            _createCommandValidator = commandValidator;
            _updateCommandValidator = updateCommandValidator;
        }
        private static CommandResponse GenerateErrorValidatior(FluentValidation.Results.ValidationResult validator)
        {
            return new CommandResponse(validator.Errors.Select(x => new Notification(nameof(CreatePersonCommand), x.ErrorMessage)).ToList());
        }

        public async Task<CommandResponse> Create(CreatePersonCommand personCommand)
        {
            var validator = _createCommandValidator.Validate(personCommand);

            if (!validator.IsValid)
                return GenerateErrorValidatior(validator);

            var person = new Domain.Aggregates.PersonAggregate.Person(personCommand.Name, personCommand.CPF, personCommand.BirthDate);

            await _personRepository.AddAsync(person);


            return new CommandResponse(person.Notifications);
        }


        public async Task<bool> Delete(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);

            if (person == null)
            {
                return false;
            }

            _personRepository.Remove(id);

            return true;
        }

        public async Task<List<Domain.Aggregates.PersonAggregate.Person>> GetAll()
        {
            var person = await _personRepository.GetAll();
            return person;
        }

        public async Task<CommandResponse> Update(UpdatePersonCommand personCommand)
        {
            var person = await _personRepository.GetByIdAsync(personCommand.Id);

            if (person == null)
            {
                List<Notification> error = new()
                {
                    new Notification("UpdatePerson", "Pessoa não encontrada.")
                };
                return new CommandResponse(error);
            }

            // Atualizar propriedades da pessoa com base no comando
            person.Update(personCommand.Name, personCommand.CPF, personCommand.BirthDate);

            var validator = _updateCommandValidator.Validate(personCommand);

            if (!validator.IsValid)
                return GenerateErrorValidatior(validator);

            await _personRepository.Update(person.Id, person);

            return new CommandResponse(person.Notifications);
        }
    }
}

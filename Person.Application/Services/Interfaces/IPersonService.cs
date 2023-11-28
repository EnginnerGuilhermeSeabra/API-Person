using Person.Application.Commands;
using Person.Application.ViewModels;

namespace Person.Application.Services.Interfaces
{
    public interface IPersonService
    {
        Task<List<Person.Domain.Aggregates.PersonAggregate.Person>> GetAll();
        Task<CommandResponse> Create(CreatePersonCommand personCommand);
        Task<CommandResponse> Update(UpdatePersonCommand personCommand);
        Task<bool> Delete(int id);

    }
}

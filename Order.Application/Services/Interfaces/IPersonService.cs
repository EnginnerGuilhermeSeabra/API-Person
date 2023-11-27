using Person.Application.Commands;
using Person.Application.ViewModels;

namespace Person.Application.Services.Interfaces
{
    public interface IPersonService
    {
        Task<string> GetAll();
    }
}

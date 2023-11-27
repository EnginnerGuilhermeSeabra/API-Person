using Person.Application.Commands.Dtos;
using Person.Infra.Validator;

namespace Person.Application.Commands
{
    public class CreatePersonCommand : Command
    {
        public string? Email { get; set; }
        public List<ProductDto>? Products { get; set; }
    }   
}

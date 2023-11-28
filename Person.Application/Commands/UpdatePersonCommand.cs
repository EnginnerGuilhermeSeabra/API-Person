using Person.Infra.Validator;

namespace Person.Application.Commands
{
    public class UpdatePersonCommand : Command
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CPF { get; set; }
        public DateTime BirthDate { get; set; }

    }
}

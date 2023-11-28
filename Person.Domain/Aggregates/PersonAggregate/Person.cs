using Person.Domain.Core;

namespace Person.Domain.Aggregates.PersonAggregate
{
    public class Person : Entity
    {
        public Person(string? name, string? document, string? birthDate)
        {
            Name = name;
            CPF = document;
            BirthDate = birthDate;
        }

        public string? Name { get; set; }
        public string? CPF { get; set; }
        public string? BirthDate { get; set; }

        public void Update(string? name, string? cPF, DateTime birthDate)
        {
            throw new NotImplementedException();
        }
    }
}

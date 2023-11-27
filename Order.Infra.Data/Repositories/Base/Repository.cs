using Microsoft.EntityFrameworkCore;
using Person.Domain.Interfaces;

namespace Person.Infra.Data.Repositories.Base
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly Context _context;
        protected readonly DbSet<T> _set;

        public Repository(Context context)
        {
            _context = context;
        }

        public virtual Task<List<object>> GetAll()
        {
            var persons = new List<object>
        {
            new {name = "Roberto Antonio", cpf = "263.435.865-25", birthDate = DateTime.Now },
            new {name = "Carlos Antonio", cpf = "234.234.578-25", birthDate = DateTime.Now },
            new {name = "Rubens Antonio", cpf = "265.567.765-25", birthDate = DateTime.Now },
            new {name = "Felipe Antonio", cpf = "223.765.234-25", birthDate = DateTime.Now },
            new {name = "Marcos Antonio", cpf = "267.654.543-25", birthDate = DateTime.Now },
            new {name = "Matheus Antonio", cpf = "276.543.534-25", birthDate = DateTime.Now },
            new {name = "Gustavo Antonio", cpf = "235.345.234-25", birthDate = DateTime.Now }
        };
            return Task.FromResult(persons);

        }

    }
}

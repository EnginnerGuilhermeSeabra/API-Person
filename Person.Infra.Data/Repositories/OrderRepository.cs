using Person.Domain.Aggregates.PersonAggregate.Interface;
using Person.Infra.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Infra.Data.Repositories
{
    public class PersonRepository : Repository<Domain.Aggregates.PersonAggregate.Person>, IPersonRepository
    {
        public PersonRepository(Context context) : base(context)
        {
        }
    }
}

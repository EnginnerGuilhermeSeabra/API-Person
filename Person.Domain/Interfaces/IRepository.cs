using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> AddAsync(T entity);
        Task<List<T>> GetAll();
        Task<T> GetByIdAsync(int id);
        Task<T> Update(int id, T entity);
        void Remove(int id);
    }
}

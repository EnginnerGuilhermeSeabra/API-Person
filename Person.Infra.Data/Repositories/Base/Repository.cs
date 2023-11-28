using Microsoft.EntityFrameworkCore;
using Person.Domain.Interfaces;

namespace Person.Infra.Data.Repositories.Base
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private static List<T> _entities = new List<T>();

        public Repository(Context context)
        {
        }

        public Task<T> AddAsync(T entity)
        {
            _entities.Add(entity);


            return Task.FromResult(entity);
        }

        public virtual Task<List<T>> GetAll()
        {        
            return Task.FromResult(_entities);
        }

        public Task<T> GetByIdAsync(int id)
        {
            var entity = _entities.FirstOrDefault(e => GetId(e) == id);
            return Task.FromResult(entity);
        }

        public void Remove(int id)
        {
            var entityToRemove = _entities.FirstOrDefault(e => GetId(e) == id);

            if (entityToRemove != null)
            {
                _entities.Remove(entityToRemove);
            }
        }


        public Task<T> Update(int id, T entity)
        {
            var existingEntity = _entities.FirstOrDefault(e => GetId(e) == id);

            if (existingEntity != null)
            {
                UpdateEntityProperties(existingEntity, entity);
            }

            return Task.FromResult(existingEntity);
        }

        private void UpdateEntityProperties(T existingEntity, T updatedEntity)
        {
            // Obtém todas as propriedades da classe.
            var properties = existingEntity.GetType().GetProperties();

            foreach (var property in properties)
            {
                // Obtém o valor da propriedade no objeto atualizado.
                var updatedValue = property.GetValue(updatedEntity);

                // Atualiza o valor da propriedade no objeto existente.
                property.SetValue(existingEntity, updatedValue);
            }
        }



        private int GetId(T entity)
        {
            var idProperty = entity.GetType().GetProperty("Id");

            if (idProperty != null)
            {
                return Convert.ToInt32(idProperty.GetValue(entity, null));
            }

            throw new InvalidOperationException("A classe não possui uma propriedade chamada 'Id'.");
        }
    }
}

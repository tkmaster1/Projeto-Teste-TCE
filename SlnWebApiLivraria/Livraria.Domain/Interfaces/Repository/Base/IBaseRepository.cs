using System.Collections.Generic;

namespace Livraria.Domain.Interfaces.Repository.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAllAsNoTracking();
        IEnumerable<TEntity> GetAllNoProxy(string[] includes = null);
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
    }
}

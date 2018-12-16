using System.Collections.Generic;

namespace Livraria.Domain.Interfaces.Services.Base
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        TEntity GetById(int id);        
        IEnumerable<TEntity> GetAll();
       // IEnumerable<TEntity> GetAllNoProxy(string[] includes = null);
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
    }
}

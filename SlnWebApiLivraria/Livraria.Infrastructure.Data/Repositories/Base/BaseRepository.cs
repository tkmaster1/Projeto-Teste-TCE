using Livraria.Domain.Interfaces.Repository.Base;
using Livraria.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;

namespace Livraria.Infrastructure.Data.Repositories.Base
{
    public class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : class
    {
        protected IDbSet<TEntity> DbSet;
        protected readonly DbContext Context;

        protected modeloContext Db = new modeloContext();

        public BaseRepository()
        {
            Context = DatabaseManager.GetContext();
            DbSet = Context.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }
        
        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> GetAllAsNoTracking()
        {
            return Db.Set<TEntity>().AsNoTracking().ToList();
        }

        public void Add(TEntity obj)
        {
            // DbSet.Add(obj);
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public IEnumerable<TEntity> GetAllNoProxy(string[] includes = null)
        {
            List<TEntity> list;
            using (Db = new modeloContext())
            {
                Db.Configuration.LazyLoadingEnabled = false;
                Db.Configuration.ProxyCreationEnabled = false;
                Db.Database.Log = s => Debug.WriteLine(s);
                IQueryable<TEntity> qr = Db.Set<TEntity>();
                if (includes != null)
                {
                    for (var i = 0; i < includes.Count(); i++)
                    {
                        qr = qr.Include(includes[i]);
                    }
                }

                list = qr.AsNoTracking().ToList();
            }
            return list;
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

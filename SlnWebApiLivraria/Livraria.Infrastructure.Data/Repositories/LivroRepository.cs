using Livraria.Domain.Entities;
using Livraria.Domain.Interfaces.Repository;
using Livraria.Infrastructure.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Livraria.Infrastructure.Data.Repositories
{
    public class LivroRepository : BaseRepository<Livro>, ILivroRepository
    {
        public IEnumerable<Livro> VerificarSeExisteISBN(string isbn)
        {
            try
            {
                return Db.Livros.Where(p => p.LivroISBN == isbn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InserirLivro(Livro objLivro)
        {
            try
            {
                Add(objLivro);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

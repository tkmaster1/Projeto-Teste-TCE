using Livraria.Domain.Entities;
using Livraria.Domain.Interfaces.Repository.Base;
using System.Collections.Generic;

namespace Livraria.Domain.Interfaces.Repository
{
    public interface ILivroRepository : IBaseRepository<Livro>
    {
        IEnumerable<Livro> VerificarSeExisteISBN(string isbn);
        void InserirLivro(Livro objLivro);        
    }
}

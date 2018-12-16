using Livraria.Domain.Entities;
using Livraria.Domain.Interfaces.Services.Base;
using Livraria.Domain.ValueObjects;
using System.Collections.Generic;

namespace Livraria.Domain.Interfaces.Services
{
    public interface ILivroService : IBaseService<Livro>
    {
        IEnumerable<Livro> VerificarSeExisteISBN(string isbn);
        IEnumerable<Livro> PesquisarLivros(PesquisarLivroValueObject objLivros);
        void InserirLivro(Livro objLivro);
    }
}

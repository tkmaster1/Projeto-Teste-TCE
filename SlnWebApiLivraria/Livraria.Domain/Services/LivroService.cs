using Livraria.Domain.Entities;
using Livraria.Domain.Interfaces.Repository;
using Livraria.Domain.Interfaces.Services;
using Livraria.Domain.Services.Base;
using Livraria.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;

namespace Livraria.Domain.Services
{
    public class LivroService : BaseService<Livro>, ILivroService
    {
        private readonly ILivroRepository _livroRepository;

        public LivroService(ILivroRepository livroRepository)
            : base(livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public IEnumerable<Livro> VerificarSeExisteISBN(string isbn)
        {
            try
            {
                var query = _livroRepository.VerificarSeExisteISBN(isbn);
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Livro> PesquisarLivros(PesquisarLivroValueObject objLivros)
        {
            var query = _livroRepository.GetAllNoProxy();

            query = (objLivros.LivroId > 0) ? query.Where(x => x.LivroId.Equals(objLivros.LivroId)) : query;

            query = (!string.IsNullOrEmpty(objLivros.LivroISBN)) ? query.Where(x => x.LivroISBN.Contains(objLivros.LivroISBN)) : query;

            if (objLivros.Preco > 0)
            {
                query = query.Where(x => x.Preco == objLivros.Preco);
            }

            query = (!string.IsNullOrEmpty(objLivros.NomeAutor)) ? query.Where(x => x.NomeAutor.Contains(objLivros.NomeAutor)) : query;

            query = (!string.IsNullOrEmpty(objLivros.NomeLivro)) ? query.Where(x => x.NomeLivro.Contains(objLivros.NomeLivro)) : query;

            query = (!string.IsNullOrEmpty(objLivros.Ativo)) ? query.Where(x => x.Ativo.Contains(objLivros.Ativo)) : query;

            DateTime dt;
            var isValid = DateTime.TryParseExact(objLivros.DataPublicacao.Value.ToShortDateString(), "dd/MM/yyyy", new CultureInfo("en-GB"), DateTimeStyles.None, out dt);
            if (!isValid)
            {
                query = (objLivros.DataPublicacao.HasValue)
                    ? query.Where(x => x.DataPublicacao >= objLivros.DataPublicacao)
                        .Where(x => x.DataPublicacao <= objLivros.DataPublicacao)
                    : query;
            }

            DateTime dtInc;
            var isValidInc = DateTime.TryParseExact(objLivros.DataInclusao.Value.ToShortDateString(), "dd/MM/yyyy", new CultureInfo("en-GB"), DateTimeStyles.None, out dtInc);
            if (!isValidInc)
            {
                query = (objLivros.DataInclusao.HasValue)
                   ? query.Where(x => x.DataInclusao >= objLivros.DataInclusao)
                       .Where(x => x.DataInclusao <= objLivros.DataInclusao)
                   : query;
            }

            if (objLivros.DataAlteracao.HasValue)
            {
                DateTime dtAlt;
                var isValidAlt = DateTime.TryParseExact(objLivros.DataAlteracao.Value.ToShortDateString(), "dd/MM/yyyy", new CultureInfo("en-GB"), DateTimeStyles.None, out dtAlt);
                if (!isValidAlt)
                {
                    query = (objLivros.DataAlteracao.HasValue)
                    ? query.Where(x => x.DataAlteracao >= objLivros.DataAlteracao)
                        .Where(x => x.DataAlteracao <= objLivros.DataAlteracao)
                    : query;
                }
            }

            if (!string.IsNullOrEmpty(objLivros.SortField))
            {
                return query.AsQueryable().OrderBy(objLivros.SortField, objLivros.Ascending);
            }
            else
            {
                return query.ToList();
            }
        }

        public void InserirLivro(Livro objLivro)
        {
            _livroRepository.InserirLivro(objLivro);
        }
    }

    public static class ExtensionMethods
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> q, string SortField, bool Ascending)
        {
            var param = Expression.Parameter(typeof(T), "p");
            var prop = Expression.Property(param, SortField);
            var exp = Expression.Lambda(prop, param);
            string method = Ascending ? "OrderBy" : "OrderByDescending";
            Type[] types = new Type[] { q.ElementType, exp.Body.Type };
            var mce = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);
            return q.Provider.CreateQuery<T>(mce);
        }
    }
}

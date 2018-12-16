using Livraria.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Web;

namespace Livraria.Application.Interface
{
    public interface ILivroApplicationService : IDisposable
    {
        LivroViewModel GetById(int id);
        List<LivroViewModel> GetAll();
        List<LivroViewModel> VerificarSeExisteISBN(string isbn);
        List<LivroViewModel> PesquisarLivros(LivroViewModel objLivros);
        void InserirLivro(LivroViewModel obj);
       // bool SalvarEvidencias(HttpRequestBase request);
        void AlterarLivro(LivroViewModel obj);
        void ExcluirLivro(int id);
    }
}

using AutoMapper;
using Livraria.Application.Base;
using Livraria.Application.Interface;
using Livraria.Application.ViewModels;
using Livraria.Domain.Entities;
using Livraria.Domain.Interfaces.Services;
using Livraria.Domain.ValueObjects;
using Livraria.Infrastructure.CrossCutting.Util;
using System;
using System.Collections.Generic;
using System.Web;

namespace Livraria.Application.Services
{
    public class LivroApplicationService : BaseApplicationService, ILivroApplicationService
    {
        private readonly ILivroService _livroService;

        public LivroApplicationService(ILivroService livroService)
        {
            _livroService = livroService;
        }

        public LivroViewModel GetById(int id)
        {
            try
            {
                var Livro = _livroService.GetById(id);
                return Mapper.Map<Livro, LivroViewModel>(Livro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<LivroViewModel> GetAll()
        {
            try
            {
                return Mapper.Map<List<LivroViewModel>>(_livroService.GetAll());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<LivroViewModel> VerificarSeExisteISBN(string isbn)
        {
            try
            {
                var listaLivro = _livroService.VerificarSeExisteISBN(isbn);
                return Mapper.Map<IEnumerable<Livro>, List<LivroViewModel>>(listaLivro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InserirLivro(LivroViewModel obj)
        {
            try
            {
                
                var livroObj = Mapper.Map<Livro>(obj);
                 _livroService.Add(livroObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AlterarLivro(LivroViewModel obj)
        {
            try
            {
                var livroObj = Mapper.Map<Livro>(obj);
                _livroService.Update(livroObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirLivro(int id)
        {
            try
            {
                var livroObj = _livroService.GetById(id);
                var result = Mapper.Map<Livro>(livroObj);
                _livroService.Remove(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //    public bool SalvarEvidencias(HttpRequestBase request)
        //    {
        //        try
        //        {
        //            // var idAgenda = Convert.ToInt32(request.Form.GetValues("IdAgenda").First());

        //            //  DeletarEvidenciasRemovidasDaTela(request, idAgenda);

        //            for (int i = 0; i < request.Files.Count; i++)
        //            {
        //                var file = request.Files[i];

        //                if (file.ContentLength > 0)
        //                {
        //                   // _livroService.InserirLivro();
        //                }

        //                //_listaPresencaService.InserirListaPresenca(MontarViewModelDiagnosticoEvidencia(ArquivoUtil.SalvarArquivoPorHttpPostedFileBase(
        //                //    file, request, ArquivoUtil.UrlBaseEvidencias, 120, idAgenda), idAgenda));
        //            }
        //            return true;

        //        }
        //        catch (Exception e)
        //        {
        //            return false;
        //        }
        //    }



        //public void DeletarEvidenciasRemovidasDaTela(HttpRequestBase request, int idAgenda)
        //{
        //    var evidenciasBanco = RetornarListaPresencaPorAgenda(idAgenda).ToList(); // ok

        //    var evidenciasBancoTela = request.Form.GetValues("EvidenciasBanco");

        //    if (evidenciasBancoTela != null)
        //    {
        //        evidenciasBanco.RemoveAll(x => evidenciasBancoTela.Contains(x.CaminhoListaPresenca));
        //    }
        //    evidenciasBanco.ForEach(x => { _listaPresencaService.DeletarListaPresenca(x.IdAgenda); ArquivoUtil.DeletarArquivo(Path.Combine(ArquivoUtil.PathListaPresenca, x.CaminhoListaPresenca)); });
        //}

        public List<LivroViewModel> PesquisarLivros(LivroViewModel objLivros)
        {
            try
            {
                var listaLivro = _livroService.PesquisarLivros(Mapper.Map<PesquisarLivroValueObject>((objLivros)));
                return Mapper.Map<IEnumerable<Livro>, List<LivroViewModel>>(listaLivro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            _livroService.Dispose();
        }
    }
}

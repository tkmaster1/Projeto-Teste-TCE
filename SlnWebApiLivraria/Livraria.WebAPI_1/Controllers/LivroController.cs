using Livraria.Application.Interface;
using Livraria.Application.ViewModels;
using Livraria.Infrastructure.CrossCutting.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;

namespace Livraria.WebAPI_1.Controllers
{
    [RoutePrefix("api/livro")]
    public class LivroController : ApiController
    {
        private readonly ILivroApplicationService _livroApplicationService;
        public LivroController(ILivroApplicationService livroApplicationService)
        {
            _livroApplicationService = livroApplicationService;
        }

        [Route("consultar/todos")]
        [HttpGet]
        public HttpResponseMessage BuscarPorTodos()
        {
            try
            {
                List<LivroViewModel> listLivros = new List<LivroViewModel>();

                var livros = _livroApplicationService.GetAll();
                if (livros == null || livros.Count <= 0)
                {
                    throw new Exception("Livro não encontrado.");
                }

                return Request.CreateResponse(HttpStatusCode.OK, livros.ToArray());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("consultar/BuscarPorId/{id:int?}")]
        [HttpGet]
        public HttpResponseMessage BuscarPorId(int id)
        {
            try
            {
                List<LivroViewModel> listLivros = new List<LivroViewModel>();

                var livros = _livroApplicationService.GetById(id);
                if (livros == null)
                {
                    throw new Exception("Livro não encontrado.");
                }

                return Request.CreateResponse(HttpStatusCode.OK, livros);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("consultar/PesquisaOrdenadaLivros/{id:int?}")]
        [HttpGet]
        public HttpResponseMessage PesquisaOrdenadaLivros(LivroViewModel model)
        {
            try
            {
                var livros = _livroApplicationService.PesquisarLivros(model);
                if (livros == null || livros.Count <= 0)
                {
                    throw new Exception("Livro não encontrado.");
                }

                return Request.CreateResponse(HttpStatusCode.OK, livros.ToArray());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("cadastrar")]
        [HttpPost]
        [Mime]
        public HttpResponseMessage Inserir()
        {
            HttpResponseMessage result = null;

            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var item = new LivroViewModel();

                    item.LivroISBN = httpRequest.Form["LivroISBN"].ToString();
                    item.NomeLivro = httpRequest.Form["NomeLivro"].ToString();
                    item.NomeAutor = httpRequest.Form["NomeAutor"].ToString();
                    item.Preco = Convert.ToDecimal(httpRequest.Form["Preco"].ToString());
                    item.DataPublicacao = Convert.ToDateTime(httpRequest.Form["DataPublicacao"].ToString());
                    item.FileName = postedFile.FileName;
                    item.FileLength = postedFile.ContentLength.ToString();
                    item.FileCreatedTime = DateTime.Now;

                     ArquivoUtil.SalvarArquivo(ArquivoUtil.UrlBaseEvidencias, item.FileName, postedFile);
                  // var filePath = HttpContext.Current.Server.MapPath("~" + ArquivoUtil.UrlBaseEvidencias + item.FileName);
                  //  postedFile.SaveAs(filePath);
                   // docfiles.Add(filePath);

                    _livroApplicationService.InserirLivro(item);
                    // var filePath = HttpContext.Current.Server.MapPath("~/" + postedFile.FileName);
                    //  postedFile.SaveAs(filePath);
                    // docfiles.Add(filePath);
                }
                result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            result = Request.CreateResponse(HttpStatusCode.OK, "ok.");

            return result;
        }

        [HttpPost]
        [Route("alterar/{id:int}")]
        public HttpResponseMessage Alterar(LivroViewModel livro)
        {
            try
            {
                if (livro == null) throw new ArgumentNullException("livro");

                _livroApplicationService.AlterarLivro(livro);

                return Request.CreateResponse(HttpStatusCode.OK, "Alteração do Livro: " + livro.NomeLivro + ", realizada com sucesso.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        [Route("excluir/{id:int}/{nome}")]
        public HttpResponseMessage Excluir(int id, string nome)
        {
            try
            {
                if (id == 0) throw new ArgumentNullException("livro");

                _livroApplicationService.ExcluirLivro(id);

                return Request.CreateResponse(HttpStatusCode.OK, "Exclusão do Livro: " + nome + ", realizada com sucesso.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        private string GetDeserializedFileName(MultipartFileData fileData)
        {
            var fileName = GetFileName(fileData);
            return JsonConvert.DeserializeObject(fileName).ToString();
        }

        public string GetFileName(MultipartFileData fileData)
        {
            return fileData.Headers.ContentDisposition.FileName;
        }
    }
}
